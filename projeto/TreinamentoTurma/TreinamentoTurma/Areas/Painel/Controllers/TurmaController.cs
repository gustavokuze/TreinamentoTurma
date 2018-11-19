using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Infra;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.Controllers
{
    public class TurmaController : Controller
    {
        // GET: Painel/Turma
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Turma turma)
    {

            if (!ModelState.IsValid)
            {
                return View(turma);
            }

            TurmaRepositorio turmaRepositorio = new TurmaRepositorio();
            turmaRepositorio.Novo(turma);

            return View();
        }


        public ActionResult Inscricao()
        {
            List<SelectListItem> turmas = new List<SelectListItem>();
            turmas.Add(new SelectListItem()
            {
                Text = "Turma de programação .Net",
                Value = "1" 
            });

            turmas.Add(new SelectListItem()
            {
                Text = "Turma de programação Java",
                Value = "2"
            });

            turmas.Add(new SelectListItem()
            {
                Text = "Turma de programação PHP",
                Value = "3"
            });

            ViewBag.Turmas = turmas;

            return View();
        }

        [HttpPost]
        public ActionResult Inscricao(Inscricao inscricao)
        {
            

            return View();
        }
    }
}