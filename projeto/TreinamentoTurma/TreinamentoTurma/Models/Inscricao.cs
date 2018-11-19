using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinamentoTurma.Models
{
    public class Inscricao
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        [Required]
        public int TurmaId { get; set; }
        [DataType(DataType.Date)]
        public DateTime InscritoEm { get; set; }
    }
}