namespace WebNesta.Coyote.Web.ViewModel
{
    public class LoginResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string CaptchaImagePath { get; set; }
        public string CaptchaCode { get; set; }
        public string FileNameCaptcha { get; set; }
        public string UserUniqueKey { get; internal set; }
        public string BarcodeImageUrl { get; internal set; }
        public string SetupCode { get; internal set; }
    }
}
