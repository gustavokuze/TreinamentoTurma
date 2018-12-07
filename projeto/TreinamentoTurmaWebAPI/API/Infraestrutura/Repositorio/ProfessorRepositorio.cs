using API.Uteis;
using API.Infraestrutura.Repositorio.Interfaces;
using API.Modelos;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq; 
using System.Threading.Tasks;

namespace API.Infraestrutura.Repositorio
{
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private IConfiguration _configuration { get; }
        private string ConnectionString;

        public ProfessorRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        public void Atualizar(Professor professor)
        {
            string query = "UPDATE professor SET Nome = @Nome, Cpf=@Cpf, Telefone = @Telefone, Endereco = @Endereco WHERE IdUsuario = @Id";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                var queryResult = conexao.Execute(query, professor);
            }
        }

        public void Excluir(int id)
        {
            string query = "DELETE FROM professor WHERE IdUsuario = @Id";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                var queryResult = conexao.Execute(query, new { Id = id });
            }
        }

        public void Inserir(Professor professor)
        {
            var query = @"INSERT INTO professor (IdUsuario, Nome, Cpf, Telefone, Endereco)
                        VALUES (@IdUsuario, @Nome, @Cpf, @Telefone, @Endereco);";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                conexao.Execute(query, new { professor.Id, professor.Nome, professor.Cpf, professor.Telefone, professor.Endereco });
            }
        }

        public Professor ObterPeloIdUsuario(int id)
        {
            string query = "SELECT * FROM professor WHERE IdUsuario = @IdUsuario;";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                return conexao.QueryFirstOrDefault<Professor>(query, new { id });
            }
        }

        public Professor ObterPeloCpf(string cpf)
        {
            string query = "SELECT IdUsuario FROM professor WHERE Cpf = @Cpf";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                return conexao.QueryFirstOrDefault<Professor>(query, new { cpf });
            }

        }

        public IEnumerable<Professor> ListarProfessores()
        {
            var query = "SELECT * FROM professor;";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                return conexao.Query<Professor>(query);
            }
        }
    }
}
