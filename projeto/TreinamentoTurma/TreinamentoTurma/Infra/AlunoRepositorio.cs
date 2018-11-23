using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Infra
{
    public class AlunoRepositorio : Repositorio
    {
      
        public void Inserir(Aluno aluno)
        {
            string senhaPraBase64 = Base64.ParaBase64(aluno.Senha);
            aluno.Senha = senhaPraBase64;

            int idUsuario = new UsuarioRepositorio().Inserir(aluno as Usuario);

            var query = @"INSERT INTO aluno (IdUsuario, Nome, Email, DataNascimento)
                        VALUES (@IdUsuario, @Nome, @Email, @DataNascimento);";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                conexao.Execute(query, new { idUsuario, aluno.Nome, aluno.Email, aluno.DataNascimento }); 
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

        //não está sendo usado no momento
        //public Aluno BuscarAluno(int id)
        //{
        //    string query = "SELECT * FROM aluno WHERE Id = @Id";

        //    using (var conexao = new SqlConnection(ObterConnectionString))
        //    {
        //        return conexao.QueryFirstOrDefault<Aluno>(query, new { id });
        //    }

        //}

        public Aluno BuscarAluno(string email)
        {
            string query = "SELECT * FROM aluno WHERE Email = @Email";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirstOrDefault<Aluno>(query, new { email });
            }

        } 

        public Aluno BuscarAlunoPorIdDeUsuario(int idUsuario)
        {
            string query = "SELECT * FROM aluno WHERE IdUsuario = @IdUsuario;";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirstOrDefault<Aluno>(query, new { idUsuario });
            }

        }
    }
}