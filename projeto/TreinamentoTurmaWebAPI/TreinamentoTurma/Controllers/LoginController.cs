using System.Web.Mvc;
using TreinamentoTurma.Areas.Painel.ViewModel;
using TreinamentoTurma.Models;
using TreinamentoTurma.Services;

namespace TreinamentoTurma.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
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
                var professorUsuario = new ProfessorService().ObterPeloIdUsuario(usuarioCadastrado.Sucesso.Usuario.Id);
                if (!professorUsuario.EstaValido)
                {
                    var alunoUsuario = new AlunoService().ObterPeloIdUsuario(usuarioCadastrado.Sucesso.Usuario.Id);
                    if (!alunoUsuario.EstaValido)
                    {
                        ModelState.AddModelError("", "Erro interno. O código do usuário está cadastrado mas não existe nenhum professor ou aluno com este código.");
                        return View("Index");
                    }
                    else
                    {
                        alunoUsuario.Sucesso.Codigo = usuarioCadastrado.Sucesso.Usuario.Codigo;
                        alunoUsuario.Sucesso.Senha = usuarioCadastrado.Sucesso.Usuario.Senha;

                        var autenticacaoAluno = new AutenticacaoAluno(alunoUsuario.Sucesso, usuarioCadastrado.Sucesso.Token);

                        Session["TreinamentoTurmaUsuarioAtual"] = autenticacaoAluno;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    professorUsuario.Sucesso.Codigo = usuarioCadastrado.Sucesso.Usuario.Codigo;
                    professorUsuario.Sucesso.Senha = usuarioCadastrado.Sucesso.Usuario.Senha;
                    
                    var autenticacaoProfessor = new AutenticacaoProfessor(professorUsuario.Sucesso, usuarioCadastrado.Sucesso.Token);

                    Session["TreinamentoTurmaUsuarioAtual"] = autenticacaoProfessor;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult Sair()
        {
            //HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}