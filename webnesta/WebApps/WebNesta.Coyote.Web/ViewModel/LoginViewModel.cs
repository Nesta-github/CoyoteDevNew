using WebNesta.Coyote.Web.Models;

namespace WebNesta.Coyote.Web.ViewModel
{
    public class LoginViewModel
    {
        public bool Key_2FAGoogle { get; set; }
        public bool Valida { get; set; }
        public string MsgErrorLogin { get; set; }
        public Tutorial Tutorial { get; set; }
        public Captcha Captcha { get; set; }
        public string TelaVersion { get; set; }
        public string UserName { get; set; }
        public string CaptchaImagePath { get; set; }

    }
}
