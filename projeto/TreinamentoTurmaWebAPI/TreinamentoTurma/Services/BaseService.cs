using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TreinamentoTurma.Helpers.Retornos.API;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Services
{
    public class BaseService
    {
        public string TokenValido { get; set; }
        public AutenticacaoUsuario UsuarioAtual { get; set; }
        
        public IRestResponse RequisitarAPI(string resource, Method method = Method.GET, object body = null, string token = "")
        {
            //var autenticacaoUsuario = HttpContext.Current.Session["TreinamentoTurmaUsuarioAtual"] as AutenticacaoUsuario;
            //var token = "";
            //if (autenticacaoUsuario != null)
            //{
            //    token = autenticacaoUsuario.Token;
            //}
            var client = new RestClient(new Uri(ConfigurationManager.AppSettings["ApiUri"]));
            var request = new RestRequest(resource, method);
            if (body != null) request.AddJsonBody(body);
            if(token != string.Empty && token != null)
                request.AddHeader("authorization", $"Bearer {token}");
             
            var response = client.Execute(request);
            return response;
        }

       public string RequisitarToken(int codigo, string senha)
        {
            var autenticacao = new UsuarioService().Autenticar(new AutenticacaoUsuario() { Usuario = new Usuario(codigo, senha) });
            if (autenticacao.EstaValido) return autenticacao.Sucesso.Token;
            return "";

        }
    }
}