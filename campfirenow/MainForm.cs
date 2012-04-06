using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Resources;
using System.Windows.Forms;
using Flare.Properties;

namespace Flare
{
   public partial class MainForm : Form
   {
      private Boolean isInStartUpMode;

      private bool forcedShutdown;

      public MainForm(string[] args)
      {
         InitializeComponent();

         isInStartUpMode = (args.Length > 0 && args[0] == "-startup");
      }

      public Account Account
      {
         get;
         private set;
      }

      public String ProgressLabelText { get; set; }

      protected override void OnLoad(EventArgs e)
      {
         autoUpdater.TryUpdate();

         Startup();

         if (isInStartUpMode && Account.User.MinimiseDuringStartup)
         {
            isInStartUpMode = false;
            Minimise();
         }

         base.OnLoad(e);
      }

      private void Startup()
      {
         try
         {
            Account = Account.FromRegistry();

            if (Account == null || string.IsNullOrEmpty(Account.User.Token))
            {
               // Show the modal dialog to fill these details
               var setupForm = new SetupForm();
               setupForm.ShowDialog();

               // Try again to retreive the details from the registry
               Account = Account.FromRegistry();
            }
            else
            {
               var newCredential = OAuthWindow.RefreshCredential(Account.User.RefreshToken);

               Account.User.Token = newCredential.OauthToken;
               Account.User.RefreshToken = newCredential.RefreshToken;

               Account.Save();
            }

            // If the account is still null, the user cancelled the dialog, the expected behaviour here is to quit
            if (Account == null)
            {
               Application.Exit();
               return;
            }
            else
            {
               showMessageNotificationToolStripMenuItem.Checked = Account.User.ShowMessageNotifications;

               // Does the user use a proxy server?
               IWebProxy proxy = WebRequest.DefaultWebProxy;
               if (!proxy.IsBypassed(new Uri(Account.CampfireUrl)))
               {
                  autoUpdater.ProxyEnabled = true;
                  autoUpdater.ProxyUrl = proxy.GetProxy(new Uri(Account.CampfireUrl)).AbsoluteUri;
               }

               Text = string.Format("{0} - Flare", Account.Name);

               LoadLobby();

               foreach (string roomName in Account.User.RoomNames)
               {
                  OpenRoom(roomName);
               }
            }
         }
         catch (Exception err)
         {
            FlareException.ShowFriendly(err);
         }
      }

      private List<TabPage> FindTabs<T>()
         where T : class
      {
         var tabs = new List<TabPage>();

         foreach (TabPage tab in tabControl.TabPages)
         {
            if (tab.Controls[0] is T)
            {
               tabs.Add(tab);
            }
         }

         return tabs;
      }

      private void UpdateRoomList(List<Room> rooms)
      {
         roomsToolStripMenuItem.DropDownItems.Clear();

         Keys key = Keys.D1;

         foreach (var room in rooms)
         {
            var newToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem.Tag = room.Id;
            newToolStripMenuItem.Text = room.Name;
            newToolStripMenuItem.Click += RoomMenuStripClicked;
            newToolStripMenuItem.ShortcutKeys = ((Keys)((Keys.Control | key++)));
            roomsToolStripMenuItem.DropDownItems.Add(newToolStripMenuItem);
         }

         roomsToolStripMenuItem.Visible = true;
      }

      private void RoomMenuStripClicked(object sender, EventArgs e)
      {
         string id = (string)((ToolStripMenuItem)sender).Tag;

         OpenRoom(id);
      }

      private void LoadLobby()
      {
         var lobby = new LobbyBrowser(Account.CampfireUrl, Account.User.Token);
         lobby.RoomsChanged += UpdateRoomList;
         lobby.OpenRoom += OpenRoom;

         AddTab(lobby, "Opening the lobby...");
      }

      private TabPage FindRoom(string roomNumber)
      {
         var rooms = FindTabs<RoomBrowser>();

         foreach (var roomTab in rooms)
         {
            var roomBrowser = (RoomBrowser)roomTab.Controls[0];

            if (roomBrowser.RoomNumber == roomNumber)
            {
               return roomTab;
            }
         }

         return null;
      }

