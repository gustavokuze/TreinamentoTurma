using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web; 

namespace API.Modelos
{
    public class Inscricao
    {  
        internal Inscricao():this(0, 0, DateTime.Now){}

        public Inscricao(int alunoId, int turmaId, DateTime inscritoEm)
        {
            AlunoId = alunoId;
            TurmaId = turmaId;
            InscritoEm = inscritoEm;
        }

        public int Id { get; set; }
        [Required] //talvez não seja necessário
        public int AlunoId { get; set; }
        [Required]
        public int TurmaId { get; set; }
        [DataType(DataType.Date)]
        public DateTime InscritoEm { get; set; }
    }
}