using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using System.Windows.Forms;

//todo:
//  +1. Запуск интерфейса должен требовать прав админа
//  +2. Сообщения приходят поздно. Нужны логи в которых будет хорошо видно когда было отправленно сообщение
//  2.1 логи писать во время отправки сообщений (куда и о чем написал)
//  +3. Разделить логин и мыло отправителя. Не у всех почтовых сервисов логин совпадает с мылом

namespace LogonSecurity
{
    class Program
    {
        //Ручные правки:
        //1. Включить в групповых политиках аудит
        //   Конфигурация компьютера - Конфигурация Windows - Параметры безопасности - Конфигурация расширенной политики безопасности - ... - Вход учетной записи
        //   Аудит проверки учетных данных: Успех и Отказ
        //
        //2. Разрешить права ветки реестра на чтение/запись только для сервиса и админа
        //   HKEY_LOCAL_MACHINE\Software\LogonSecurity

        [STAThread]
        static void Main(string[] args)
        {
            //RunTestService();
            //return;


            Config.Open();

            if (args.Length > 0 && args[0] == "-service")
                RunService();
            else
                RunInterface();

        }


        static void RunInterface()
        {
            Log.StartThread();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void RunService()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service()
            };
            ServiceBase.Run(ServicesToRun);
        }

        static void RunTestService()
        {
            new Service();
        }
    }
}
