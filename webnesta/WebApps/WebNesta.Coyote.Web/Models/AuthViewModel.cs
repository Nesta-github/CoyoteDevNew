using System;
using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;


namespace WebNesta.Coyote.Web.Models
{
    public class AuthViewModel
    {
        [Required]
        [StringLength(10, MinimumLength = 4)]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 1)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string Lang { get; set; }


       
    }
}
