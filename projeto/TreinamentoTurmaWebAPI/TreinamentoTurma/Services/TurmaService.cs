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

        public Resultado<Inscricao, Helpers.Retornos.API.Falha> CadastrarInscricao(Inscricao inscricao)
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

        public async System.Threading.Tasks.Task<IEnumerable<Turma>> ListarTurmasAsync()
        {
            List<Turma> turmas = new List<Turma>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiUri"]);

                var responseTask = client.GetAsync("turma");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var dados = await result.Content.ReadAsStringAsync();

                    JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                    turmas = jsSerializer.Deserialize<List<Turma>>(dados);
                }
                return turmas;
            }
        }

        public Resultado<Inscricao, Helpers.Retornos.API.Falha> ObterIncricao(int alunoId, int turmaId)
        {
            throw new NotImplementedException();
        }

        public Resultado<Inscricao, Helpers.Retornos.API.Falha> ObterPeloTurmaId(int id)
        {
            throw new NotImplementedException();
        }

        public Resultado<Turma, Helpers.Retornos.API.Falha> ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }
        
        public void ExcluirInscricoesPeloAlunoId(int alunoId)
        {
            throw new NotImplementedException();
        }

        public Resultado<Inscricao, Helpers.Retornos.API.Falha> ObterPeloAlunoId(int id)
        {
            throw new NotImplementedException();
        }
    }
}