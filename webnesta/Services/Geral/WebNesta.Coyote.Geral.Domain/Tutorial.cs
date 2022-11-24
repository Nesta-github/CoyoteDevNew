using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WebNesta.Coyote.Geral.Domain
{
    public class Tutorial
    {
        public Tutorial(string user = "-1")
        {
            if (user != "-1")
                CREDUSER = user;
        }
        public int TUTOIDUS { get; set; }
        public DateTime TUTODTUS { get; set; }
        public string USIDUSUA { get; set; }
        public int FSIDFUSI { get; set; }
        public int TUTOORDE { get; set; }
        public int qtd { get; set; }
        public bool GuiaRapido { get; set; }
        public string TUTODSUS { get; set; }
        public string CREDUSER { get; set; }
        public List<TutorialSteps> TUTOSTEP { get; set; }
        public TutorialSteps tutorialSteps { get; set; }
        public Exception exception { get; set; }

    }
}
