using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace LogonSecurity
{
    class Events
    {
        public static void ReadAppLog()
        {
            //Начало лога - в самом низу. Оно самое старое
            //Конец лога - в самом верху. Он самый новый
            //Читаем самый первый лог
            //Берем его ID
            //Вычитаем тот, что храним
            //Получаем цифру смещения
            //Смещаемся
            //И читаем от него к концу (самому верху, самым новым)


            int SessionID = new Random().Next();
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". AppLog. Start reading");

            string LogName = "Microsoft-Windows-TerminalServices-LocalSessionManager/Operational";
            EventLogQuery elQuery = new EventLogQuery(LogName, PathType.LogName);
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". AppLog. Query created");

            EventLogReader elReader = new EventLogReader(elQuery);
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". AppLog. Reader created");

            long SeekNumber = GetSeekNumber(elReader);
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". AppLog. Seek Number = " + SeekNumber);


            elReader.Seek(System.IO.SeekOrigin.Current, SeekNumber);
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". AppLog. Seeked");

            if (IgnoreLogs)//Если игнорируем старые логи - перейти читать в самый конец
            {
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". AppLog. Ignore logs start");

                elReader.Seek(System.IO.SeekOrigin.End, 0);

                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". AppLog. Ignore logs complete");
            }


            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". AppLog. Reading logs. Start");
            for (EventRecord eventInstance = elReader.ReadEvent(); eventInstance != null; eventInstance = elReader.ReadEvent())
            {
                if (Config.NeedToStop)
                    break;

                long? Index = eventInstance.RecordId;
                DateTime? time = eventInstance.TimeCreated;

                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". AppLog. Index: " + Index + ". Time: " + time + ". ID: " + eventInstance.Id);

                //Console.WriteLine(Index);
                if (Index <= Config.LastReadedAppLogIndex)
                {
                    if (Config.log.Work)
                        Log.Add("Session ID: " + SessionID + ". AppLog. Index: " + Index + ". Less or equal than Last Readed App Log Index: " + Config.LastReadedAppLogIndex + ". Go to next log");

                    continue;
                }

                if (eventInstance.Properties.Count < 3)
                {
                    if (Config.log.Work)
                        Log.Add("Session ID: " + SessionID + ". AppLog. Index: " + Index + ". eventInstance.Properties.Count < 3. Go to next log");

                    Config.LastReadedAppLogIndex = eventInstance.RecordId;
                    Config.Save();
                    continue;
                }

                if (eventInstance.Id == 21)
                    ReadLog21(eventInstance);
                else if (eventInstance.Id == 24)
                    ReadLog24(eventInstance);
                else if (eventInstance.Id == 25)
                    ReadLog25(eventInstance);

                Config.LastReadedAppLogIndex = eventInstance.RecordId;
                Config.Save();

                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". AppLog. Index: " + Index + ". Log read finish");
            }

            elReader.Dispose();


            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". AppLog. Finish reading");
        }
        static long GetSeekNumber(EventLogReader elReader)
        {
            EventRecord eventInstance = elReader.ReadEvent();
            elReader.Seek(System.IO.SeekOrigin.Current, -1);

            long? Seek = Config.LastReadedAppLogIndex - eventInstance.RecordId + 1;

            return (long)Seek;
        }
        static void ReadEventRecord(EventRecord Value)
        {
        }
        static void ReadLog21(EventRecord value)//Успешный вход в новый сеанс
        {
            string UserName = value.Properties[0].Value.ToString();
            string FromPC = value.Properties[2].Value.ToString();
            string Time = value.TimeCreated.ToString();

            if (UserName.Contains("\\"))
                UserName = UserName.Split('\\')[1];

            user usr = user.FindUserByName(UserName);
            if (usr == null)
                return;

            string Message = Time + " с " + FromPC + " Вход в " + UserName + " (Новый сеанс)";
            if (Config.log.Event)
                Log.Add("Вход. " + Message);

            if (usr.NotifySuccessLogon)
                EMail.Send(usr.ToEmail, "Вход", Message);


            user.SetNewPassword(usr);
        }
        static void ReadLog25(EventRecord value)//Успешное переподключение в существующий сеанс
        {
            string UserName = value.Properties[0].Value.ToString();
            string FromPC = value.Properties[2].Value.ToString();
            string Time = value.TimeCreated.ToString();

            if (UserName.Contains("\\"))
                UserName = UserName.Split('\\')[1];

            user usr = user.FindUserByName(UserName);
            if (usr == null)
                return;

            string Message = Time + " с " + FromPC + " Вход в " + UserName + " (Существующий сеанс)";
            if (Config.log.Event)
                Log.Add("Вход. " + Message);

            if (usr.NotifySuccessLogon)
                EMail.Send(usr.ToEmail, "Вход", Message);

            user.SetNewPassword(usr);
        }
        static void ReadLog24(EventRecord value)//Отключение от сеанса
        {
            string UserName = value.Properties[0].Value.ToString();
            string FromPC = value.Properties[2].Value.ToString();
            string Time = value.TimeCreated.ToString();

            if (UserName.Contains("\\"))
                UserName = UserName.Split('\\')[1];

            user usr = user.FindUserByName(UserName);
            if (usr == null)
                return;

            string Message = Time + " с " + FromPC + " пользователь " + UserName + " отключился от сеанса";
            if (Config.log.Event)
                Log.Add("Отключение. " + Message);

            user.SetNewPassword(usr);
        }


        public static void ReadEventLog()
        {
            //Начало лога - в самом низу. Оно самое старое
            //Конец лога - в самом верху. Он самый новый
            //Бинарным поиском находим последнее прочитанное событие
            //И читаем от него к концу (самому верху, самым новым)

            int SessionID = new Random().Next();
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". EventLog. Start reading");

            EventLog SecurityEvents = new EventLog("Security");
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". EventLog. EventLog Opened");

            EventLogEntryCollection events = SecurityEvents.Entries;
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". EventLog. Logs opened");

            #region Ignore Logs
            if (IgnoreLogs)
            {
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs started");

                int EventsCount = events.Count;
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs. Events count: " + EventsCount);

                EventLogEntry LastEvent = events[EventsCount - 1];
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs. Readed last event");

                int LastIndex = LastEvent.Index;
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs. Readed last index: " + LastIndex);

                Config.LastReadedEventLogIndex = LastIndex;
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs. last index written to config");

                Config.Save();
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs. Config saved");

                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs finished");

                return;
            }
            #endregion//Ignore Logs

            int index = BinaryFindLastReadedIndex(events);
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". EventLog. Start reading from log[" + index + "]");

            for (int i = index + 1; i < events.Count; i++)
            {
                if (Config.NeedToStop)
                    break;

                EventLogEntry item = events[i];
                int Index = item.Index;
                string time = item.TimeGenerated.ToString();

                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Index: " + Index + ". Time: " + time + ". ID: " + item.InstanceId);

                if (item.InstanceId == 4776)
                    ReadLog4776(item);


                Config.LastReadedEventLogIndex = events[i].Index;
                Config.Save();

                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Index: " + Index + ". Finish reading log");
            }


            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". EventLog. Finish reading");
        }
        public static void ReadEventLogOLD()
        {
            //Начало лога - в самом низу. Оно самое старое
            //Конец лога - в самом верху. Он самый новый
            //Бинарным поиском находим последнее прочитанное событие
            //И читаем от него к концу (самому верху, самым новым)

            int SessionID = new Random().Next();
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". EventLog. Start reading");

            EventLog SecurityEvents = new EventLog("Security");
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". EventLog. EventLog Opened");

            IEnumerable<EventLogEntry> events = SecurityEvents.Entries.Cast<EventLogEntry>();
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". EventLog. Logs opened");

            #region Ignore Logs
            if (IgnoreLogs)
            {
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs started");

                int EventsCount = events.Count();
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs. Events count: " + EventsCount);

                EventLogEntry LastEvent = events.ElementAt(EventsCount - 1);
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs. Readed last event");

                int LastIndex = LastEvent.Index;
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs. Readed last index: " + LastIndex);

                Config.LastReadedEventLogIndex = LastIndex;
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs. last index written to config");

                Config.Save();
                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs. Config saved");

                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Ignore logs finished");

                return;
            }
            #endregion//Ignore Logs

            int index = BinaryFindLastReadedIndexOLD(events);
            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". EventLog. Start reading from log[" + index + "]");

            for (int i = index + 1; i < events.Count(); i++)
            {
                if (Config.NeedToStop)
                    break;

                EventLogEntry item = events.ElementAt(i);
                int Index = item.Index;
                string time = item.TimeGenerated.ToString();
                //if (item.Index <= Config.LastReadedEventLogIndex)
                //    break;

                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Index: " + Index + ". Time: " + time + ". ID: " + item.InstanceId);

                if (item.InstanceId == 4776)
                    ReadLog4776(item);


                Config.LastReadedEventLogIndex = events.ElementAt(i).Index;
                Config.Save();

                if (Config.log.Work)
                    Log.Add("Session ID: " + SessionID + ". EventLog. Index: " + Index + ". Finish reading log");
            }


            if (Config.log.Work)
                Log.Add("Session ID: " + SessionID + ". EventLog. Finish reading");
        }
        static int BinaryFindLastReadedIndex(EventLogEntryCollection events)
        {
            int SearchFor = Config.LastReadedEventLogIndex;

            // Проверить, имеет ли смыл вообще выполнять поиск:
            if (events.Count == 0 ||                          // - если длина массива равна нулю - искать нечего;
                SearchFor < events[0].Index ||        // - если искомый элемент меньше первого элемента массива, значит, его в массиве нет;
                SearchFor > events[events.Count - 1].Index) // - если искомый элемент больше последнего элемента массива, значит, его в массиве нет.
            {
                return -1;
            }

            // Приступить к поиску.
            // Номер первого элемента в массиве.
            int first = 0;
            // Номер элемента массива, СЛЕДУЮЩЕГО за последним
            int last = events.Count;

            // Если просматриваемый участок не пуст, first < last
            while (first < last)
            {
                int mid = first + (last - first) / 2;

                if (SearchFor <= events[mid].Index)
                    last = mid;
                else
                    first = mid + 1;
            }

            // Теперь last может указывать на искомый элемент массива.
            if (events[last].Index == SearchFor)
                return last;
            else
                return -1;
        }
        static int BinaryFindLastReadedIndexOLD(IEnumerable<EventLogEntry> events)
        {
            int SearchFor = Config.LastReadedEventLogIndex;

            // Проверить, имеет ли смыл вообще выполнять поиск:
            if (events.Count() == 0 ||                          // - если длина массива равна нулю - искать нечего;
                SearchFor < events.ElementAt(0).Index ||        // - если искомый элемент меньше первого элемента массива, значит, его в массиве нет;
                SearchFor > events.ElementAt(events.Count() - 1).Index) // - если искомый элемент больше последнего элемента массива, значит, его в массиве нет.
            {
                return -1;
            }

            // Приступить к поиску.
            // Номер первого элемента в массиве.
            int first = 0;
            // Номер элемента массива, СЛЕДУЮЩЕГО за последним
            int last = events.Count();

            // Если просматриваемый участок не пуст, first < last
            while (first < last)
            {
                int mid = first + (last - first) / 2;

                if (SearchFor <= events.ElementAt(mid).Index)
                    last = mid;
                else
                    first = mid + 1;
            }

            // Теперь last может указывать на искомый элемент массива.
            if (events.ElementAt(last).Index == SearchFor)
                return last;
            else
                return -1;
        }
        static void ReadLog4776(EventLogEntry value)//Попытка подбора пароля
        {
            //if (value.EntryType != EventLogEntryType.FailureAudit)
            //    return;
            if (value.ReplacementStrings == null)
                return;
            if (value.ReplacementStrings.Length < 4)
                return;

            string ErrorCode = value.ReplacementStrings[3].ToLower();
            string ErrorMessage;
            switch (ErrorCode)
            {
                case "0x0":
                    ErrorMessage = "Success";
                    break;
                case "0xc0000064":
                    ErrorMessage = "User name does not exist";
                    break;
                case "0xc000006a":
                    ErrorMessage = "User name is correct but the password is wrong";
                    break;
                case "0xc0000234":
                    ErrorMessage = "User is currently locked out";
                    break;
                case "0xc0000072":
                    ErrorMessage = "Account is currently disabled";
                    break;
                case "0xc000006f":
                    ErrorMessage = "User tried to logon outside his day of week or time of day restrictions";
                    break;
                case "0xc0000070":
                    ErrorMessage = "Workstation restriction";
                    break;
                case "0xc0000193":
                    ErrorMessage = "Account expiration";
                    break;
                case "0xc0000071":
                    ErrorMessage = "Expired password";
                    break;
                case "0xc0000224":
                    ErrorMessage = "User is required to change password at next logon";
                    break;
                case "0xc0000225":
                    ErrorMessage = "Evidently a bug in Windows and not a risk";
                    break;
            }

            string UserName = value.ReplacementStrings[1];
            string FromPC = value.ReplacementStrings[2];
            string Time = value.TimeGenerated.ToString();

            user usr = user.FindUserByName(UserName);
            if (usr == null)
                return;

            string Title = "";
            string Message = "";
            string CurrentPassword = "";
            if (ErrorCode == "0x0")
            {
                Title = "Вход";
                Message = Time + " с " + FromPC + " Вход в " + Environment.MachineName.ToString() + "\\" + UserName;
            }
            else
            {
                Title = "Попытка входа";
                Message = Time + " с " + FromPC + " попытка подключения к " + Environment.MachineName.ToString() + "\\" + UserName;
                CurrentPassword = " ##### Правильный пароль: " + usr.CurrentPassword;
            }

            if (Config.log.Event)
                Log.Add(Title + ". " + Message);

            if (ErrorCode == "0x0")
                user.SetNewPassword(usr);

            if (usr.NotifySuccessLogon)
                EMail.Send(usr.ToEmail, Title, Message + CurrentPassword);
        }


        public static bool IgnoreLogs = false;
        public static void IgnoreOldLogs()
        {
            IgnoreLogs = true;

            ReadAppLog();
            ReadEventLog();

            IgnoreLogs = false;
        }

        static void LoggingTurnOn() { }
    }
}
