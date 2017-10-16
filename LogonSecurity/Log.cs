using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace LogonSecurity
{
    class Log
    {
        static FileStream fs;
        static StreamWriter file;
        static Queue<string> logs = new Queue<string>();
        static Thread LogThread;

        public static void Open(string fileName)
        {
            try
            {
                string LogsFolder = Path.GetDirectoryName(fileName);
                Directory.CreateDirectory(LogsFolder);

                fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                file = new StreamWriter(fs);
            }
            catch (Exception ex)
            {
                string Message = "Can not open log file\r\n";
                Message += "FileName: " + fileName + "\r\n";
                Message += "FileMode: Append\r\n";
                Message += "FileAcces: Write\r\n";
                Message += "FileShare: ReadWrite\r\n";
                Message += "\r\n";
                Message += "Error message: " + ex.Message;

                Events.WriteEventLog(Message, System.Diagnostics.EventLogEntryType.Error, 10);
            }
        }

        public static void Close()
        {
            try
            {
                file.Dispose();
                file.Close();

                fs.Dispose();
                fs.Close();
            }
            catch (Exception ex)
            {
                string Message = "Can not close log file\r\n";
                Message += "\r\n";
                Message += "Error message: " + ex.Message;

                Events.WriteEventLog(Message, System.Diagnostics.EventLogEntryType.Error, 12);
            }
        }

        public static void Add(string Message)
        {
            string Time = DateTime.Now.ToString("yyyy.MM.dd_HH:mm:ss:ffffff");
            Message = Time + "# " + Message;

            logs.Enqueue(Message);
        }




        public static void StartThread()
        {
            LogThread = new Thread(LoggerThread);
            LogThread.IsBackground = true;
            LogThread.Start();
        }
        static void LoggerThread()
        {
            logs = new Queue<string>();

            string ProgramExePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string LogsFolder = Path.Combine(Path.GetDirectoryName(ProgramExePath), "LogonSecurity_logs");

            while (!Config.NeedToStop)
            {
                string LogFileName = Path.Combine(LogsFolder, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
                Open(LogFileName);

                while (logs.Count > 0)
                {
                    string log = logs.Dequeue();
                    SaveToDisk(log);
                }
                Close();

                Service.Sleep(Config.ReadLogEveryMilliseconds);
            }
        }

        static void SaveToDisk(string Value)
        {
            try
            {
                file.WriteLine(Value);
            }
            catch (Exception ex)
            {
                FileStream fs = (FileStream)file.BaseStream;
                string logFileName = fs.Name;

                string Message = "Can not write message to log file\r\n";
                Message += "FileName: " + logFileName + "\r\n";
                Message += "Log Message: " + Value + "\r\n";
                Message += "\r\n";
                Message += "Error message: " + ex.Message;

                Events.WriteEventLog(Message, System.Diagnostics.EventLogEntryType.Error, 11);
            }

        }



        public bool Email;
        public bool Password;
        public bool Event;
        public bool Work;
    }
}
