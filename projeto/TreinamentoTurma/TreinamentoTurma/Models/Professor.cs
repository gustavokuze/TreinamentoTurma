using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinamentoTurma.Models
{
    public class Professor : Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required] 
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Digite um CPF válido")]
        public string Cpf { get; set; }
    }
}