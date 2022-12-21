using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebNesta.Coyote.Web.Models
{
    public class RecoveryPasswordViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        public string Lang { get; set; }
    }
}
