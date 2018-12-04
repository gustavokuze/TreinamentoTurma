using API.Models;
using System.Collections.Generic;

namespace API.Infrastructure.Repository.Interfaces
{
    public interface IUsuarioRepositorio
    {
        int Inserir(Usuario usuario);
        Usuario ValidarUsuario(int codigo, string senha);
        Usuario BuscarUsuarioPeloCodigo(int codigo);
        Usuario ValidarCodigo(int codigo);
        IEnumerable<Usuario> ObterTodos();

    }
}