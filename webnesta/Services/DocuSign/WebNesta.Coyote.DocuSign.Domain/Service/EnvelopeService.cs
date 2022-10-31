using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Client.Auth;
using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;
using System.Text;
using WebNesta.Coyote.Core.Contracts;

namespace WebNesta.Coyote.DocuSign.Domain.Service
{
    /// <summary>
    /// Trata o envio do envelope com os documentos
    /// </summary>
    public class EnvelopeService : IServiceEnvelope
    {
        //private readonly Auth Authorization;
        //public EnvelopeService(Auth configuration)
        //{
        //    Authorization = configuration;
        //}

        public void SendEnvelope(Auth Authorization, EnvelopeDefinition evenlopeDefinition)
        {
            var envelopesApi = new EnvelopesApi(Authorization.Configuration.ApiClient);
            EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(Authorization.Configuration.AccountId, evenlopeDefinition);
        }
    }
}
