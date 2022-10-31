using DocuSign.eSign.Api;
using System;
using System.Collections.Generic;
using System.Text;
using WebNesta.Coyote.Core.Contracts;
using WebNesta.Coyote.DocuSign.Domain.Service;

namespace WebNesta.Coyote.DocuSign.Domain.Factories
{
    public class DocuSignApiFactory : IFactory
    {
        public IDocuSignServiceAPI Create(DocuSignObjecyAPI entityType)
        {
            switch (entityType)
            {
                case DocuSignObjecyAPI.Envelope:
                    return new DocuSignEnvelopeAPIService();  
              //  case DocuSignObjecyAPI.Signer:
              //      return new  DocuSignSignerAPIService()// DocuSignEnvelopeAPIService();
                default:
                    return null;
            }
        }
    }
}
