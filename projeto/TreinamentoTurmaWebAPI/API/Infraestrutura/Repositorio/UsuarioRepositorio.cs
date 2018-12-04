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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private IConfiguration _configuration;
        private string connectionString;

        public UsuarioRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString"); 
        }
        
        public int Inserir(Usuario usuario)
        {
            string query = "INSERT INTO usuario (Codigo, Senha) VALUES (@Codigo, @Senha);SELECT SCOPE_IDENTITY();";
            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.QueryFirst<int>(query, new { usuario.Codigo, usuario.Senha });
            }
        }

        public Usuario ValidarUsuario(int codigo, string senha)
        {
            string query = "SELECT * FROM usuario where Codigo = @Codigo AND Senha = @Senha";
            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.QueryFirstOrDefault<Usuario>(query, new { codigo, senha });
            }
        }

        public Usuario BuscarUsuarioPeloCodigo(int codigo)
        {
            string query = "SELECT * FROM usuario where Codigo = @Codigo";
            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.QueryFirstOrDefault<Usuario>(query, new { codigo });
            }
        }

        public Usuario ObterPeloCodigo(int codigo)
        {
            string query = "SELECT * FROM usuario where Codigo = @Codigo";
            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.QueryFirstOrDefault<Usuario>(query, new { codigo });
            }
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            var query = "SELECT * FROM usuario;";

            using (var conexao = new SqlConnection(connectionString))
            {
                return conexao.Query<Usuario>(query);
            }
        }
        
    }
}
