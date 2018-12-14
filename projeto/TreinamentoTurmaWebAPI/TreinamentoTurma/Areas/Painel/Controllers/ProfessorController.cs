using AutoMapper;
using System.Web.Mvc;
using TreinamentoTurma.Areas.Painel.ViewModel;
using TreinamentoTurma.Filters;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Models;
using TreinamentoTurma.Services;

namespace TreinamentoTurma.Areas.Painel.Controllers
{
    [Autenticacao(Roles = "_PROFESSOR_")]
    public class ProfessorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(ProfessorViewModel professorViewModel) 
        {
            var professorService = new ProfessorService(); 
            if (professorService.ObterPeloCpf(professorViewModel.Cpf) is var retorno && retorno.EstaValido)
            {
                ModelState.AddModelError("", $"O CPF {professorViewModel.Cpf} já está cadastrado");
                return View();
            }
            else
            {
                Professor professor = Mapper.Map<Professor>(professorViewModel);
                var professorCadastrado = professorService.Cadastrar(professor);
                TempData["Sucesso"] = $"Professor cadastrado com sucesso. Anote sua senha: {Base64.ParaString(professorCadastrado.Sucesso.Senha)}.";
            }

            return RedirectToAction("Cadastrar");
        }

        
    }
}