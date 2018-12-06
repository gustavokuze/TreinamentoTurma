using API.Modelos;
using API.Uteis.Retornos.Validacao;
using System.Collections.Generic;

namespace API.Servicos.Interfaces
{
    public interface IProfessorServico
    {
        void Atualizar(Professor professor);
        void Excluir(int id);
        void Cadastrar(Professor professor);
        Resultado<Professor, Falha> ObterPeloIdUsuario(int id);
        Resultado<Professor, Falha> ObterPeloCpf(string cpf);
        IEnumerable<Professor> ListarProfessores();
    }
}
 