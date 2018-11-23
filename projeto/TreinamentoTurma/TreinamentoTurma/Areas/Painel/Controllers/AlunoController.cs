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
            if (repositorio.BuscarAluno(aluno.Email) == null)
            {
                var codigoUsuario = Geradores.GerarCodigoValido();
                var senhaUsuario = Geradores.GerarSenha();
                aluno.Codigo = codigoUsuario;
                aluno.Senha = senhaUsuario;

                repositorio.Inserir(aluno);
                TempData["Sucesso"] = $"Aluno cadastrado com sucesso. Anote sua senha: {senhaUsuario}.";
            }
            else
            {
                ModelState.AddModelError("", $"O email {aluno.Email} já está cadastrado");
            }
            
            return RedirectToAction("Cadastrar");
        }
        
        

    }
}