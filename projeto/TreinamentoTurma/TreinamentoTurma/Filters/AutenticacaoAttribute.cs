using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreinamentoTurma.Filters
{
    public class AutenticacaoAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["TreinamentoTurmaUsuarioAtual"] == null)
            {
                return false;
            }
            return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            HttpContext.Current.Session.Clear();
            filterContext.Result = new RedirectResult("/Painel/Usuario/Login");
        }
    }
}