using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Filters
{
    public class AutenticacaoAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var usuarioAtual = Login.ObterUsuarioAtualObject();

            /*
                pesquisar como saber se uma chave existe dentro de um objeto
                ex: se aluno existe em usuarioAtual ou se professor existe


                Se isso não funcionar eu preciso talvez criar um quarto tipo de Model AutenticacaoAlgumaCoisa, que além de conter 
                a autenticação em sí, vai conter o tipo de autenticação contida nela
             
            */

            if (usuarioAtual != null)
            {

                var usuarioAtualType = usuarioAtual.GetType().Name ;

                if ((usuarioAtualType == "AutenticacaoAluno" && Roles == "_ALUNO_") ||
                     (usuarioAtualType == "AutenticacaoProfessor"
                        && Roles == "_PROFESSOR_") ||
                        string.IsNullOrEmpty(Roles))
                {
                    return true;
                }
            }

            return false; //apenas pra teste tornei true que permite tudo
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //HttpContext.Current.Session.Clear();
            if (Login.ObterUsuarioAtual() != null)
            {
                filterContext.Controller.TempData["NaoAutorizado"] = "Seu usuário não tem permissão para acessar esse conteúdo";
                filterContext.Result = new RedirectResult("/Painel/Dashboard");
            }
            else
            {
                filterContext.Result = new RedirectResult("/Login");
            }
        }

    }
}