using System;

namespace WebNesta.Coyote.WebApp.Models
{
    [Serializable]
    public class AuthViewModel
    {
        public AuthViewModel(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
