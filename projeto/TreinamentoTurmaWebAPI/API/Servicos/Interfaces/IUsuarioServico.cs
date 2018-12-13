using API.Modelos;
using API.Uteis.Retornos.Validacao;
using System;
using System.Collections.Generic;

namespace API.Servicos.Interfaces
{
    public interface IUsuarioServico
    {
        Resultado<Usuario, Falha> Inserir(Usuario usuario);
        Resultado<Usuario, Falha> ValidarUsuario(int codigo, string senha);
        Resultado<Usuario, Falha> ObterPeloCodigo(int codigo);
        IEnumerable<Usuario> ListarUsuarios();
        int GerarCodigoValido(Random random = null);
        void Excluir(int id);
    }
}
