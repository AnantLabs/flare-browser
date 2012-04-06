using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Flare
{
   public partial class SetupForm : Form
   {
      private Account account;
      private bool nicknameHasBeenManuallySet;

      public SetupForm()
      {
         InitializeComponent();
      }

      public String NewAccountName { get; set; }
      public String NewNickname { get; set; }
      public String NewToken { get; set; }
      public String NewRefreshToken { get; set; }
      public bool NewNotifyOnlyWhenNicknameIsFound { get; set; }
      public Int32 NewNotifyWindowDelay { get; set; }
      public bool MinimiseInsteadOfQuitting { get; set; }

      private void okBtn_Click(object sender, EventArgs e)
      {
         // Validation
         Int32 notifyWindowDelay;
         if (!Int32.TryParse(notificationWindowDelayTextBox.Text, out notifyWindowDelay))
         {
            MessageBox.Show("The value you've entered for how long the notification window should display for isn't a whole number.\n\nPlease enter a whole number.",
                "Unable to save new notification window settings",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
         }

         if (string.IsNullOrEmpty(NewAccountName))
         {
            MessageBox.Show("An account must be selected");
            return;
         }
         else if (string.IsNullOrEmpty(NewToken))
         {
            MessageBox.Show("You must login to continue");
            return;
         }

         account.Name = accountName.Text;

         if (account.User == null)
            account.User = new User();

         account.User.MinimiseDuringStartup = minimiseAtStartupCheckBox.Checked;
         account.User.MinimiseInsteadOfQuitting = dontQuitCheckBox.Checked;
         account.User.Username = loggedInAs.Text;
         if (nicknameHasBeenManuallySet)
         {
            account.User.Nickname = nicknameBox.Text;
         }
         
         account.User.NotifyOnlyWhenNicknameIsFound = nickNotifications.Checked;
         account.User.NotifyWindowDelay = notifyWindowDelay;
         account.User.Token = NewToken;
         account.User.RefreshToken = NewRefreshToken;

         account.Save();

         NewAccountName = accountName.Text;
         NewNickname = nicknameBox.Text;
         NewNotifyOnlyWhenNicknameIsFound = nickNotifications.Checked;
         NewNotifyWindowDelay = notifyWindowDelay;
         MinimiseInsteadOfQuitting = account.User.MinimiseInsteadOfQuitting;

         SetStartupSituation(startUpCheckbox.Checked);

         Close();
      }

      private void cancelBtn_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void SetupForm_Load(object sender, EventArgs e)
      {
         account = Account.FromRegistry();

         if (account == null)
         {
            account = new Account();
         }

         accountName.Text = account.Name;
         loggedInAs.Text = account.User.Username;
         nicknameBox.Text = account.User.Nickname;
         notificationWindowDelayTextBox.Text = account.User.NotifyWindowDelay.ToString();
         nickNotifications.Checked = account.User.NotifyOnlyWhenNicknameIsFound;
         minimiseAtStartupCheckBox.Checked = account.User.MinimiseDuringStartup;
         startUpCheckbox.Checked = GetStartupSituation();
         dontQuitCheckBox.Checked = account.User.MinimiseInsteadOfQuitting;

         NewToken = account.User.Token;
         NewAccountName = accountName.Text;
         NewNickname = nicknameBox.Text;
         NewNotifyOnlyWhenNicknameIsFound = nickNotifications.Checked;

         try
         {
            RefreshAuthorization(NewToken);
         }
         catch
         {
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

      private void nicknameBox_TextChanged(object sender, EventArgs e)
      {
         nicknameHasBeenManuallySet = true;
      }

      private void loginButton_Click(object sender, EventArgs e)
      {
         var credential = OAuthWindow.OauthLogin();

         if (credential != null)
         {
            NewToken = credential.OauthToken;
            NewRefreshToken = credential.RefreshToken;

            RefreshAuthorization(NewToken);
         }
      }

      private void RefreshAuthorization( string token )
      {
         var auth = OAuthWindow.GetAuthorization(token);

         accountName.Items.Clear();

         foreach (var oauthAccount in auth.Accounts)
         {
            if (oauthAccount.Product == "campfire")
            {
               accountName.Items.Add(oauthAccount.AccountName());
            }
         }

         if (!accountName.Items.Contains(NewAccountName))
         {
            accountName.Text = @"";
         }

         loggedInAs.Text = auth.Identity.EmailAddress;
         account.User.Username = auth.Identity.EmailAddress;
      }
   }
}