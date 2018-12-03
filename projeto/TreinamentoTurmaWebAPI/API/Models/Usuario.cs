using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using API.Helpers;
using API.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;

namespace API.Models
{
    public class Usuario
    {
        internal Usuario() : this(0, string.Empty) { }

        public Usuario(int codigo, string senha)
        {
            Codigo = codigo;
            Senha = senha;
        }

        public void GerarCodigoESenha(UsuarioRepositorio repositorio)
        {
            Codigo = new Geradores(repositorio).GerarCodigoValido();
            Senha = new Geradores(repositorio).GerarSenha();
        }

        public int Id { get; set; }
        //[Required]
        public int Codigo { get; set; }
        //[Required]
        public string Senha { get; set; }
    }
}