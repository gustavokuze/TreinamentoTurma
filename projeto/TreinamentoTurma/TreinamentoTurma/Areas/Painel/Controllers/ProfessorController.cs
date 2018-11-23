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
            if (repositorio.BuscarProfessor(professor.Cpf) == null)
            {
                var codigoUsuario = Geradores.GerarCodigoValido();
                var senhaUsuario = Geradores.GerarSenha();
                professor.Codigo = codigoUsuario;
                professor.Senha = senhaUsuario;

                repositorio.Inserir(professor);
                TempData["Sucesso"] = $"Professor cadastrado com sucesso. Anote sua senha: {senhaUsuario}.";
            }
            else
            {
                ModelState.AddModelError("", $"O CPF {professor.Cpf} já está cadastrado");
            }

            return RedirectToAction("Cadastrar");
        }

        
    }
}