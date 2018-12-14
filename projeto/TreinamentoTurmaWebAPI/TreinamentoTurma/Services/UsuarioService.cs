using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinamentoTurma.Helpers.Retornos.API;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Services
{
    public class UsuarioService : BaseService
    {
        public Helpers.Retornos.Validacao.Resultado< AutenticacaoUsuario, Helpers.Retornos.Validacao.Falha> Autenticar(AutenticacaoUsuario autenticacaoUsuario)
        {
            var response = JsonConvert.DeserializeObject<Retorno<AutenticacaoUsuario, Falha>>( RequisitarAPI("login/autenticar", RestSharp.Method.POST, autenticacaoUsuario).Content);
            
            if (response.Sucesso != null) return response.Sucesso.Objeto;
            return new Helpers.Retornos.Validacao.Falha(response.Falha.Mensagem);
        }
    }
}