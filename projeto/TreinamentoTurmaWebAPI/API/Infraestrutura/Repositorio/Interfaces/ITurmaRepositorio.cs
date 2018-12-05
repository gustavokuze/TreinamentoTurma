using API.Modelos;
using System.Collections.Generic;

namespace API.Infraestrutura.Repositorio.Interfaces
{
    public interface ITurmaRepositorio
    {
        int Inserir(Turma turma);
        void Atualizar(Turma turma);
        void Excluir(int id);
        Turma ObterPeloId(int id);
        IEnumerable<Turma> ListarTurmas();
        void CadastrarInscricao(Inscricao inscricao);
        void ExcluirInscricao(int inscricaoId);
        Inscricao ObterIncricao(int alunoId, int turmaId);
    }
}