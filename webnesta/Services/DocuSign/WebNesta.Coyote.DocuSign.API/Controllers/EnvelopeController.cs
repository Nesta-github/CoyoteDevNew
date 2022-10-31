using DocuSign.eSign.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WebNesta.Coyote.Core.Contracts;
using WebNesta.Coyote.DocuSign.Domain;
using WebNesta.Coyote.DocuSign.Domain.Service;
using WebNesta.Coyote.Core.Utils;

namespace WebNesta.Coyote.DocuSign.API.Controllers
{
    public class EnvelopeController : Controller
    {
        private readonly Auth Authorization;
        public EnvelopeController(IAuthorizationDocuSign authorization)
        {
            Authorization = (Auth)authorization;
        }
        public IActionResult Index()
        {

            var docuSignEnvelopeAPIService = new DocuSignEnvelopeAPIService();

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


            var signTest1File = @"C:\Users\ALEX\source\repos\Nesta_DocsSignatarios_API\PréFérias0721.pdf";

            byte[] fileBytes = FileUtil.GetFileBytes(signTest1File);

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

            envDef.Documents = new List<Document> { doc };
            envDef.Status = "sent";

            envDef.Recipients = new Recipients
            {
                Signers = signers,

            };

            envDef.Status = "sent";
            var envelopeService = new EnvelopeService();
            return View();
        }


    }
}
