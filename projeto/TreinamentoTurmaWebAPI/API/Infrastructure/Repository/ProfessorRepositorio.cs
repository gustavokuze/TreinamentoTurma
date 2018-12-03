using API.Helpers;
using API.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq; 
using System.Threading.Tasks;

namespace API.Infrastructure.Repository
{
    public class ProfessorRepositorio 
    {
        private IConfiguration _configuration;
        private string connectionString;

        public ProfessorRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        public void Atualizar(Professor professor)
        {
            string query = "UPDATE professor SET Nome = @Nome, Cpf=@Cpf, Telefone = @Telefone, Endereco = @Endereco WHERE Id = @Id";

            using (var conexao = new SqlConnection(connectionString))
            {
                var queryResult = conexao.Execute(query, professor);
            }
        }

        public void Excluir(int id)
        {
            string query = "DELETE FROM professor WHERE Id = @Id";

            using (var conexao = new SqlConnection(connectionString))
            {
                var queryResult = conexao.Execute(query, new { Id = id });
            }
        }

        public void Inserir(Professor professor)
        {
            string senhaPraBase64 = Base64.ParaBase64(professor.Senha);
            professor.Senha = senhaPraBase64;

            int idUsuario = new UsuarioRepositorio(_configuration).Inserir(professor as Usuario);

            var query = @"INSERT INTO professor (IdUsuario, Nome, Cpf, Telefone, Endereco)
                        VALUES (@IdUsuario, @Nome, @Cpf, @Telefone, @Endereco);";

            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Execute(query, new { idUsuario, professor.Nome, professor.Cpf, professor.Telefone, professor.Endereco });
            }
        }

        public Professor ObterPeloIdUsuario(int id)
        {
            string query = "SELECT * FROM professor WHERE IdUsuario = @IdUsuario;";

            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.QueryFirstOrDefault<Professor>(query, new { id });
            }

        }

        public Resultado<Professor, Falha> ObterPeloCpf(string cpf)
        {
            string query = "SELECT IdUsuario FROM professor WHERE Cpf = @Cpf";

            using (var conexao = new SqlConnection(connectionString))
            {
                var retorno = conexao.QueryFirstOrDefault<Professor>(query, new { cpf });
                if (retorno == null)
                    return new Falha("Usuário não encontrado");
                return retorno;
            }

        }

        public IEnumerable<Professor> ObterTodos()
        {
            var query = "SELECT * FROM professor;";

            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.Query<Professor>(query);
            }
        }
    }
}
