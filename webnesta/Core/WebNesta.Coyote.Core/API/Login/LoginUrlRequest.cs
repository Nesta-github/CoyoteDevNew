using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace WebNesta.Coyote.Core.API.Login
{
    public class LoginUrlRequest : IRequest
    {
        public string GetUrl(ApiContext context, object[] parametros)
        {
            var url = string.Empty;

            switch (context)
            {
                case ApiContext.LoginTutorialCarregar:
                    url = string.Format("api/v1/Tutorial/Carregar?currentUser={0}&_FSIDFUSI={1}&_TUTOORDE={2}", 
                        parametros[0],
                        parametros[1],
                        parametros[2]);
                    break;
                    //return
            }

            return url;
        }
    }
}
