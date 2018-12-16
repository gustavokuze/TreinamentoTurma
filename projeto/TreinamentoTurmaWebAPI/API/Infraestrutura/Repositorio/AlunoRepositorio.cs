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
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private string ConnectionString;
        private IConfiguration _configuration { get; }

        public AlunoRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        public void Atualizar(Aluno aluno)
        {
            string query = "UPDATE aluno SET Nome = @Nome, Email = @Email, DataNascimento = @DataNascimento, Telefone = @Telefone, Endereco = @Endereco WHERE IdUsuario = @Id";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                var queryResult = conexao.Execute(query, aluno);
            }
        }

        public void Excluir(int id)
        {
            string query = "DELETE FROM aluno WHERE IdUsuario = @Id;";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                var queryResult = conexao.Execute(query, new { id });
            }
        }

        public void Inserir(Aluno aluno)
        {
            var query = @"INSERT INTO aluno (IdUsuario, Nome, Email, DataNascimento, Telefone, Endereco)
                        VALUES (@Id, @Nome, @Email, @DataNascimento, @Telefone, @Endereco);";

            using (var conexao = new SqlConnection(ConnectionString))
            {    
                //ao invés de aluno.Id era IdUsuario antes da API
                conexao.Execute(query, new { aluno.Id, aluno.Nome, aluno.Email, aluno.DataNascimento, aluno.Telefone, aluno.Endereco });
            }
        }

        public Aluno ObterPeloIdUsuario(int id)
        {
            string query = "select aluno.IdUsuario as Id, aluno.Nome, aluno.Email, aluno.DataNascimento, aluno.Telefone, aluno.Endereco, usuario.Codigo from aluno inner join usuario on aluno.IdUsuario = usuario.Id where aluno.IdUsuario = @Id; ";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                return conexao.QueryFirstOrDefault<Aluno>(query, new { id });
            }
            /*
             pra buscar a senha e código(s) junto(s), a query seria:
             select aluno.*, usuario.Codigo, usuario.Senha from aluno inner join usuario on aluno.IdUsuario = usuario.Id;
             */

        }

        public Aluno ObterPeloEmail(string email)
        {
            string query = "select aluno.IdUsuario as Id, aluno.Nome, aluno.Email, aluno.DataNascimento, aluno.Telefone, aluno.Endereco, usuario.Codigo from aluno inner join usuario on aluno.IdUsuario = usuario.Id where aluno.Email = @Email; "; ;

            using (var conexao = new SqlConnection(ConnectionString))
            {
                return conexao.QueryFirstOrDefault<Aluno>(query, new { email });
            }
        }

        public IEnumerable<Aluno> ListarAlunos()
        {
            var query = "select aluno.IdUsuario as Id, aluno.Nome, aluno.Email, aluno.DataNascimento, aluno.Telefone, aluno.Endereco, usuario.Codigo, usuario.Senha from aluno inner join usuario on aluno.IdUsuario = usuario.Id;"; ;

            using (var conexao = new SqlConnection(ConnectionString))
            {
                return conexao.Query<Aluno>(query);
            }
            //List<Aluno> alunos = new List<Aluno>(); //teste
            //return alunos;
        }
    }
}
