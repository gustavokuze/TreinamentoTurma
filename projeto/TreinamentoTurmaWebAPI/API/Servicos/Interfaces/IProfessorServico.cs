using API.Modelos;
using API.Uteis;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
 