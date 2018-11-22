using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Infra
{
    public class UsuarioRepositorio : Repositorio
    {
        public int Inserir(Usuario usuario)
        {
            string query = "INSERT INTO usuario (Codigo, Senha) VALUES (@Codigo, @Senha);SELECT SCOPE_IDENTITY();";
            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirst<int>(query, new { usuario.Codigo, usuario.Senha });
            }
        }
         
        public Usuario VerificarUsuario(int codigo, string senha)
        {
            string query = "SELECT * FROM usuario where Codigo = @Codigo AND Senha = @Senha";
            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirstOrDefault<Usuario>(query, new { codigo, senha });
            }
        }

        public Usuario BuscarUsuarioPeloCodigo(int codigo)
        {
            string query = "SELECT * FROM usuario where Codigo = @Codigo";
            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirstOrDefault<Usuario>(query, new { codigo});
            }
        }

        public Usuario ValidarCodigo(int codigo) 
        {
            string query = "SELECT * FROM usuario where Codigo = @Codigo";
            using (var conexao = new SqlConnection(ObterConnectionString))
            {
                return conexao.QueryFirstOrDefault<Usuario>(query, new { codigo });
            }
        }

        
    }
}