using API.Uteis;
using API.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infraestrutura.Repositorio.Interfaces
{
    public interface IProfessorRepositorio
    {
        void Atualizar(Professor aluno);
        void Excluir(int id);
        void Inserir(Professor aluno);
        Professor ObterPeloIdUsuario(int id);
        Professor ObterPeloCpf(string email);
        IEnumerable<Professor> ListarProfessores();
    }
}
