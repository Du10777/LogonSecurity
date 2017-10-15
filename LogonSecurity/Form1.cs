using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace LogonSecurity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "LogonSecurity v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            PasswordTimer_numericUpDown.Value = Config.ChangePasswordEveryMilliseconds;
            LogTimer_numericUpDown.Value = Config.ReadLogEveryMilliseconds;
            PasswordLength_numericUpDown.Value = Config.PasswordLength;
            PasswordChars_textBox.Text = Config.PasswordChars;

            ServiceInterfaceRefresh();

            EMail_Server_textBox.Text = Config.eMail.Server;
            EMail_Port_numericUpDown.Value = Config.eMail.Port;
            EMail_Address_textBox.Text = Config.eMail.Address;
            EMail_Login_textBox.Text = Config.eMail.Login;
            EMail_Password_textBox.Text = Config.eMail.Password;
            EMail_SSL_checkBox.Checked = Config.eMail.SSL;
            EMail_ErrorRepeatSending_numericUpDown.Value = Config.eMail.ErrorRepeatSending;

            foreach (user usr in Config.Users)
                users_listBox.Items.Add(usr.Name);
            if (Config.Users.Count > 0)
                users_listBox.SelectedIndex = 0;

            Log_EMail_checkBox.Checked = Config.log.Email;
            Log_Password_checkBox.Checked = Config.log.Password;
            Log_Event_checkBox.Checked = Config.log.Password;
            Log_Work_checkBox.Checked = Config.log.Work;
        }

        private void PasswordTimer_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Config.ChangePasswordEveryMilliseconds = (int)PasswordTimer_numericUpDown.Value;
            Config.Save();
        }
        private void LogTimer_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Config.ReadLogEveryMilliseconds = (int)LogTimer_numericUpDown.Value;
            Config.Save();
        }
        private void PasswordLength_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Config.PasswordLength = (int)PasswordLength_numericUpDown.Value;
            Config.Save();
        }
        private void PasswordChars_textBox_TextChanged(object sender, EventArgs e)
        {
            Config.PasswordChars = PasswordChars_textBox.Text;
            Config.Save();
        }

        private void IgnoreOldLogs_button_Click(object sender, EventArgs e)
        {
            LogonSecurity.Events.IgnoreOldLogs();
        }


        void ServiceInterfaceRefresh()
        {
            System.Threading.Thread.Sleep(100);
            if (Service.IsInstalled())
            {
                Install_button.Enabled = false;
                UnInstall_button.Enabled = true;
                Start_button.Enabled = true;
                Stop_button.Enabled = true;
                ServiceStartType_comboBox.Enabled = true;

                Service.StartType startType = Service.GetStartType();
                if ((int)startType >= 0 && (int)startType <= 3)
                    ServiceStartType_comboBox.SelectedIndex = (int)startType;

                string Status = Service.GetStatus();
                ServiceStatus_label.Text = "Status: " + Status;

                if (Status == "Stopped")
                    Stop_button.Enabled = false;
                if (Status == "Running")
                    Start_button.Enabled = false;
            }
            else
            {
                Install_button.Enabled = true;
                UnInstall_button.Enabled = false;
                Start_button.Enabled = false;
                Stop_button.Enabled = false;
                ServiceStartType_comboBox.Enabled = false;
            }
        }
        private void Install_button_Click(object sender, EventArgs e)
        {
            Service.Install();
            ServiceInterfaceRefresh();
        }
        private void UnInstall_button_Click(object sender, EventArgs e)
        {
            Service.Stop();
            Service.UnInstall();
            ServiceInterfaceRefresh();
        }
        private void Start_button_Click(object sender, EventArgs e)
        {
            Service.Start();
            ServiceInterfaceRefresh();
        }
        private void Stop_button_Click(object sender, EventArgs e)
        {
            Service.Stop();
            ServiceInterfaceRefresh();
        }
        private void ServiceStartType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Service.StartType value = (Service.StartType)ServiceStartType_comboBox.SelectedIndex;
            Service.SetStartType(value);
        }


        private void EMail_Server_textBox_TextChanged(object sender, EventArgs e)
        {
            Config.eMail.Server = EMail_Server_textBox.Text;
            Config.Save();
        }
        private void EMail_Port_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Config.eMail.Port = (int)EMail_Port_numericUpDown.Value;
            Config.Save();
        }
        private void EMail_Address_textBox_TextChanged(object sender, EventArgs e)
        {
            Config.eMail.Address = EMail_Address_textBox.Text;
            Config.Save();
        }
        private void EMail_Login_textBox_TextChanged(object sender, EventArgs e)
        {
            Config.eMail.Login = EMail_Login_textBox.Text;
            Config.Save();
        }
        private void EMail_Password_textBox_TextChanged(object sender, EventArgs e)
        {
            Config.eMail.Password = EMail_Password_textBox.Text;
            Config.Save();
        }
        private void EMail_SSL_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Config.eMail.SSL = EMail_SSL_checkBox.Checked;
            Config.Save();
        }
        private void EMail_ErrorRepeatSending_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Config.eMail.ErrorRepeatSending = (int)EMail_ErrorRepeatSending_numericUpDown.Value;
            Config.Save();
        }


        private void users_add_button_Click(object sender, EventArgs e)
        {
            string newUserName = "UserName";
            Config.Users.Add(new user(newUserName));

            users_listBox.Items.Add(newUserName);
            users_listBox.SelectedItem = newUserName;
        }
        private void users_remove_button_Click(object sender, EventArgs e)
        {
            int Index = users_listBox.SelectedIndex;

            DialogResult answer = MessageBox.Show("Are you sure you want to delete user \"" + Config.Users[Index].Name + "\"?", "Delete user?", MessageBoxButtons.YesNo);
            if (answer == DialogResult.No)
                return;

            users_listBox.Items.RemoveAt(Index);
            Config.Users.RemoveAt(Index);
        }
        private void users_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RenamingUser)
                return;

            int Index = users_listBox.SelectedIndex;
            if (Index == -1)
            {
                Users_splitContainer.Panel2.Enabled = false;
                users_remove_button.Enabled = false;
                return;
            }

            Users_splitContainer.Panel2.Enabled = true;
            users_remove_button.Enabled = true;

            user usr = Config.Users[Index];

            user_Name_textBox.Text = usr.Name;
            user_ChangePassword_checkBox.Checked = usr.ChangePassword;
            user_NotifyLogonAttempts_checkBox.Checked = usr.NotifyLogonAttempts;
            user_NotifySuccesLogon_checkBox.Checked = usr.NotifySuccessLogon;
            user_ToEmail_textBox.Text = usr.ToEmail;
        }

        static bool RenamingUser;
        private void user_Name_textBox_TextChanged(object sender, EventArgs e)
        {
            RenamingUser = true;

            int Index = users_listBox.SelectedIndex;
            Config.Users[Index].Name = user_Name_textBox.Text;
            users_listBox.Items[Index] = user_Name_textBox.Text;

            Config.Save();

            RenamingUser = false;
        }
        private void user_ChangePassword_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            int Index = users_listBox.SelectedIndex;
            Config.Users[Index].ChangePassword = user_ChangePassword_checkBox.Checked;

            Config.Save();
        }
        private void user_NotifyLogonAttempts_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            int Index = users_listBox.SelectedIndex;
            Config.Users[Index].NotifyLogonAttempts = user_NotifyLogonAttempts_checkBox.Checked;

            Config.Save();
        }
        private void user_NotifySuccesLogon_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            int Index = users_listBox.SelectedIndex;
            Config.Users[Index].NotifySuccessLogon = user_NotifySuccesLogon_checkBox.Checked;

            Config.Save();
        }
        private void user_ToEmail_textBox_TextChanged(object sender, EventArgs e)
        {
            int Index = users_listBox.SelectedIndex;
            Config.Users[Index].ToEmail = user_ToEmail_textBox.Text;

            Config.Save();
        }
        private void user_Test_Email_button_Click(object sender, EventArgs e)
        {
            int Index = users_listBox.SelectedIndex;
            user usr = Config.Users[Index];

            string ErrorMessage = EMail.trySendOnce(usr.ToEmail, "Test", "test Message");
            if (ErrorMessage == String.Empty)
            {
                MessageBox.Show("Message sended");
                return;
            }

            MessageBox.Show(ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void Log_EMail_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Config.log.Email = Log_EMail_checkBox.Checked;
            Config.Save();
        }
        private void Log_Password_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Config.log.Password = Log_Password_checkBox.Checked;
            Config.Save();
        }
        private void Log_Event_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Config.log.Event = Log_Event_checkBox.Checked;
            Config.Save();
        }
        private void Log_Work_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Config.log.Work = Log_Work_checkBox.Checked;
            Config.Save();
        }
    }
}
