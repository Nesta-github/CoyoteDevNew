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
            _whatsAppProvider = new SecretariaNatyService(@"https://api.beta.naty.app/api/v1",
               "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzY29wZSI6WyJjcmVhdGU6bWVzc2FnZXMiLCJjcmVhdGU6bWVkaWFzIiwicmVhZDp3aGF0c2FwcHMiLCJ1cGRhdGU6d2hhdHNhcHBzIl0sImNvbXBhbnlJZCI6IjJkZjcwYzFjLTQ2NTAtNDM2Ni1hNGUxLTRlMjkyMDYwZDRjMyIsImlhdCI6MTY2ODE3NzE5OH0.U5izcwWlAoJaMO9p5IxGmmDcc7tuJ_xADP9tsUJkulM"
                // "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzY29wZSI6WyJjcmVhdGU6bWVzc2FnZXMiLCJjcmVhdGU6bWVkaWFzIiwicmVhZDp3aGF0c2FwcHMiLCJ1cGRhdGU6d2hhdHNhcHBzIl0sImNvbXBhbnlJZCI6IjJkZjcwYzFjLTQ2NTAtNDM2Ni1hNGUxLTRlMjkyMDYwZDRjMyIsImlhdCI6MTY2Mjk4NDAwMH0.tBBnbKE1ZMBblNBEn5-h-u3pzt-hsrhtGbo54bAORVQ"
                //eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzY29wZSI6WyJjcmVhdGU6bWVzc2FnZXMiLCJjcmVhdGU6bWVkaWFzIiwicmVhZDp3aGF0c2FwcHMiLCJ1cGRhdGU6d2hhdHNhcHBzIl0sImNvbXBhbnlJZCI6IjJkZjcwYzFjLTQ2NTAtNDM2Ni1hNGUxLTRlMjkyMDYwZDRjMyIsImlhdCI6MTY2Mjk4NDAwMH0.tBBnbKE1ZMBblNBEn5-h-u3pzt-hsrhtGbo54bAORVQ
                //"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzY29wZSI6WyJjcmVhdGU6bWVzc2FnZXMiLCJjcmVhdGU6bWVkaWFzIiwicmVhZDp3aGF0c2FwcHMiLCJ1cGRhdGU6d2hhdHNhcHBzIl0sImNvbXBhbnlJZCI6ImNjZTc2MzI1LWVhNDgtNDA3My05ZWNkLWE5YzZlYTFmMzA1MSIsImlhdCI6MTYzMjc0MTU1M30.AQWP_DHFwvbrFJC55SKMuLxbFDJ7WKlKmzeYa0G5NJc"
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
