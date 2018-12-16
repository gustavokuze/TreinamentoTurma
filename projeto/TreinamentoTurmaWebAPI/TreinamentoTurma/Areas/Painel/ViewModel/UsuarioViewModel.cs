using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string Senha { get; set; }

        public List<Professor> ProfessoresLista { get; set; } = new List<Professor>();
        public List<Aluno> AlunosLista { get; set; } = new List<Aluno>();
    }
}