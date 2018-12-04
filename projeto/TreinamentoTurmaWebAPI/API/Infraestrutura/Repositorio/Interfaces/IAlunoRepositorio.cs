using API.Uteis;
using API.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infraestrutura.Repositorio.Interfaces
{
    public interface IAlunoRepositorio
    {
        void Atualizar(Aluno aluno);
        void Excluir(int id);
        void Inserir(Aluno aluno);
        Aluno ObterPeloIdUsuario(int id);
        Resultado<Aluno, Falha> ObterPeloEmail(string email);
        IEnumerable<Aluno> ObterTodos();
    }
}
