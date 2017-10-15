namespace LogonSecurity
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.General_tabPage = new System.Windows.Forms.TabPage();
            this.PasswordLength_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LogTimer_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.PasswordTimer_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.EMail_groupBox = new System.Windows.Forms.GroupBox();
            this.EMail_Port_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.EMail_SSL_checkBox = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.EMail_Server_textBox = new System.Windows.Forms.TextBox();
            this.EMail_Password_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.EMail_Login_textBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.EMail_Address_textBox = new System.Windows.Forms.TextBox();
            this.PasswordChars_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ServiceStatus_label = new System.Windows.Forms.Label();
            this.ServiceStartType_comboBox = new System.Windows.Forms.ComboBox();
            this.ServiceStartType_label = new System.Windows.Forms.Label();
            this.Stop_button = new System.Windows.Forms.Button();
            this.Start_button = new System.Windows.Forms.Button();
            this.UnInstall_button = new System.Windows.Forms.Button();
            this.Install_button = new System.Windows.Forms.Button();
            this.IgnoreOldLogs_button = new System.Windows.Forms.Button();
            this.PasswordChars_label = new System.Windows.Forms.Label();
            this.PasswordLength_label = new System.Windows.Forms.Label();
            this.LogTimer_label = new System.Windows.Forms.Label();
            this.PasswordTimer_label = new System.Windows.Forms.Label();
            this.users_tabPage = new System.Windows.Forms.TabPage();
            this.Users_splitContainer = new System.Windows.Forms.SplitContainer();
            this.users_listBox = new System.Windows.Forms.ListBox();
            this.users_add_button = new System.Windows.Forms.Button();
            this.users_remove_button = new System.Windows.Forms.Button();
            this.user_Test_Email_button = new System.Windows.Forms.Button();
            this.user_ToEmail_textBox = new System.Windows.Forms.TextBox();
            this.user_ToEmail_label = new System.Windows.Forms.Label();
            this.user_NotifySuccesLogon_checkBox = new System.Windows.Forms.CheckBox();
            this.user_NotifyLogonAttempts_checkBox = new System.Windows.Forms.CheckBox();
            this.user_ChangePassword_checkBox = new System.Windows.Forms.CheckBox();
            this.user_Name_textBox = new System.Windows.Forms.TextBox();
            this.user_Name_label = new System.Windows.Forms.Label();
            this.Log_tabPage = new System.Windows.Forms.TabPage();
            this.Log_Work_checkBox = new System.Windows.Forms.CheckBox();
            this.Log_Event_checkBox = new System.Windows.Forms.CheckBox();
            this.Log_Password_checkBox = new System.Windows.Forms.CheckBox();
            this.Log_EMail_checkBox = new System.Windows.Forms.CheckBox();
            this.EMail_ErrorRepeatSending_label = new System.Windows.Forms.Label();
            this.EMail_ErrorRepeatSending_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tabControl.SuspendLayout();
            this.General_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordLength_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogTimer_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTimer_numericUpDown)).BeginInit();
            this.EMail_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EMail_Port_numericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.users_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Users_splitContainer)).BeginInit();
            this.Users_splitContainer.Panel1.SuspendLayout();
            this.Users_splitContainer.Panel2.SuspendLayout();
            this.Users_splitContainer.SuspendLayout();
            this.Log_tabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EMail_ErrorRepeatSending_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.General_tabPage);
            this.tabControl.Controls.Add(this.users_tabPage);
            this.tabControl.Controls.Add(this.Log_tabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(603, 204);
            this.tabControl.TabIndex = 0;
            // 
            // General_tabPage
            // 
            this.General_tabPage.Controls.Add(this.PasswordLength_numericUpDown);
            this.General_tabPage.Controls.Add(this.LogTimer_numericUpDown);
            this.General_tabPage.Controls.Add(this.PasswordTimer_numericUpDown);
            this.General_tabPage.Controls.Add(this.EMail_groupBox);
            this.General_tabPage.Controls.Add(this.PasswordChars_textBox);
            this.General_tabPage.Controls.Add(this.groupBox1);
            this.General_tabPage.Controls.Add(this.IgnoreOldLogs_button);
            this.General_tabPage.Controls.Add(this.PasswordChars_label);
            this.General_tabPage.Controls.Add(this.PasswordLength_label);
            this.General_tabPage.Controls.Add(this.LogTimer_label);
            this.General_tabPage.Controls.Add(this.PasswordTimer_label);
            this.General_tabPage.Location = new System.Drawing.Point(4, 22);
            this.General_tabPage.Name = "General_tabPage";
            this.General_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.General_tabPage.Size = new System.Drawing.Size(595, 178);
            this.General_tabPage.TabIndex = 0;
            this.General_tabPage.Text = "General";
            this.General_tabPage.UseVisualStyleBackColor = true;
            // 
            // PasswordLength_numericUpDown
            // 
            this.PasswordLength_numericUpDown.Location = new System.Drawing.Point(98, 56);
            this.PasswordLength_numericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PasswordLength_numericUpDown.Name = "PasswordLength_numericUpDown";
            this.PasswordLength_numericUpDown.Size = new System.Drawing.Size(44, 20);
            this.PasswordLength_numericUpDown.TabIndex = 13;
            this.PasswordLength_numericUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PasswordLength_numericUpDown.ValueChanged += new System.EventHandler(this.PasswordLength_numericUpDown_ValueChanged);
            // 
            // LogTimer_numericUpDown
            // 
            this.LogTimer_numericUpDown.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LogTimer_numericUpDown.Location = new System.Drawing.Point(122, 33);
            this.LogTimer_numericUpDown.Maximum = new decimal(new int[] {
            86400000,
            0,
            0,
            0});
            this.LogTimer_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LogTimer_numericUpDown.Name = "LogTimer_numericUpDown";
            this.LogTimer_numericUpDown.Size = new System.Drawing.Size(70, 20);
            this.LogTimer_numericUpDown.TabIndex = 12;
            this.LogTimer_numericUpDown.Value = new decimal(new int[] {
            86400000,
            0,
            0,
            0});
            this.LogTimer_numericUpDown.ValueChanged += new System.EventHandler(this.LogTimer_numericUpDown_ValueChanged);
            // 
            // PasswordTimer_numericUpDown
            // 
            this.PasswordTimer_numericUpDown.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PasswordTimer_numericUpDown.Location = new System.Drawing.Point(159, 7);
            this.PasswordTimer_numericUpDown.Maximum = new decimal(new int[] {
            86400000,
            0,
            0,
            0});
            this.PasswordTimer_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PasswordTimer_numericUpDown.Name = "PasswordTimer_numericUpDown";
            this.PasswordTimer_numericUpDown.Size = new System.Drawing.Size(70, 20);
            this.PasswordTimer_numericUpDown.TabIndex = 11;
            this.PasswordTimer_numericUpDown.Value = new decimal(new int[] {
            86400000,
            0,
            0,
            0});
            this.PasswordTimer_numericUpDown.ValueChanged += new System.EventHandler(this.PasswordTimer_numericUpDown_ValueChanged);
            // 
            // EMail_groupBox
            // 
            this.EMail_groupBox.Controls.Add(this.EMail_ErrorRepeatSending_numericUpDown);
            this.EMail_groupBox.Controls.Add(this.EMail_ErrorRepeatSending_label);
            this.EMail_groupBox.Controls.Add(this.EMail_Port_numericUpDown);
            this.EMail_groupBox.Controls.Add(this.EMail_SSL_checkBox);
            this.EMail_groupBox.Controls.Add(this.label11);
            this.EMail_groupBox.Controls.Add(this.EMail_Server_textBox);
            this.EMail_groupBox.Controls.Add(this.EMail_Password_textBox);
            this.EMail_groupBox.Controls.Add(this.label1);
            this.EMail_groupBox.Controls.Add(this.label10);
            this.EMail_groupBox.Controls.Add(this.EMail_Login_textBox);
            this.EMail_groupBox.Controls.Add(this.label9);
            this.EMail_groupBox.Controls.Add(this.label8);
            this.EMail_groupBox.Controls.Add(this.EMail_Address_textBox);
            this.EMail_groupBox.Location = new System.Drawing.Point(410, 3);
            this.EMail_groupBox.Name = "EMail_groupBox";
            this.EMail_groupBox.Size = new System.Drawing.Size(180, 170);
            this.EMail_groupBox.TabIndex = 10;
            this.EMail_groupBox.TabStop = false;
            this.EMail_groupBox.Text = "E-Mail Configuration";
            // 
            // EMail_Port_numericUpDown
            // 
            this.EMail_Port_numericUpDown.Location = new System.Drawing.Point(40, 42);
            this.EMail_Port_numericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.EMail_Port_numericUpDown.Name = "EMail_Port_numericUpDown";
            this.EMail_Port_numericUpDown.Size = new System.Drawing.Size(52, 20);
            this.EMail_Port_numericUpDown.TabIndex = 14;
            this.EMail_Port_numericUpDown.ValueChanged += new System.EventHandler(this.EMail_Port_numericUpDown_ValueChanged);
            // 
            // EMail_SSL_checkBox
            // 
            this.EMail_SSL_checkBox.AutoSize = true;
            this.EMail_SSL_checkBox.Location = new System.Drawing.Point(123, 43);
            this.EMail_SSL_checkBox.Name = "EMail_SSL_checkBox";
            this.EMail_SSL_checkBox.Size = new System.Drawing.Size(46, 17);
            this.EMail_SSL_checkBox.TabIndex = 8;
            this.EMail_SSL_checkBox.Text = "SSL";
            this.EMail_SSL_checkBox.UseVisualStyleBackColor = true;
            this.EMail_SSL_checkBox.CheckedChanged += new System.EventHandler(this.EMail_SSL_checkBox_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Password:";
            // 
            // EMail_Server_textBox
            // 
            this.EMail_Server_textBox.Location = new System.Drawing.Point(52, 16);
            this.EMail_Server_textBox.Name = "EMail_Server_textBox";
            this.EMail_Server_textBox.Size = new System.Drawing.Size(117, 20);
            this.EMail_Server_textBox.TabIndex = 1;
            this.EMail_Server_textBox.TextChanged += new System.EventHandler(this.EMail_Server_textBox_TextChanged);
            // 
            // EMail_Password_textBox
            // 
            this.EMail_Password_textBox.Location = new System.Drawing.Point(67, 118);
            this.EMail_Password_textBox.Name = "EMail_Password_textBox";
            this.EMail_Password_textBox.Size = new System.Drawing.Size(102, 20);
            this.EMail_Password_textBox.TabIndex = 4;
            this.EMail_Password_textBox.TextChanged += new System.EventHandler(this.EMail_Password_textBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "E-Mail:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Login:";
            // 
            // EMail_Login_textBox
            // 
            this.EMail_Login_textBox.Location = new System.Drawing.Point(47, 92);
            this.EMail_Login_textBox.Name = "EMail_Login_textBox";
            this.EMail_Login_textBox.Size = new System.Drawing.Size(122, 20);
            this.EMail_Login_textBox.TabIndex = 3;
            this.EMail_Login_textBox.TextChanged += new System.EventHandler(this.EMail_Login_textBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Port:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Server:";
            // 
            // EMail_Address_textBox
            // 
            this.EMail_Address_textBox.Location = new System.Drawing.Point(47, 66);
            this.EMail_Address_textBox.Name = "EMail_Address_textBox";
            this.EMail_Address_textBox.Size = new System.Drawing.Size(122, 20);
            this.EMail_Address_textBox.TabIndex = 3;
            this.EMail_Address_textBox.TextChanged += new System.EventHandler(this.EMail_Address_textBox_TextChanged);
            // 
            // PasswordChars_textBox
            // 
            this.PasswordChars_textBox.Location = new System.Drawing.Point(86, 84);
            this.PasswordChars_textBox.Name = "PasswordChars_textBox";
            this.PasswordChars_textBox.Size = new System.Drawing.Size(144, 20);
            this.PasswordChars_textBox.TabIndex = 9;
            this.PasswordChars_textBox.TextChanged += new System.EventHandler(this.PasswordChars_textBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ServiceStatus_label);
            this.groupBox1.Controls.Add(this.ServiceStartType_comboBox);
            this.groupBox1.Controls.Add(this.ServiceStartType_label);
            this.groupBox1.Controls.Add(this.Stop_button);
            this.groupBox1.Controls.Add(this.Start_button);
            this.groupBox1.Controls.Add(this.UnInstall_button);
            this.groupBox1.Controls.Add(this.Install_button);
            this.groupBox1.Location = new System.Drawing.Point(239, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 133);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service";
            // 
            // ServiceStatus_label
            // 
            this.ServiceStatus_label.AutoSize = true;
            this.ServiceStatus_label.Location = new System.Drawing.Point(6, 74);
            this.ServiceStatus_label.Name = "ServiceStatus_label";
            this.ServiceStatus_label.Size = new System.Drawing.Size(46, 13);
            this.ServiceStatus_label.TabIndex = 11;
            this.ServiceStatus_label.Text = "Status: -";
            // 
            // ServiceStartType_comboBox
            // 
            this.ServiceStartType_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServiceStartType_comboBox.FormattingEnabled = true;
            this.ServiceStartType_comboBox.Items.AddRange(new object[] {
            "Disabled",
            "Manual",
            "Automatic",
            "Automatic (delayed)"});
            this.ServiceStartType_comboBox.Location = new System.Drawing.Point(6, 103);
            this.ServiceStartType_comboBox.Name = "ServiceStartType_comboBox";
            this.ServiceStartType_comboBox.Size = new System.Drawing.Size(117, 21);
            this.ServiceStartType_comboBox.TabIndex = 10;
            this.ServiceStartType_comboBox.SelectedIndexChanged += new System.EventHandler(this.ServiceStartType_comboBox_SelectedIndexChanged);
            // 
            // ServiceStartType_label
            // 
            this.ServiceStartType_label.AutoSize = true;
            this.ServiceStartType_label.Location = new System.Drawing.Point(6, 87);
            this.ServiceStartType_label.Name = "ServiceStartType_label";
            this.ServiceStartType_label.Size = new System.Drawing.Size(95, 13);
            this.ServiceStartType_label.TabIndex = 10;
            this.ServiceStartType_label.Text = "Service Start Type";
            // 
            // Stop_button
            // 
            this.Stop_button.Location = new System.Drawing.Point(87, 48);
            this.Stop_button.Name = "Stop_button";
            this.Stop_button.Size = new System.Drawing.Size(75, 23);
            this.Stop_button.TabIndex = 8;
            this.Stop_button.Text = "Stop";
            this.Stop_button.UseVisualStyleBackColor = true;
            this.Stop_button.Click += new System.EventHandler(this.Stop_button_Click);
            // 
            // Start_button
            // 
            this.Start_button.Location = new System.Drawing.Point(6, 48);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(75, 23);
            this.Start_button.TabIndex = 8;
            this.Start_button.Text = "Start";
            this.Start_button.UseVisualStyleBackColor = true;
            this.Start_button.Click += new System.EventHandler(this.Start_button_Click);
            // 
            // UnInstall_button
            // 
            this.UnInstall_button.Location = new System.Drawing.Point(87, 19);
            this.UnInstall_button.Name = "UnInstall_button";
            this.UnInstall_button.Size = new System.Drawing.Size(75, 23);
            this.UnInstall_button.TabIndex = 8;
            this.UnInstall_button.Text = "UnInstall";
            this.UnInstall_button.UseVisualStyleBackColor = true;
            this.UnInstall_button.Click += new System.EventHandler(this.UnInstall_button_Click);
            // 
            // Install_button
            // 
            this.Install_button.Location = new System.Drawing.Point(6, 19);
            this.Install_button.Name = "Install_button";
            this.Install_button.Size = new System.Drawing.Size(75, 23);
            this.Install_button.TabIndex = 8;
            this.Install_button.Text = "Install";
            this.Install_button.UseVisualStyleBackColor = true;
            this.Install_button.Click += new System.EventHandler(this.Install_button_Click);
            // 
            // IgnoreOldLogs_button
            // 
            this.IgnoreOldLogs_button.Location = new System.Drawing.Point(8, 110);
            this.IgnoreOldLogs_button.Name = "IgnoreOldLogs_button";
            this.IgnoreOldLogs_button.Size = new System.Drawing.Size(90, 23);
            this.IgnoreOldLogs_button.TabIndex = 6;
            this.IgnoreOldLogs_button.Text = "Ignore Old Logs";
            this.IgnoreOldLogs_button.UseVisualStyleBackColor = true;
            this.IgnoreOldLogs_button.Click += new System.EventHandler(this.IgnoreOldLogs_button_Click);
            // 
            // PasswordChars_label
            // 
            this.PasswordChars_label.AutoSize = true;
            this.PasswordChars_label.Location = new System.Drawing.Point(3, 87);
            this.PasswordChars_label.Name = "PasswordChars_label";
            this.PasswordChars_label.Size = new System.Drawing.Size(89, 13);
            this.PasswordChars_label.TabIndex = 5;
            this.PasswordChars_label.Text = "Password Chars: ";
            // 
            // PasswordLength_label
            // 
            this.PasswordLength_label.AutoSize = true;
            this.PasswordLength_label.Location = new System.Drawing.Point(3, 58);
            this.PasswordLength_label.Name = "PasswordLength_label";
            this.PasswordLength_label.Size = new System.Drawing.Size(92, 13);
            this.PasswordLength_label.TabIndex = 4;
            this.PasswordLength_label.Text = "Password Length:";
            // 
            // LogTimer_label
            // 
            this.LogTimer_label.AutoSize = true;
            this.LogTimer_label.Location = new System.Drawing.Point(3, 35);
            this.LogTimer_label.Name = "LogTimer_label";
            this.LogTimer_label.Size = new System.Drawing.Size(113, 13);
            this.LogTimer_label.TabIndex = 2;
            this.LogTimer_label.Text = "Pasre Log Every ... ms";
            // 
            // PasswordTimer_label
            // 
            this.PasswordTimer_label.AutoSize = true;
            this.PasswordTimer_label.Location = new System.Drawing.Point(3, 9);
            this.PasswordTimer_label.Name = "PasswordTimer_label";
            this.PasswordTimer_label.Size = new System.Drawing.Size(150, 13);
            this.PasswordTimer_label.TabIndex = 0;
            this.PasswordTimer_label.Text = "Change Password every ... ms";
            // 
            // users_tabPage
            // 
            this.users_tabPage.Controls.Add(this.Users_splitContainer);
            this.users_tabPage.Location = new System.Drawing.Point(4, 22);
            this.users_tabPage.Name = "users_tabPage";
            this.users_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.users_tabPage.Size = new System.Drawing.Size(595, 178);
            this.users_tabPage.TabIndex = 1;
            this.users_tabPage.Text = "users";
            this.users_tabPage.UseVisualStyleBackColor = true;
            // 
            // Users_splitContainer
            // 
            this.Users_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Users_splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.Users_splitContainer.Location = new System.Drawing.Point(3, 3);
            this.Users_splitContainer.Name = "Users_splitContainer";
            // 
            // Users_splitContainer.Panel1
            // 
            this.Users_splitContainer.Panel1.Controls.Add(this.users_listBox);
            this.Users_splitContainer.Panel1.Controls.Add(this.users_add_button);
            this.Users_splitContainer.Panel1.Controls.Add(this.users_remove_button);
            // 
            // Users_splitContainer.Panel2
            // 
            this.Users_splitContainer.Panel2.Controls.Add(this.user_Test_Email_button);
            this.Users_splitContainer.Panel2.Controls.Add(this.user_ToEmail_textBox);
            this.Users_splitContainer.Panel2.Controls.Add(this.user_ToEmail_label);
            this.Users_splitContainer.Panel2.Controls.Add(this.user_NotifySuccesLogon_checkBox);
            this.Users_splitContainer.Panel2.Controls.Add(this.user_NotifyLogonAttempts_checkBox);
            this.Users_splitContainer.Panel2.Controls.Add(this.user_ChangePassword_checkBox);
            this.Users_splitContainer.Panel2.Controls.Add(this.user_Name_textBox);
            this.Users_splitContainer.Panel2.Controls.Add(this.user_Name_label);
            this.Users_splitContainer.Panel2.Enabled = false;
            this.Users_splitContainer.Size = new System.Drawing.Size(589, 172);
            this.Users_splitContainer.SplitterDistance = 230;
            this.Users_splitContainer.TabIndex = 0;
            // 
            // users_listBox
            // 
            this.users_listBox.FormattingEnabled = true;
            this.users_listBox.Location = new System.Drawing.Point(3, 32);
            this.users_listBox.Name = "users_listBox";
            this.users_listBox.Size = new System.Drawing.Size(224, 95);
            this.users_listBox.TabIndex = 0;
            this.users_listBox.SelectedIndexChanged += new System.EventHandler(this.users_listBox_SelectedIndexChanged);
            // 
            // users_add_button
            // 
            this.users_add_button.Location = new System.Drawing.Point(3, 3);
            this.users_add_button.Name = "users_add_button";
            this.users_add_button.Size = new System.Drawing.Size(116, 23);
            this.users_add_button.TabIndex = 1;
            this.users_add_button.Text = "Add";
            this.users_add_button.UseVisualStyleBackColor = true;
            this.users_add_button.Click += new System.EventHandler(this.users_add_button_Click);
            // 
            // users_remove_button
            // 
            this.users_remove_button.Enabled = false;
            this.users_remove_button.Location = new System.Drawing.Point(125, 3);
            this.users_remove_button.Name = "users_remove_button";
            this.users_remove_button.Size = new System.Drawing.Size(102, 23);
            this.users_remove_button.TabIndex = 2;
            this.users_remove_button.Text = "Remove";
            this.users_remove_button.UseVisualStyleBackColor = true;
            this.users_remove_button.Click += new System.EventHandler(this.users_remove_button_Click);
            // 
            // user_Test_Email_button
            // 
            this.user_Test_Email_button.Location = new System.Drawing.Point(228, 88);
            this.user_Test_Email_button.Name = "user_Test_Email_button";
            this.user_Test_Email_button.Size = new System.Drawing.Size(122, 23);
            this.user_Test_Email_button.TabIndex = 7;
            this.user_Test_Email_button.Text = "test E-Mail Delivery";
            this.user_Test_Email_button.UseVisualStyleBackColor = true;
            this.user_Test_Email_button.Click += new System.EventHandler(this.user_Test_Email_button_Click);
            // 
            // user_ToEmail_textBox
            // 
            this.user_ToEmail_textBox.Location = new System.Drawing.Point(16, 114);
            this.user_ToEmail_textBox.Name = "user_ToEmail_textBox";
            this.user_ToEmail_textBox.Size = new System.Drawing.Size(334, 20);
            this.user_ToEmail_textBox.TabIndex = 6;
            this.user_ToEmail_textBox.TextChanged += new System.EventHandler(this.user_ToEmail_textBox_TextChanged);
            // 
            // user_ToEmail_label
            // 
            this.user_ToEmail_label.AutoSize = true;
            this.user_ToEmail_label.Location = new System.Drawing.Point(13, 98);
            this.user_ToEmail_label.Name = "user_ToEmail_label";
            this.user_ToEmail_label.Size = new System.Drawing.Size(129, 13);
            this.user_ToEmail_label.TabIndex = 5;
            this.user_ToEmail_label.Text = "Send messages to E-Mail:";
            // 
            // user_NotifySuccesLogon_checkBox
            // 
            this.user_NotifySuccesLogon_checkBox.AutoSize = true;
            this.user_NotifySuccesLogon_checkBox.Location = new System.Drawing.Point(16, 78);
            this.user_NotifySuccesLogon_checkBox.Name = "user_NotifySuccesLogon_checkBox";
            this.user_NotifySuccesLogon_checkBox.Size = new System.Drawing.Size(160, 17);
            this.user_NotifySuccesLogon_checkBox.TabIndex = 4;
            this.user_NotifySuccesLogon_checkBox.Text = "Notify about Success Logon";
            this.user_NotifySuccesLogon_checkBox.UseVisualStyleBackColor = true;
            this.user_NotifySuccesLogon_checkBox.CheckedChanged += new System.EventHandler(this.user_NotifySuccesLogon_checkBox_CheckedChanged);
            // 
            // user_NotifyLogonAttempts_checkBox
            // 
            this.user_NotifyLogonAttempts_checkBox.AutoSize = true;
            this.user_NotifyLogonAttempts_checkBox.Location = new System.Drawing.Point(16, 55);
            this.user_NotifyLogonAttempts_checkBox.Name = "user_NotifyLogonAttempts_checkBox";
            this.user_NotifyLogonAttempts_checkBox.Size = new System.Drawing.Size(160, 17);
            this.user_NotifyLogonAttempts_checkBox.TabIndex = 3;
            this.user_NotifyLogonAttempts_checkBox.Text = "Notify about Logon Attempts";
            this.user_NotifyLogonAttempts_checkBox.UseVisualStyleBackColor = true;
            this.user_NotifyLogonAttempts_checkBox.CheckedChanged += new System.EventHandler(this.user_NotifyLogonAttempts_checkBox_CheckedChanged);
            // 
            // user_ChangePassword_checkBox
            // 
            this.user_ChangePassword_checkBox.AutoSize = true;
            this.user_ChangePassword_checkBox.Location = new System.Drawing.Point(16, 32);
            this.user_ChangePassword_checkBox.Name = "user_ChangePassword_checkBox";
            this.user_ChangePassword_checkBox.Size = new System.Drawing.Size(111, 17);
            this.user_ChangePassword_checkBox.TabIndex = 2;
            this.user_ChangePassword_checkBox.Text = "Change password";
            this.user_ChangePassword_checkBox.UseVisualStyleBackColor = true;
            this.user_ChangePassword_checkBox.CheckedChanged += new System.EventHandler(this.user_ChangePassword_checkBox_CheckedChanged);
            // 
            // user_Name_textBox
            // 
            this.user_Name_textBox.Location = new System.Drawing.Point(54, 10);
            this.user_Name_textBox.Name = "user_Name_textBox";
            this.user_Name_textBox.Size = new System.Drawing.Size(296, 20);
            this.user_Name_textBox.TabIndex = 1;
            this.user_Name_textBox.TextChanged += new System.EventHandler(this.user_Name_textBox_TextChanged);
            // 
            // user_Name_label
            // 
            this.user_Name_label.AutoSize = true;
            this.user_Name_label.Location = new System.Drawing.Point(13, 13);
            this.user_Name_label.Name = "user_Name_label";
            this.user_Name_label.Size = new System.Drawing.Size(35, 13);
            this.user_Name_label.TabIndex = 0;
            this.user_Name_label.Text = "Name";
            // 
            // Log_tabPage
            // 
            this.Log_tabPage.Controls.Add(this.Log_Work_checkBox);
            this.Log_tabPage.Controls.Add(this.Log_Event_checkBox);
            this.Log_tabPage.Controls.Add(this.Log_Password_checkBox);
            this.Log_tabPage.Controls.Add(this.Log_EMail_checkBox);
            this.Log_tabPage.Location = new System.Drawing.Point(4, 22);
            this.Log_tabPage.Name = "Log_tabPage";
            this.Log_tabPage.Padding = new System.Windows.Forms.Padding(3);
            this.Log_tabPage.Size = new System.Drawing.Size(595, 178);
            this.Log_tabPage.TabIndex = 2;
            this.Log_tabPage.Text = "Log";
            this.Log_tabPage.UseVisualStyleBackColor = true;
            // 
            // Log_Work_checkBox
            // 
            this.Log_Work_checkBox.AutoSize = true;
            this.Log_Work_checkBox.Location = new System.Drawing.Point(3, 75);
            this.Log_Work_checkBox.Name = "Log_Work_checkBox";
            this.Log_Work_checkBox.Size = new System.Drawing.Size(52, 17);
            this.Log_Work_checkBox.TabIndex = 3;
            this.Log_Work_checkBox.Text = "Work";
            this.Log_Work_checkBox.UseVisualStyleBackColor = true;
            this.Log_Work_checkBox.CheckedChanged += new System.EventHandler(this.Log_Work_checkBox_CheckedChanged);
            // 
            // Log_Event_checkBox
            // 
            this.Log_Event_checkBox.AutoSize = true;
            this.Log_Event_checkBox.Location = new System.Drawing.Point(3, 52);
            this.Log_Event_checkBox.Name = "Log_Event_checkBox";
            this.Log_Event_checkBox.Size = new System.Drawing.Size(78, 17);
            this.Log_Event_checkBox.TabIndex = 2;
            this.Log_Event_checkBox.Text = "Event read";
            this.Log_Event_checkBox.UseVisualStyleBackColor = true;
            this.Log_Event_checkBox.CheckedChanged += new System.EventHandler(this.Log_Event_checkBox_CheckedChanged);
            // 
            // Log_Password_checkBox
            // 
            this.Log_Password_checkBox.AutoSize = true;
            this.Log_Password_checkBox.Location = new System.Drawing.Point(3, 29);
            this.Log_Password_checkBox.Name = "Log_Password_checkBox";
            this.Log_Password_checkBox.Size = new System.Drawing.Size(114, 17);
            this.Log_Password_checkBox.TabIndex = 1;
            this.Log_Password_checkBox.Text = "Paswwrod change";
            this.Log_Password_checkBox.UseVisualStyleBackColor = true;
            this.Log_Password_checkBox.CheckedChanged += new System.EventHandler(this.Log_Password_checkBox_CheckedChanged);
            // 
            // Log_EMail_checkBox
            // 
            this.Log_EMail_checkBox.AutoSize = true;
            this.Log_EMail_checkBox.Location = new System.Drawing.Point(3, 6);
            this.Log_EMail_checkBox.Name = "Log_EMail_checkBox";
            this.Log_EMail_checkBox.Size = new System.Drawing.Size(81, 17);
            this.Log_EMail_checkBox.TabIndex = 0;
            this.Log_EMail_checkBox.Text = "E-Mail send";
            this.Log_EMail_checkBox.UseVisualStyleBackColor = true;
            this.Log_EMail_checkBox.CheckedChanged += new System.EventHandler(this.Log_EMail_checkBox_CheckedChanged);
            // 
            // EMail_ErrorRepeatSending_label
            // 
            this.EMail_ErrorRepeatSending_label.AutoSize = true;
            this.EMail_ErrorRepeatSending_label.Location = new System.Drawing.Point(5, 146);
            this.EMail_ErrorRepeatSending_label.Name = "EMail_ErrorRepeatSending_label";
            this.EMail_ErrorRepeatSending_label.Size = new System.Drawing.Size(112, 13);
            this.EMail_ErrorRepeatSending_label.TabIndex = 15;
            this.EMail_ErrorRepeatSending_label.Text = "Error Repeat Sending:";
            // 
            // EMail_ErrorRepeatSending_numericUpDown
            // 
            this.EMail_ErrorRepeatSending_numericUpDown.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.EMail_ErrorRepeatSending_numericUpDown.Location = new System.Drawing.Point(113, 144);
            this.EMail_ErrorRepeatSending_numericUpDown.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.EMail_ErrorRepeatSending_numericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EMail_ErrorRepeatSending_numericUpDown.Name = "EMail_ErrorRepeatSending_numericUpDown";
            this.EMail_ErrorRepeatSending_numericUpDown.Size = new System.Drawing.Size(64, 20);
            this.EMail_ErrorRepeatSending_numericUpDown.TabIndex = 16;
            this.EMail_ErrorRepeatSending_numericUpDown.Value = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.EMail_ErrorRepeatSending_numericUpDown.ValueChanged += new System.EventHandler(this.EMail_ErrorRepeatSending_numericUpDown_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 204);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "LogonSecurity";
            this.tabControl.ResumeLayout(false);
            this.General_tabPage.ResumeLayout(false);
            this.General_tabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordLength_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogTimer_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTimer_numericUpDown)).EndInit();
            this.EMail_groupBox.ResumeLayout(false);
            this.EMail_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EMail_Port_numericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.users_tabPage.ResumeLayout(false);
            this.Users_splitContainer.Panel1.ResumeLayout(false);
            this.Users_splitContainer.Panel2.ResumeLayout(false);
            this.Users_splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Users_splitContainer)).EndInit();
            this.Users_splitContainer.ResumeLayout(false);
            this.Log_tabPage.ResumeLayout(false);
            this.Log_tabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EMail_ErrorRepeatSending_numericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage General_tabPage;
        private System.Windows.Forms.TabPage users_tabPage;
        private System.Windows.Forms.Label LogTimer_label;
        private System.Windows.Forms.Label PasswordTimer_label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Stop_button;
        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.Button UnInstall_button;
        private System.Windows.Forms.Button Install_button;
        private System.Windows.Forms.Button IgnoreOldLogs_button;
        private System.Windows.Forms.Label PasswordChars_label;
        private System.Windows.Forms.Label PasswordLength_label;
        private System.Windows.Forms.SplitContainer Users_splitContainer;
        private System.Windows.Forms.Button users_add_button;
        private System.Windows.Forms.ListBox users_listBox;
        private System.Windows.Forms.Button users_remove_button;
        private System.Windows.Forms.Label user_Name_label;
        private System.Windows.Forms.TextBox PasswordChars_textBox;
        private System.Windows.Forms.TextBox user_Name_textBox;
        private System.Windows.Forms.CheckBox user_ChangePassword_checkBox;
        private System.Windows.Forms.CheckBox user_NotifySuccesLogon_checkBox;
        private System.Windows.Forms.CheckBox user_NotifyLogonAttempts_checkBox;
        private System.Windows.Forms.Label ServiceStartType_label;
        private System.Windows.Forms.ComboBox ServiceStartType_comboBox;
        private System.Windows.Forms.GroupBox EMail_groupBox;
        private System.Windows.Forms.TextBox EMail_Password_textBox;
        private System.Windows.Forms.TextBox EMail_Login_textBox;
        private System.Windows.Forms.TextBox EMail_Server_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown PasswordTimer_numericUpDown;
        private System.Windows.Forms.NumericUpDown LogTimer_numericUpDown;
        private System.Windows.Forms.NumericUpDown PasswordLength_numericUpDown;
        private System.Windows.Forms.Label ServiceStatus_label;
        private System.Windows.Forms.TextBox user_ToEmail_textBox;
        private System.Windows.Forms.Label user_ToEmail_label;
        private System.Windows.Forms.Button user_Test_Email_button;
        private System.Windows.Forms.CheckBox EMail_SSL_checkBox;
        private System.Windows.Forms.NumericUpDown EMail_Port_numericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EMail_Address_textBox;
        private System.Windows.Forms.TabPage Log_tabPage;
        private System.Windows.Forms.CheckBox Log_Event_checkBox;
        private System.Windows.Forms.CheckBox Log_Password_checkBox;
        private System.Windows.Forms.CheckBox Log_EMail_checkBox;
        private System.Windows.Forms.CheckBox Log_Work_checkBox;
        private System.Windows.Forms.Label EMail_ErrorRepeatSending_label;
        private System.Windows.Forms.NumericUpDown EMail_ErrorRepeatSending_numericUpDown;
    }
}

