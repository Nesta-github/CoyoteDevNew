using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Client.Auth;
using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WebNesta.Coyote.Core.Contracts;

namespace WebNesta.Coyote.DocuSign.Domain.Service
{
    /// <summary>
    /// Acessa a API da DocuSign e envia o documento 
    /// </summary>
    public class DocuSignEnvelopeAPIService : IDocuSignServiceAPI
    {
     // private readonly IAuthorizationDocuSign Authorization;
     // public DocuSignEnvelopeAPIService(IAuthorizationDocuSign configuration)
     // {
     //     Authorization = configuration;
     // }

        public void SendEnvelope(Auth Authorization, EnvelopeDefinition envelopeDefinition)
        {
              var envelopesApi = new EnvelopesApi(Authorization.Configuration.ApiClient);
              EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(Authorization.Configuration.AccountId, envelopeDefinition);
        }
    }
}
