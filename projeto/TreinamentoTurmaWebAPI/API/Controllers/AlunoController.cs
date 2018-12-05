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
    public class AlunoController : ControllerBase
    {
        private IAlunoServico _alunoService;
        
        public AlunoController(IAlunoServico alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public IEnumerable<Aluno> Listar()
        {
            return _alunoService.ListarAlunos();
        }

        [HttpGet("{id}")]
        public Aluno Obter(int id)
        {
            return (_alunoService.ObterPeloIdUsuario(id) is var resultado 
                && resultado.EstaValido) ? resultado.Sucesso : new Aluno();
        }

        [HttpPost]
        public ObjectResult Cadastrar([FromBody]Aluno aluno)
        {
            if(_alunoService.ObterPeloEmail(aluno.Email) is var resultado && resultado.EstaValido)
            {
                return BadRequest($"O email {aluno.Email} já está cadastrado.");
            }
            else
            {
                _alunoService.Cadastrar(aluno);
                return Ok( "Aluno cadastrado com sucesso!");
            }
        }

        [HttpPut]
        public ObjectResult Atualizar([FromBody]Aluno aluno)
        {
            try
            {
                _alunoService.Atualizar(aluno);
                return Ok("Aluno atualizado com sucesso!") ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message) ;
            }
        }

        [HttpDelete("{id}")]
        public ObjectResult Excluir(int id)
        {
            try
            {
                _alunoService.Excluir(id);
                return Ok( "Aluno excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
