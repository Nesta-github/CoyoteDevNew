using System.Collections.Generic;
using System;

namespace WebNesta.Coyote.Web.Models
{
    public class TutorialViewModel
    {
 
            public int TUTOIDUS { get; set; }
            public DateTime TUTODTUS { get; set; }
            public string USIDUSUA { get; set; }
            public int FSIDFUSI { get; set; }
            public int TUTOORDE { get; set; }
            public int qtd { get; set; }
            public bool GuiaRapido { get; set; }
            public string TUTODSUS { get; set; }
            public string CREDUSER { get; set; }
            public List<TutorialStepsViewModel> TUTOSTEP { get; set; }
            public TutorialStepsViewModel tutorialSteps { get; set; }
            public Exception exception { get; set; }

    }

    public class TutorialStepsViewModel
    {
        public int TUTOIDST { get; set; }
        public int TUTOIDUS { get; set; }
        public string TUTOTTST { get; set; }
        public string TUTODSST { get; set; }
        public string TUTOIIMG { get; set; }
        public string TUTOVIDE { get; set; }
        public int? TUTOSTEP { get; set; }

        //public HttpPostedFileBase file { get; set; }
    }
}
