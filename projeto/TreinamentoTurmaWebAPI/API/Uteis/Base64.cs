using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Uteis
{
    public class Base64
    {
        internal static string ParaBase64(string texto)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(texto));
        }

        internal static string ParaString(string stringBase64)
        {
            var base64EncodedBytes = Convert.FromBase64String(stringBase64);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}