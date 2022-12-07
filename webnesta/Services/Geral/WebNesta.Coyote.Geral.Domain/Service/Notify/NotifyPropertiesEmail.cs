using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public class NotifyPropertiesEmail : NotifyProperties
    {
        private IConfiguration _config;
        
        
        public NotifyPropertiesEmail(IConfiguration config)
        {
            _config = config;
        }
        
        public void Init(string htmlContentEncerraPath, string htmlContentDefault, string htmlContentReset)
        {
            CC = new List<string>();
            BCC = new List<string>();
            From = _config.GetValue<string>("WebNestaApiGeral:Notify:EmailFrom");//"suporte@webnesta.com";
            Encerramento = false;
            HtmlContentEncerra = _config.GetValue<string>("WebNestaApiGeral:Notify:HtmlContentEncerraPath"); //"E:\\ProjetoAlex\\CoyoteDevNew\\webnesta\\Services\\Geral\\WebNesta.Coyote.Geral.API\\Html\\mailing_encerra.html";
            HtmlContentDefault = _config.GetValue<string>("WebNestaApiGeral:Notify:HtmlContentDefault"); //"E:\\ProjetoAlex\\CoyoteDevNew\\webnesta\\Services\\Geral\\WebNesta.Coyote.Geral.API\\Html\\mailing_default.html";
            HtmlContentReset = _config.GetValue<string>("WebNestaApiGeral:Notify:HtmlContentReset"); //"E:\\ProjetoAlex\\CoyoteDevNew\\webnesta\\Services\\Geral\\WebNesta.Coyote.Geral.API\\Html\\mailing_reset.html";
        }
        // constants
        private const string HtmlEmailHeader = "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">" +
            "<html xmlns=\"http://www.w3.org/1999/xhtml\">" +
            " <head>" +
            "  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />" +
            "  <title>Demystifying Email Design</title>" +
            "  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"/>" +
            "</head>";
        private const string HtmlEmailFooter = "</html>";

        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public string From { get; set; }

        public string Anexo { get; set; }
        public bool Encerramento { get; set; }

        public string linkAprova { get; set; }
        public string linkReprova { get; set; }
        public string HtmlContentEncerra { get; set; }
        public string HtmlContentDefault { get; set; }
        public string HtmlContentReset { get; set; }
    }
}
