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
            AlunoRepositorio repositorio = new AlunoRepositorio();
            if (repositorio.BuscarAluno(alunoViewModel.Email) is var retorno && retorno.EstaValido)
            {
                ModelState.AddModelError("", $"O email {alunoViewModel.Email} já está cadastrado");
                return View();
            }
            else
            {
                Aluno aluno = Mapper.Map<Aluno>(alunoViewModel);
                repositorio.Inserir(aluno);
                TempData["Sucesso"] = $"Aluno cadastrado com sucesso. Anote sua senha: {Base64.ParaString(aluno.Senha) }.";
            }
             
            return RedirectToAction("Cadastrar");
        }
        
    }
}