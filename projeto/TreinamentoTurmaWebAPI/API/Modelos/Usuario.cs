using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using API.Uteis;
using API.Infraestrutura.Repositorio;
using API.Infraestrutura.Repositorio.Interfaces;
using Microsoft.Extensions.Configuration;

namespace API.Modelos
{
    public class Usuario
    {
        internal Usuario() : this(0, string.Empty) { }

        public Usuario(int codigo, string senha)
        {
            Codigo = codigo;
            Senha = senha;
        }
        

        public int Id { get; set; }
        //[Required]
        public int Codigo { get; set; }
        //[Required]
        public string Senha { get; set; }
    }
}