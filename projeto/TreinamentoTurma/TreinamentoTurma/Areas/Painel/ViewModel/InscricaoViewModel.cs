using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinamentoTurma.Areas.Painel.ViewModel
{
    public class InscricaoViewModel
    {
        public int Id { get; set; }
        [Required] //talvez não seja necessário
        public int AlunoId { get; set; }
        [Required]
        public int TurmaId { get; set; }
        [DataType(DataType.Date)]
        public DateTime InscritoEm { get; set; }
    }
}