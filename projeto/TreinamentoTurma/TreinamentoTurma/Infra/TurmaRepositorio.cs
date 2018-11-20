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
        public int Inserir(Turma turma)
        {
            /*
             O "SELECT SCOPE_IDENTITY();" na query abaixo, previne que quando formos editar uma turma, 
             o link contenha um parâmetro id, uma vez que esse select retorna null
             */


            string query = "INSERT INTO turma (Descricao,LimiteAlunos) VALUES (@Descricao, @LimiteAlunos); SELECT SCOPE_IDENTITY();";
            
            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                //queryfirst faz a consulta para o primeira registro, ao contrário do query
                //que busca por TODOS os registro e então devolve apenas o primeiro
                return conexao.QueryFirst<int>(query, turma); 
            }
        }

        public List<Turma> ListarTurmas()
        {
            List<Turma> turmas = new List<Turma>();
            string query = "SELECT * FROM turma";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.Query<Turma>(query)
                    .ToList();
            }
        }

        public Turma BuscarTurmaPorId(int id)
        {
            string query = "SELECT * FROM turma WHERE Id = @Id";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirst<Turma>(query, new { id });
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

        public void Excluir(int turmaId)
        {
            string query = "DELETE FROM turma WHERE Id = @Id";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                var queryResult = conexao.Execute(query, new { Id = turmaId });
            }
        }
    }
}