using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreinamentoTurma.Models
{
    public class AutenticacaoAluno : AutenticacaoUsuario
    {
        public AutenticacaoAluno(Aluno aluno, string token)
        {
            Aluno = aluno;
            base.Token = token;
            base.Usuario = aluno as Usuario;
        }
        public Aluno Aluno { get; set; }
    }
}