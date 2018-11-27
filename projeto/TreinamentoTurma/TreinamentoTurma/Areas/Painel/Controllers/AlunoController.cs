using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Filters;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Infra;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.Controllers
{
    [Autenticacao]
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
            if (repositorio.BuscarAluno(aluno.Id) is var retorno && retorno.EstaValido)
            {
                ModelState.AddModelError("", $"O email {aluno.Email} já está cadastrado");
                return View();
            }
            else
            {
                repositorio.Inserir(aluno);
                TempData["Sucesso"] = $"Aluno cadastrado com sucesso. Anote sua senha: {aluno.Senha}.";
            }
            
            return RedirectToAction("Cadastrar");
        }
        
    }
}