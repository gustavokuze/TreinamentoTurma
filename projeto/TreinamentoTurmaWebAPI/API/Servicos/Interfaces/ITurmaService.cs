using API.Modelos;
using API.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicos.Interfaces
{
    public interface ITurmaService
    {
        void Atualizar(Turma turma);
        void Excluir(int id);
        int Cadastrar(Turma turma);
        Resultado<Turma, Falha> ObterPeloId(int id);
        Resultado<Turma, Falha> ObterPeloCpf(string cpf);
        IEnumerable<Turma> ListarTurmas();
        void CadastrarInscricao(Inscricao inscricao);
        void ExcluirInscricao(int id);
        Inscricao ObterIncricao(int alunoId, int turmaId);
    }
}
