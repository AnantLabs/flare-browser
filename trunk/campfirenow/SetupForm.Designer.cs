namespace Flare
{
    partial class SetupDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupDialog));
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this.tabControl = new System.Windows.Forms.TabControl();
         this.accountTab = new System.Windows.Forms.TabPage();
         this.optionsTab = new System.Windows.Forms.TabPage();
         this.notificationWindowGroupBox = new System.Windows.Forms.GroupBox();
         this.label5 = new System.Windows.Forms.Label();
         this._notificationWindowDelayTextBox = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.nicknameGroupBox = new System.Windows.Forms.GroupBox();
         this._alertOnNicknameCheckBox = new System.Windows.Forms.CheckBox();
         this._nicknameTextBox = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.startUpTabPage = new System.Windows.Forms.TabPage();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._minimizeFlareWhenUserClosesWindowCheckBox = new System.Windows.Forms.CheckBox();
         this._minimiseFlareOnStartupCheckBox = new System.Windows.Forms.CheckBox();
         this._startFlareOnStartUpCheckbox = new System.Windows.Forms.CheckBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._loginButton = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.tabControl.SuspendLayout();
         this.accountTab.SuspendLayout();
         this.optionsTab.SuspendLayout();
         this.notificationWindowGroupBox.SuspendLayout();
         this.nicknameGroupBox.SuspendLayout();
         this.startUpTabPage.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._okButton.Location = new System.Drawing.Point(197, 244);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 3;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this.OkClicked);
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._cancelButton.Location = new System.Drawing.Point(278, 244);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 4;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         this._cancelButton.Click += new System.EventHandler(this.CancelClicked);
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
         this.accountTab.Controls.Add(this.groupBox2);
         this.accountTab.Location = new System.Drawing.Point(4, 22);
         this.accountTab.Name = "accountTab";
         this.accountTab.Padding = new System.Windows.Forms.Padding(3);
         this.accountTab.Size = new System.Drawing.Size(341, 206);
         this.accountTab.TabIndex = 0;
         this.accountTab.Text = "Account";
         this.accountTab.UseVisualStyleBackColor = true;
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
         this.notificationWindowGroupBox.Controls.Add(this._notificationWindowDelayTextBox);
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
         // _notificationWindowDelayTextBox
         // 
         this._notificationWindowDelayTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._notificationWindowDelayTextBox.Location = new System.Drawing.Point(86, 26);
         this._notificationWindowDelayTextBox.Name = "_notificationWindowDelayTextBox";
         this._notificationWindowDelayTextBox.Size = new System.Drawing.Size(74, 20);
         this._notificationWindowDelayTextBox.TabIndex = 12;
         this._notificationWindowDelayTextBox.Text = "1500";
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
         this.nicknameGroupBox.Controls.Add(this._alertOnNicknameCheckBox);
         this.nicknameGroupBox.Controls.Add(this._nicknameTextBox);
         this.nicknameGroupBox.Controls.Add(this.label6);
         this.nicknameGroupBox.Location = new System.Drawing.Point(7, 7);
         this.nicknameGroupBox.Name = "nicknameGroupBox";
         this.nicknameGroupBox.Size = new System.Drawing.Size(328, 92);
         this.nicknameGroupBox.TabIndex = 0;
         this.nicknameGroupBox.TabStop = false;
         this.nicknameGroupBox.Text = "Nickname";
         // 
         // _alertOnNicknameCheckBox
         // 
         this._alertOnNicknameCheckBox.Location = new System.Drawing.Point(86, 52);
         this._alertOnNicknameCheckBox.Name = "_alertOnNicknameCheckBox";
         this._alertOnNicknameCheckBox.Size = new System.Drawing.Size(189, 33);
         this._alertOnNicknameCheckBox.TabIndex = 13;
         this._alertOnNicknameCheckBox.Text = "Only alert me when someone uses my nickname";
         this._alertOnNicknameCheckBox.UseVisualStyleBackColor = true;
         // 
         // _nicknameTextBox
         // 
         this._nicknameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._nicknameTextBox.Location = new System.Drawing.Point(86, 26);
         this._nicknameTextBox.Name = "_nicknameTextBox";
         this._nicknameTextBox.Size = new System.Drawing.Size(189, 20);
         this._nicknameTextBox.TabIndex = 12;
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
         this.groupBox1.Controls.Add(this._minimizeFlareWhenUserClosesWindowCheckBox);
         this.groupBox1.Controls.Add(this._minimiseFlareOnStartupCheckBox);
         this.groupBox1.Controls.Add(this._startFlareOnStartUpCheckbox);
         this.groupBox1.Location = new System.Drawing.Point(6, 6);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(328, 118);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Starting && closing Flare";
         // 
         // _minimizeFlareWhenUserClosesWindowCheckBox
         // 
         this._minimizeFlareWhenUserClosesWindowCheckBox.Location = new System.Drawing.Point(6, 75);
         this._minimizeFlareWhenUserClosesWindowCheckBox.Name = "_minimizeFlareWhenUserClosesWindowCheckBox";
         this._minimizeFlareWhenUserClosesWindowCheckBox.Size = new System.Drawing.Size(316, 33);
         this._minimizeFlareWhenUserClosesWindowCheckBox.TabIndex = 16;
         this._minimizeFlareWhenUserClosesWindowCheckBox.Text = "Minimise Flare when I close the window (instead of quitting)";
         this._minimizeFlareWhenUserClosesWindowCheckBox.UseVisualStyleBackColor = true;
         // 
         // _minimiseFlareOnStartupCheckBox
         // 
         this._minimiseFlareOnStartupCheckBox.Location = new System.Drawing.Point(6, 47);
         this._minimiseFlareOnStartupCheckBox.Name = "_minimiseFlareOnStartupCheckBox";
         this._minimiseFlareOnStartupCheckBox.Size = new System.Drawing.Size(316, 33);
         this._minimiseFlareOnStartupCheckBox.TabIndex = 15;
         this._minimiseFlareOnStartupCheckBox.Text = "Minimise Flare to a tray icon during startup";
         this._minimiseFlareOnStartupCheckBox.UseVisualStyleBackColor = true;
         // 
         // _startFlareOnStartUpCheckbox
         // 
         this._startFlareOnStartUpCheckbox.Location = new System.Drawing.Point(6, 19);
         this._startFlareOnStartUpCheckbox.Name = "_startFlareOnStartUpCheckbox";
         this._startFlareOnStartUpCheckbox.Size = new System.Drawing.Size(316, 33);
         this._startFlareOnStartUpCheckbox.TabIndex = 14;
         this._startFlareOnStartUpCheckbox.Text = "Always start Flare when I login to my computer";
         this._startFlareOnStartUpCheckbox.UseVisualStyleBackColor = true;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.label2);
         this.groupBox2.Controls.Add(this._loginButton);
         this.groupBox2.Location = new System.Drawing.Point(3, 6);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(335, 52);
         this.groupBox2.TabIndex = 1;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Login";
         // 
         // _loginButton
         // 
         this._loginButton.Location = new System.Drawing.Point(6, 19);
         this._loginButton.Name = "_loginButton";
         this._loginButton.Size = new System.Drawing.Size(75, 23);
         this._loginButton.TabIndex = 0;
         this._loginButton.Text = "Log In";
         this._loginButton.UseVisualStyleBackColor = true;
         this._loginButton.Click += new System.EventHandler(this._loginButton_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(87, 24);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(85, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Logged in as {0}";
         // 
         // SetupDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(358, 274);
         this.Controls.Add(this.tabControl);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SetupDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Settings";
         this.Load += new System.EventHandler(this.OnLoaded);
         this.tabControl.ResumeLayout(false);
         this.accountTab.ResumeLayout(false);
         this.optionsTab.ResumeLayout(false);
         this.notificationWindowGroupBox.ResumeLayout(false);
         this.notificationWindowGroupBox.PerformLayout();
         this.nicknameGroupBox.ResumeLayout(false);
         this.nicknameGroupBox.PerformLayout();
         this.startUpTabPage.ResumeLayout(false);
         this.groupBox1.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage accountTab;
        private System.Windows.Forms.TabPage optionsTab;
        private System.Windows.Forms.GroupBox nicknameGroupBox;
        private System.Windows.Forms.CheckBox _alertOnNicknameCheckBox;
        private System.Windows.Forms.TextBox _nicknameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox notificationWindowGroupBox;
        private System.Windows.Forms.TextBox _notificationWindowDelayTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage startUpTabPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox _minimizeFlareWhenUserClosesWindowCheckBox;
        private System.Windows.Forms.CheckBox _minimiseFlareOnStartupCheckBox;
        private System.Windows.Forms.CheckBox _startFlareOnStartUpCheckbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _loginButton;
    }
}
