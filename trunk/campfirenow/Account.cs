using System;
using Microsoft.Win32;

namespace Flare
{
   public class Account
   {
      public String Name { get; set; }
      public User User { get; set; }

      public Account()
      {
         Name = String.Empty;
         User = new User();
      }

      public string CampfireUrl
      {
         get { return String.Format("https://{0}.campfirenow.com/", Name); }
      }

      public static Account FromRegistry()
      {
         // Attempt to open the key
         RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Flare", true);

         // If the return value is null, the key doesn't exist
         if (key == null)
            // The key doesn't exist; create it / open it
            key = Registry.CurrentUser.CreateSubKey("Software\\Flare");

         var account = new Account();

         account.Name = key.GetValue("accountname", string.Empty).ToString();

         if (string.IsNullOrEmpty(account.Name))
            return null;
         key.Close();

         account.User = User.FromRegistry();

         return account;
      }

      public void Save()
      {
         RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Flare", true);

         // If the return value is null, the key doesn't exist, create it
         if (key == null)
            key = Registry.CurrentUser.CreateSubKey("Software\\Flare");

         key.SetValue("accountname", Name);
         
         if (User != null)
            User.Save();
      }
   }
}