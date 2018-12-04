using API.Infraestrutura.Repositorio;
using API.Infraestrutura.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Uteis
{
    public class Geradores
    {
        internal static int GerarCodigo(Random random = null)
        {
            var rand = (random == null) ? new Random() : random;
            int randNum = rand.Next(100000, 999999);

            return randNum;
        }

        internal static string GerarSenha()
        {
            Guid g = Guid.NewGuid();
            string GuidString = g.ToString();
            return GuidString.Substring(0, 6);
        }
    }
}