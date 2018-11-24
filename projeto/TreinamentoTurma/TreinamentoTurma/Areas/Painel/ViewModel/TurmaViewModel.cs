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
            
        }

        public Turma Turma { get; set; } = new Turma();
        public List<Turma> ListaTurmas { get; set; } = new List<Turma>();
    }
}

/*
 A ViewModel garante que os dados sejam carregados e buscados em memória, para que 
 não seja necessária uma consulta completa ao DB toda vez que uma alteração seja feita
     
     */