using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Helpers.Retornos.API;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Services.Interfaces
{
    public interface IAlunoService
    {
        void Atualizar(Aluno aluno);
        void Excluir(int id);
        void Cadastrar(Aluno aluno);
        Resultado<Aluno, Helpers.Retornos.API.Falha> ObterPeloIdUsuario(int id);
        Resultado<Aluno, Helpers.Retornos.API.Falha> ObterPeloEmail(string email);
        IEnumerable<Aluno> ListarAlunosAsync();
    }
}
