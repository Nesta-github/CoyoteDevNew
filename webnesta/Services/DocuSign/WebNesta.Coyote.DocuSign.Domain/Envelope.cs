using DocuSign.eSign.Api;
using DocuSign.eSign.Client.Auth;
using DocuSign.eSign.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;

namespace WebNesta.Coyote.DocuSign.Domain
{
    public class Envelope
    {
        private List<Signer> Signers { get; set; }
        private EnvelopeDefinition EnvelopeDefinition { get; set; }
        private List<Document> Documents { get; set; }

        
        public Envelope(List<Signer> signers, EnvelopeDefinition envelopeDefinition, List<Document> documents)
        {
            Signers = signers;
            EnvelopeDefinition = envelopeDefinition;
            Documents = documents;
        }
    
        public void CreateEnvelope()
        {
            //EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(auth.Configuration.AccountId, envDef);

            //var auth = new Auth();
            /*
                        var util = new EnvelopeUtils();

                        //*************** 2 - CRIAR SIGNITÁRIOS
                        //var SignerEmail = "nalim.education@gmail.com";
                        //var RecipientName = "Alex Recipiente";


                        var signers = new List<Signer> {
            new Signer
            {
            Email = "nalim.ft@gmail.com",
            Name = "Alex Nalim 1",
            RecipientId = "1",
            // ClientUserId = "1234", //utilizado para um cliente já cadastrado
            DeliveryMethod = "Email",
            Tabs = new Tabs
            {
            SignHereTabs = new List<SignHere>()
            {
            // new SignHere(){
            // DocumentId = "1",
            // PageNumber = "1",
            // RecipientId = "1",
            // XPosition = "100",
            // YPosition = "100",
            // ScaleValue = ".5"
            //}
            }
            }
            },
            new Signer
            {
            Email = "alex.nalim@gmail.com",
            Name = "Alex Nalim 2",
            RecipientId = "2",
            // ClientUserId = "1234", //utilizado para um cliente já cadastrado
            DeliveryMethod = "Email",
            Tabs = new Tabs
            {
            SignHereTabs = new List<SignHere>()
            {
            // new SignHere(){
            // DocumentId = "1",
            // PageNumber = "1",
            // RecipientId = "1",
            // XPosition = "100",
            // YPosition = "100",
            // ScaleValue = ".5"
            //}
            }
            }
            },

            };


                        // var signer = new Signer
                        // {
                        // Email = SignerEmail,
                        // Name = RecipientName,
                        // RecipientId = "1",
                        // // ClientUserId = "1234", //utilizado para um cliente já cadastrado
                        // DeliveryMethod = "Email",
                        // Tabs = new Tabs
                        // {
                        // SignHereTabs = new List<SignHere>()
                        // }
                        // };

                        var signTest1File = @"C:\Users\ALEX\source\repos\Nesta_DocsSignatarios_API\PréFérias0721.pdf";
                        // var signTest1File = @"C:\Users\ALEX\source\repos\Nesta_DocsSignatarios_API\SignTest1.pdf";

                        byte[] fileBytes = util.GetFileBytes(signTest1File);

                        var envDef = new EnvelopeDefinition
                        {
                            EmailSubject = "[WebNesta] - Por favor, assine o documento",
                        };

                        var doc = new Document
                        {
                            DocumentBase64 = Convert.ToBase64String(fileBytes),
                            Name = "SignTest1.pdf",
                            DocumentId = "1"
                        };


                        // var signHere = new SignHere
                        // {
                        // DocumentId = "1",
                        // PageNumber = "1",
                        // RecipientId = "1",
                        // XPosition = "500",
                        // YPosition = "500",
                        // ScaleValue = ".5",
                        // };
                        //
                        //signer.Tabs.SignHereTabs.Add(signHere);


                        envDef.Documents = new List<Document> { doc };
                        envDef.Status = "sent";

                        envDef.Recipients = new Recipients
                        {

                            Signers = signers,

                        };

                        envDef.Status = "sent";

                        var envelopesApi = new EnvelopesApi(auth.Configuration.ApiClient);
                        EnvelopeSummary envelopeSummary = envelopesApi.CreateEnvelope(auth.Configuration.AccountId, envDef);

                        return new { AuthObject = auth };
                    }


                    [HttpPost("hook")]
                    public object GetHook(object objeto)
                    {
                        if (objeto != null)
                        {
                            var docuSignObject = JsonConvert.DeserializeObject<DocuSignWebHookMainViewModel>(objeto.ToString());

                            if (docuSignObject != null)
                            {
                                //ENVELOPE ENVIADO A DOCUSIGN
                                if (docuSignObject.Event == "envelope-sent")
                                {

                                }

                                //SIGNATÁRIO RECEBEU DOCUMENTO PARA ASSINAR
                                if (docuSignObject.Event == "recipient-delivered")
                                {

                                }

                                //SIGNATÁRIO ASSINOU O DOCUMENTO
                                if (docuSignObject.Event == "recipient-completed")
                                {

                                }

                                //ENVELOPE FINALIZADO
                                if (docuSignObject.Event == "envelope-completed")
                                {

                                }
                            }
                        }

                        return null;

                    }*/
        }

        private byte[] GetFileBytes(string path)
        {
            byte[] file = null;

            if (!string.IsNullOrEmpty(path))
                file = File.ReadAllBytes(path);

            return file;
        }
    }
}
