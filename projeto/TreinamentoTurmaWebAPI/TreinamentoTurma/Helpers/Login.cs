using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Helpers
{
    public static class Login
    {
        public static string ChaveUsuarioSession { get; private set; } = "TreinamentoTurmaUsuarioAtual";
        public static AutenticacaoUsuario ObterUsuarioAtual()
        {
            return HttpContext.Current.Session[ChaveUsuarioSession] as AutenticacaoUsuario;
        }

        public static object ObterUsuarioAtualObject()
        {
            return HttpContext.Current.Session[ChaveUsuarioSession];
        }
    }
}