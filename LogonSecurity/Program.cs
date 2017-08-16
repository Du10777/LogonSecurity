using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using System.Windows.Forms;

//todo:
//  - Ведение версии
//  - Действия по отправке сообщения
//      - логоф
//      - блокировка учетки
//      - выключение компа (не у всех учеток должны быть права)
//        в свойствах учетку сделать галку CanShutDown
//  - Понизить ФреймВорк
//  - Проверить работу (наличие и включение логирования) на разных ОС:
//      - WinXP
//      - WinServer2003
//      - Win8
//      - WinServer2012
//  - Ведение и отправка статистики за час/сутки/неделю/месяц
//      В настройках профиля проставить галки какую статистику слать
//      Вести надо всю статистику
//      - сколько логонов
//      - сколько попыток
//  - Отправка сообщений с телефона с целью заблокировать вход на N часов 

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
