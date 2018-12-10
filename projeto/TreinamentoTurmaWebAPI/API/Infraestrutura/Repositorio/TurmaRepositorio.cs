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
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private string connectionString;
        private IConfiguration _configuration { get; }

        public TurmaRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        public int Inserir(Turma turma)
        {
            string query = "INSERT INTO turma (Descricao,LimiteAlunos) VALUES (@Descricao, @LimiteAlunos); SELECT SCOPE_IDENTITY();";

            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.QueryFirst<int>(query, turma);
            }
        }

        public void Atualizar(Turma turma)
        {
            string query = "UPDATE turma SET Descricao = @Descricao, LimiteAlunos = @LimiteAlunos WHERE Id = @Id";

            using (var conexao = new SqlConnection(connectionString))
            {
                var queryResult = conexao.Execute(query, turma);
            }
        }

        public void Excluir(int id)
        {
            string query = "DELETE FROM turma WHERE Id = @Id";

            using (var conexao = new SqlConnection(connectionString))
            {
                var queryResult = conexao.Execute(query, new { Id = id });
            }
        }

        public Turma ObterPeloId(int id)
        {
            string query = "SELECT * FROM turma WHERE Id = @Id";

            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.QueryFirstOrDefault<Turma>(query, new { id });
            }
        }

        public IEnumerable<Turma> ListarTurmas()
        {
            var query = "SELECT * FROM turma;";

            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.Query<Turma>(query);
            }
        }

        public void InserirInscricao(Inscricao inscricao)
        {
            string query = "INSERT INTO inscricao (AlunoId, TurmaId, InscritoEm) VALUES (@AlunoId, @TurmaId, @InscritoEm)";
            using (var conexao = new SqlConnection(connectionString))
            {
                var queryResult = conexao.Execute(query, inscricao);
            }
        }
        
        public void ExcluirInscricao(int inscricaoId)
        {
            string query = "DELETE FROM inscricao WHERE Id = @Id";

            using (var conexao = new SqlConnection(connectionString))
            {
                var queryResult = conexao.Execute(query, new { Id = inscricaoId });
            }
        }
        
        public Inscricao ObterInscricao(int alunoId, int turmaId)
        {
            string query = "SELECT * FROM inscricao WHERE AlunoId = @AlunoId AND TurmaId = @TurmaId";

            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.QueryFirstOrDefault<Inscricao>(query, new { alunoId, turmaId });
            }
        }
        
        public Inscricao ObterInscricaoPeloAlunoId(int alunoId)
        {
            string query = "SELECT * FROM inscricao WHERE AlunoId = @AlunoId";

            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.QueryFirstOrDefault<Inscricao>(query, new { alunoId });
            }
        }

        public IEnumerable<Inscricao> ListarInscricoesPeloTurmaId(int turmaId)
        {
            string query = "SELECT * FROM inscricao WHERE TurmaId = @TurmaId";

            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.Query<Inscricao>(query, new { turmaId });
            }
        }

        public void ExcluirInscricoesPeloAlunoId(int alunoId)
        {
            string query = "DELETE FROM inscricao WHERE AlunoId = @AlunoId";

            using (var conexao = new SqlConnection(connectionString))
            {
                var queryResult = conexao.Execute(query, new { alunoId });
            }
        }

        public void ExcluirInscricoesPeloTurmaId(int turmaId)
        {
            string query = "DELETE FROM inscricao WHERE TurmaId = @TurmaId";

            using (var conexao = new SqlConnection(connectionString))
            {
                var queryResult = conexao.Execute(query, new { turmaId });
            }
        }

        public IEnumerable<Inscricao> ListarInscricoesPeloAlunoId(int alunoId)
        {
            string query = "SELECT * FROM inscricao WHERE AlunoId = @AlunoId";

            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.Query<Inscricao>(query, new { alunoId });
            }
        }

    }
}
