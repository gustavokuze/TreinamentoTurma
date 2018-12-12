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
        public IRestResponse RequisitarAPI(string resource, Method method = Method.GET)
        {
            var autenticacaoUsuario = HttpContext.Current.Session["TreinamentoTurmaUsuarioAtual"] as AutenticacaoUsuario;
            var token = "";
            if (autenticacaoUsuario != null)
            {
                token = autenticacaoUsuario.Token;
            }
            var client = new RestClient(new Uri(ConfigurationManager.AppSettings["ApiUri"]));
            var request = new RestRequest(resource, method);
            if(token != string.Empty && token != null)
                request.AddHeader("authorization", $"Bearer {token}");

            var response = client.Execute(request);
            return response;
        }
    }
}