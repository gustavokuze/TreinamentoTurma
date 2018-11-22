using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var usuarioCadastrado = repositorio.VerificarUsuario(usuario.Codigo, usuario.Senha);

            if(usuarioCadastrado == null)
            {
                return Content("O usuario não foi encontrado");
            }
            else
            {
                var alunoUsuario = new AlunoRepositorio().BuscarAlunoPorCodigoDeUsuario(usuario.Codigo);
                if (alunoUsuario == null)
                {
                    return Content("O aluno com o codigo passado não foi encontrado");
                }
                else
                {
                    return Content(alunoUsuario.Email);
                }
            }

            //return View();
        }
    }
}