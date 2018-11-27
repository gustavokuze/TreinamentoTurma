using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TreinamentoTurma.Helpers;

namespace TreinamentoTurma.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }

        public Usuario(int codigo, string senha)
        {
            Codigo = codigo;
            Senha = senha;
        }

        public void GerarCodigoESenha()
        {
            Codigo = Geradores.GerarCodigoValido();
            Senha = Geradores.GerarSenha();
        }

        public int Id { get; set; }
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}