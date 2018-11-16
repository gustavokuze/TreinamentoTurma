using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreinamentoTurma.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int LimiteAlunos { get; set; }
    }
}