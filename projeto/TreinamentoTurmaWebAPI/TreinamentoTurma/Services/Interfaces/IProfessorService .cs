using System.Collections.Generic;
using TreinamentoTurma.Helpers.Retornos.Validacao;
using TreinamentoTurma.Models;
using Falha = TreinamentoTurma.Helpers.Retornos.Validacao.Falha;

namespace TreinamentoTurma.Services.Interfaces
{
    public interface IProfessorService
    {
        Resultado<Professor, Falha> Atualizar(Professor professor);
        Resultado<int, Falha> Excluir(int id);
        Resultado<Usuario, Falha> Cadastrar(Professor professor);
        Resultado<Professor, Falha> ObterPeloIdUsuario(int id);
        Resultado<Professor, Falha> ObterPeloCpf(string cpf);
        Resultado<IEnumerable<Professor>, Falha> ListarProfessores();
    }
}
