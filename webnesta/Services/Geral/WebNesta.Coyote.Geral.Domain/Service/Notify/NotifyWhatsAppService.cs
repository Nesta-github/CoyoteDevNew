using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public class NotifyWhatsAppService : IDomainNotifyService
    {
        public SecretariaNatyService _whatsAppProvider;

        public Task SendMessage(Notify messageProperties)
        {
            _whatsAppProvider = new SecretariaNatyService(@"https://api.naty.app/api/v1",
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzY29wZSI6WyJjcmVhdGU6bWVzc2FnZXMiLCJyZWFkOndoYXRzYXBwcyIsImNyZWF0ZTptZWRpYXMiLCJ1cGRhdGU6d2hhdHNhcHBzIl0sImNvbXBhbnlJZCI6ImNjZTc2MzI1LWVhNDgtNDA3My05ZWNkLWE5YzZlYTFmMzA1MSIsImlhdCI6MTYzMDYwMTg0OH0.eB6FI7MXT1fhQJN5-bpo_0ZFes7jNOAd_xq-2TBMUOw");

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
