using API.Modelos;
using API.Uteis;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicos.Interfaces
{
    public interface IAlunoServico
    {
        void Atualizar(Aluno aluno);
        void Excluir(int id);
        void Cadastrar(Aluno aluno);
        Resultado<Aluno, Falha> ObterPeloIdUsuario(int id);
        Resultado<Aluno, Falha> ObterPeloEmail(string email);
        IEnumerable<Aluno> ListarAlunos();
    }
}
 