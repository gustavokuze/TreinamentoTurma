using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infraestrutura.Repositorio;
using API.Infraestrutura.Repositorio.Interfaces;
using API.Modelos;
using API.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private IProfessorServico _professorService;

        public ProfessorController(IProfessorServico professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public IEnumerable<Professor> Listar()
        {
            return _professorService.ListarProfessores();
        }

        [HttpGet("{id}")]
        public Professor Obter(int id)
        {
            return (_professorService.ObterPeloIdUsuario(id) is var resultado
                && resultado.EstaValido) ? resultado.Sucesso : new Professor();
        }

        [HttpPost]
        public ObjectResult Cadastrar([FromBody]Professor professor)
        {
            if (_professorService.ObterPeloCpf(professor.Cpf) is var resultado && resultado.EstaValido)
            {
                return BadRequest($"O CPF {professor.Cpf} já está cadastrado.");
            }
            else
            {
                _professorService.Cadastrar(professor);
                return Ok("Professor cadastrado com sucesso!");
            }
        }

        [HttpPut]
        public ObjectResult Atualizar([FromBody]Professor professor)
        {
            try
            {
                _professorService.Atualizar(professor);
                return Ok("Professor atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ObjectResult Excluir(int id)
        {
            try
            {
                _professorService.Excluir(id);
                return Ok("Professor excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
