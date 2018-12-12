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
                        alunoUsuario.Senha = usuarioCadastrado.Senha;
                        
                        /*
                         Aqui eu deveria criar uma nova instancia de AutenticacaoAluno e passar isso para o objeto da Session
                         */

                        Session["TreinamentoTurmaUsuarioAtual"] = alunoUsuario;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    professorUsuario.Codigo = usuarioViewModel.Codigo;
                    professorUsuario.Senha = usuarioCadastrado.Senha;

                    /*
                     Aqui eu deveria criar uma nova instancia de AutenticacaoProfessor e passar isso para o objeto da Session
                     */

                    Session["TreinamentoTurmaUsuarioAtual"] = professorUsuario;
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