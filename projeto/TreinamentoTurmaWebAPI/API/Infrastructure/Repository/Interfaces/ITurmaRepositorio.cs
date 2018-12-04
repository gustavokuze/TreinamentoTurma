using API.Models;
using System.Collections.Generic;

namespace API.Infrastructure.Repository.Interfaces
{
    public interface ITurmaRepositorio
    {
        int Inserir(Turma turma);
        void Atualizar(Turma turma);
        void Excluir(int id);
        Turma ObterPeloId(int id);
        IEnumerable<Turma> ObterTodos();
        void Inserir(Inscricao inscricao);
        void ExcluirInscricao(int inscricaoId);
        Inscricao ObterIncricao(int alunoId, int turmaId);
    }
}