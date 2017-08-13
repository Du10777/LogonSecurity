using System;
using System.DirectoryServices;

namespace LogonSecurity
{
    class user
    {
        public user() { }
        public user(string UserName)
        {
            this.Name = UserName;
        }

        public string Name = String.Empty;
        public string CurrentPassword = "Password Generation Error";
        public string ToEmail = "";

        public bool ChangePassword;
        public bool NotifyLogonAttempts;
        public bool NotifySuccessLogon;

        public static user FindUserByName(string Name)
        {
            foreach (user usr in Config.Users)
            {
                if (StringComparer.OrdinalIgnoreCase.Compare(usr.Name, Name) == 0)
                    return usr;
            }

            return null;
        }


        public static void SetNewPassword(user usr)
        {
            if (!usr.ChangePassword)//Если не надо менять пароль
                return;//Выйти


            int PasswordID = new Random().Next();
            if (Config.log.Password)
                Log.Add("PasswordID # " + PasswordID + ". Start changing password to " + usr.Name);

            try
            {
                string NewPassword = GeneratePassword();
                SetNewPassword(usr.Name, NewPassword);
                usr.CurrentPassword = NewPassword;
            }
            catch{ }

            if (Config.log.Password)
                Log.Add("PasswordID # " + PasswordID + ". Password successfully changed to " + usr.Name);
        }
        static void SetNewPassword(string User, string NewPassword)
        {
            DirectoryEntry localDirectory = new DirectoryEntry("WinNT://" + Environment.MachineName.ToString());
            DirectoryEntries users = localDirectory.Children;
            DirectoryEntry user = users.Find(User);

            user.Invoke("SetPassword", NewPassword);
        }
        static string GeneratePassword()
        {
            string Chars = Config.PasswordChars;
            char[] StringChars = new char[Config.PasswordLength];
            Random random = new Random();

            for (int i = 0; i < StringChars.Length; i++)
            {
                StringChars[i] = Chars[random.Next(Chars.Length)];
            }

            string result = new String(StringChars);

            return result;
        }
    }
}
