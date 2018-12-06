using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Uteis.Retornos.Validacao
{
    public class Falha
    {
        public Falha(string msg)
        {
            Msg = msg;
        }

        public string Msg { get; set; }
    }
}