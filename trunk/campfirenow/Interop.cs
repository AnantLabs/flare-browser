using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Flare
{
   class Interop
   {
      public const int FlashwTimernofg = 0x0000000C;

      [DllImport("user32.dll")]
      public static extern bool FlashWindowEx([MarshalAs(UnmanagedType.Struct)] ref FLASHWINFO pfwi);

      [StructLayout(LayoutKind.Sequential)]
      public struct FLASHWINFO
      {
         [MarshalAs(UnmanagedType.U4)]
         public int CbSize;
         public IntPtr Hwnd;
         [MarshalAs(UnmanagedType.U4)]
         public int DWFlags;
         [MarshalAs(UnmanagedType.U4)]
         public int UCount;
         [MarshalAs(UnmanagedType.U4)]
         public int DWTimeout;
      }

      public static void FlashWindow(Form window)
      {
         var f = new FLASHWINFO
         {
            CbSize = Marshal.SizeOf(typeof(FLASHWINFO)),
            Hwnd = window.Handle,
            DWFlags = FlashwTimernofg,
            UCount = 2,
            DWTimeout = 0
         };
         FlashWindowEx(ref f);
      }
   }
}
