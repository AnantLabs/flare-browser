using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using MSHTML;

namespace Flare
{   
   class LobbyBrowser : CampfireBrowser
   {
      public delegate void OpenRoomDelegate(string roomNumber);
      public delegate void RoomsChangedDelegate(List<Room> rooms);

      public event OpenRoomDelegate OpenRoom;
      public event RoomsChangedDelegate RoomsChanged;

      private Timer _timer = new Timer();

      public LobbyBrowser(string url, string accessToken) : base (accessToken )
      {
         Url = new Uri(url + _accessToken);
      }

      protected override void OnDocumentCompleted( WebBrowserDocumentCompletedEventArgs e)
      {
         OnTitleChanged("Lobby");

         FixCreateRoomForm();

         UpdateRoomList();

         base.OnDocumentCompleted( e );
      }

      public override void TabSelected()
      {
         UpdateRoomList();

         base.TabSelected();
      }

      private void FixCreateRoomForm()
      {
         var createRoomFormElement = Document.GetElementById("new_room_form");

         createRoomFormElement.OuterHtml = createRoomFormElement.OuterHtml.Replace("?from=lobby", "?from=lobby" + _accessToken.Replace("?", "&"));
      }

      private void UpdateRoomList()
      {
         var regex = new Regex(@"/room/(?<id>\d+)""\>(?<name>.*?)\<");

         var matches = regex.Matches(DocumentText);

         var rooms = new List<Room>();

         foreach (Match match in matches)
         {
            rooms.Add(new Room(match.Groups["id"].Value, match.Groups["name"].Value));
         }

         if (RoomsChanged != null) RoomsChanged(rooms);
      }

      protected override void OnNavigating(object sender, WebBrowserNavigatingEventArgs e)
      {
         if (e.Url.OriginalString.Contains(@"/room"))
         {
            if (OpenRoom != null)
            {
               var regex = new Regex(@"/room/(?<id>\d+)");
               OpenRoom(regex.Match(e.Url.OriginalString).Groups["id"].Value);
            }
         }
         else if (e.Url.OriginalString.EndsWith(@".com/"))
         {
            Url = new Uri(e.Url.OriginalString + _accessToken);
         }
         else if (!e.Url.OriginalString.EndsWith("/login"))
         {
            Utility.LaunchWebPage(e.Url.OriginalString);
         }

         e.Cancel = true;
      }
   }
}
