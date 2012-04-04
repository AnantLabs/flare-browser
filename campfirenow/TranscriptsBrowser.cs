using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MSHTML;

namespace Flare
{
   class TranscriptsBrowser : CampfireBrowser
   {
      public delegate void OpenTranscriptsDelegate();

      public event Flare.TranscriptBrowser.OpenTranscriptionDelegate OpenTranscription;
      public event SearchBrowser.OnSearchDelegate OnSearch;

      public TranscriptsBrowser(string accounturl, string accessToken)
         : base(accessToken)
      {
         string url = accounturl + @"files+transcripts";

         Url = new Uri(url + _accessToken);
      }

      protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
      {
         OnTitleChanged("Transcripts");

         base.OnDocumentCompleted(e);
      }

      protected override void OnNewWindow(System.ComponentModel.CancelEventArgs e)
      {
         if (StatusText.Contains("/transcript/"))
         {
            if (OpenTranscription != null) OpenTranscription(StatusText);
         }
         else
         {
            base.OnNewWindow(e);
         }

         e.Cancel = true;
      }

      protected override void OnNavigating(object sender, WebBrowserNavigatingEventArgs e)
      {
         if (e.Url.OriginalString.EndsWith("/search/"))
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

      protected override void OnStatusTextChanged(EventArgs e)
      {
         Debug.WriteLine(StatusText);
      }
   }
}
