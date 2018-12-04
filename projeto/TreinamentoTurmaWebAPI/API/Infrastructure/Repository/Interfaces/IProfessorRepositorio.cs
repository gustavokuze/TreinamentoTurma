using API.Helpers;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure.Repository.Interfaces
{
    public interface IProfessorRepositorio
    {
        void Atualizar(Professor aluno);
        void Excluir(int id);
        void Inserir(Professor aluno);
        Professor ObterPeloIdUsuario(int id);
        Resultado<Professor, Falha> ObterPeloCpf(string email);
        IEnumerable<Professor> ObterTodos();
    }
}
