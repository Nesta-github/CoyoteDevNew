namespace WebNesta.Coyote.Web.ViewModel
{
    public class LoginResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string CaptchaImagePath { get; set; }
        public string CaptchaCode { get; set; }
        public string FileNameCaptcha { get; set; }

    }
}
