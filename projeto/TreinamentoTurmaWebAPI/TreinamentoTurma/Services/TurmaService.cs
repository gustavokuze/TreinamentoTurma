using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using TreinamentoTurma.Models;
using TreinamentoTurma.Services.Interfaces;
using TreinamentoTurma.Helpers.Retornos.Validacao;
using TreinamentoTurma.Helpers.Retornos.API;

namespace TreinamentoTurma.Services
{
    public class TurmaService : BaseService, ITurmaService
    {
        public Resultado<Turma, Helpers.Retornos.Validacao.Falha> Atualizar(Turma turma)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Turma, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma", Method.PUT, turma).Content);
            if (response.Sucesso != null)
            {
                return new Resultado<Turma,
                    Helpers.Retornos.Validacao.Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<Turma,
                    Helpers.Retornos.Validacao.Falha>(new Helpers.Retornos.Validacao.Falha(response.Falha.Mensagem));
            }
        }

        public int Cadastrar(Turma turma)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Turma, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma", Method.POST, turma).Content);
            if (response.Sucesso != null)
            {
                return response.Sucesso.Objeto.Id;
            }
            else
            {
                return 0;
            }
        }
        
        public Resultado<int, Helpers.Retornos.Validacao.Falha> Excluir(int id)
        {
            var response = JsonConvert.DeserializeObject<Retorno<int, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/{id}", Method.DELETE).Content);
            if (response.Sucesso != null)
            {
                return new Resultado<int, Helpers.Retornos.Validacao.Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<int, Helpers.Retornos.Validacao.Falha>(new Helpers.Retornos.Validacao.Falha(response.Falha.Mensagem));
            }
        }

        public Resultado<int, Helpers.Retornos.Validacao.Falha> ExcluirInscricao(int id)
        {
            var response = JsonConvert.DeserializeObject<Retorno<int, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/inscricao/{id}", Method.DELETE).Content);
            if (response.Sucesso != null)
            {
                return new Resultado<int, Helpers.Retornos.Validacao.Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<int, Helpers.Retornos.Validacao.Falha>(new Helpers.Retornos.Validacao.Falha(response.Falha.Mensagem));
            }
        }
        
        public IEnumerable<Turma> ListarTurmas()
        {
            var turmas = new List<Turma>();
            var response = RequisitarAPI("turma");
            var responseData = JsonConvert.DeserializeObject<Retorno<List<Turma>, Helpers.Retornos.API.Falha>>(response.Content);

            if (responseData.Sucesso != null)
                turmas = responseData.Sucesso.Objeto;
            return turmas;
        }
        
        public Resultado<Turma, Helpers.Retornos.Validacao.Falha> ObterPeloId(int id)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Turma, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/{id}").Content);
            if (response.Sucesso != null)
            {
                return new Resultado<Turma,
                    Helpers.Retornos.Validacao.Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<Turma,
                    Helpers.Retornos.Validacao.Falha>(new Helpers.Retornos.Validacao.Falha(response.Falha.Mensagem));
            }
        }
        
        public Resultado<Inscricao, Helpers.Retornos.Validacao.Falha> CadastrarInscricao(Inscricao inscricao)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Inscricao, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/inscricao", Method.POST, inscricao).Content);
            if (response.Sucesso != null)
            {
                return new Resultado<Inscricao, 
                    Helpers.Retornos.Validacao.Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<Inscricao, 
                    Helpers.Retornos.Validacao.Falha>(new Helpers.Retornos.Validacao.Falha(response.Falha.Mensagem));
            }
        }

        public Resultado<Inscricao, Helpers.Retornos.Validacao.Falha> BuscarInscricao(int alunoId, int turmaId)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Inscricao, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/inscricao/{alunoId}/{turmaId}").Content);
            if (response.Sucesso != null)
            {
                return new Resultado<Inscricao,
                    Helpers.Retornos.Validacao.Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<Inscricao,
                    Helpers.Retornos.Validacao.Falha>(new Helpers.Retornos.Validacao.Falha(response.Falha.Mensagem));
            }
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

        //Resultado<Inscricao, Helpers.Retornos.Validacao.Falha> ObterPeloAlunoId(int id)
        //{
        //    var response = JsonConvert.DeserializeObject<Retorno<Inscricao, Helpers.Retornos.API.Falha>>(RequisitarAPI($"turma/inscricao/{id}").Content);
        //    if (response.Sucesso != null)
        //    {
        //        return new Resultado<Inscricao,
        //            Helpers.Retornos.Validacao.Falha>(response.Sucesso.Objeto);
        //    }
        //    else
        //    {
        //        return new Resultado<Inscricao,
        //            Helpers.Retornos.Validacao.Falha>(new Helpers.Retornos.Validacao.Falha(response.Falha.Mensagem));
        //    }
        //}