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
    public class AlunoRepositorio
    {
        private string connectionString;
        private IConfiguration _configuration;

        public AlunoRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        public void Atualizar(Aluno aluno)
        {
            string query = "UPDATE aluno SET Nome = @Nome, Email = @Email, DataNascimento = @DataNascimento, Telefone = @Telefone, Endereco = @Endereco WHERE Id = @Id";

            using (var conexao = new SqlConnection(connectionString))
            {
                var queryResult = conexao.Execute(query, aluno);
            }
        }

        public void Excluir(int id)
        {
            string query = "DELETE FROM aluno WHERE IdUsuario = @IdUsuario";

            using (var conexao = new SqlConnection(connectionString))
            {
                var queryResult = conexao.Execute(query, new { IdUsuario = id });
            }
        }

        public void Inserir(Aluno aluno)
        {
            string senhaPraBase64 = Base64.ParaBase64(aluno.Senha);
            aluno.Senha = senhaPraBase64;

            int idUsuario = new UsuarioRepositorio(_configuration).Inserir(aluno as Usuario);

            var query = @"INSERT INTO aluno (IdUsuario, Nome, Email, DataNascimento, Telefone, Endereco)
                        VALUES (@IdUsuario, @Nome, @Email, @DataNascimento, @Telefone, @Endereco);";

            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Execute(query, new { idUsuario, aluno.Nome, aluno.Email, aluno.DataNascimento, aluno.Telefone, aluno.Endereco });
            }
        }

        public Aluno ObterPeloIdUsuario(int id)
        {
            string query = "SELECT * FROM aluno WHERE IdUsuario = @IdUsuario;";

            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.QueryFirstOrDefault<Aluno>(query, new { id });
            }

        }

        public Resultado<Aluno, Falha> ObterPeloEmail(string email)
        {
            string query = "SELECT * FROM aluno WHERE Email = @Email";

            using (var conexao = new SqlConnection(connectionString))
            {
                var retorno = conexao.QueryFirstOrDefault<Aluno>(query, new { email });
                if (retorno == null)
                    return new Falha("Usuário não encontrado");
                return retorno;
            }
        }

        public IEnumerable<Aluno> ObterTodos()
        {
            var query = "SELECT * FROM aluno;";

            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.Query<Aluno>(query);
            }
        }
    }
}
