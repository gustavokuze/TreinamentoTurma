using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoTurma.Areas.Painel.ViewModel;
using TreinamentoTurma.Filters;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Infra;
using TreinamentoTurma.Models;

namespace TreinamentoTurma.Areas.Painel.Controllers
{
    [Autenticacao(Roles = "_PROFESSOR_")]
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
        public ActionResult Cadastrar(ProfessorViewModel professorViewModel) 
        {
            ProfessorRepositorio repositorio = new ProfessorRepositorio(); 
            if (repositorio.BuscarProfessor(professorViewModel.Cpf) is var retorno && retorno.EstaValido)
            {
                ModelState.AddModelError("", $"O CPF {professorViewModel.Cpf} já está cadastrado");
                return View();
            }
            else
            {
                Professor professor = Mapper.Map<Professor>(professorViewModel);
                professor.GerarCodigoESenha();
                repositorio.Inserir(professor);
                TempData["Sucesso"] = $"Professor cadastrado com sucesso. Anote sua senha: {Base64.ParaString(professor.Senha)}.";
            }

            return RedirectToAction("Cadastrar");
        }

        
    }
}