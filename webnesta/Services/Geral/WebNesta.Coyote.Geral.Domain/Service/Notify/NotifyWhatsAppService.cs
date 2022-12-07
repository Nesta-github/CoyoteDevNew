using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public class NotifyWhatsAppService : IDomainNotifyService
    {
        public SecretariaNatyService _whatsAppProvider;
        public IConfiguration _config;

        public void SetConfigurations(IConfiguration config)
        {
            _config = config;
        }

        public Task SendMessage(Notify messageProperties)
        {
            _whatsAppProvider = new SecretariaNatyService(
                _config.GetValue<string>("WebNestaApiGeral:Notify:ChatApiUrl"),
                _config.GetValue<string>("WebNestaApiGeral:Notify:ChatApiToken")


         //  @"https://api.beta.naty.app/api/v1",
         //     "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzY29wZSI6WyJjcmVhdGU6bWVzc2FnZXMiLCJjcmVhdGU6bWVkaWFzIiwicmVhZDp3aGF0c2FwcHMiLCJ1cGRhdGU6d2hhdHNhcHBzIl0sImNvbXBhbnlJZCI6IjJkZjcwYzFjLTQ2NTAtNDM2Ni1hNGUxLTRlMjkyMDYwZDRjMyIsImlhdCI6MTY2ODE3NzE5OH0.U5izcwWlAoJaMO9p5IxGmmDcc7tuJ_xADP9tsUJkulM"
                   );
            //    Notifying.SendingWhats(accounts[0].USNUMCEL, "Coyote Contracts", string.Format("Senha de acesso ao sistema foi recuperada. \n*{0}*", code));
            _whatsAppProvider.SendMessage("", 
                messageProperties.PhoneTo, 
                "*Remetente:* " + messageProperties.From + "\n*Mensagem:* " + messageProperties.Message);

           
            //SecretariaNaty naty = new SecretariaNaty(ConfigurationManager.AppSettings["CHAT-API_URL"], ConfigurationManager.AppSettings["CHAT-API_TOKEN"]);
            //naty.SendMessage("", numTo, "*Remetente:* " + from + "\n*Mensagem:* " + msg);
            throw new NotImplementedException();
        }
    }
}
