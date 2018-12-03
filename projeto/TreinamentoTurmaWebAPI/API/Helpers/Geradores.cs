using API.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Helpers
{
    public class Geradores
    {
        private UsuarioRepositorio repositorio;
        public Geradores(UsuarioRepositorio usuarioRepositorio)
        {
            repositorio = usuarioRepositorio;
        }

        internal int GerarCodigoValido(Random random = null)
        {
            var rand = (random == null) ? new Random() : random;
            int randNum = rand.Next(100000, 999999);

            return (repositorio.ValidarCodigo(randNum) == null) ? randNum : GerarCodigoValido(rand);
        }

        internal string GerarSenha()
        {
            Guid g = Guid.NewGuid();
            string GuidString = g.ToString();
            return GuidString.Substring(0, 6);
        }
    }
}