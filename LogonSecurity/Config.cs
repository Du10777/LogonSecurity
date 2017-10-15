using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Security.Permissions;

namespace LogonSecurity
{
    class Config
    {
        public static int ChangePasswordEveryMilliseconds = 1000*60*5;
        public static int ReadLogEveryMilliseconds = 1000;

        public static int PasswordLength = 8;
        public static string PasswordChars = "abcdefghijkmnopqrstuvwxyz0123456789";


        public static int LastReadedEventLogIndex = 0;
        public static long? LastReadedAppLogIndex = 0;


        public static bool Pause;
        public static bool NeedToStop;
        
        public static EMail eMail = new EMail();
        public static List<user> Users = new List<user>();
        public static Log log = new Log();

        public static void Open()
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
            reg = reg.OpenSubKey("LogonSecurity");
            if (reg == null)
                return;


            Config.ChangePasswordEveryMilliseconds = ReadRegistry<int>(Config.ChangePasswordEveryMilliseconds, reg, "ChangePasswordEveryMilliseconds");
            Config.ReadLogEveryMilliseconds = ReadRegistry<int>(Config.ReadLogEveryMilliseconds, reg, "ReadLogEveryMilliseconds");

            Config.PasswordLength = ReadRegistry<int>(Config.PasswordLength, reg, "PasswordLength");
            Config.PasswordChars = ReadRegistry<string>(Config.PasswordChars, reg, "PasswordChars");


            Config.LastReadedEventLogIndex = ReadRegistry<int>(Config.LastReadedEventLogIndex, reg, "LastReadedEventLogIndex");
            Config.LastReadedAppLogIndex = ReadRegistry<long?>(Config.LastReadedAppLogIndex, reg, "LastReadedAppLogIndex");

            #region EMail
            Config.eMail.Server = ReadRegistry<string>(Config.eMail.Server, reg, "EMail.Server");
            Config.eMail.Port = ReadRegistry<int>(Config.eMail.Port, reg, "EMail.Port");
            Config.eMail.Address = ReadRegistry<string>(Config.eMail.Address, reg, "EMail.Address");
            Config.eMail.Login = ReadRegistry<string>(Config.eMail.Login, reg, "EMail.Login");
            Config.eMail.Password = ReadRegistry<string>(Config.eMail.Password, reg, "EMail.Password");
            Config.eMail.SSL = ReadRegistry<bool>(Config.eMail.SSL, reg, "EMail.SSL");
            Config.eMail.ErrorRepeatSending = ReadRegistry<int>(Config.eMail.ErrorRepeatSending, reg, "EMail.ErrorRepeatSending");
            #endregion//EMail

            #region Users
            int UsersCount = ReadRegistry<int>(Config.Users.Count, reg, "Users.Count");
            Config.Users = new List<user>(UsersCount);

            for (int i = 0; i < Config.Users.Capacity; i++)
            {
                user tmpUser = new user();

                tmpUser.Name = ReadRegistry<string>(tmpUser.Name, reg, "User" + i + ".Name");
                tmpUser.ToEmail = ReadRegistry<string>(tmpUser.ToEmail, reg, "User" + i + ".ToEmail");

                tmpUser.ChangePassword = ReadRegistry<bool>(tmpUser.ChangePassword, reg, "User" + i + ".ChangePassword");
                tmpUser.NotifyLogonAttempts = ReadRegistry<bool>(tmpUser.NotifyLogonAttempts, reg, "User" + i + ".NotifyLogonAttempts");
                tmpUser.NotifySuccessLogon = ReadRegistry<bool>(tmpUser.NotifySuccessLogon, reg, "User" + i + ".NotifySuccessLogon");

                Config.Users.Add(tmpUser);
            }
            #endregion//Users

            #region Log
            Config.log.Email = ReadRegistry<bool>(Config.log.Email, reg, "Log.EMail");
            Config.log.Password = ReadRegistry<bool>(Config.log.Password, reg, "Log.Password");
            Config.log.Event = ReadRegistry<bool>(Config.log.Event, reg, "Log.Event");
            Config.log.Work = ReadRegistry<bool>(Config.log.Work, reg, "Log.Work");
            #endregion//Log

            reg.Close();
        }
        public static void OpenOld()
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
            reg = reg.OpenSubKey("LogonSecurity");
            if (reg == null)
                return;


            //Config.UserName = (string)reg.GetValue("UserName");
            Config.ChangePasswordEveryMilliseconds = (int)reg.GetValue("ChangePasswordEveryMilliseconds");
            Config.ReadLogEveryMilliseconds = (int)reg.GetValue("ReadLogEveryMilliseconds");

            Config.PasswordLength = (int)reg.GetValue("PasswordLength");
            Config.PasswordChars = (string)reg.GetValue("PasswordChars");

