using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace WebNesta.Coyote.Geral.Domain
{
    public class Notify
    {
        public Notify() { }
        public Notify(string from, List<string> to, string subject, string message, string body, string randomCode, bool reset)
        {
            From = from; To = to; Subject = subject; Message = message;
            RandomCode = randomCode; Reset = reset; Body = body;
        }

        public string From { get; set; }
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Body { get; set; }
        public string RandomCode { get; set; }
        public bool Reset { get; set; }

        public string PhoneTo { get; set; }
    }
}
