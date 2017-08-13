using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Diagnostics;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.Threading;

namespace LogonSecurity
{
    class Service : ServiceBase
    {
        public Service()
        {
            Config.Open();

            Config.Pause = false;
            new Thread(LoopThread).Start();
            new Thread(PasswordGeneratorThread).Start();
            Log.StartThread();
        }

        static void LoopThread()
        {
            while (!Config.NeedToStop)
            {
                if (Config.Pause)
                    continue;

                LogonSecurity.Events.ReadAppLog();
                LogonSecurity.Events.ReadEventLog();
                Config.Save();


                int SessionID = new Random().Next();
                if (Config.log.Work)
                    Log.Add("SessionID: " + SessionID + ". Loop thread. Start sleeping " + Config.ReadLogEveryMilliseconds + " ms");

                Sleep(Config.ReadLogEveryMilliseconds);

                if (Config.log.Work)
                    Log.Add("SessionID: " + SessionID + ". Loop thread. Finish sleeping");
            }
        }

        static void PasswordGeneratorThread()
        {
            Thread.CurrentThread.IsBackground = true;

            while (!Config.NeedToStop)
            {
                if (Config.Pause)
                    continue;

                foreach (user usr in Config.Users)
                {
                    user.SetNewPassword(usr);
                }

                int SessionID = new Random().Next();
                if (Config.log.Work)
                    Log.Add("SessionID: " + SessionID + ". Password change thread. Start sleeping " + Config.ChangePasswordEveryMilliseconds + " ms");
                Sleep(Config.ChangePasswordEveryMilliseconds);

                if (Config.log.Work)
                    Log.Add("SessionID: " + SessionID + ". Password change thread. finish sleeping");
            }
        }

        /// <summary>
        /// This funtion need to wait and stop program when user wants to stop
        /// </summary>
        public static void Sleep(int NeedToSleep)
        {
            int SleepStep = 10;

            int Slept = 0;
            while (true)
            {
                if (Config.NeedToStop)
                    break;

                Thread.Sleep(SleepStep);
                Slept += SleepStep;
                if (Slept >= NeedToSleep)
                    break;
            }
        }

        protected override void OnPause()
        {
            Config.Pause = true;
        }
        protected override void OnContinue()
        {
            Config.Pause = false;
        }
        protected override void OnStop()
        {
            Config.NeedToStop = true;
            if (Config.log.Work)
                Log.Add("Stop service");
        }


        public static void Install()
        {
            if (IsInstalled())
                return;

            Process proc = new Process();
            proc.StartInfo.FileName = "sc";
            proc.StartInfo.Arguments = "create ";
            proc.StartInfo.Arguments += "LogonSecurity ";
            proc.StartInfo.Arguments += "binpath= ";
            proc.StartInfo.Arguments += '\"'.ToString() + '\\' + '\"';
            proc.StartInfo.Arguments += System.Reflection.Assembly.GetEntryAssembly().Location;
            proc.StartInfo.Arguments += '\\'.ToString() + '\"';
            proc.StartInfo.Arguments += " -service";
            proc.StartInfo.Arguments += '\"'.ToString();


            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;


            proc.Start();
        }
        public static void UnInstall()
        {
            if (!IsInstalled())
                return;

            Process proc = new Process();
            proc.StartInfo.FileName = "sc";
            proc.StartInfo.Arguments = "delete ";
            proc.StartInfo.Arguments += "LogonSecurity";


            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            proc.Start();
        }

        public static void Start()
        {
            ServiceController serv = GetService();
            if (serv == null)
                return;

            if (serv.Status != ServiceControllerStatus.Running)
                serv.Start();
        }
        public static void Stop()
        {
            ServiceController serv = GetService();
            if (serv == null)
                return;

            if (serv.Status != ServiceControllerStatus.Stopped)
                serv.Stop();
        }
        public static string GetStatus()
        {
            ServiceController serv = GetService();
            if (serv == null)
                return "-";

            return serv.Status.ToString();
        }

        public static bool IsInstalled()
        {
            ServiceController serv = GetService();
            if (serv == null)
                return false;
            else
                return true;
        }
        static ServiceController GetService()
        {
            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController serv in services)
            {
                if (serv.ServiceName == "LogonSecurity")
                    return serv;
            }

            return null;
        }


        public enum StartType
        {
            Disabled = 0,
            Manual = 1,
            Automatic = 2,
            AturomaticDelayed = 3,
            Boot = 4,
            System = 5,
            Unknown = 6
        }
        public static StartType GetStartType()
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\LogonSecurity");
            if (reg == null)
                return StartType.Unknown;

            int startupTypeValue = (int)reg.GetValue("Start");
            StartType result;

            switch (startupTypeValue)
            {
                case 0:
                    result = StartType.Boot;
                    break;

                case 1:
                    result = StartType.System;
                    break;

                case 2:
                    result = StartType.Automatic;
                    break;

                case 3:
                    result = StartType.Manual;
                    break;

                case 4:
                    result = StartType.Disabled;
                    break;

                default:
                    result = StartType.Unknown;
                    break;
            }

            if (startupTypeValue == 2)
            {
                try
                {
                    int DelayedAutostart = (int)reg.GetValue("DelayedAutostart");
                    if (DelayedAutostart == 1)
                        result = StartType.AturomaticDelayed;
                }
                catch{}
            }

            return result;
        }
        public static void SetStartType(StartType Value)
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\LogonSecurity", RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
            if (reg == null)
                return;

            switch (Value)
            {
                case StartType.Disabled:
                    reg.SetValue("Start", 4, RegistryValueKind.DWord);
                    break;

                case StartType.Manual:
                    reg.SetValue("Start", 3, RegistryValueKind.DWord);
                    break;

                case StartType.Automatic:
                    reg.SetValue("Start", 2, RegistryValueKind.DWord);
                    reg.SetValue("DelayedAutostart", 0, RegistryValueKind.DWord);
                    break;

                case StartType.AturomaticDelayed:
                    reg.SetValue("Start", 2, RegistryValueKind.DWord);
                    reg.SetValue("DelayedAutostart", 1, RegistryValueKind.DWord);
                    break;
            }
        }
    }
}
