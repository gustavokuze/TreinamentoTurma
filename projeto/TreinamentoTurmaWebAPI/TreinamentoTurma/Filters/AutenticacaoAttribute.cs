using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Filters
{
    public class AutenticacaoAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["TreinamentoTurmaUsuarioAtual"] != null)
            {
                if (    (httpContext.Session["TreinamentoTurmaUsuarioAtual"] is Aluno && Roles == "_ALUNO_")    ||
                        (httpContext.Session["TreinamentoTurmaUsuarioAtual"] is Professor && Roles == "_PROFESSOR_")    ||
                        string.IsNullOrEmpty(Roles) )
                {
                    return true; 
                }
            }

            return true; //apenas pra teste tornei true que permite tudo
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //HttpContext.Current.Session.Clear();
            filterContext.Result = new RedirectResult("/Login"); 
        }
        
    }
}