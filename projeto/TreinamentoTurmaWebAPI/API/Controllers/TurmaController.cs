using System;
using System.Collections.Generic;
using System.Linq;
using API.Modelos;
using API.Servicos.Interfaces;
using API.Uteis.Retornos.API;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : BaseController
    {
        private ITurmaServico _turmaServico { get; set; }
        public TurmaController(ITurmaServico turmaServico)
        {
            _turmaServico = turmaServico;
        }

        [HttpGet]
        public Retorno<List<Turma>, Falha> Listar()
        {
            var turmas = _turmaServico.ListarTurmas();

            return FormataRetorno(turmas.ToList());
        }

        [HttpGet("{id}")]
        public Retorno<Turma, Falha> Obter(int id)
        {
            var turma = _turmaServico.ObterPeloId(id);
            if (turma.EstaValido)
                return FormataRetorno(turma.Sucesso);
            return FormataRetorno(turma.Sucesso, "Turma não encontrada");
        }

        [HttpPost]
        public Retorno<Turma, Falha> Cadastrar([FromBody]Turma turma)
        {
            try
            {
                _turmaServico.Cadastrar(turma);
                return FormataRetorno(turma);
            }
            catch (Exception ex)
            {
                return FormataRetorno(turma, ex.Message);
            }
        }

        [HttpPut]
        public Retorno<Turma, Falha> Atualizar([FromBody]Turma turma)
        {
            try
            {
                _turmaServico.Atualizar(turma);
                return FormataRetorno(turma);
            }
            catch (Exception ex)
            {
                return FormataRetorno(turma, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public Retorno<int, Falha> Excluir(int id)
        {
            try
            {
                _turmaServico.Excluir(id);
                return FormataRetorno(id);
            }
            catch (Exception ex)
            {
                return FormataRetorno(id, ex.Message);
            }
        }

        [HttpPost("inscricao")]
        public Retorno<Inscricao, Falha> Inscrever([FromBody]Inscricao inscricao)
        {
            try
            {
                var resultado = _turmaServico.CadastrarInscricao(inscricao);

                if (resultado.EstaValido)
                    return FormataRetorno(inscricao);
                return FormataRetorno(inscricao, resultado.Falha.Msg);

            }
            catch (Exception ex)
            {
                return FormataRetorno(inscricao, ex.Message);
            }
        }

        [HttpDelete("inscricao/{id}")]
        public Retorno<int, Falha> ExcluirInscricao(int id)
        {
            try
            {
                _turmaServico.ExcluirInscricao(id);
                return FormataRetorno(id);
            }
            catch (Exception ex)
            {
                return FormataRetorno(id, ex.Message);
            }
        }

        [HttpGet("inscricao/{AlunoId}/{TurmaId}")]
        public Retorno<Inscricao, Falha> BuscarInscricao(int AlunoId, int TurmaId)
        {
            var resultado = _turmaServico.ObterIncricao(AlunoId, TurmaId);
            if (resultado.Sucesso != null)
            {
                return FormataRetorno(resultado.Sucesso);
            }
            return FormataRetorno(resultado.Sucesso, "Inscrição não encontrada");
        }
    }
}