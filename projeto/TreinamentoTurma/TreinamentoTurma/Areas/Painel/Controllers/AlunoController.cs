using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Infra;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.Controllers
{
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
                var codigoUsuario = GerarCodigoValido();
                var senhaUsuario = GerarSenha();
                aluno.Codigo = codigoUsuario;
                aluno.Senha = senhaUsuario;

                repositorio.Inserir(aluno);
            }
            else
            {
                ModelState.AddModelError("", $"O email {aluno.Email} já está cadastrado");
            }
            
            return View(new Aluno());
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
            return GuidString;
        }

    }
}