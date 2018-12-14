using AutoMapper;
using System.Web.Mvc;
using TreinamentoTurma.Areas.Painel.ViewModel;
using TreinamentoTurma.Filters;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Models;
using TreinamentoTurma.Services;

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
        public ActionResult Cadastrar(AlunoViewModel alunoViewModel)
        {
            var alunoService = new AlunoService();
            if (alunoService.ObterPeloEmail( alunoViewModel.Email) is var retorno && retorno.EstaValido)
            {
                ModelState.AddModelError("", $"O email {alunoViewModel.Email} já está cadastrado");
                return View();
            }
            else
            {
                Aluno aluno = Mapper.Map<Aluno>(alunoViewModel);
                var alunoCadastrado = alunoService.Cadastrar(aluno);
                TempData["Sucesso"] = $"Aluno cadastrado com sucesso. Anote sua senha: {Base64.ParaString(alunoCadastrado.Sucesso.Senha) }.";
            }
             
            return RedirectToAction("Cadastrar");
        }
        
    }
}