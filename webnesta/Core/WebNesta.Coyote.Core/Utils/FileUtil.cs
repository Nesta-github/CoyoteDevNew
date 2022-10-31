using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebNesta.Coyote.Core.Utils
{
    public static class FileUtil
    {
        public static byte[] GetFileBytes(string path)
        {
            byte[] file = null;

            if (!string.IsNullOrEmpty(path))
                file = File.ReadAllBytes(path);

            return file;
        }
    }
}
