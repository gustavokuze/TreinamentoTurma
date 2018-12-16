using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreinamentoTurma.Helpers
{
    public class Base64
    {
        public static string ParaBase64(string texto)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(texto));
        }

        public static string ParaString(string stringBase64)
        {
            var base64EncodedBytes = Convert.FromBase64String(stringBase64);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}