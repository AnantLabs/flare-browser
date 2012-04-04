using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Flare
{
   class Utility
   {
      public static void LaunchWebPage( string url )
      {
         Process openBrowser = new Process();
         openBrowser.StartInfo = new ProcessStartInfo(url);
         openBrowser.Start();
      }
   }
}
