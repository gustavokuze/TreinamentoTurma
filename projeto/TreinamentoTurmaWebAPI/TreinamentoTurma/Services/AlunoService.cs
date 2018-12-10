using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using TreinamentoTurma.Helpers;
using TreinamentoTurma.Helpers.Retornos.API;
using TreinamentoTurma.Models;
using TreinamentoTurma.Services.Interfaces;

namespace TreinamentoTurma.Services
{
    public class AlunoService : IAlunoService
    {
        public void Atualizar(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task<IEnumerable<Aluno>> ListarAlunosAsync()
        {
            List<Aluno> alunos = new List<Aluno>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUri"]);

                var responseTask = client.GetAsync("aluno");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var dados = await result.Content.ReadAsStringAsync();

                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    alunos = jsSerializer.Deserialize<List<Aluno>>(dados);
                }
                return alunos;
            }
        }

        public Resultado<Aluno, Helpers.Retornos.API.Falha> ObterPeloEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Resultado<Aluno, Helpers.Retornos.API.Falha> ObterPeloIdUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}