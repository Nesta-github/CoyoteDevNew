using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public class NotifyEmailService : IDomainNotifyService
    {
        public NotifyEmailService() { messageProperties = new NotifyPropertiesEmail(); messageProperties. Init(null, null,null); }
        public NotifyPropertiesEmail messageProperties { get; set; }
        public async Task SendMessage(Notify mainProperties)
        {
            using (MailMessage message = new MailMessage())
            {
                if (mainProperties.To != null && mainProperties.To.Count > 0)
                    foreach (var x in mainProperties.To)
                    {
                        message.To.Add(x);
                    }

                if (messageProperties.CC != null && messageProperties.CC.Count > 0)
                    foreach (var x in messageProperties.CC)
                    {
                        message.CC.Add(x);
                    }

                if (messageProperties.BCC != null && messageProperties.BCC.Count > 0)
                    foreach (var x in messageProperties.BCC)
                    {
                        message.Bcc.Add(x);
                    }

                message.Subject = mainProperties.Subject;

                if (mainProperties.Reset)
                {
                    string contentHtml = File.ReadAllText(messageProperties.HtmlContentReset, Encoding.UTF8);
                    contentHtml = contentHtml.Replace("{subject}", mainProperties.Subject);
                    contentHtml = contentHtml.Replace("{body}", mainProperties.Body);
                    contentHtml = contentHtml.Replace("{random_code}", mainProperties.RandomCode);
                    message.Body = contentHtml;
                }
                else if (messageProperties.Encerramento)
                {
                    string contentHtml = File.ReadAllText(messageProperties.HtmlContentEncerra, Encoding.UTF8);
                    contentHtml = contentHtml.Replace("{subject}", mainProperties.Subject);
                    contentHtml = contentHtml.Replace("{body}", mainProperties.Body);
                    contentHtml = contentHtml.Replace("{linkaprovar}", messageProperties.linkAprova);
                    contentHtml = contentHtml.Replace("{linkreaprovar}", messageProperties.linkReprova);
                    message.Body = contentHtml;
                }
                else
                {
                    string contentHtml = File.ReadAllText(messageProperties.HtmlContentDefault, Encoding.UTF8);
                    contentHtml = contentHtml.Replace("{subject}", mainProperties.Subject);
                    contentHtml = contentHtml.Replace("{body}", mainProperties.Body);
                    message.Body = contentHtml;
                }
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.From = new MailAddress(messageProperties.From);
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                if (!string.IsNullOrEmpty(messageProperties.Anexo))
                    message.Attachments.Add(new Attachment(messageProperties.Anexo));

                var server = "smtp.gmail.com";
                var user = "suporte@webnesta.com";
                var pwd = "987%SM@ster";
                var port = "587";
                var enableSSL = "true";

                //send the message
                using (var smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.Host = server;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new System.Net.NetworkCredential(user, pwd);
                    await smtp.SendMailAsync(message);
                    await Task.FromResult(0);
                }
            }
        }

    }
}
