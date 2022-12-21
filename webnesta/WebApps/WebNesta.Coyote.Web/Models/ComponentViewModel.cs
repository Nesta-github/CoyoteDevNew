using System.ComponentModel.DataAnnotations;

namespace WebNesta.Coyote.Web.Models
{
    public class ComponentViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
       
        [Required]
        [StringLength(10, MinimumLength = 4)]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 1)]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 1)]
        [Display(Name = "Classe")]
        public string Classe { get; set; }
    }
}
