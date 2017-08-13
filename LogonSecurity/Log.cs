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
            fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            file = new StreamWriter(fs);
        }

        public static void Close()
        {
            file.Dispose();
            file.Close();

            fs.Dispose();
            fs.Close();
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
            Directory.CreateDirectory(LogsFolder);

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
            file.WriteLine(Value);
        }



        public bool Email;
        public bool Password;
        public bool Event;
        public bool Work;
    }
}
