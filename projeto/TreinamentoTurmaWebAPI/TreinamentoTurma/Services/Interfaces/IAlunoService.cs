using System.Collections.Generic;
using TreinamentoTurma.Helpers.Retornos.Validacao;
using TreinamentoTurma.Models;
using Falha = TreinamentoTurma.Helpers.Retornos.Validacao.Falha;

namespace TreinamentoTurma.Services.Interfaces
{
    public interface IAlunoService
    {
        Resultado<Aluno, Falha> Atualizar(Aluno aluno);
        Resultado<int, Falha> Excluir(int id);
        Resultado<Usuario, Falha> Cadastrar(Aluno aluno);
        Resultado<Aluno, Falha> ObterPeloIdUsuario(int id);
        Resultado<Aluno, Falha> ObterPeloEmail(string email);
        IEnumerable<Aluno> ListarAlunos();
    }
}
