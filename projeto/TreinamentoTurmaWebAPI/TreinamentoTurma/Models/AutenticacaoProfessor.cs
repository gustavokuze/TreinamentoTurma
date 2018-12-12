using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreinamentoTurma.Models
{
    public class AutenticacaoProfessor : AutenticacaoUsuario
    {
        public AutenticacaoProfessor(Professor professor, string token)
        {
            Professor = professor;
            base.Token = token;
            base.Usuario = professor as Usuario;
        }
        public Professor Professor { get; set; }
    }
}