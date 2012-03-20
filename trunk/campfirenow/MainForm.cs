using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Win32;
using Flare.CampfireModels;

namespace Flare
{
   public partial class MainForm : Form
   {
      // TODO LIST
      /*
       * Flash icon for new messages
       * Display Notifications when messages come in
       * When User selects tab, focus the input box
       * 
       */

      public MainForm(string[] args)
      {
         InitializeComponent();

         // isInStartUpMode = (args.Length > 0 && args[0] == "-startup");
      }

      public Settings Settings
      {
         get;
         set;
      }

      public String ProgressLabelText { get; set; }

      private void MainForm_Load(object sender, EventArgs e)
      {
         Startup();

         if (Settings.MinimiseDuringStartup)
            WindowState = FormWindowState.Minimized;

         autoUpdater.TryUpdate();
      }

      private void Startup()
      {
         try
         {
            Settings = Settings.FromRegistry();

            if (Settings == null)
            {
               Settings = new Settings();

               // Show the modal dialog to fill these details
               var setupForm = new SetupDialog(Settings);
               if (setupForm.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
               {
                  Application.Exit();
               }
            }

            _fileNotificationsCheckboxMenuItem.Checked = Settings.ShowMessageNotifications;

            // Does the user use a proxy server?
            //IWebProxy proxy = WebRequest.DefaultWebProxy;
            //if ( !proxy.IsBypassed( Account.CampfireUri ) )
            //{
            //   autoUpdater.ProxyEnabled = true;
            //   autoUpdater.ProxyURL = proxy.GetProxy( Account.CampfireUri ).AbsoluteUri;
            //}

            Text = string.Format( "{0} - Flare", Settings.User.Username );

            // TODO Load the Lobby
         }
         catch (Exception err)
         {
            FlareException.ShowFriendly(err);
         }
      }

      private void SaveOpenRooms()
      {
         Settings.Save();
      }

      private void changeSettingsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var setupForm = new SetupDialog(Settings);

         // if anything was changed, reload the page
         if (setupForm.ShowDialog() == DialogResult.OK)
         {
            for (int i = 1; i < tabControl.TabPages.Count; i++)
            {
               tabControl.TabPages.RemoveAt(i);
               i--;
            }
            Startup();
         }
      }

      private void MainForm_Resize(object sender, EventArgs e)
      {
         // if the form has been resized to minimize the hide the form
         if (WindowState == FormWindowState.Minimized && Environment.OSVersion.Version.Major < 6)
            Minimise();
      }

      private void Minimise()
      {
         Hide();
         notifyIcon.Visible = true;
         notifyIcon.Text = Text;
      }

      private void notifyIcon_DoubleClick(object sender, EventArgs e)
      {
         ShowWindow();
      }

      public void ShowWindow()
      {
         Show();
         WindowState = FormWindowState.Normal;
         notifyIcon.Visible = false;
         TopMost = true;
         TopMost = false;
      }

      private void showMessageNotificationToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Settings.ShowMessageNotifications = !_fileNotificationsCheckboxMenuItem.Checked;

         Settings.Save();
      }

      private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         MessageBox.Show("Flare\nv" + Application.ProductVersion + "\n\nMatt Brindley\nhttp://mattbrindley.com/",
                         "Flare", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      private void OpenBtn_Click(object sender, EventArgs e)
      {
         ShowWindow();
      }

      private void onlineSupportForumsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Process.Start("http://code.google.com/p/flare-browser/issues/list");
      }

      private void AutoUpdaterOnAutoUpdateComplete()
      {
         MessageBox.Show(
             "Flare has been updated and needs to very quickly restart itself.\n\nPress OK to restart Flare.");
      }

      private void MainForm_DragDrop(object sender, DragEventArgs e)
      {

      }

      private void MainForm_DragEnter(object sender, DragEventArgs e)
      {
         e.Effect = DragDropEffects.Copy;
      }

      private void MainForm_DragLeave(object sender, EventArgs e)
      {

      }

      private void MainForm_DragOver(object sender, DragEventArgs e)
      {

      }

      private void tabPageCloseBtn_Click(object sender, EventArgs e)
      {
         var tabPage = tabControl.SelectedTab;
         tabControl.TabPages.Remove(tabPage);
         SaveOpenRooms();
      }

      private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
      {

      }

      private void MainForm_Activated(object sender, EventArgs e)
      {

      }

      private void makeADonationToFlareToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=ADLAU6DWJQVRY");
      }

      private bool _userWantsToQuit;

      private void exitToolStripMenuItem_Click( object sender, EventArgs e )
      {
         UserWantsToQuit();
      }

      private void CloseBtn_Click( object sender, EventArgs e )
      {
         UserWantsToQuit();
      }

      private void UserWantsToQuit()
      {
         _userWantsToQuit = true;
         Application.Exit();
      }

      private void MainForm_FormClosing( object sender, FormClosingEventArgs e )
      {
         if ( !_userWantsToQuit && Settings.MinimiseInsteadOfQuitting )
         {
            if ( Environment.OSVersion.Version.Major < 6 )    // if we're not on Vista or above:
               Minimise();
            else
               WindowState = FormWindowState.Minimized;
            e.Cancel = true;
         }
      }
   }
}