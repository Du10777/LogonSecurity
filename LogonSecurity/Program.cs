﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using System.Windows.Forms;

//todo:
//Критично:
//  - Сделать оповещение о том, что журнал безопасности был очищен
//  - Понизить ФреймВорк
//  - Проверить работу (наличие и включение логирования) на разных ОС:
//      - WinXP
//      - WinServer2003
//      - Win8
//      - WinServer2012
//      - WinServer2016
//  - Действия по отправке сообщения с телефона (увидел уведомление, и захотел с телефона пресечь использование компа)
//      - логоф
//      - блокировка учетки
//      - выключение компа (не у всех учеток должны быть права)
//        в свойствах учетку сделать галку CanShutDown
//      - блокировка учетки на N часов
//      Есть доступ к папке входящие
//      Есть информация от кого письмо
//      В теле письма есть информация про какую учетку идет речь
//      У этой учетки сделать галки разрешающие/запрещающие делать действия указанные выше
//      Парсить входящие письма, и если найдено письмо от одного из пользователей, то пропарсить в поисках имени учетки
//      После нахождения имени проверить есть ли такая учетка, и какое мыло у неё прописанно. Если мыло не совпадает - игнор
//      Проверить что написанно в тексте написанным пользователем
//      Если оно совпадает с одной из известных команд, и у пользователя есть на это право (проставлена галка в профиле) - выполнить
//      Действия при получении писем от пользователей
//      В письма с информацией о попытке входа или входа в конец дописывать блок о том что надо отправить в ответ, что бы сделать какое-то действие
//      Например так
//      1 – логоф
//      2 – выкл
//      3 – ребут
//      4 - форматирование

//  - Ведение и отправка статистики за час/сутки/неделю/месяц
//      В настройках профиля проставить галки какую статистику слать
//      Вести надо всю статистику
//      - сколько логонов
//      - сколько попыток
//  - покрыть код try catch логированием
//  - Как отключить локальный (консольный) вход
//      это нужно, если злоумышленник отключил на компе интернет и локально подбирает пароли
//      ГПО - КОнфиг компа - Конфиг винды - Параметры безопасности - Локальные политики - Назначение прав пользователя - Запретить локальный вход
//  - Хранить пароль немного шифрованным
//  - Отдебажить момент, когда при подключении по RDP надо несколько раз успешно набрать пароль. Может дело в сессии и KerberOS?
//  - будет ли меняться пароль если политика требует сложный пароль?
//  - Может, слать еще сообщения о включении и выключении компьютера?
//    В профиле пользователей поставить галки на уведомления. И при обнаружении таких событий - проверять кому отправить и слать
//  - Если программа запускается с носителя защищенного от записи (сетевой ресурс, или оптический диск) - сделать установку в Program Files
//      Иначе, потом логи не будут писаться
//      Но лучше не .ехе перемещять, а лог писать в другое место
//      А может лучше .ехе перемещять (работать то все равно будет локально), и при нажатии Кнопки инсталл - копировать .ехе файл в нужное место
//      Или предоставить возможность выбора каталога с логами, по умолчанию предлагая дефолтный
//      Ваабще в семерке лучше писать в ProgramData, а в WinXP писать в All Users
//  - В профиле пользователя сделать галку "Получать оповещения о событиях всех пользователей кроме тех, что есть в списке слева"
//  + Ведение версии
//  + Если не правильно настроена почта, вылетает ли ошибка когда нажимаем проверку доставки почты?
//  + Проверить падает ли программа без интернета, при попытке отправить сообщение
//  + Не всегда может быть интернет (при локальном логоне)
//      Пытаться отправить письмо пока не получится. Что бы программе не надо было хранить не отправленные сообщения
//      И что бы программа пыталась отправить то, что в журнале еще не прочитано
//  + Сохранение конфига. Когда служба работает, она постоянно пишет конфиг который в памяти службы
//    и если я открываю интерфейс проги и редактирую конфиг - то он один раз сохраняется, а потом служба пишет поверх тот конфиг, который ей известен
//    Может, если служба запущена, то отключить редактирование конфига? Сделать Enabled = false для groupBox'ов и tabPage'ей
//  + Не всегда может получиться записать лог (кто-то занял файл, или умер жесткий диск)
//      Сделать попытки записи лога
//  + Секретный пароль. В поле ввода пароля от почты поставить точки
//
//Не критично:
//  - Поддержка разных языков. Сделать файл локализации
//    - Поплывет расположение элементов. Нужен резиновый интерфейс, который сам себя расширяет в зависимости от длинны надписей
//    - сделать класс Localisation и сделать экземплярр этого класса с именем Language
//      в нем сделать несколько подклассов, по одному для каждой группы надписей
//      при инициализации проги - производить локализацию интерфейса
//      если какая-то строчка будет пустой (вся null, или после удаления пробелов и табов (ради тест) длинна 0) - заменять на дефолтную надпись.
//      Это поможет в дальнейшем, когда я сделаю новую кнопку, а на японский её еще ни кто не перевел
//      нужен экземпляр класса по имени enLanguage, в котором будут храниться дефолтные надписи
//      как хранить локализацию. самое простое - xml файл (вспомнить про сериализацию/десериализацию). если серики мне подойдут - использовать их, если нет - написать своё с блекджеком и шлюхами
//    - как хранить локализацию? в проге или папка с локализациями?
//    - В проге нужна возможность выбрать язык
//  - Преобразование IP адреса в страну, населенный пункт, и название провайдера
//      это будет онлайн сервис, который может тормозить всю работу
//      надо сделать таймаут ответа, после которого эта вся инфа будет не нужна,
//      и будет отправляться только IP
//  - Всплывающие подсказки
//      Смена пароля раз в N минут нужна что бы пароль не сбрутили (снизить вероятность)
//      Пояснить параметр Email Error Repeat Sending (Если не ушло письмо, попытаться отправить его через N милисекунд)
//  - Сделать галку для автообновления
//  + Сделать таймер, который будет обновлять статус службы (работает или нет)
//  + Сделать документации
//    + Как начать пользоваться
//    + Как оно работает
//  - Хранить конфиг в HKLM\SYSTEM\CurrentControlSet\services\LogonSecutity\Config

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
