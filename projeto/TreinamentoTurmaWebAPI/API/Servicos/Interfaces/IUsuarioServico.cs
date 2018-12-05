using API.Modelos;
using API.Uteis;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servicos.Interfaces
{
    public interface IUsuarioServico
    {
        int Inserir(Usuario usuario);
        Resultado<Usuario, Falha> ValidarUsuario(int codigo, string senha);
        Resultado<Usuario, Falha> ObterPeloCodigo(int codigo);
        IEnumerable<Usuario> ListarUsuarios();
        int GerarCodigoValido(Random random = null);
        void Excluir(int id);
    }
}
