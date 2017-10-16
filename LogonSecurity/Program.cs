﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using System.Windows.Forms;

//todo:
//Критично:
//  + Ведение версии
//  + Если не правильно настроена почта, вылетает ли ошибка когда нажимаем проверку доставки почты?
//  + Проверить падает ли программа без интернета, при попытке отправить сообщение
//  + Не всегда может быть интернет (при локальном логоне)
//      Пытаться отправить письмо пока не получится. Что бы программе не надо было хранить не отправленные сообщения
//      И что бы программа пыталась отправить то, что в журнале еще не прочитано
//  + Сохранение конфига. Когда служба работает, она постоянно пишет конфиг который в памяти службы
//    и если я открываю интерфейс проги и редактирую конфиг - то он один раз сохраняется, а потом служба пишет поверх тот конфиг, который ей известен
//    Может, если служба запущена, то отключить редактирование конфига? Сделать Enabled = false для groupBox'ов и tabPage'ей
//  - Понизить ФреймВорк
//  - Проверить работу (наличие и включение логирования) на разных ОС:
//      - WinXP
//      - WinServer2003
//      - Win8
//      - WinServer2012
//  - Действия по отправке сообщения с телефона (увидел уведомление, и захотел с телефона пресечь использование компа)
//      - логоф
//      - блокировка учетки
//      - выключение компа (не у всех учеток должны быть права)
//        в свойствах учетку сделать галку CanShutDown
//      - блокировка учетки на N часов
//  - Ведение и отправка статистики за час/сутки/неделю/месяц
//      В настройках профиля проставить галки какую статистику слать
//      Вести надо всю статистику
//      - сколько логонов
//      - сколько попыток
//  - Раз в 3 дня служба падает. Отдебажить и найти причину
//  - покрыть код try catch логированием
//  + Не всегда может получиться записать лог (кто-то занял файл, или умер жесткий диск)
//      Сделать попытки записи лога
//  - Как отключить локальный (консольный) вход
//      это нужно, если злоумышленник отключил на компе интернет и локально подбирает пароли
//      ГПО - КОнфиг компа - Конфиг винды - Параметры безопасности - Локальные политики - Назначение прав пользователя - Запретить локальный вход
//  - Секретный пароль. В поле ввода пароля от почты поставить галки
//  - Хранить пароль немного шифрованным
//  - Отдебажить момент, когда при подключении по RDP надо несколько раз успешно набрать пароль. Может дело в сессия и KerberOS?
//  - будет ли меняться пароль если политика требует сложный пароль?
//  - Может, слать еще сообщения о включении и выключении компьютера?
//    В профиле пользователей поставить галки на уведомления. И при обнаружении таких событий - проверять кому отправить и слать
//
//Не критично:
//  - Поддержка разных языков. Сделать файл локализации
//      Поплывет расположение элементов. Нужен резиновый интерфейс, который сам себя расширяет в зависимости от длинны надписей
//  - Преобразование IP адреса в страну, населенный пункт, и название провайдера
//      это будет онлайн сервис, который может тормозить всю работу
//      надо сделать таймаут ответа, после которого эта вся инфа будет не нужна,
//      и будет отправляться только IP
//  - Сделать документации
//    - Как начать пользоваться
//    - Как оно работает
//  - Всплывающие подсказки
//      Смена пароля раз в N минут нужна что бы пароль не сбрутили (снизить вероятность)
//      Пояснить параметр Email Error Repeat Sending (Если не ушло письмо, попытаться отправить его через N милисекунд)

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