      private void OpenRoom(string roomNumber)
      {
         var roomTab = FindRoom(roomNumber);

         if (roomTab == null)
         {
            var room = new RoomBrowser(Account.CampfireUrl, roomNumber, Account.User.Token);
            room.OnSearch += OpenSearch;
            room.OpenTranscripts += OpenTranscripts;
            room.MessageRecieved += MessageRecieved;

            AddTab(room, "Joining the room...");

            SaveOpenRooms();
         }
         else
         {
            tabControl.SelectedTab = roomTab;
         }
      }

      private void OpenSearch(string term)
      {
         var tabs = FindTabs<SearchBrowser>();

         if (tabs.Count == 0)
         {
            var room = new SearchBrowser(Account.CampfireUrl, term, Account.User.Token);
            room.OpenTranscription += OpenTranscription;
            room.OpenTranscripts += OpenTranscripts;

            AddTab(room, "Searching " + term + "...");
         }
         else
         {
            tabControl.SelectedTab = tabs[0];

            var control = tabs[0].Controls[0];

            ((SearchBrowser)control).Search(term);
         }
      }

      private void OpenTranscripts()
      {
         var tabs = FindTabs<TranscriptsBrowser>();

         if (tabs.Count == 0)
         {
            var room = new TranscriptsBrowser(Account.CampfireUrl, Account.User.Token);
            room.OnSearch += OpenSearch;
            room.OpenTranscription += OpenTranscription;

            AddTab(room, "Opening Transcripts ...");
         }
         else
         {
            tabControl.SelectedTab = tabs[0];
         }
      }

      private void OpenTranscription(string url)
      {
         var room = new TranscriptBrowser(url, Account.User.Token);

         AddTab(room, "Opening Transcript ...");
      }

      private void AddTab(CampfireBrowser browser, string loading)
      {
         loadingCover.Visible = true;
         browser.DocumentCompleted += (sender, e) => loadingCover.Visible = false;

         var newTabPage = new TabPage();
         newTabPage.Text = loading;
         newTabPage.UseVisualStyleBackColor = true;

         newTabPage.Controls.Add(browser);
         browser.LeftRoom += () => CloseTab(newTabPage);

         tabControl.TabPages.Add(newTabPage);
         tabControl.SelectedTab = newTabPage;

         browser.TitleChanged += title => newTabPage.Text = title;
      }

      private void MessageRecieved(RoomBrowser browser, Message message)
      {
         if (SelectedBrowser != browser)
         {
            var notifyForm = new NotifyForm(browser.Parent.Text, message, this);

            notifyForm.ShowInactiveTopmost();
         }

         if (!Focused)
         {
            var resources = new ResourceManager(typeof(Resources));

            notifyIcon.Icon = ((Icon)(resources.GetObject("newMsg")));

            Interop.FlashWindow(this);
         }
      }

      protected override void OnClosed(EventArgs e)
      {
         Application.Exit();
         base.OnClosed(e);
      }

      private void SaveOpenRooms()
      {
         Account.User.RoomNames = new List<string>();
         foreach (TabPage tabPage in tabControl.TabPages)
         {
            if (tabPage.Controls[0] is RoomBrowser)
            {
               var browser = (RoomBrowser)tabPage.Controls[0];
               Account.User.RoomNames.Add(browser.RoomNumber);
            }
         }
         Account.Save();
      }

      private void changeSettingsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var setupForm = new SetupForm();
         setupForm.ShowDialog();

         // if anything was changed, reload the page
         if (SettingsChanged(setupForm))
         {
            Account.User.RoomNames.Clear();

            Account.Save();

            int tabCount = tabControl.TabPages.Count;
            for (int i = 0; i < tabCount; i++)
            {
               tabControl.TabPages.RemoveAt(0);
            }
            Startup();
         }
      }

