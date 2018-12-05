using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infraestrutura.Repositorio.Interfaces;
using API.Modelos;
using API.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private ITurmaServico _turmaServico { get; set; }
        public TurmaController(ITurmaServico turmaServico)
        {
            _turmaServico = turmaServico;
        }

        [HttpGet]
        public IEnumerable<Turma> Listar()
        {
            return _turmaServico.ListarTurmas();
        }

        [HttpGet("{id}")]
        public Turma Obter(int id)
        {
            var turma = _turmaServico.ObterPeloId(id);
            if (turma is var resultado && resultado.EstaValido)
                return resultado.Sucesso;
            return new Turma();
        }

        [HttpPost("cadastrar")]
        public ObjectResult Cadastrar([FromBody]Turma turma)
        {
            try
            {
                _turmaServico.Cadastrar(turma);
                return Ok("Turma cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public string Atualizar([FromBody]Turma turma)
        {
            try
            {
                _turmaServico.Atualizar(turma);
                return "Turma atualizada com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        [HttpDelete("{id}")]
        public string Excluir(int id)
        {
            try
            {
                _turmaServico.Excluir(id);
                return "Turma excluída com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost("inscrever")]
        public ObjectResult Inscrever([FromBody]Inscricao inscricao)
        {
            try
            {
                _turmaServico.CadastrarInscricao(inscricao);
                return Ok("Inscrição excluída com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}