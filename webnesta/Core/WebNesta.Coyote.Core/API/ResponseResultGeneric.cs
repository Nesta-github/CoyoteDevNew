using System;
using System.Collections.Generic;
using System.Text;

namespace WebNesta.Coyote.Core.API
{
    public class ResponseResultGeneric<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public ResponseResultGeneric()
        {
            Errors = new ResponseErrorMessages();
        }


        public ResponseErrorMessages Errors { get; set; }
    }

    public class ResponseErrorMessages
    {
        public ResponseErrorMessages()
        {
            Mensagens = new List<string>();
        }

        public List<string> Mensagens { get; set; }
    }
}
