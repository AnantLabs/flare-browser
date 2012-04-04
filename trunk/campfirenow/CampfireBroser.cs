using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Flare
{
   delegate void TitleChangedDelegate( string title );

   abstract class CampfireBrowser : WebBrowser
   {
      public delegate void LeftRoomDelegate();
      public event LeftRoomDelegate LeftRoom;

      protected string _accessToken;

      public CampfireBrowser( string token )
      {
         Dock = DockStyle.Fill;
         _accessToken = @"?access_token=" + token;

         ScriptErrorsSuppressed = true;
         IsWebBrowserContextMenuEnabled = false;
      }          

      public event TitleChangedDelegate TitleChanged;

      protected void OnTitleChanged(string title)
      {
         if (TitleChanged != null)
         {
            TitleChanged(title);
         }
      }

      protected void OnLeftRoom()
      {
         if (LeftRoom != null)
         {
            LeftRoom();
         }
      }

      public virtual void TabSelected()
      {
      }

      public virtual void LeaveRoom()
      {
      }

      protected override void OnNewWindow(System.ComponentModel.CancelEventArgs e)
      {
         e.Cancel = true;
         if (StatusText.EndsWith("/login"))
         {
            Utility.LaunchWebPage(StatusText);
         }
      }

      protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
      {
         base.OnDocumentCompleted(e);

         if (Document.GetElementById("header") != null)
            Document.GetElementById("header").Style = "display: none;";
         if (Document.GetElementById("launchbar") != null)
            Document.GetElementById("launchbar").Style = "display: none;";
         if (Document.GetElementById("open_bar") != null)
            Document.GetElementById("open_bar").Style = "display: none;";
         if (Document.GetElementById("sidebar") != null)
            Document.GetElementById("sidebar").Style = "top: 5px;";

         Navigating -= OnNavigating;
         Navigating += OnNavigating;
      }

      protected abstract void OnNavigating(object sender, WebBrowserNavigatingEventArgs e);
   }
}
