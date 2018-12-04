using API.Modelos;
using System.Collections.Generic;

namespace API.Infraestrutura.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        int Inserir(Usuario usuario);
        Usuario ValidarUsuario(int codigo, string senha);
        Usuario BuscarUsuarioPeloCodigo(int codigo);
        Usuario ObterPeloCodigo(int codigo);
        IEnumerable<Usuario> ObterTodos();
    }
}