using API.Uteis;
using API.Infraestrutura.Repositorio.Interfaces;
using API.Modelos;
using API.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using API.Uteis.Retornos.Validacao;

namespace API.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        IUsuarioRepositorio _usuarioRepositorio { get; set; }
        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        
        public int GerarCodigoValido(Random random = null)
        {
            int randNum = Geradores.GerarCodigo(random);
            return (_usuarioRepositorio.ObterPeloCodigo(randNum) == null) ? randNum : GerarCodigoValido(random);
        }

        public int Inserir(Usuario usuario)
        {
            try
            {
                usuario.Codigo = GerarCodigoValido();
                usuario.Senha = Base64.ParaBase64( GerarSenha());
                
                return _usuarioRepositorio.Inserir(usuario);
            } 
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IEnumerable<Usuario>  ListarUsuarios()
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
        
        public string GerarSenha()
        {
            return Geradores.GerarSenha();
        }

        public void Excluir(int id)
        {
            _usuarioRepositorio.Excluir(id);
        }
    }
}
