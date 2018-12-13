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
        public AutenticacaoUsuario Autenticar(AutenticacaoUsuario autenticacaoUsuario)
        {//o único erro provavel é o erro de login, aparentemente
            var response = JsonConvert.DeserializeObject<Retorno<AutenticacaoUsuario, Falha>>( RequisitarAPI("login/autenticar", RestSharp.Method.POST, autenticacaoUsuario).Content);
            if (response.Sucesso != null) return response.Sucesso.Objeto;
            return null;
        }
    }
}