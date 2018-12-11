using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Helpers.Retornos.Validacao;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Infra
{
    public class ProfessorRepositorio : Repositorio
    {
        public void Inserir(Professor professor)
        {
            string senhaPraBase64 = Base64.ParaBase64(professor.Senha);
            professor.Senha = senhaPraBase64;

            int idUsuario = new UsuarioRepositorio().Inserir(professor as Usuario);
             
            var query = @"INSERT INTO professor (IdUsuario, Nome, Cpf, Telefone, Endereco)
                        VALUES (@IdUsuario, @Nome, @Cpf, @Telefone, @Endereco);";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                conexao.Execute(query, new { idUsuario, professor.Nome, professor.Cpf, professor.Telefone, professor.Endereco});
            }
        }

        public void Atualizar(Professor professor)
        {
            string query = "UPDATE professor SET Nome = @Nome, Cpf=@Cpf, Telefone = @Telefone, Endereco = @Endereco WHERE Id = @Id";

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
        
        public Resultado<Professor, Falha> BuscarProfessor(string cpf)
        {
            string query = "SELECT IdUsuario FROM professor WHERE Cpf = @Cpf";

            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                 var retorno = conexao.QueryFirstOrDefault<Professor>(query, new { cpf });
                if (retorno == null)
                    return new Falha("Usuário não encontrado");
                return retorno;
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