            //Config.ToEmail = (string)reg.GetValue("ToEmail");
            //Config.Email = (string)reg.GetValue("Email");
            //Config.EMailPassword = (string)reg.GetValue("EMail.Password");
            //Config.EMailServer = (string)reg.GetValue("EMail.Server");
            //Config.EMailServerPort = (int)reg.GetValue("EMail.Port");

            Config.LastReadedEventLogIndex = (int)reg.GetValue("LastReadedEventLogIndex");
            Config.LastReadedAppLogIndex = (long?)reg.GetValue("LastReadedAppLogIndex");

            #region EMail
            Config.eMail.Server = (string)reg.GetValue("EMail.Server");
            Config.eMail.Port = (int)reg.GetValue("EMail.Port");
            Config.eMail.Address = (string)reg.GetValue("EMail.Address");
            Config.eMail.Login = (string)reg.GetValue("EMail.Login");
            Config.eMail.Password = (string)reg.GetValue("EMail.Password");
            Config.eMail.SSL = Convert.ToBoolean(reg.GetValue("EMail.SSL"));
            #endregion//EMail

            #region Users
            Config.Users = new List<user>((int)reg.GetValue("Users.Count"));

            for (int i = 0; i < Config.Users.Capacity; i++)
            {
                user tmpUser = new user();

                tmpUser.Name = (string)reg.GetValue("User" + i + ".Name");
                tmpUser.ToEmail = (string)reg.GetValue("User" + i + ".ToEmail");

                tmpUser.ChangePassword = Convert.ToBoolean(reg.GetValue("User" + i + ".ChangePassword"));
                tmpUser.NotifyLogonAttempts = Convert.ToBoolean(reg.GetValue("User" + i + ".NotifyLogonAttempts"));
                tmpUser.NotifySuccessLogon = Convert.ToBoolean(reg.GetValue("User" + i + ".NotifySuccessLogon"));

                Config.Users.Add(tmpUser);
            }
            #endregion//Users

            #region Log
            Config.log.Email = Convert.ToBoolean(reg.GetValue("Log.EMail"));
            Config.log.Password = Convert.ToBoolean(reg.GetValue("Log.Password"));
            Config.log.Event = Convert.ToBoolean(reg.GetValue("Log.Event"));
            #endregion//Log

