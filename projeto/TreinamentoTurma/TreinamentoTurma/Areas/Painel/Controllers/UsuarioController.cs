using System;
using System.Collections.Generic;
using System.Linq; 
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Areas.Painel.ViewModel;
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
        public ActionResult Login(UsuarioViewModel viewModel)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();
            var usuarioCadastrado = repositorio.VerificarUsuario(viewModel.Usuario.Codigo, viewModel.Usuario.Senha); 

            if(usuarioCadastrado == null)
            {
                return Content("O usuario não foi encontrado");
            }
            else
            {
                if (viewModel.SouProfessor)
                {
                    var professorUsuario = new ProfessorRepositorio().BuscarProfessorPorIdDeUsuario(usuarioCadastrado.Id);
                    if (professorUsuario == null)
                    {
                        return Content("O professor com o codigo passado não foi encontrado.");
                    }
                    else
                    {
                        return Content(professorUsuario.Cpf);
                    } 
                }
                else
                {
                    var alunoUsuario = new AlunoRepositorio().BuscarAlunoPorIdDeUsuario(usuarioCadastrado.Id);
                    if (alunoUsuario == null)
                    {
                        return Content("O aluno com o codigo passado não foi encontrado.");
                    }
                    else
                    {
                        return Content(alunoUsuario.Email);
                    }
                }

                
            }

            //return View();
        }
    }
}