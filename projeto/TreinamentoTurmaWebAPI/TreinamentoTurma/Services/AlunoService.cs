using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using TreinamentoTurma.Helpers.Retornos.API;
using TreinamentoTurma.Helpers.Retornos.Validacao;
using TreinamentoTurma.Models;
using TreinamentoTurma.Services.Interfaces;
using Falha = TreinamentoTurma.Helpers.Retornos.Validacao.Falha;

namespace TreinamentoTurma.Services
{
    public class AlunoService : BaseService, IAlunoService
    {

        public AlunoService()
        {
            var usuarioAtual = HttpContext.Current.Session["TreinamentoTurmaUsuarioAtual"] as AutenticacaoUsuario;
            if (usuarioAtual == null)
            {
                TokenValido = "";
            }
            else
            {
                TokenValido = RequisitarToken(usuarioAtual.Usuario.Codigo, usuarioAtual.Usuario.Senha);
            }
        }

        public Resultado<Aluno, Falha> Atualizar(Aluno aluno)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Aluno, Helpers.Retornos.API.Falha>>(RequisitarAPI($"aluno", RestSharp.Method.PUT, aluno).Content);
            if (response.Sucesso.Objeto != null)
            {
                return new Resultado<Aluno, Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<Aluno, Falha>(new Falha(response.Falha.Mensagem));
            }
        }

        public Resultado<Usuario, Falha> Cadastrar(Aluno aluno)
        {
            var usuarioCadastrado = new UsuarioService().Autenticar((AutenticacaoUsuario)HttpContext.Current.Session["TreinamentoTurmaUsuarioAtual"]);
            if (!usuarioCadastrado.EstaValido) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }

            var response = JsonConvert.DeserializeObject<Retorno<Usuario, Helpers.Retornos.API.Falha>>(RequisitarAPI($"aluno", RestSharp.Method.POST, aluno, usuarioCadastrado.Sucesso.Token).Content);
            if (response.Sucesso.Objeto != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

        public Resultado<int, Falha> Excluir(int id)
        {
            var response = JsonConvert.DeserializeObject<Retorno<int, Helpers.Retornos.API.Falha>>(RequisitarAPI($"aluno/{id}", RestSharp.Method.DELETE).Content);
            if (response.Sucesso.Objeto > 0)
            {
                return new Resultado<int, Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<int, Falha>(new Falha(response.Falha.Mensagem));
            }
        }

        public IEnumerable<Aluno> ListarAlunos()
        {
            List<Aluno> alunos = new List<Aluno>();

            var response = JsonConvert.DeserializeObject<Retorno<List<Aluno>, Falha>>(RequisitarAPI("aluno").Content);
            if (response.Sucesso.Objeto != null) alunos = response.Sucesso.Objeto;
            return alunos;
        }

        public Resultado<Aluno, Falha> ObterPeloEmail(string email)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Aluno, Helpers.Retornos.API.Falha>>(RequisitarAPI($"aluno/obter/{email}", RestSharp.Method.GET, null, TokenValido).Content);
            if (response.Sucesso.Objeto == null || TokenValido == "")
            {
                return new Resultado<Aluno, Falha>(new Falha(response.Falha.Mensagem));
            }
            else
            {
                return new Resultado<Aluno, Falha>(response.Sucesso.Objeto);
            }
        }

        public Resultado<Aluno, Falha> ObterPeloIdUsuario(int id)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Aluno, Helpers.Retornos.API.Falha>>(RequisitarAPI($"aluno/{id}", RestSharp.Method.GET, null, TokenValido).Content);
            if (response.Sucesso == null || TokenValido == "")
            {
                return new Resultado<Aluno, Falha>(new Falha(response.Falha.Mensagem));
            }
            else
            {
                return new Resultado<Aluno, Falha>(response.Sucesso.Objeto);
            }
        }

    }
}