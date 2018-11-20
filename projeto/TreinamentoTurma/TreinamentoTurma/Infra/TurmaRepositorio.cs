using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TreinamentoTurma.Models;  

namespace TreinamentoTurma.Infra
{
    public class TurmaRepositorio : Repositorio 
    {
        public void Inserir(Turma turma)
        {
            string query = "INSERT INTO turma (Descricao,LimiteAlunos) VALUES (@Descricao, @LimiteAlunos)";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                var queryResult = conexao.Execute(query, turma);
            }
        }

        public List<Turma> ListarTurmas()
        {
            List<Turma> turmas = new List<Turma>();
            string query = "SELECT * FROM turma";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                var queryResult = conexao.Query<Turma>(query);
                turmas = queryResult.ToList();
            }

            return turmas;
        }

        public Turma BuscarTurmaPorId(int id)
        {
            string query = "SELECT * FROM turma WHERE Id = @Id";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                var queryResult = conexao.Query<Turma>(query, new {Id = id } );
                return queryResult.SingleOrDefault();
            }
            
        }

        public void Atualizar(Turma turma)
        {
            string query = "UPDATE turma SET Descricao = @Descricao, LimiteAlunos = @LimiteAlunos WHERE Id = @Id";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                var queryResult = conexao.Execute(query, turma);
            }
        }

        public void Excluir(Turma turma)
        {
            string query = "DELETE FROM turma WHERE Id = @Id";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                var queryResult = conexao.Execute(query, turma);
            }
        }
    }
}