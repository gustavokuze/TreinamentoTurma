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
    [Autenticacao(Roles = "_PROFESSOR_")]
    public class ProfessorController : Controller
    {
        // GET: Painel/Professor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Professor professor) 
        {
            ProfessorRepositorio repositorio = new ProfessorRepositorio(); 
            if (repositorio.ProfessorJaCadastrado(professor.Cpf))
            {
                ModelState.AddModelError("", $"O CPF {professor.Cpf} já está cadastrado");
                return View();
            }
            else
            {
                repositorio.Inserir(professor);
                TempData["Sucesso"] = $"Professor cadastrado com sucesso. Anote sua senha: {professor.Senha}.";
            }

            return RedirectToAction("Cadastrar");
        }

        
    }
}