using API.Modelos;
using API.Uteis.Retornos.Validacao;
using System.Collections.Generic;

namespace API.Servicos.Interfaces
{
    public interface ITurmaServico
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
        IEnumerable<Inscricao> listarInscricoesPeloAlunoId(int id);
    }
}
