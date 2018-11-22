using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Infra;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.Controllers
{
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
                var codigoUsuario = GerarCodigoValido();
                var senhaUsuario = GerarSenha();
                professor.Codigo = codigoUsuario;
                professor.Senha = senhaUsuario;

                repositorio.Inserir(professor);
            }
            else
            {
                ModelState.AddModelError("", $"O CPF {professor.Cpf} já está cadastrado");
            }

            return RedirectToAction("Cadastrar");
        }

        private int GerarCodigoValido(Random random = null)
        {
            UsuarioRepositorio repositorio = new UsuarioRepositorio();


            var rand = (random == null) ? new Random() : random;
            int randNum = rand.Next(100000, 999999);

            return (repositorio.ValidarCodigo(randNum) == null) ? randNum : GerarCodigoValido(rand);
        }

        private string GerarSenha()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");
            GuidString = GuidString.Replace("\\", "");

            return GuidString.Substring(0, 6);
        }
    }
}