using System.Collections;
using System.Collections.Generic;


namespace WebNesta.Coyote.Core.Utils
{
    public static class ResourceUtil
    {
        public static Dictionary<string,string> GetResource(List<string> keys, string resxFilePath)
        {
            string resxFile = @".\App_GlobalResources\Login.resx";

            var translate = new Dictionary<string, string>();

            using (var resxReader = new System.Resources.ResourceReader(resxFile))
            {
                foreach (DictionaryEntry entry in resxReader)
                {
                    if(keys.Contains((string)entry.Key))
                    {
                        translate.Add((string)entry.Key, (string)entry.Value);
                    }
                }
            }

            return translate;
        }
    }
}