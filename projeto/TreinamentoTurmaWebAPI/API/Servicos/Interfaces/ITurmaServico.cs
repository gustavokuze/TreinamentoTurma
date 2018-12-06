using API.Modelos;
using API.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicos.Interfaces
{
    public interface ITurmaServico
    {
        void Atualizar(Turma turma);
        void Excluir(int id);
        int Cadastrar(Turma turma);
        Resultado<Turma, Falha> ObterPeloId(int id);
        IEnumerable<Turma> ListarTurmas();
        void CadastrarInscricao(Inscricao inscricao);
        void ExcluirInscricao(int id);
        void ExcluirInscricoesPeloAlunoId(int alunoId);
        Resultado<Inscricao, Falha> ObterIncricao(int alunoId, int turmaId);
        Resultado<Inscricao, Falha> ObterPeloAlunoId(int id);
    }
}
