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
            Turma = new Turma("", 0, 0); // Garante que Turma sempre estará instanciada
        }

        public Turma Turma { get; set; }
        public List<Turma> ListaTurmas { get; set; }
    }
}

/*
 A ViewModel garante que os dados sejam carregados e buscados em memória, para que 
 não seja necessária uma consulta completa ao DB toda vez que uma alteração seja feita
     
     */