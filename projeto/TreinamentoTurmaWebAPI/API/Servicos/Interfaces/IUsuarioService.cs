using API.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicos.Interfaces
{
    public interface IUsuarioService
    {
         ObjectResult Inserir(Usuario usuario);
        Usuario ValidarUsuario(int codigo, string senha);
        Usuario BuscarUsuarioPeloCodigo(int codigo);
        Usuario ValidarCodigo(int codigo);
        IEnumerable<Usuario> ObterTodos();
        int GerarCodigoValido(Random random = null);
    }
}
