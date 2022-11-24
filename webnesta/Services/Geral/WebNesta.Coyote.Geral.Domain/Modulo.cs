using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WebNesta.Coyote.Geral.Domain
{
    public class Modulo
    {
        public Modulo(string user = "-1")
        {
            if (user != "-1")
                CREDUSER = user;
        }
        public long FSIDFUSI { get; set; }
        public long FSPIFUSI { get; set; }
        public int FSNRACES { get; set; }
        public string FSDSFUSI { get; set; }
        public string FSVEFUSI { get; set; }
        public string FSCAFUSI { get; set; }
        public string FSLANGFS { get; set; }
        public bool FAVORITO { get; set; }
        public string CREDUSER { get; set; }
        public Exception exception { get; set; }
    }
}
