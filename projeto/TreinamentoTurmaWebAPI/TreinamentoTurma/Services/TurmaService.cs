using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Models;
using TreinamentoTurma.Services.Interfaces;
using TreinamentoTurma.Helpers.Retornos.Validacao;
using TreinamentoTurma.Helpers.Retornos.API;

namespace TreinamentoTurma.Services
{
    public class TurmaService : ITurmaService
    {
        public void Atualizar(Turma turma)
        {
            throw new NotImplementedException();
        }

        public int Cadastrar(Turma turma)
        {
            throw new NotImplementedException();
        }
        
        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void ExcluirInscricao(int id)
        {
            throw new NotImplementedException();
        }

        public void ExcluirInscricoesPeloTurmaId(int alunoId)
        {
            throw new NotImplementedException();
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

        public IEnumerable<Turma> ListarTurmas()
        {
            // isso aqui precisa ser colocado em uma classe que fará a autenticação
            // talvez utilizando cookies
            var turmas = new List<Turma>();
            var client = new RestClient(new Uri(ConfigurationManager.AppSettings["ApiUri"]));
            var request = new RestRequest("turma");
            request.AddHeader("authorization",
                $"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjI3IiwibmJmIjoxNTQ0NTMwMDk4LCJleHAiOjE1NDQ3ODkyOTgsImlhdCI6MTU0NDUzMDA5OH0.89hN3L9Klhn1nxK9E12joLGNsT7nz__ColWmAdBkcJg");
            var response = client.Execute(request);
            var responseData = JsonConvert.DeserializeObject<Retorno<List<Turma>, Helpers.Retornos.API.Falha>>(response.Content);

            if (responseData.Sucesso != null)
                turmas = responseData.Sucesso.Objeto;
            return turmas;
        }

        public Resultado<Inscricao, Helpers.Retornos.Validacao.Falha> ObterIncricao(int alunoId, int turmaId)
        {
            throw new NotImplementedException();
        }

        public Resultado<Inscricao, Helpers.Retornos.API.Falha> ObterPeloTurmaId(int id)
        {
            throw new NotImplementedException();
        }

        public Resultado<Turma, Helpers.Retornos.Validacao.Falha> ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public void ExcluirInscricoesPeloAlunoId(int alunoId)
        {
            throw new NotImplementedException();
        }
        
        Resultado<Inscricao, Helpers.Retornos.Validacao.Falha> ITurmaService.CadastrarInscricao(Inscricao inscricao)
        {
            throw new NotImplementedException();
        }

        Resultado<Inscricao, Helpers.Retornos.Validacao.Falha> ITurmaService.ObterPeloAlunoId(int id)
        {
            throw new NotImplementedException();
        }
    }
}