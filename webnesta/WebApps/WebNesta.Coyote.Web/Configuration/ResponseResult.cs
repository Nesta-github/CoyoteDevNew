using System.Collections.Generic;

namespace WebNesta.Coyote.Web.Configuration
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            Errors = new ResponseErrorMessages();
        }

        public string Title { get; set; }
        public string CaptchaImagePath { get; set; }
        public string CaptchaCode { get; set; }
        public string FileNameCaptcha { get; set; }
        public int Status { get; set; }
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
