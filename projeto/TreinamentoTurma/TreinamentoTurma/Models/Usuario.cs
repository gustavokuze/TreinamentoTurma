using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinamentoTurma.Models
{
    public class Usuario
    {
        internal Usuario()
        {

        }

        public Usuario(int codigo, string senha)
        {
            Codigo = codigo;
            Senha = senha;
        }

        public int Id { get; set; }
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}