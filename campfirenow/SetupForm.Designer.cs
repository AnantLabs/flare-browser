namespace Flare
{
    partial class SetupForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
         this.okBtn = new System.Windows.Forms.Button();
         this.cancelBtn = new System.Windows.Forms.Button();
         this.tabControl = new System.Windows.Forms.TabControl();
         this.accountTab = new System.Windows.Forms.TabPage();
         this.userDetailsGroupBox = new System.Windows.Forms.GroupBox();
         this.loggedInAs = new System.Windows.Forms.Label();
         this.loginButton = new System.Windows.Forms.Button();
         this.label = new System.Windows.Forms.Label();
         this.accountDetailsGroupBox = new System.Windows.Forms.GroupBox();
         this.accountName = new System.Windows.Forms.ComboBox();
         this.accountNameLabel = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.optionsTab = new System.Windows.Forms.TabPage();
         this.notificationWindowGroupBox = new System.Windows.Forms.GroupBox();
         this.label5 = new System.Windows.Forms.Label();
         this.notificationWindowDelayTextBox = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.nicknameGroupBox = new System.Windows.Forms.GroupBox();
         this.nickNotifications = new System.Windows.Forms.CheckBox();
         this.nicknameBox = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.startUpTabPage = new System.Windows.Forms.TabPage();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.dontQuitCheckBox = new System.Windows.Forms.CheckBox();
         this.minimiseAtStartupCheckBox = new System.Windows.Forms.CheckBox();
         this.startUpCheckbox = new System.Windows.Forms.CheckBox();
         this.tabControl.SuspendLayout();
         this.accountTab.SuspendLayout();
         this.userDetailsGroupBox.SuspendLayout();
         this.accountDetailsGroupBox.SuspendLayout();
         this.optionsTab.SuspendLayout();
         this.notificationWindowGroupBox.SuspendLayout();
         this.nicknameGroupBox.SuspendLayout();
         this.startUpTabPage.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // okBtn
         // 
         this.okBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.okBtn.Location = new System.Drawing.Point(197, 244);
         this.okBtn.Name = "okBtn";
         this.okBtn.Size = new System.Drawing.Size(75, 23);
         this.okBtn.TabIndex = 3;
         this.okBtn.Text = "OK";
         this.okBtn.UseVisualStyleBackColor = true;
         this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
         // 
         // cancelBtn
         // 
         this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.cancelBtn.Location = new System.Drawing.Point(278, 244);
         this.cancelBtn.Name = "cancelBtn";
         this.cancelBtn.Size = new System.Drawing.Size(75, 23);
         this.cancelBtn.TabIndex = 4;
         this.cancelBtn.Text = "Cancel";
         this.cancelBtn.UseVisualStyleBackColor = true;
         this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
         // 
         // tabControl
         // 
         this.tabControl.Controls.Add(this.accountTab);
         this.tabControl.Controls.Add(this.optionsTab);
         this.tabControl.Controls.Add(this.startUpTabPage);
         this.tabControl.Location = new System.Drawing.Point(4, 6);
         this.tabControl.Name = "tabControl";
         this.tabControl.SelectedIndex = 0;
         this.tabControl.Size = new System.Drawing.Size(349, 232);
         this.tabControl.TabIndex = 11;
         // 
         // accountTab
         // 
         this.accountTab.Controls.Add(this.userDetailsGroupBox);
         this.accountTab.Controls.Add(this.accountDetailsGroupBox);
         this.accountTab.Location = new System.Drawing.Point(4, 22);
         this.accountTab.Name = "accountTab";
         this.accountTab.Padding = new System.Windows.Forms.Padding(3);
         this.accountTab.Size = new System.Drawing.Size(341, 206);
         this.accountTab.TabIndex = 0;
         this.accountTab.Text = "Account";
         this.accountTab.UseVisualStyleBackColor = true;
         // 
         // userDetailsGroupBox
         // 
         this.userDetailsGroupBox.Controls.Add(this.loggedInAs);
         this.userDetailsGroupBox.Controls.Add(this.loginButton);
         this.userDetailsGroupBox.Controls.Add(this.label);
         this.userDetailsGroupBox.Location = new System.Drawing.Point(6, 6);
         this.userDetailsGroupBox.Name = "userDetailsGroupBox";
         this.userDetailsGroupBox.Size = new System.Drawing.Size(328, 69);
         this.userDetailsGroupBox.TabIndex = 15;
         this.userDetailsGroupBox.TabStop = false;
         this.userDetailsGroupBox.Text = "Your details";
         // 
         // loggedInAs
         // 
         this.loggedInAs.AutoSize = true;
         this.loggedInAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.loggedInAs.Location = new System.Drawing.Point(88, 46);
         this.loggedInAs.Name = "loggedInAs";
         this.loggedInAs.Size = new System.Drawing.Size(0, 16);
         this.loggedInAs.TabIndex = 18;
         this.loggedInAs.UseCompatibleTextRendering = true;
         // 
         // loginButton
         // 
         this.loginButton.Location = new System.Drawing.Point(10, 20);
         this.loginButton.Name = "loginButton";
         this.loginButton.Size = new System.Drawing.Size(75, 23);
         this.loginButton.TabIndex = 17;
         this.loginButton.Text = "Log In";
         this.loginButton.UseVisualStyleBackColor = true;
         this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
         // 
         // label
         // 
         this.label.AutoSize = true;
         this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label.Location = new System.Drawing.Point(10, 46);
         this.label.Name = "label";
         this.label.Size = new System.Drawing.Size(72, 17);
         this.label.TabIndex = 16;
         this.label.Text = "Logged in as:";
         this.label.UseCompatibleTextRendering = true;
         // 
         // accountDetailsGroupBox
         // 
         this.accountDetailsGroupBox.Controls.Add(this.accountName);
         this.accountDetailsGroupBox.Controls.Add(this.accountNameLabel);
         this.accountDetailsGroupBox.Controls.Add(this.label2);
         this.accountDetailsGroupBox.Location = new System.Drawing.Point(6, 81);
         this.accountDetailsGroupBox.Name = "accountDetailsGroupBox";
         this.accountDetailsGroupBox.Size = new System.Drawing.Size(328, 59);
         this.accountDetailsGroupBox.TabIndex = 14;
         this.accountDetailsGroupBox.TabStop = false;
         this.accountDetailsGroupBox.Text = "Your account";
         // 
         // accountName
         // 
         this.accountName.FormattingEnabled = true;
         this.accountName.Location = new System.Drawing.Point(93, 24);
         this.accountName.Name = "accountName";
         this.accountName.Size = new System.Drawing.Size(121, 21);
         this.accountName.TabIndex = 19;
         // 
         // accountNameLabel
         // 
         this.accountNameLabel.AutoSize = true;
         this.accountNameLabel.Location = new System.Drawing.Point(7, 27);
         this.accountNameLabel.Name = "accountNameLabel";
         this.accountNameLabel.Size = new System.Drawing.Size(82, 13);
         this.accountNameLabel.TabIndex = 18;
         this.accountNameLabel.Text = "Account name: ";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(220, 27);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(96, 17);
         this.label2.TabIndex = 16;
         this.label2.Text = ".campfirenow.com";
         this.label2.UseCompatibleTextRendering = true;
         // 
         // optionsTab
         // 
         this.optionsTab.Controls.Add(this.notificationWindowGroupBox);
         this.optionsTab.Controls.Add(this.nicknameGroupBox);
         this.optionsTab.Location = new System.Drawing.Point(4, 22);
         this.optionsTab.Name = "optionsTab";
         this.optionsTab.Padding = new System.Windows.Forms.Padding(3);
         this.optionsTab.Size = new System.Drawing.Size(341, 206);
         this.optionsTab.TabIndex = 1;
         this.optionsTab.Text = "Notifications";
         this.optionsTab.UseVisualStyleBackColor = true;
         // 
         // notificationWindowGroupBox
         // 
         this.notificationWindowGroupBox.Controls.Add(this.label5);
         this.notificationWindowGroupBox.Controls.Add(this.notificationWindowDelayTextBox);
         this.notificationWindowGroupBox.Controls.Add(this.label1);
         this.notificationWindowGroupBox.Location = new System.Drawing.Point(7, 105);
         this.notificationWindowGroupBox.Name = "notificationWindowGroupBox";
         this.notificationWindowGroupBox.Size = new System.Drawing.Size(328, 84);
         this.notificationWindowGroupBox.TabIndex = 1;
         this.notificationWindowGroupBox.TabStop = false;
         this.notificationWindowGroupBox.Text = "Notification window";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(166, 29);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(66, 17);
         this.label5.TabIndex = 13;
         this.label5.Text = "milliseconds";
         this.label5.UseCompatibleTextRendering = true;
         // 
         // notificationWindowDelayTextBox
         // 
         this.notificationWindowDelayTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.notificationWindowDelayTextBox.Location = new System.Drawing.Point(86, 26);
         this.notificationWindowDelayTextBox.Name = "notificationWindowDelayTextBox";
         this.notificationWindowDelayTextBox.Size = new System.Drawing.Size(74, 20);
         this.notificationWindowDelayTextBox.TabIndex = 12;
         this.notificationWindowDelayTextBox.Text = "1500";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(7, 29);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(61, 17);
         this.label1.TabIndex = 11;
         this.label1.Text = "Display for:";
         this.label1.UseCompatibleTextRendering = true;
         // 
         // nicknameGroupBox
         // 
         this.nicknameGroupBox.Controls.Add(this.nickNotifications);
         this.nicknameGroupBox.Controls.Add(this.nicknameBox);
         this.nicknameGroupBox.Controls.Add(this.label6);
         this.nicknameGroupBox.Location = new System.Drawing.Point(7, 7);
         this.nicknameGroupBox.Name = "nicknameGroupBox";
         this.nicknameGroupBox.Size = new System.Drawing.Size(328, 92);
         this.nicknameGroupBox.TabIndex = 0;
         this.nicknameGroupBox.TabStop = false;
         this.nicknameGroupBox.Text = "Nickname";
         // 
         // nickNotifications
         // 
         this.nickNotifications.Location = new System.Drawing.Point(86, 52);
         this.nickNotifications.Name = "nickNotifications";
         this.nickNotifications.Size = new System.Drawing.Size(189, 33);
         this.nickNotifications.TabIndex = 13;
         this.nickNotifications.Text = "Only alert me when someone uses my nickname";
         this.nickNotifications.UseVisualStyleBackColor = true;
         // 
         // nicknameBox
         // 
         this.nicknameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.nicknameBox.Location = new System.Drawing.Point(86, 26);
         this.nicknameBox.Name = "nicknameBox";
         this.nicknameBox.Size = new System.Drawing.Size(189, 20);
         this.nicknameBox.TabIndex = 12;
         this.nicknameBox.TextChanged += new System.EventHandler(this.nicknameBox_TextChanged);
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label6.Location = new System.Drawing.Point(7, 29);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(58, 17);
         this.label6.TabIndex = 11;
         this.label6.Text = "Nickname:";
         this.label6.UseCompatibleTextRendering = true;
         // 
         // startUpTabPage
         // 
         this.startUpTabPage.Controls.Add(this.groupBox1);
         this.startUpTabPage.Location = new System.Drawing.Point(4, 22);
         this.startUpTabPage.Name = "startUpTabPage";
         this.startUpTabPage.Padding = new System.Windows.Forms.Padding(3);
         this.startUpTabPage.Size = new System.Drawing.Size(341, 206);
         this.startUpTabPage.TabIndex = 2;
         this.startUpTabPage.Text = "Starting && closing Flare";
         this.startUpTabPage.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.dontQuitCheckBox);
         this.groupBox1.Controls.Add(this.minimiseAtStartupCheckBox);
         this.groupBox1.Controls.Add(this.startUpCheckbox);
         this.groupBox1.Location = new System.Drawing.Point(6, 6);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(328, 118);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Starting && closing Flare";
         // 
         // dontQuitCheckBox
         // 
         this.dontQuitCheckBox.Location = new System.Drawing.Point(6, 75);
         this.dontQuitCheckBox.Name = "dontQuitCheckBox";
         this.dontQuitCheckBox.Size = new System.Drawing.Size(316, 33);
         this.dontQuitCheckBox.TabIndex = 16;
         this.dontQuitCheckBox.Text = "Minimise Flare when I close the window (instead of quitting)";
         this.dontQuitCheckBox.UseVisualStyleBackColor = true;
         // 
         // minimiseAtStartupCheckBox
         // 
         this.minimiseAtStartupCheckBox.Location = new System.Drawing.Point(6, 47);
         this.minimiseAtStartupCheckBox.Name = "minimiseAtStartupCheckBox";
         this.minimiseAtStartupCheckBox.Size = new System.Drawing.Size(316, 33);
         this.minimiseAtStartupCheckBox.TabIndex = 15;
         this.minimiseAtStartupCheckBox.Text = "Minimise Flare to a tray icon during startup";
         this.minimiseAtStartupCheckBox.UseVisualStyleBackColor = true;
         // 
         // startUpCheckbox
         // 
         this.startUpCheckbox.Location = new System.Drawing.Point(6, 19);
         this.startUpCheckbox.Name = "startUpCheckbox";
         this.startUpCheckbox.Size = new System.Drawing.Size(316, 33);
         this.startUpCheckbox.TabIndex = 14;
         this.startUpCheckbox.Text = "Always start Flare when I login to my computer";
         this.startUpCheckbox.UseVisualStyleBackColor = true;
         // 
         // SetupForm
         // 
         this.AcceptButton = this.okBtn;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.cancelBtn;
         this.ClientSize = new System.Drawing.Size(358, 274);
         this.Controls.Add(this.tabControl);
         this.Controls.Add(this.cancelBtn);
         this.Controls.Add(this.okBtn);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SetupForm";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Settings";
         this.Load += new System.EventHandler(this.SetupForm_Load);
         this.tabControl.ResumeLayout(false);
         this.accountTab.ResumeLayout(false);
         this.userDetailsGroupBox.ResumeLayout(false);
         this.userDetailsGroupBox.PerformLayout();
         this.accountDetailsGroupBox.ResumeLayout(false);
         this.accountDetailsGroupBox.PerformLayout();
         this.optionsTab.ResumeLayout(false);
         this.notificationWindowGroupBox.ResumeLayout(false);
         this.notificationWindowGroupBox.PerformLayout();
         this.nicknameGroupBox.ResumeLayout(false);
         this.nicknameGroupBox.PerformLayout();
         this.startUpTabPage.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage accountTab;
        private System.Windows.Forms.TabPage optionsTab;
        private System.Windows.Forms.GroupBox accountDetailsGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label accountNameLabel;
        private System.Windows.Forms.GroupBox userDetailsGroupBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.GroupBox nicknameGroupBox;
        private System.Windows.Forms.CheckBox nickNotifications;
        private System.Windows.Forms.TextBox nicknameBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox notificationWindowGroupBox;
        private System.Windows.Forms.TextBox notificationWindowDelayTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage startUpTabPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox dontQuitCheckBox;
        private System.Windows.Forms.CheckBox minimiseAtStartupCheckBox;
        private System.Windows.Forms.CheckBox startUpCheckbox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.ComboBox accountName;
        private System.Windows.Forms.Label loggedInAs;
    }
}
