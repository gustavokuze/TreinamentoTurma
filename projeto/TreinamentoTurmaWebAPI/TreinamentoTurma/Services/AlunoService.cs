using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using TreinamentoTurma.Helpers;
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
            UsuarioAtual = Login.ObterUsuarioAtual();
            if (UsuarioAtual == null)
            {
                TokenValido = "";
            }
            else
            {
                TokenValido = RequisitarToken(UsuarioAtual.Usuario.Codigo, UsuarioAtual.Usuario.Senha);
            }
        }

        public Resultado<Aluno, Falha> Atualizar(Aluno aluno)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }


            var response = JsonConvert.DeserializeObject<Retorno<Aluno, Helpers.Retornos.API.Falha>>(RequisitarAPI($"aluno", RestSharp.Method.PUT, aluno, TokenValido).Content);
            if (response.Sucesso.Objeto != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

        public Resultado<Usuario, Falha> Cadastrar(Aluno aluno)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }

            var response = JsonConvert.DeserializeObject<Retorno<Usuario, Helpers.Retornos.API.Falha>>(RequisitarAPI($"aluno", RestSharp.Method.POST, aluno, TokenValido).Content);
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
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }


            var response = JsonConvert.DeserializeObject<Retorno<int, Helpers.Retornos.API.Falha>>(RequisitarAPI($"aluno/{id}", RestSharp.Method.DELETE, null, TokenValido).Content);
            if (response.Sucesso != null && response.Sucesso.Objeto > 0)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha("Erro ao excluir");
            }
        }

        public Resultado< IEnumerable<Aluno>, Falha> ListarAlunos()
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }

            List<Aluno> alunos = new List<Aluno>();

            var response = JsonConvert.DeserializeObject<Retorno<List<Aluno>, Falha>>(RequisitarAPI("aluno", RestSharp.Method.GET, null, TokenValido).Content);
            if (response.Sucesso.Objeto != null) alunos = response.Sucesso.Objeto;
            return alunos;
        }

        public Resultado<Aluno, Falha> ObterPeloEmail(string email)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }

            var response = JsonConvert.DeserializeObject<Retorno<Aluno, Helpers.Retornos.API.Falha>>(RequisitarAPI($"aluno/obter/{email}", RestSharp.Method.GET, null, TokenValido).Content);
            if (response.Sucesso.Objeto != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

        public Resultado<Aluno, Falha> ObterPeloIdUsuario(int id)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }

            var response = JsonConvert.DeserializeObject<Retorno<Aluno, Helpers.Retornos.API.Falha>>(RequisitarAPI($"aluno/{id}", RestSharp.Method.GET, null, TokenValido).Content);
            if (response.Sucesso.Objeto != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

    }
}