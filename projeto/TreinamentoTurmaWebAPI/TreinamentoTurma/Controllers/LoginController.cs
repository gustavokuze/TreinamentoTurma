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
            //UsuarioRepositorio repositorio = new UsuarioRepositorio();
            //var usuarioCadastrado = repositorio.ValidarUsuario(usuarioViewModel.Codigo, 
            //    Base64.ParaBase64(usuarioViewModel.Senha));

            AutenticacaoUsuario usuarioParaAutenticar = new AutenticacaoUsuario();
            usuarioParaAutenticar.Usuario = usuarioParaAutenticar.Usuario;

            UsuarioService usuarioService = new UsuarioService();
            var usuarioCadastrado = usuarioService.Autenticar(usuarioParaAutenticar);


            if (usuarioCadastrado == null)
            {
                ModelState.AddModelError("", "Senha ou código(s) incorreto(s).");
                return View("Index");
            }
            else
            {
                var professorUsuario = new ProfessorService().ObterPeloIdUsuario(usuarioCadastrado.Usuario.Id);
                if (professorUsuario.Sucesso == null)
                {
                    var alunoUsuario = new AlunoService().ObterPeloIdUsuario(usuarioCadastrado.Usuario.Id);
                    if (alunoUsuario.Sucesso == null)
                    {
                        ModelState.AddModelError("", "Erro interno. O código do usuário está cadastrado mas não existe nenhum professor ou aluno com este código.");
                        return View("Index");
                    }
                    else
                    {
                        alunoUsuario.Sucesso.Codigo = usuarioCadastrado.Usuario.Codigo;
                        alunoUsuario.Sucesso.Senha = usuarioCadastrado.Usuario.Senha;

                        var autenticacaoAluno = new AutenticacaoAluno(alunoUsuario.Sucesso, usuarioCadastrado.Token);

                        Session["TreinamentoTurmaUsuarioAtual"] = autenticacaoAluno;
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    professorUsuario.Sucesso.Codigo = usuarioCadastrado.Usuario.Codigo;
                    professorUsuario.Sucesso.Senha = usuarioCadastrado.Usuario.Senha;


                    var autenticacaoProfessor = new AutenticacaoProfessor(professorUsuario.Sucesso, usuarioCadastrado.Token);

                    Session["TreinamentoTurmaUsuarioAtual"] = autenticacaoProfessor;
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