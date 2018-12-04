using API.Uteis;
using API.Infraestrutura.Repositorio.Interfaces;
using API.Modelos;
using API.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicos
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        
        public int GerarCodigoValido(Random random = null)
        {
            //rever isso aqui pra usar o util
            var rand = (random == null) ? new Random() : random;
            int randNum = rand.Next(100000, 999999);

            return (_usuarioRepositorio.ObterPeloCodigo(randNum) == null) ? randNum : GerarCodigoValido(rand);
        }

        public string Inserir(Usuario usuario)
        {
            try
            {
                //talvez verificar aqui se a senha e o código estão presentes
                _usuarioRepositorio.Inserir(usuario);
                return "Usuário inserido com sucesso";
            } 
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<Usuario>  ObterTodos()
        {
            return _usuarioRepositorio.ObterTodos();
        }

        public Resultado<Usuario, Falha> ObterPeloCodigo(int codigo)
        {
            var usuario = _usuarioRepositorio.ObterPeloCodigo(codigo);
            if (usuario == null) new Falha("Usuário não encontrado") ;
            return usuario;
        }

        public Resultado<Usuario, Falha> ValidarUsuario(int codigo, string senha)
        {
            var usuario = _usuarioRepositorio.ValidarUsuario(codigo, senha);
            if (usuario == null)  return new Falha("Senha ou Código inválido(s)");
            return usuario;
        }
        
        public int GerarSenha()
        {
            throw new NotImplementedException();
        }
    }
}
