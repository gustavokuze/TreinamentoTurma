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

            /*O ERRO que ta acontecendo aqui é por que na primeira vez a senha vem decidoficada e a segunda vez não, preciso
             descobrir onde seria a melhor parte pra decodificar a senha*/

            if (autenticacaoUsuario == null) return new Helpers.Retornos.Validacao.Falha("Informe um usuário para autenticar");
            var response = JsonConvert.DeserializeObject<Retorno<AutenticacaoUsuario, Falha>>( RequisitarAPI("login/autenticar", RestSharp.Method.POST, autenticacaoUsuario).Content);
            
            if (response.Falha == null) return response.Sucesso.Objeto;
            return new Helpers.Retornos.Validacao.Falha(response.Falha.Mensagem);
        }
    }
}