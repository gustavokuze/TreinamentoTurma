using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinamentoTurma.Infra;

namespace TreinamentoTurma.Helpers
{
    public class Geradores
    {
        internal static int GerarCodigoValido(Random random = null)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            var rand = (random == null) ? new Random() : random;
            int randNum = rand.Next(100000, 999999);

            return (repositorio.ValidarCodigo(randNum) == null) ? randNum : GerarCodigoValido(rand);
        }

        internal static string GerarSenha()
        {
            Guid g = Guid.NewGuid();
            string GuidString = g.ToString();
            //Convert.ToBase64String(g.ToByteArray());
            //GuidString = GuidString.Replace("=", "");
            //GuidString = GuidString.Replace("+", "");
            //GuidString = GuidString.Replace("/", "");
            //GuidString = GuidString.Replace("\\", "");
            return GuidString.Substring(0, 6);
        }
    }
}