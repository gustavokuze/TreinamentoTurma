using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace API.Models
{
    public class Turma
    {
        internal Turma():this(string.Empty, 0){}

        public Turma(string descricao, int limiteAlunos)
        {
            Descricao = descricao;
            LimiteAlunos = limiteAlunos;
        }

        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int LimiteAlunos { get; set; }
         

    }
}