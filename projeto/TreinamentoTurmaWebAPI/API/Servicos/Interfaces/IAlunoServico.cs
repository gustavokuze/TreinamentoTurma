using API.Modelos;
using API.Uteis.Retornos.Validacao;
using System.Collections.Generic;

namespace API.Servicos.Interfaces
{
    public interface IAlunoServico
    {
        void Atualizar(Aluno aluno);
        void Excluir(int id);
        void Cadastrar(Aluno aluno);
        Resultado<Aluno, Falha> ObterPeloIdUsuario(int id);
        Resultado<Aluno, Falha> ObterPeloEmail(string email);
        IEnumerable<Aluno> ListarAlunos();
    }
}
 