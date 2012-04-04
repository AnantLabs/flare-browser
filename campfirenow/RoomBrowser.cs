using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using MSHTML;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Flare
{
   class RoomBrowser : CampfireBrowser
   {
      public event TranscriptsBrowser.OpenTranscriptsDelegate OpenTranscripts;

      public delegate void MessageReceivedDelegate(RoomBrowser browser, Message message);
      public event MessageReceivedDelegate MessageRecieved;

      public event SearchBrowser.OnSearchDelegate OnSearch;

      private string _roomUrl;
      public string RoomNumber;
      private int _lastMessageIndex = 0;
      private int _newMessageCount = 0;

      private Timer _messageTimer = new Timer();

      public RoomBrowser(string url, string roomNumber, string accessToken)
         : base(accessToken)
      {
         RoomNumber = roomNumber;
         
         _roomUrl = url + @"room/" + roomNumber;
         Url = new Uri(_roomUrl + _accessToken);

         _messageTimer.Tick += CheckForNewMessages;
         _messageTimer.Interval = 2000;
      }

      protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
      {
         base.OnDocumentCompleted(e);

         UpdateTitle();

         UpdateSpeakUrl();

         _lastMessageIndex = GetMostRecentMessage();

         _messageTimer.Start();
      }

      private void UpdateSpeakUrl()
      {
         HtmlElement head = Document.GetElementsByTagName("body")[0];
         HtmlElement scriptEl = Document.CreateElement("script");
         IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
         element.text = string.Format("function editSpeak() {{ window.chat.speaker.chat.speakURL = '{0}' }}", _roomUrl + @"/speak" + _accessToken);
         head.AppendChild(scriptEl);
         var something = Document.InvokeScript("editSpeak");
      }

      protected override void OnNewWindow(System.ComponentModel.CancelEventArgs e)
      {
         base.OnNewWindow(e);
      }

      protected override void OnNavigating(object sender, WebBrowserNavigatingEventArgs e)
      {
         if (e.Url.OriginalString.EndsWith("leave"))
         {
            Url = new Uri(_roomUrl + @"/leave" + _accessToken);
            OnLeftRoom();
         }
         else if (e.Url.OriginalString.Contains("leave") || e.Url.OriginalString.Contains("javascript"))
         {
            return;
         }
         else if (e.Url.OriginalString.EndsWith(@"files+transcripts"))
         {
            if (OpenTranscripts != null) OpenTranscripts();
         }
         else if (e.Url.OriginalString.EndsWith(@"/search/"))
         {
            var term = Document.GetElementById("term");

            if (OnSearch != null) OnSearch(((HTMLInputTextElement)term.DomElement).value);
         }
         else if (!e.Url.OriginalString.EndsWith("/login"))
         {
            Utility.LaunchWebPage(e.Url.OriginalString);
         }

         e.Cancel = true;
      }

      public void UpdateTitle()
      {
         HtmlElement titleElement = Document.GetElementById("room_name");
         if (titleElement != null)
         {
            string title = titleElement.InnerText;

            if ( !Focused && _newMessageCount > 0 )
            {
               title += string.Format( " ({0})", _newMessageCount );
            }

            OnTitleChanged(title);
         }
      }

      public override void TabSelected()
      {
         try
         {
            if (!string.IsNullOrEmpty(DocumentText))
            {
               _newMessageCount = 0;

               Navigate("javascript:try{$('input').focus();void(0);}catch(e){}");
            }
         }
         catch
         {
         }
      }

      public override void LeaveRoom()
      {
         var leaveElement = Document.GetElementById("leave_link");
         ((MSHTML.HTMLAnchorElement)leaveElement.DomElement).click();
      }

      private HtmlElementCollection GetChatRows()
      {
         var chatTable = Document.GetElementById("chat");

         return chatTable.GetElementsByTagName("tr");
      }

      private int GetMostRecentMessage()
      {
         var rows = GetChatRows();

         var lastRow = rows[rows.Count - 1];

         return GetMessageId(lastRow);
      }

      private static int GetMessageId(HtmlElement lastRow)
      {
         var messageId = lastRow.Id;

         return int.Parse((new Regex(@"\d+")).Match(messageId).Value);
      }

      private void CheckForNewMessages(object sender, EventArgs e)
      {
         try
         {
            _messageTimer.Stop();

            if (_lastMessageIndex != GetMostRecentMessage())
            {
               var messageList = GetNewMessages();

               _newMessageCount += messageList.Count;

               if (MessageRecieved != null) MessageRecieved(this, GetMessage(messageList[messageList.Count - 1]));

               _lastMessageIndex = GetMostRecentMessage();
            }

            UpdateTitle();
         }
         catch
         {

         }
         finally
         {
            _messageTimer.Start();
         }
      }

      private Message GetMessage(HtmlElement messageElement)
      {
         string name = "";
         string message = "";
         string className = ((MSHTML.IHTMLElement)messageElement.DomElement).className;

         foreach (HtmlElement td in messageElement.All)
         {
            try
            {
               if (((MSHTML.IHTMLElement)td.DomElement).className.Contains("person"))
                  name = td.InnerText;
               else if (((MSHTML.IHTMLElement)td.DomElement).className.Contains("body"))
                  message = td.InnerText;
            }
            catch
            {
            }
         }

         return new Message(name, message, messageElement.Id, className);
      }

      private List<HtmlElement> GetNewMessages()
      {
         var rows = GetChatRows();
         var messageList = new List<HtmlElement>();

         foreach (HtmlElement messageRow in rows)
         {
            int messageId = GetMessageId(messageRow);

            if (messageId > _lastMessageIndex)
            {
               messageList.Add(messageRow);
            }
         }

         return messageList;
      }
   }
}