      private bool SettingsChanged(SetupForm setupForm)
      {
         return setupForm.NewAccountName != Account.Name ||
                      setupForm.NewToken != Account.User.Token ||
                      setupForm.NewNickname != Account.User.Nickname ||
                      setupForm.NewNotifyOnlyWhenNicknameIsFound != Account.User.NotifyOnlyWhenNicknameIsFound ||
                      setupForm.NewNotifyWindowDelay != Account.User.NotifyWindowDelay ||
                      setupForm.MinimiseInsteadOfQuitting != Account.User.MinimiseInsteadOfQuitting;
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         forcedShutdown = true;
         Application.Exit();
      }

      protected override void OnResize(EventArgs e)
      {
         // if the form has been resized to minimize the hide the form
         if (WindowState == FormWindowState.Minimized && Environment.OSVersion.Version.Major < 6)
            Minimise();

         base.OnResize(e);
      }

      private void Minimise()
      {
         Hide();
         notifyIcon.Visible = true;
         notifyIcon.Text = Text;
      }

      private void notifyIcon_DoubleClick(object sender, EventArgs e)
      {
         ShowFormHideIcon();
      }

      public void ShowFormHideIcon()
      {
         Show();
         WindowState = FormWindowState.Normal;
         notifyIcon.Visible = false;
         TopMost = true;
         TopMost = false;
      }

      private void showMessageNotificationToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Account.User.ShowMessageNotifications = showMessageNotificationToolStripMenuItem.Checked;
         Account.Save();
      }

      private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         MessageBox.Show("Flare\nv" + Application.ProductVersion + "\n\nMatt Brindley\nhttp://mattbrindley.com/",
                         "Flare", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }

      private void CloseBtn_Click(object sender, EventArgs e)
      {
         Application.Exit();
      }

      private void OpenBtn_Click(object sender, EventArgs e)
      {
         ShowFormHideIcon();
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

      protected override void OnDragDrop(DragEventArgs drgevent)
      {
         var files = (string[])drgevent.Data.GetData(DataFormats.FileDrop);
         // Upload file
         base.OnDragDrop(drgevent);
      }

      protected override void OnDragEnter(DragEventArgs drgevent)
      {
         drgevent.Effect = DragDropEffects.Copy;
         base.OnDragEnter(drgevent);
      }

      private CampfireBrowser SelectedBrowser
      {
         get
         {
            var tabPage = tabControl.SelectedTab;
            return ((CampfireBrowser)tabPage.Controls[0]);
         }
      }

      private void tabPageCloseBtn_Click(object sender, EventArgs e)
      {
         CloseTab(tabControl.SelectedTab);
         SelectedBrowser.LeaveRoom();
      }

      private void CloseTab(TabPage tabPage)
      {
         tabControl.TabPages.Remove(tabPage);
         SaveOpenRooms();
      }

      private void filesTranscriptsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OpenTranscripts();
      }

      private void membersToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Utility.LaunchWebPage(Account.CampfireUrl + @"account/people");
      }

      private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
      {
         Utility.LaunchWebPage(Account.CampfireUrl + @"account/settingsW");
      }

      private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
      {
         RefreshSelectedTab();
      }

      protected override void OnActivated(EventArgs e)
      {
         var resources = new ResourceManager(typeof(Resources));
         notifyIcon.Icon = ((Icon)(resources.GetObject("noNewMsgs")));

         RefreshSelectedTab();
         base.OnActivated(e);
      }

      private void RefreshSelectedTab()
      {
         if (tabControl.TabCount != 0)
         {
            tabPageCloseBtn.Enabled = (tabControl.SelectedIndex != 0);
            SelectedBrowser.TabSelected();
         }
      }

      protected override void OnClosing(CancelEventArgs e)
      {
         if (!forcedShutdown && Account.User.MinimiseInsteadOfQuitting)
         {
            if (Environment.OSVersion.Version.Major < 6)    // if we're not on Vista or above:
               Minimise();
            else
               WindowState = FormWindowState.Minimized;
            e.Cancel = true;
         }

         base.OnClosing(e);
      }

      private void makeADonationToFlareToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=ADLAU6DWJQVRY");
      }
   }
}