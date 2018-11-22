using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Infra
{
    public class ProfessorRepositorio : Repositorio
    {
        public void Inserir(Professor professor)
        {
            int idUsuario = new UsuarioRepositorio().Inserir(professor as Usuario);

            var query = @"INSERT INTO professor (IdUsuario, Nome, Cpf)
                        VALUES (@IdUsuario, @Nome, @Cpf);";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                conexao.Execute(query, new { idUsuario, professor.Nome, professor.Cpf});
            }
        }

        public void Atualizar(Professor professor)
        {
            string query = "UPDATE professor SET Nome = @Nome, Cpf=@Cpf WHERE Id = @Id";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                var queryResult = conexao.Execute(query, professor);
            }
        }

        public void Excluir(int professorId)
        {
            string query = "DELETE FROM professor WHERE Id = @Id";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                var queryResult = conexao.Execute(query, new { Id = professorId });
            }
        }

        public List<Professor> ListarProfessors()
        {
            List<Professor> turmas = new List<Professor>();
            string query = "SELECT * FROM professor";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.Query<Professor>(query)
                    .ToList();
            }
        }
        
        public Professor BuscarProfessor(string cpf)
        {
            string query = "SELECT * FROM professor WHERE Cpf = @Cpf";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirstOrDefault<Professor>(query, new { cpf });
            }

        }

        public Professor BuscarProfessorPorIdDeUsuario(int idUsuario)
        {
            string query = "SELECT * FROM professor WHERE IdUsuario = @IdUsuario;";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirstOrDefault<Professor>(query, new { idUsuario });
            }

        }
    }
}