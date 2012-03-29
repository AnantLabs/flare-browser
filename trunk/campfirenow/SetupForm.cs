using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using Flare.CampfireModels;

namespace Flare
{
   public partial class SetupDialog : Form
   {
      private Settings _settings;

      public SetupDialog(Settings settings)
      {
         _settings = settings;

         InitializeComponent();

         AcceptButton = _okButton;
         CancelButton = _cancelButton;
      }

      private void OkClicked(object sender, EventArgs e)
      {
         // Validation
         Int32 notifyWindowDelay;
         if (!Int32.TryParse(_notificationWindowDelayTextBox.Text, out notifyWindowDelay))
         {
            MessageBox.Show("The value you've entered for how long the notification window should display for isn't a whole number.\n\nPlease enter a whole number.",
                "Unable to save new notification window settings",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }

         _settings.User.Nickname = _nicknameTextBox.Text;

         _settings.MinimiseDuringStartup = _minimiseFlareOnStartupCheckBox.Checked;
         _settings.MinimiseInsteadOfQuitting = _minimizeFlareWhenUserClosesWindowCheckBox.Checked;
         _settings.NotifyOnlyWhenNicknameIsFound = _alertOnNicknameCheckBox.Checked;
         _settings.NotifyWindowDelay = notifyWindowDelay;

         _settings.Save();

         SetStartupSituation(_startFlareOnStartUpCheckbox.Checked);

         DialogResult = DialogResult.OK;
      }

      private void CancelClicked(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
      }

      private void OnLoaded(object sender, EventArgs e)
      {
         RefreshUsernameAndNickname();
         _notificationWindowDelayTextBox.Text = _settings.NotifyWindowDelay.ToString();
         _alertOnNicknameCheckBox.Checked = _settings.NotifyOnlyWhenNicknameIsFound;
         _minimiseFlareOnStartupCheckBox.Checked = _settings.MinimiseDuringStartup;
         _startFlareOnStartUpCheckbox.Checked = GetStartupSituation();
         _minimizeFlareWhenUserClosesWindowCheckBox.Checked = _settings.MinimiseInsteadOfQuitting;
      }

      private void RefreshUsernameAndNickname()
      {
         if (string.IsNullOrEmpty(_settings.User.Token))
         {
            _loggedInAs.Text = @"Please log in";
         }
         else
         {
            _loggedInAs.Text = string.Format(@"Logged in as: {0}", _settings.User.Username);
            _nicknameTextBox.Text = _settings.User.Nickname;
         }
      }

      private static bool GetStartupSituation()
      {
         // If the user has an entry in the startup directory
         var runKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
         if (!string.IsNullOrEmpty(runKey.GetValue("Flare", string.Empty).ToString())) return true;

         // Or the user has an entry in the startup registry entry
         var startupShortcut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Microsoft\Windows\Start Menu\Programs\Startup\Flare.lnk");
         if (File.Exists(startupShortcut)) return true;

         startupShortcut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Flare.lnk");
         if (File.Exists(startupShortcut)) return true;

         return false;
      }

      private static void SetStartupSituation(bool startup)
      {
         var runKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
         if (startup)
            runKey.SetValue("Flare", Application.ExecutablePath);
         else if (runKey.GetValue("Flare", null) != null)
            runKey.DeleteValue("Flare");

         // Delete the older method of starting up if it's there
         var startupShortcut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "Flare.lnk");
         if (File.Exists(startupShortcut))
            File.Delete(startupShortcut);

         startupShortcut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"Microsoft\Windows\Start Menu\Programs\Startup\Flare.lnk");
         if (File.Exists(startupShortcut))
            File.Delete(startupShortcut);
      }

      private void _loginButton_Click(object sender, EventArgs e)
      {
         var credentials = CampfireApiNet.CampfireLogin.OauthLogin(Constants.AuthId, Constants.AuthRedirectUrl);

         if (credentials != null)
         {
            _settings.User.Token = credentials.OauthToken;
            _settings.User.RefreshToken = credentials.RefreshToken;

            var authorization = CampfireApiNet.CampfireLogin.GetAuthorization(credentials);
            _settings.User.Username = authorization.Identity.EmailAddress;

            RefreshUsernameAndNickname();
         }
      }
   }
}