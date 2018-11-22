using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Infra
{
    public class AlunoRepositorio : Repositorio
    {
      

        public int Inserir(Aluno aluno)
        {
            
            int idUsuario = new UsuarioRepositorio().Inserir(aluno as Usuario);

            var query = "INSERT INTO aluno (IdUsuario, Nome, Email, DataNascimento) VALUES (@IdUsuario, @Nome, @Email, @DataNascimento) ;"; //precisamos criar uma variável aqui

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirstOrDefault<int>(query, new { idUsuario, aluno.Nome, aluno.Email, aluno.DataNascimento }); 
            }
        }

        public void Atualizar(Aluno aluno)
        {
            string query = "UPDATE aluno SET Nome = @Nome, Email = @Email, DataNascimento = @DataNascimento WHERE Id = @Id";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                var queryResult = conexao.Execute(query, aluno);
            }
        }

        public void Excluir(int alunoId)
        {
            string query = "DELETE FROM aluno WHERE Id = @Id";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                var queryResult = conexao.Execute(query, new { Id = alunoId });
            }
        }

        public List<Aluno> ListarAlunos()
        {
            List<Aluno> turmas = new List<Aluno>();
            string query = "SELECT * FROM aluno";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.Query<Aluno>(query)
                    .ToList();
            }
        }

        public Aluno BuscarAluno(int id)
        {
            string query = "SELECT * FROM aluno WHERE Id = @Id";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirstOrDefault<Aluno>(query, new { id });
            }

        }

        public Aluno BuscarAluno(string email)
        {
            string query = "SELECT * FROM aluno WHERE Email = @Email";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirstOrDefault<Aluno>(query, new { email });
            }

        }

        public Aluno BuscarAlunoPorCodigoDeUsuario(int codigo)
        {
            string query = "SELECT * FROM aluno WHERE IdUsuario = @IdUsuario";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirstOrDefault<Aluno>(query, new { codigo });
            }

        }
    }
}