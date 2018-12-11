using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Helpers.Retornos.API;
using TreinamentoTurma.Helpers.Retornos.Validacao;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Services.Interfaces
{
    public interface IAlunoService
    {
        void Atualizar(Aluno aluno);
        void Excluir(int id);
        void Cadastrar(Aluno aluno);
        Resultado<Aluno, Helpers.Retornos.Validacao.Falha> ObterPeloIdUsuario(int id);
        Resultado<Aluno, Helpers.Retornos.Validacao.Falha> ObterPeloEmail(string email);
        Task<IEnumerable<Aluno>> ListarAlunosAsync();
    }
}
