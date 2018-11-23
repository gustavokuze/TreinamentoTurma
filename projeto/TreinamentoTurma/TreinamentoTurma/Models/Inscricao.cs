using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web; 

namespace TreinamentoTurma.Models
{
    public class Inscricao
    {
        internal Inscricao()
        {

        }

        public Inscricao(int alunoId, int turmaId, DateTime inscritoEm)
        {
            AlunoId = alunoId;
            TurmaId = turmaId;
            InscritoEm = inscritoEm;
        }

        public int Id { get; set; }
        public int AlunoId { get; set; }
        [Required]
        public int TurmaId { get; set; }
        [DataType(DataType.Date)]
        public DateTime InscritoEm { get; set; }
    }
}