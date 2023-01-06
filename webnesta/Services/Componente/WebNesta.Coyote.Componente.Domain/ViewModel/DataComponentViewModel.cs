using System.Collections.Generic;

namespace WebNesta.Coyote.Componente.Domain.ViewModel
{
    public class DataComponentViewModel
    {
        public List<Classe> Classes { get; set; }
        public List<Modelo> Modelos { get; set; }
        public List<CHCOMPOT> Componentes { get; set; }
        
    }

    public class Classe 
    {
        public decimal Id { get; set; } 
        public string Descricao { get; set; }

    }
    public class Modelo
    {
        public decimal Id { get; set; }
        public string Descricao { get; set; }
    }
}
