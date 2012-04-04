using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MSHTML;

namespace Flare
{
   class SearchBrowser : CampfireBrowser
   {
      public delegate void OnSearchDelegate(string term);

      public event TranscriptsBrowser.OpenTranscriptsDelegate OpenTranscripts;
      public event Flare.TranscriptBrowser.OpenTranscriptionDelegate OpenTranscription;

      private string _searchUrl;

      public SearchBrowser(string url, string term, string accessToken)
         : base(accessToken)
      {
         _searchUrl = url + @"search/";
         Search(term);
      }

      public void Search(string term)
      {
         Url = new Uri(_searchUrl + term + _accessToken);
      }

      protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
      {
         OnTitleChanged("Search for ...");

         base.OnDocumentCompleted(e);
      }

      protected override void OnNavigating(object sender, WebBrowserNavigatingEventArgs e)
      {
         if (e.Url.OriginalString.EndsWith("/search/"))
         {
            var term = Document.GetElementById("term");

            Search(((HTMLInputTextElement)term.DomElement).value);
         }
         if (e.Url.OriginalString.Contains("/search/"))
         {
            return;
         }
         else if (e.Url.OriginalString.EndsWith(@"files+transcripts"))
         {
            if (OpenTranscripts != null) OpenTranscripts();
         }
         else if (e.Url.OriginalString.Contains("/transcript/"))
         {
            if (OpenTranscription != null) OpenTranscription(e.Url.OriginalString);
         }
         else if (!e.Url.OriginalString.EndsWith("/login"))
         {
            Utility.LaunchWebPage(e.Url.OriginalString);
         }

         e.Cancel = true;
      }
   }
}
