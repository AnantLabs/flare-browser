using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Flare
{
   class TranscriptBrowser : CampfireBrowser
   {
      public delegate void OpenTranscriptionDelegate(string url);

      public TranscriptBrowser(string url, string accessToken)
         : base(accessToken)
      {
         Url = new Uri(url + _accessToken);
      }

      protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
      {
         var match = (new Regex(@"(?<year>\d+)/(?<month>\d+)/(?<day>\d+)")).Match(e.Url.OriginalString);

         string title = string.Format( "Transcript for {0}/{1}/{2}", match.Groups["month"], match.Groups["day"], match.Groups["year"] );

         OnTitleChanged(title);

         base.OnDocumentCompleted(e);
      }

      protected override void OnNavigating(object sender, WebBrowserNavigatingEventArgs e)
      {
         if (!e.Url.OriginalString.Contains("/transcript/"))
         {
            Utility.LaunchWebPage(e.Url.OriginalString);
         }
         else if (!e.Url.OriginalString.Contains("?"))
         {
            Url = new Uri(e.Url.OriginalString + _accessToken);
         }
         else if (!e.Url.OriginalString.EndsWith("/login"))
         {
            return;
         }

         e.Cancel = true;         
      }
   }
}
