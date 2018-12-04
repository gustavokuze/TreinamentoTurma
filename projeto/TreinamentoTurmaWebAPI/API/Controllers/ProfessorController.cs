using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure.Repository;
using API.Infrastructure.Repository.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private IProfessorRepositorio _professorRepositorio;
        private IUsuarioRepositorio _usuarioRepositorio;

        public ProfessorController(IProfessorRepositorio professorRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _professorRepositorio = professorRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IEnumerable<Professor> Listar()
        {
            return _professorRepositorio.ObterTodos();
        }

        [HttpGet("{id}")]
        public Professor Obter(int id)
        {
            return _professorRepositorio.ObterPeloIdUsuario(id);
        }

        [HttpPost]
        public ObjectResult Cadastrar([FromBody]Professor professor)
        {
            if (_professorRepositorio.ObterPeloCpf(professor.Cpf) is var resultado && resultado.EstaValido)
            {
                return BadRequest($"O email {professor.Cpf} já está cadastrado.");
            }
            else
            {
                professor.GerarCodigoESenha(_usuarioRepositorio);
                _professorRepositorio.Inserir(professor);
                return Ok("Professor cadastrado com sucesso!");
            }
        }

        [HttpPut]
        public string Atualizar([FromBody]Professor professor)
        {
            try
            {
                _professorRepositorio.Atualizar(professor);
                return "Professor atualizado com sucesso!";
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
                _professorRepositorio.Excluir(id);
                return "Professor excluído com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

