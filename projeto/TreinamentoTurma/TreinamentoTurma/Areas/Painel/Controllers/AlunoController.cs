using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Infra;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Painel/Aluno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Aluno aluno)
        {
            AlunoRepositorio repositorio = new AlunoRepositorio();
            if (repositorio.BuscarAluno(aluno.Email) == null)
            {
                repositorio.Inserir(aluno);
            }
            else
            {
                ModelState.AddModelError("", $"O email {aluno.Email} já está cadastrado");
            }
            
            return View(new Aluno());
        }
        
    }
}