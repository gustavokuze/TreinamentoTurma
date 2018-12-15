using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Filters;

namespace TreinamentoTurma.Areas.Painel.Controllers
{
    public class DashboardController : Controller
    {

        //[Autenticacao]
        public ActionResult Index()
        {
            return View();  
        }
    }
}

 //if (Session["TreinamentoTurmaUsuarioAtual"] == null)
 //           {
 //               return RedirectToAction("Login", "Usuario", new { Area = "Painel" });
 //           }
 //           else
 //           {
 //               return View();
 //           }