using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infraestrutura.Repositorio.Interfaces;
using API.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private ITurmaRepositorio _turmaRepositorio { get; set; }
        public TurmaController(ITurmaRepositorio turmaRepositorio)
        {
            _turmaRepositorio = turmaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Turma> Listar()
        {
            return _turmaRepositorio.ListarTurmas();
        }

        [HttpGet("{id}")]
        public Turma Obter(int id)
        {
            return _turmaRepositorio.ObterPeloId(id);
        }

        [HttpPost("cadastrar")]
        public ObjectResult Cadastrar([FromBody]Turma turma)
        {
            try
            {
                _turmaRepositorio.Inserir(turma);
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
                _turmaRepositorio.Atualizar(turma);
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
                _turmaRepositorio.Excluir(id);
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
                _turmaRepositorio.InserirInscricao(inscricao);
                return Ok("Inscrição excluída com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}