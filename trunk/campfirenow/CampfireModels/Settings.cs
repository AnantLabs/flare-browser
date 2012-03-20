using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Flare.CampfireModels
{
   public class Settings
   {
      public Settings()
      {
         User = new User();
         NotifyWindowDelay = 1500;
      }

      public User User { get; set; }
      public Int32 NotifyWindowDelay { get; set; }
      public bool MinimiseDuringStartup { get; set; }
      public bool MinimiseInsteadOfQuitting { get; set; }
      public Boolean LoginAsGuest { get; set; }
      public Boolean ShowMessageNotifications { get; set; }
      public Boolean NotifyOnlyWhenNicknameIsFound { get; set; }
      public List<string> RoomNames { get; set; }

      /// <summary>
      /// Retreives the user's details and preferences from the default registry entries.
      /// </summary>
      public static Settings FromRegistry()
      {
         RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Flare");

         var settings = new Settings();

         settings.User = User.FromRegistry();

         settings.LoginAsGuest = (key.GetValue("loginAsGuest", "0").ToString() == "1");
         settings.MinimiseDuringStartup = (key.GetValue("minstartup", "0").ToString() == "1");
         settings.MinimiseInsteadOfQuitting = (key.GetValue("minquit", "0").ToString() == "1");
         try
         {
            settings.NotifyWindowDelay = Int32.Parse(key.GetValue("notifydelay", "1500").ToString());
         }
         catch (FormatException)
         {
            settings.NotifyWindowDelay = 1500;
         }
         settings.ShowMessageNotifications = (key.GetValue("showMsgNotify", "1").ToString() == "1");
         settings.RoomNames = new List<string>();
         string[] rooms = key.GetValue("roomnames", "notset").ToString().Split(',');
         foreach (string room in rooms)
            settings.RoomNames.Add(room);
         settings.NotifyOnlyWhenNicknameIsFound = key.GetValue("nicknotifications", "0").ToString() == "1";

         key.Close();

         return settings;
      }

      public void Save()
      {
         RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Flare");
         key.SetValue("loginAsGuest", LoginAsGuest ? "1" : "0");
         key.SetValue("minstartup", MinimiseDuringStartup ? "1" : "0");
         key.SetValue("minquit", MinimiseInsteadOfQuitting ? "1" : "0");
         key.SetValue("notifydelay", NotifyWindowDelay.ToString());
         if (RoomNames == null)
            RoomNames = new List<string>();
         key.SetValue("roomnames", string.Join(",", RoomNames.ToArray()));
         key.SetValue("nicknotifications", NotifyOnlyWhenNicknameIsFound ? "1" : "0");
         key.Close();

         User.Save();
      }
   }
}
