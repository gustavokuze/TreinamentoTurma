using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Areas.Painel.ViewModel;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Infra;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Painel/Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            var usuarioCadastrado = repositorio.ValidarUsuario(usuario.Codigo, Base64.ParaBase64(usuario.Senha) );
            
            Session["TreinamentoTurmaUsuarioAtual"] = usuario;
            
            if (usuarioCadastrado == null)
            {
                return Content("O usuario não foi encontrado");
            }
            else
            {
                var professorUsuario = new ProfessorRepositorio().BuscarProfessorPorIdDeUsuario(usuarioCadastrado.Id);
                if (professorUsuario == null)
                {
                    var alunoUsuario = new AlunoRepositorio().BuscarAlunoPorIdDeUsuario(usuarioCadastrado.Id);
                    if (alunoUsuario == null)
                    {
                        return Content("Erro interno. O código do usuário está cadastrado mas não existe nenhum professor ou aluno com este código.");
                    }
                    else
                    {
                        return Content($"O email do aluno é: {alunoUsuario.Email}");
                    }
                }
                else
                {
                    return Content($"O CPF do professor é: {professorUsuario.Cpf}");

                }
            }

            //return View();
        }
    }
}