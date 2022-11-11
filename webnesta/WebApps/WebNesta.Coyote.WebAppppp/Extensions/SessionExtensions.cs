using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Text.Json;
//using Newtonsoft.Json;using
//System.Text.Json;

namespace WebNesta.Coyote.WebApp.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.Set<T>(key, value
                //JsonSerializer.SerializeToUtf8Bytes(value)
                //JsonConvert.SerializeObject(value)
                );
        }
       
        public static T Get<T>(this ISession session, string key)
        {
            if (session.Keys != null && session.Keys.Count() > 0)
            {
                var value = session.Get<T>(key);

                return value == null ? default(T) : value
                    //JsonSerializer.Deserialize<T>(value)
                    ;
            }
            return default(T);

        }
    }
}
