using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.ViewModel
{
    public class TurmaViewModel
    {
        public TurmaViewModel()
        {
            Turma = new Turma();
        }

        public Turma Turma { get; set; }
        public List<Turma> ListaTurmas { get; set; }
    }
}