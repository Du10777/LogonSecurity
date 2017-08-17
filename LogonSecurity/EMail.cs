using System;
using System.Net.Mail;

namespace LogonSecurity
{
    class EMail
    {
        public string Server = String.Empty;
        public int Port;
        public string Address = String.Empty;
        public string Login = String.Empty;
        public string Password = String.Empty;
        public bool SSL;

        public static void Send(string ToEmail, string Title, string Message)
        {
            if (Events.IgnoreLogs)
                return;//Происходит чтение и игнорирование старых логов

            int MessageID = new Random().Next();
            if(Config.log.Email)
                Log.Add("MessageID # " + MessageID + ". Start sending email to " + ToEmail + ". Subject: " + Title);

            MailMessage msg = new MailMessage(Config.eMail.Address, ToEmail, Title, Message);
            SmtpClient smtpClient = new SmtpClient(Config.eMail.Server, Config.eMail.Port);
            smtpClient.Credentials = new System.Net.NetworkCredential(Config.eMail.Login, Config.eMail.Password);
            smtpClient.EnableSsl = Config.eMail.SSL;
            smtpClient.Send(msg);

            if (Config.log.Email)
                Log.Add("MessageID # " + MessageID + ". Email Sended to " + ToEmail + ". Subject: " + Title);
        }
    }
}
