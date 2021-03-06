﻿using System.Linq;
using System.Web.Mvc;
using TreinamentoTurma.Areas.Painel.ViewModel;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Models;
using TreinamentoTurma.Services;

namespace TreinamentoTurma.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            var alunoService = new AlunoService();
            var professorService = new ProfessorService();
            var viewModel = new UsuarioViewModel();
            viewModel.AlunosLista = alunoService.ListarAlunos().Sucesso.ToList();
            viewModel.ProfessoresLista = professorService.ListarProfessores().Sucesso.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Entrar(UsuarioViewModel usuarioViewModel)
        {
            AutenticacaoUsuario usuarioParaAutenticar = new AutenticacaoUsuario();
            usuarioParaAutenticar.Usuario = AutoMapper.Mapper.Map<Usuario>( usuarioViewModel);
            
            UsuarioService usuarioService = new UsuarioService();
            var usuarioCadastrado = usuarioService.Autenticar(usuarioParaAutenticar);
            
            if (!usuarioCadastrado.EstaValido)
            {
                ModelState.AddModelError("", "Senha ou código(s) incorreto(s)."); //ou algum outro problema, investigar
                return View("Index");
            }
            else
            {
                Session[Login.ChaveUsuarioSession] = usuarioCadastrado.Sucesso; // pra poder gerar o token
                
                var professorUsuario = new ProfessorService().ObterPeloIdUsuario(usuarioCadastrado.Sucesso.Usuario.Id);
                //if (true) { }
                if (professorUsuario.Sucesso == null && !professorUsuario.EstaValido)
                {
                    var alunoUsuario = new AlunoService().ObterPeloIdUsuario(usuarioCadastrado.Sucesso.Usuario.Id);
                    if (alunoUsuario.Sucesso == null && !alunoUsuario.EstaValido)
                    {
                        ModelState.AddModelError("", "Erro interno. O código do usuário está cadastrado mas não existe nenhum professor ou aluno com este código.");
                        return View("Index");
                    }
                    else
                    {
                        alunoUsuario.Sucesso.Codigo = usuarioCadastrado.Sucesso.Usuario.Codigo;
                        alunoUsuario.Sucesso.Senha = usuarioCadastrado.Sucesso.Usuario.Senha;

                        var autenticacaoAluno = new AutenticacaoAluno(alunoUsuario.Sucesso, usuarioCadastrado.Sucesso.Token);

                        Session[Login.ChaveUsuarioSession] = autenticacaoAluno;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    professorUsuario.Sucesso.Codigo = usuarioCadastrado.Sucesso.Usuario.Codigo;
                    professorUsuario.Sucesso.Senha = usuarioCadastrado.Sucesso.Usuario.Senha;
                    
                    var autenticacaoProfessor = new AutenticacaoProfessor(professorUsuario.Sucesso, usuarioCadastrado.Sucesso.Token);

                    Session[Login.ChaveUsuarioSession] = autenticacaoProfessor;
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