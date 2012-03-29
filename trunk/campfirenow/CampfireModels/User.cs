using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using CampfireApiNet.Models;

namespace Flare
{
   public class User
   {
      public User()
      {
      }

      public UserCredential Credentials
      {
         get
         {
            return new UserCredential { OauthToken = Token, RefreshToken = RefreshToken };
         }
      }

      public String Username { get; set; }
      public string Token { get; set; }
      public string RefreshToken { get; set; }
      private String _nickname;
      public String Nickname
      {
         get
         {
            if (String.IsNullOrEmpty(_nickname))
               return Username.Contains("@") ? Username.Substring(0, Username.IndexOf('@')) : Username;
            return _nickname;
         }
         set { _nickname = value; }
      }

      /// <summary>
      /// Retreives the user's details and preferences from the default registry entries.
      /// </summary>
      public static User FromRegistry()
      {
         RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Flare");

         var user = new User();

         user.Username = key.GetValue("username", string.Empty).ToString();
         user.Nickname = key.GetValue("_nickname", string.Empty).ToString();
         user.Token = key.GetValue("token", string.Empty).ToString();
         user.RefreshToken = key.GetValue("refreshtoken", string.Empty).ToString();
         key.Close();

         return user;
      }

      public void Save()
      {
         RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Flare");
         key.SetValue("username", Username);
         key.SetValue("_nickname", Nickname);
         key.SetValue("token", Token);
         key.SetValue("refreshtoken", RefreshToken);
         key.Close();
      }
   }
}