using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using TreinamentoTurma.Models;
using TreinamentoTurma.Services.Interfaces;
using TreinamentoTurma.Helpers.Retornos.Validacao;
using TreinamentoTurma.Helpers;

namespace TreinamentoTurma.Services
{
    public class TurmaService : BaseService, ITurmaService
    {
        public TurmaService()
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
        public Resultado<Turma, Falha> Atualizar(Turma turma)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var response = JsonConvert.DeserializeObject<Helpers.Retornos.API.Retorno<Turma, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma", Method.PUT, turma, TokenValido).Content);
            if (response.Sucesso != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

        public Resultado<int, Falha> Cadastrar(Turma turma)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var response = JsonConvert.DeserializeObject<Helpers.Retornos.API.Retorno<Turma, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma", Method.POST, turma, TokenValido).Content);
            if (response.Sucesso != null)
            {
                return response.Sucesso.Objeto.Id;
            }
            else
            {
                return new Falha("Erro ao cadastrar, objeto vazio");
            }
        }

        public Resultado<int, Falha> Excluir(int id)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var response = JsonConvert.DeserializeObject<Helpers.Retornos.API.Retorno<int, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/{id}", Method.DELETE, null, TokenValido).Content);
            if (response.Sucesso != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

        public Resultado<int, Falha> ExcluirInscricao(int id)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var response = JsonConvert.DeserializeObject<Helpers.Retornos.API.Retorno<int, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/inscricao/{id}", Method.DELETE, null, TokenValido).Content);
            if (response.Sucesso != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

        public Resultado<IEnumerable<Turma>, Falha> ListarTurmas()
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var turmas = new List<Turma>();
            var response = JsonConvert.DeserializeObject<Helpers.Retornos.API.Retorno<List<Turma>, Helpers.Retornos.API.Falha>>(RequisitarAPI("turma", Method.GET, null, TokenValido).Content);

            if (response.Sucesso != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem); //isso aqui talvez precise ser alterado como listar inscricoespeloAlunoId
            }
        }

        public Resultado<Turma, Falha> ObterPeloId(int id)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var response = JsonConvert.DeserializeObject<Helpers.Retornos.API.Retorno<Turma, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/{id}", Method.GET, null, TokenValido).Content);
            if (response.Sucesso != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

        public Resultado<Inscricao, Falha> CadastrarInscricao(Inscricao inscricao)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var response = JsonConvert.DeserializeObject<Helpers.Retornos.API.Retorno<Inscricao, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/inscricao", Method.POST, inscricao, TokenValido).Content);
            if (response.Sucesso != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

        public Resultado<Inscricao, Falha> BuscarInscricao(int alunoId, int turmaId)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var response = JsonConvert.DeserializeObject<Helpers.Retornos.API.Retorno<Inscricao, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/inscricao/{alunoId}/{turmaId}", Method.GET, null, TokenValido).Content);
            if (response.Sucesso != null)
            {
                return response.Sucesso.Objeto;
            }
            else
            {
                return new Falha(response.Falha.Mensagem);
            }
        }

        public Resultado<IEnumerable<Inscricao>, Falha> ListarInscricoesPeloAlunoId(int alunoId)
        {
            if (TokenValido == string.Empty) { return new Falha("O usuário precisa estar logado para efetuar esta tarefa"); }
            var turmas = new List<Inscricao>();
            var response = JsonConvert.DeserializeObject<Helpers.Retornos.API.Retorno<List<Inscricao>, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/inscricao/listar/{alunoId}", Method.GET, null, TokenValido).Content);

            if (response.Sucesso != null)
            {
                return response.Sucesso.Objeto;
            }

            return new List<Inscricao>();
        }
    }
}
//public async Task<IEnumerable<Turma>> ListarTurmasAsync()
//{
//    List<Turma> turmas = new List<Turma>();

//    using (var client = new HttpClient())
//    {
//        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUri"]);

//        var responseTask = client.GetAsync("turma");
//        responseTask.Wait();

//        var result = responseTask.Result;
//        if (result.IsSuccessStatusCode)
//        {
//            var dados = await result.Content.ReadAsStringAsync();

//            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
//            turmas = jsSerializer.Deserialize<List<Turma>>(dados);
//        }
//        return turmas;
//    }
//}

//Resultado<Inscricao, Falha> ObterPeloAlunoId(int id)
//{
//    var response = JsonConvert.DeserializeObject<Retorno<Inscricao, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/inscricao/{id}").Content);
//    if (response.Sucesso != null)
//    {
//        return new Resultado<Inscricao,
//            Falha>(response.Sucesso.Objeto);
//    }
//    else
//    {
//        return new Resultado<Inscricao,
//            Falha>(new Falha(response.Falha.Mensagem));
//    }
//}