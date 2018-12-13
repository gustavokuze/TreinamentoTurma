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
        private IConfiguration _configuration { get; }
        private string ConnectionString;

        public UsuarioRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = configuration.GetValue<string>("DBInfo:ConnectionString"); 
        }
        
        public Usuario Inserir(Usuario usuario)
        {
            string query = "INSERT INTO usuario (Codigo, Senha) VALUES (@Codigo, @Senha);SELECT SCOPE_IDENTITY();";
            using (var conexao = new SqlConnection(ConnectionString))
            {
                int id = conexao.QueryFirst<int>(query, new { usuario.Codigo, usuario.Senha });
                usuario.Id = id;
                return usuario;
            }
        }

        public Usuario ValidarUsuario(int codigo, string senha)
        {
            string query = "SELECT * FROM usuario where Codigo = @Codigo AND Senha = @Senha";
            using (var conexao = new SqlConnection(ConnectionString))
            {
                return conexao.QueryFirstOrDefault<Usuario>(query, new { codigo, senha });
            }
        }

        public Usuario BuscarUsuarioPeloCodigo(int codigo)
        {
            string query = "SELECT * FROM usuario where Codigo = @Codigo";
            using (var conexao = new SqlConnection(ConnectionString))
            {
                return conexao.QueryFirstOrDefault<Usuario>(query, new { codigo });
            }
        }

        public Usuario ObterPeloCodigo(int codigo)
        {
            string query = "SELECT * FROM usuario where Codigo = @Codigo";
            using (var conexao = new SqlConnection(ConnectionString))
            {
                return conexao.QueryFirstOrDefault<Usuario>(query, new { codigo });
            }
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            var query = "SELECT * FROM usuario;";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                return conexao.Query<Usuario>(query);
            }
        }
        
        public void Excluir(int id)
        {
            var query = "DELETE FROM usuario WHERE Id=@Id;";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                conexao.Execute(query, new { id });
            }
        }
        
    }
}
