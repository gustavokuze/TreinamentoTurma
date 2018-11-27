using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace TreinamentoTurma.Models
{
    public class Turma
    {
        internal Turma()
        {

        }

        public Turma(string descricao, int limiteAlunos)
        {
            Descricao = descricao;
            LimiteAlunos = limiteAlunos;
        }

        public int Id { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório!")]
        //[Display(Name = "Descrição")]
        public string Descricao { get; set; }

        //[Required]
        //[Display(Name = "Limite de alunos")]
        public int LimiteAlunos { get; set; }
         

    }
}