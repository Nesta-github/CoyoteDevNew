using WebNesta.Coyote.WebApp.Models;

namespace WebNesta.Coyote.WebApp.ViewModel
{
    public class LoginViewModel
    {
        
        public bool Key_2FAGoogle { get; set; }
        public bool Valida { get; set; }
        public string MsgErrorLogin { get; set; }
        public Tutorial Tutorial { get; set; }
        public Captcha Captcha { get; set; }
    }
}
