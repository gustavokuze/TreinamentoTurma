using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinamentoTurma.Areas.Painel.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}