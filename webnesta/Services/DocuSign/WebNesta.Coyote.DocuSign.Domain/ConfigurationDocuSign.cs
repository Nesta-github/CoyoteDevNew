using DocuSign.eSign.Client;
using System;
using System.Collections.Generic;
using System.Text;
using WebNesta.Coyote.Core.Contracts;

namespace WebNesta.Coyote.DocuSign.Domain
{
    public class ConfigurationDocuSign : IAuthorizationDocuSign
    {
        public string IntegratorKey { get; set; }
        public ApiClient ApiClient { get; set; }
        public string AccountId { get; set; }
        public string UserId { get; set; }
        public string OAuthBasePath { get; set; }
        public byte[] FileStream { get; set; }
        public string PrivateKeyFile { get; set; }
        public int ExpiresInHours { get; set; }
    }
}