            reg.Close();
        }
        static T ReadRegistry<T>(T DefaultValue, RegistryKey reg, string ValueName)
        {
            object Value;
            try
            {
                Value = reg.GetValue(ValueName);
                if (typeof(T) == typeof(bool))
                    Value = Convert.ToBoolean(Value);
                if (Value == null)
                    Value = DefaultValue;
            }
            catch
            {
                Value = DefaultValue;
            }

            return (T)Value;
        }
        

        public static void Save()
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
            reg = reg.CreateSubKey("LogonSecurity");


            //reg.SetValue("UserName", Config.UserName, RegistryValueKind.String);
            WriteRegistry<int>(reg, "ChangePasswordEveryMilliseconds", Config.ChangePasswordEveryMilliseconds);
            WriteRegistry<int>(reg, "ReadLogEveryMilliseconds", Config.ReadLogEveryMilliseconds);

            WriteRegistry<int>(reg, "PasswordLength", Config.PasswordLength);
            WriteRegistry<string>(reg, "PasswordChars", Config.PasswordChars);


            WriteRegistry<int>(reg, "LastReadedEventLogIndex", Config.LastReadedEventLogIndex);
            WriteRegistry<long?>(reg, "LastReadedAppLogIndex", Config.LastReadedAppLogIndex);


            #region EMail
            WriteRegistry<string>(reg, "EMail.Server", Config.eMail.Server);
            WriteRegistry<int>(reg, "EMail.Port", Config.eMail.Port);
            WriteRegistry<string>(reg, "EMail.Address", Config.eMail.Address);
            WriteRegistry<string>(reg, "EMail.Login", Config.eMail.Login);
            WriteRegistry<string>(reg, "EMail.Password", Config.eMail.Password);
            WriteRegistry<bool>(reg, "EMail.SSL", Config.eMail.SSL);
            WriteRegistry<int>(reg, "EMail.ErrorRepeatSending", Config.eMail.ErrorRepeatSending);
            #endregion//EMail

            #region Users
            WriteRegistry<int>(reg, "Users.Count", Config.Users.Count);
            for (int i = 0; i < Users.Count; i++)
            {
                WriteRegistry<string>(reg, "User" + i + ".Name", Users[i].Name);
                WriteRegistry<string>(reg, "User" + i + ".ToEmail", Users[i].ToEmail);

                WriteRegistry<bool>(reg, "User" + i + ".ChangePassword", Users[i].ChangePassword);
                WriteRegistry<bool>(reg, "User" + i + ".NotifyLogonAttempts", Users[i].NotifyLogonAttempts);
                WriteRegistry<bool>(reg, "User" + i + ".NotifySuccessLogon", Users[i].NotifySuccessLogon);
            }
            #endregion//Users

            #region Log
            WriteRegistry<bool>(reg, "Log.EMail", Config.log.Email);
            WriteRegistry<bool>(reg, "Log.Password", Config.log.Password);
            WriteRegistry<bool>(reg, "Log.Event", Config.log.Event);
            WriteRegistry<bool>(reg, "Log.Work", Config.log.Work);
            #endregion//Log

            reg.Close();
        }
        public static void SaveOld()
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
            reg = reg.CreateSubKey("LogonSecurity");


            //reg.SetValue("UserName", Config.UserName, RegistryValueKind.String);
            reg.SetValue("ChangePasswordEveryMilliseconds", Config.ChangePasswordEveryMilliseconds, RegistryValueKind.DWord);
            reg.SetValue("ReadLogEveryMilliseconds", Config.ReadLogEveryMilliseconds, RegistryValueKind.DWord);

            reg.SetValue("PasswordLength", Config.PasswordLength, RegistryValueKind.DWord);
            reg.SetValue("PasswordChars", Config.PasswordChars, RegistryValueKind.String);

            //reg.SetValue("ToEmail", Config.ToEmail, RegistryValueKind.String);
            //reg.SetValue("Email", Config.Email, RegistryValueKind.String);
            //reg.SetValue("EMailPassword", Config.EMailPassword, RegistryValueKind.String);
            //reg.SetValue("EMailServer", Config.EMailServer, RegistryValueKind.String);
            //reg.SetValue("EMailServerPort", Config.EMailServerPort, RegistryValueKind.DWord);

            reg.SetValue("LastReadedEventLogIndex", Config.LastReadedEventLogIndex, RegistryValueKind.DWord);
            reg.SetValue("LastReadedAppLogIndex", Config.LastReadedAppLogIndex, RegistryValueKind.QWord);


            #region EMail
            reg.SetValue("EMail.Server", Config.eMail.Server, RegistryValueKind.String);
            reg.SetValue("EMail.Port", Config.eMail.Port, RegistryValueKind.DWord);
            reg.SetValue("EMail.Address", Config.eMail.Address, RegistryValueKind.String);
            reg.SetValue("EMail.Login", Config.eMail.Login, RegistryValueKind.String);
            reg.SetValue("EMail.Password", Config.eMail.Password, RegistryValueKind.String);
            reg.SetValue("EMail.SSL", Convert.ToInt32(Config.eMail.SSL), RegistryValueKind.DWord);
            #endregion//EMail

            #region Users
            reg.SetValue("Users.Count", Config.Users.Count, RegistryValueKind.DWord);
            for (int i = 0; i < Users.Count; i++)
            {
                reg.SetValue("User" + i + ".Name", Users[i].Name, RegistryValueKind.String);
                reg.SetValue("User" + i + ".ToEmail", Users[i].ToEmail, RegistryValueKind.String);

                reg.SetValue("User" + i + ".ChangePassword", Convert.ToInt32(Users[i].ChangePassword), RegistryValueKind.DWord);
                reg.SetValue("User" + i + ".NotifyLogonAttempts", Convert.ToInt32(Users[i].NotifyLogonAttempts), RegistryValueKind.DWord);
                reg.SetValue("User" + i + ".NotifySuccessLogon", Convert.ToInt32(Users[i].NotifySuccessLogon), RegistryValueKind.DWord);
            }
            #endregion//Users

            #region Log
            reg.SetValue("Log.EMail", Convert.ToInt32(Config.log.Email), RegistryValueKind.DWord);
            reg.SetValue("Log.Password", Convert.ToInt32(Config.log.Password), RegistryValueKind.DWord);
            reg.SetValue("Log.Event", Convert.ToInt32(Config.log.Event), RegistryValueKind.DWord);
            reg.SetValue("Log.Work", Convert.ToInt32(Config.log.Work), RegistryValueKind.DWord);
            #endregion//Log

            reg.Close();
        }
        static void WriteRegistry<T>(RegistryKey reg, string ValueName, T Value)
        {
            if (typeof(T) == typeof(bool))
                reg.SetValue(ValueName, Convert.ToInt32(Value), RegistryValueKind.DWord);
            else if (typeof(T) == typeof(int))
                reg.SetValue(ValueName, Value, RegistryValueKind.DWord);
            else if (typeof(T) == typeof(long))
                reg.SetValue(ValueName, Value, RegistryValueKind.QWord);
            else if (typeof(T) == typeof(long?))
                reg.SetValue(ValueName, Value, RegistryValueKind.QWord);
            else if (typeof(T) == typeof(string))
                reg.SetValue(ValueName, Value, RegistryValueKind.String);
            else
                throw new Exception("Unknown value type " + typeof(T));

        }
    }
}
