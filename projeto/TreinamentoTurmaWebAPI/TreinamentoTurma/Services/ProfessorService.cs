﻿using Newtonsoft.Json;
using System.Collections.Generic;
using TreinamentoTurma.Helpers.Retornos.API;
using TreinamentoTurma.Helpers.Retornos.Validacao;
using TreinamentoTurma.Models;
using TreinamentoTurma.Services.Interfaces;
using Falha = TreinamentoTurma.Helpers.Retornos.Validacao.Falha;

namespace TreinamentoTurma.Services
{
    public class ProfessorService : BaseService, IProfessorService
    {
        
        public Resultado<Professor, Falha> Atualizar(Professor professor)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Professor, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor", RestSharp.Method.PUT, professor).Content);
            if (response.Sucesso != null)
            {
                return new Resultado<Professor, Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<Professor, Falha>(new Falha(response.Falha.Mensagem));
            }
        }

        public Resultado<Professor, Falha> Cadastrar(Professor professor)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Professor, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor", RestSharp.Method.POST, professor).Content);
            if (response.Sucesso != null)
            {
                return new Resultado<Professor, Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<Professor, Falha>(new Falha(response.Falha.Mensagem));
            }
        }

        public Resultado<int, Falha> Excluir(int id)
        {
            var response = JsonConvert.DeserializeObject<Retorno<int, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor/{id}", RestSharp.Method.DELETE).Content);
            if (response.Sucesso != null)
            {
                return new Resultado<int, Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<int, Falha>(new Falha(response.Falha.Mensagem));
            }
        }

        public IEnumerable<Professor> ListarProfessores()
        {
            List<Professor> professores = new List<Professor>();

            var response = JsonConvert.DeserializeObject<Retorno<List<Professor>, Falha> >( RequisitarAPI("professor").Content);
            if (response.Sucesso != null) professores = response.Sucesso.Objeto;
            return professores;
        }

        public Resultado<Professor, Falha> ObterPeloCpf(string cpf)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Professor, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor/obter/{cpf}").Content);
            if (response.Sucesso != null)
            {
                return new Resultado<Professor, Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<Professor, Falha>(new Falha(response.Falha.Mensagem));
            }
        }

        public Resultado<Professor, Falha> ObterPeloIdUsuario(int id)
        {
            var response = JsonConvert.DeserializeObject<Retorno<Professor, Helpers.Retornos.API.Falha>>(RequisitarAPI($"professor/{id}").Content);
            if(response.Sucesso != null)
            {
                return new Resultado<Professor, Falha>(response.Sucesso.Objeto);
            }
            else
            {
                return new Resultado<Professor, Falha>(new Falha(response.Falha.Mensagem));
            }
        }
        
    }
}