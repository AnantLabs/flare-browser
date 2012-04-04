using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Flare
{
   public partial class OAuthWindow : Form
   {
      private static string OAuthClientId = @"118e75c775b4e2c51712ff36e848690ff6d1d458";
      private static string OAuthClientSecret = @"f9f5762dfc79857b48ede315215966af80a638b3";
      private static string OAuthRedirect = @"http://code.google.com/p/flare-browser/";

      private string _redirectUrl;

      public OAuthWindow(string url, string redirectUrl)
      {
         _redirectUrl = redirectUrl;

         InitializeComponent();

         _webBrowser.DocumentCompleted += DocumentCompleted;
         _webBrowser.Navigate(url);

         Token = null;
      }

      void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
      {
         string url = e.Url.ToString();

         if (url.StartsWith(_redirectUrl))
         {
            ProcessRedirectUrl(url);
            return;
         }
      }

      private void ProcessRedirectUrl(string url)
      {
         if (url.Contains("#error="))
         {
            DialogResult = DialogResult.Cancel;
         }
         else
         {
            Token = UserCredential.ParseAccessToken(url);
            RefreshToken = UserCredential.ParseRefreshToken(url);
            DialogResult = DialogResult.OK;
         }
      }

      public string Token
      {
         get;
         private set;
      }

      public string RefreshToken
      {
         get;
         private set;
      }

      public static UserCredential OauthLogin()
      {
         string url = string.Format(@"https://launchpad.37signals.com/authorization/new?type={0}&client_id={1}&redirect_uri={2}", "user_agent", OAuthClientId, OAuthRedirect);

         var browserWindow = new OAuthWindow(url, OAuthRedirect);

         browserWindow.ShowDialog();

         var user = new UserCredential();
         user.OauthToken = browserWindow.Token;
         user.RefreshToken = browserWindow.RefreshToken;

         return user;
      }

      public static Authorization GetAuthorization(string token)
      {
         var request = WebRequest.Create("https://launchpad.37signals.com/authorization.xml?access_token=" + token);
         request.Method = "GET";

         var response = request.GetResponse();

         var serializer = new XmlSerializer(typeof(Authorization));

         return (Authorization)serializer.Deserialize(response.GetResponseStream());
      }

      public static UserCredential RefreshCredential(string refreshToken)
      {
         var request = WebRequest.Create(@"https://launchpad.37signals.com/authorization/token");
         request.Method = "POST";
         request.ContentType = "application/x-www-form-urlencoded";

         using (var writer = new StreamWriter(request.GetRequestStream()))
         {
            writer.Write(string.Format(@"type=refresh&client_id={0}&client_secret={1}&refresh_token={2}&format=form", OAuthClientId, OAuthClientSecret, refreshToken));
         }

         var response = request.GetResponse();

         var userCredential = new UserCredential();

         using (var reader = new StreamReader(response.GetResponseStream()))
         {
            string responseString = reader.ReadToEnd();

            userCredential.OauthToken = UserCredential.ParseAccessToken(responseString);

            string newRefreshToken = UserCredential.ParseRefreshToken(responseString);

            userCredential.RefreshToken = newRefreshToken ?? refreshToken;
         }

         return userCredential;
      }
   }

   [Serializable]
   [XmlRoot("authorization")]
   public class Authorization
   {
      [XmlElement("identity")]
      public Identity Identity;

      [XmlArray("accounts")]
      [XmlArrayItem("account")]
      public List<OauthAccount> Accounts;
   }

   [XmlRoot("identity")]
   public class Identity
   {
      [XmlAttribute("id")]
      public string Id;

      [XmlAttribute("email_address")]
      public string EmailAddress;

      [XmlAttribute("first_name")]
      public string FirstName;

      [XmlAttribute("last_name")]
      public string LastName;
   }

   [XmlRoot("account")]
   public class OauthAccount
   {
      [XmlAttribute("href")]
      public string Url;

      [XmlAttribute("name")]
      public string Name;

      [XmlAttribute("id")]
      public string Id;

      [XmlAttribute("product")]
      public string Product;

      public string AccountName()
      {
         var regex = new Regex(@"https?://(?<account>.*?)\.");

         var match = regex.Match(Url);

         return match.Groups["account"].Value;
      }
   }

   public class UserCredential
   {
      public string OauthToken;
      public string RefreshToken;

      public static string ParseAccessToken(string url)
      {
         var tokenRegex = new Regex(@"access_token=(?<token>.*?)(&|$)");

         var tokenMatch = tokenRegex.Match(url);

         var token = tokenMatch.Groups["token"].Value;
         return token;
      }

      public static string ParseRefreshToken(string url)
      {
         var tokenRegex = new Regex(@"refresh_token=(?<token>.*?)(&|$)");

         var tokenMatch = tokenRegex.Match(url);

         if (tokenMatch.Success)
         {
            var token = tokenMatch.Groups["token"].Value;
            return token;
         }

         return null;
      }
   }
}
