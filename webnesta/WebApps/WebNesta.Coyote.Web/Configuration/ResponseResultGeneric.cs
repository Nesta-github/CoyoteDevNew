using System.Collections.Generic;

namespace WebNesta.Coyote.Web.Configuration
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
}
