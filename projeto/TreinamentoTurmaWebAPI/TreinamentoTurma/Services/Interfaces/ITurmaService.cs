using System.Collections.Generic;
using TreinamentoTurma.Helpers.Retornos.Validacao;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Services.Interfaces
{
    public interface ITurmaService
    {
        void Atualizar(Turma turma);
        void Excluir(int id);
        int Cadastrar(Turma turma);
        Resultado<Turma, Falha> ObterPeloId(int id);
        IEnumerable<Turma> ListarTurmas();
        Resultado<Inscricao, Falha> CadastrarInscricao(Inscricao inscricao);
        void ExcluirInscricao(int id);
        void ExcluirInscricoesPeloAlunoId(int alunoId);
        Resultado<Inscricao, Falha> ObterIncricao(int alunoId, int turmaId);
        Resultado<Inscricao, Falha> ObterPeloAlunoId(int id);
    }
}
