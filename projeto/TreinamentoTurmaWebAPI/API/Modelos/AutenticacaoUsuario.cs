using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Modelos
{
    public class AutenticacaoUsuario
    {
        public Usuario Usuario { get; set; }
        public string Token { get; set; }
    }
}
