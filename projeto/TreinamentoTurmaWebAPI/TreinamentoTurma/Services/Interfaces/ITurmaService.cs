using System.Collections.Generic;
using TreinamentoTurma.Helpers.Retornos.Validacao;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Services.Interfaces
{
    public interface ITurmaService
    {
        Resultado<Turma, Falha> Atualizar(Turma turma);
        Resultado<int, Falha> Excluir(int id);
        Resultado<int, Falha> Cadastrar(Turma turma);
        Resultado<Turma, Falha> ObterPeloId(int id);
        Resultado<IEnumerable<Turma>, Falha> ListarTurmas();
        Resultado<Inscricao, Falha> CadastrarInscricao(Inscricao inscricao);
        Resultado<int, Falha> ExcluirInscricao(int id);
        Resultado<Inscricao, Falha> BuscarInscricao(int alunoId, int turmaId);
    }
}
