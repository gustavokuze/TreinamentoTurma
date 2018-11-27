using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.ViewModel
{
    public class TurmaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Limite de alunos")]
        public int LimiteAlunos { get; set; }

        public List<TurmaViewModel> ListaTurmas { get; set; }
    }
}

/*
 A ViewModel garante que os dados sejam carregados e buscados em memória, para que 
 não seja necessária uma consulta completa ao DB toda vez que uma alteração seja feita
     
     */