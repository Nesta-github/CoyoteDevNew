using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocuSign.eSign.Client;
using DocuSign.eSign.Client.Auth;
using DocuSign.eSign.Model;
using WebNesta.Coyote.Core.Contracts;

namespace WebNesta.Coyote.DocuSign.Domain
{
    public class Auth : IAuthorizationDocuSign
    {
        public Auth()
        {
            InitializeAuth();
            SetAccessToken();
            SetUserInfo();
            SetClientBasePath();
        }

        #region Properties
        public ConfigurationDocuSign Configuration { get; set; }
        public OAuth.UserInfo AuthUser { get; set; }
        public OAuth.OAuthToken TokenInfo { get; set; }
        #endregion

        private void InitializeAuth()
        {
            Configuration = new ConfigurationDocuSign();
            Configuration.AccountId = "c60f7c7a-7503-4dec-9a24-bf0ab8e6e4fd";
            Configuration.UserId = "d6fae223-3ba7-4304-be71-8da0c9d3fdf3";
            Configuration.IntegratorKey = "ac218c58-f3ac-4a2b-8117-021a5233359f";
            Configuration.OAuthBasePath = "account-d.docusign.com";
            Configuration.ExpiresInHours = 1;
            Configuration.PrivateKeyFile = @"C:\Users\ALEX\source\repos\Nesta_DocsSignatarios_API\private.key";
            Configuration.FileStream = File.ReadAllBytes(Configuration.PrivateKeyFile);
            Configuration.ApiClient = new ApiClient(Configuration.OAuthBasePath);
            Configuration.ApiClient.SetOAuthBasePath(Configuration.OAuthBasePath);
        }

        private void SetAccessToken()
        {
            var scopes = new List<string> { OAuth.Scope_SIGNATURE, OAuth.Scope_IMPERSONATION };

            TokenInfo = Configuration.ApiClient.RequestJWTUserToken(
               Configuration.IntegratorKey,
               Configuration.UserId,
               Configuration.OAuthBasePath,
               Configuration.FileStream,
               Configuration.ExpiresInHours,
                scopes);
        }
        private void SetUserInfo()
        {
            AuthUser = Configuration.ApiClient.GetUserInfo(TokenInfo.access_token);
        }

        private void SetClientBasePath()
        {
            foreach (OAuth.UserInfo.Account item in AuthUser.Accounts)
            {
                if (item.IsDefault == "true")
                {
                    Configuration.AccountId = item.AccountId;
                    Configuration.ApiClient.SetBasePath(item.BaseUri + "/restapi");
                    break;
                }
            }
        }
    }
}
