using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Areas.Painel.ViewModel;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Infra;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar(UsuarioViewModel usuarioViewModel)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            var usuarioCadastrado = repositorio.ValidarUsuario(usuarioViewModel.Codigo, 
                Base64.ParaBase64(usuarioViewModel.Senha));

            if (usuarioCadastrado == null)
            {
                ModelState.AddModelError("", "Senha ou código(s) incorreto(s).");
                return View("Index");
            }
            else
            {
                //isso poderia ser validado com um container assim como aluno
                var professorUsuario = new ProfessorRepositorio().BuscarProfessorPorIdDeUsuario(usuarioCadastrado.Id);
                if (professorUsuario == null)
                {
                    var alunoUsuario = new AlunoRepositorio().BuscarAlunoPorIdDeUsuario(usuarioCadastrado.Id);
                    if (alunoUsuario == null)
                    {
                        ModelState.AddModelError("", "Erro interno. O código do usuário está cadastrado mas não existe nenhum professor ou aluno com este código.");
                        return View("Index");
                    }
                    else
                    {
                        alunoUsuario.Codigo = usuarioViewModel.Codigo;
                        Session["TreinamentoTurmaUsuarioAtual"] = alunoUsuario;
                        //return Content($"O email do aluno é: {alunoUsuario.Email}");
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    professorUsuario.Codigo = usuarioViewModel.Codigo;
                    Session["TreinamentoTurmaUsuarioAtual"] = professorUsuario;
                    //return Content($"O CPF do professor é: {professorUsuario.Cpf}");
                    return RedirectToAction("Index", "Home");

                }
            }
        }

        public ActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}