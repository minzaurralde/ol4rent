
using Microsoft.Web.WebPages.OAuth;
using System.Collections.Generic;
using WebMatrix.WebData;
namespace OL4RENT
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Usuarios", "Id", "NombreUsuario", autoCreateTables: true);

            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            Dictionary<string, object> TwittersocialData = new Dictionary<string, object>();
            TwittersocialData.Add("Icon", "/Images/twitter.png");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "TMsjobPGqpOaGYYHfnpg",
                consumerSecret: "jCv6EEpx2f8dj3nBaqGTwbBuQGp5dRAvcCk9PBvndoI",
                displayName: "Twitter",
                extraData: TwittersocialData);
            
            Dictionary<string, object> FacebooksocialData = new Dictionary<string, object>();
            FacebooksocialData.Add("Icon", "/Images/facebook.png");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "518933541499049",
                appSecret: "c30ffd1cfba61f199fe0289701ae95e4",
                displayName: "Facebook",
                extraData: FacebooksocialData);

            //OAuthWebSecurity.RegisterGoogleClient();            
        }
    }
}
