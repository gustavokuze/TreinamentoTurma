using System.Collections.Generic;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Services.Interfaces
{
    public interface ITurmaService
    {
        void Atualizar(Turma turma);
        void Excluir(int id);
        int Cadastrar(Turma turma);
        Resultado<Turma, Helpers.Retornos.API.Falha> ObterPeloId(int id);
        IEnumerable<Turma> ListarTurmas();
        Resultado<Inscricao, Helpers.Retornos.API.Falha> CadastrarInscricao(Inscricao inscricao);
        void ExcluirInscricao(int id);
        void ExcluirInscricoesPeloAlunoId(int alunoId);
        Resultado<Inscricao, Helpers.Retornos.API.Falha> ObterIncricao(int alunoId, int turmaId);
        Resultado<Inscricao, Helpers.Retornos.API.Falha> ObterPeloAlunoId(int id);
    }
}
