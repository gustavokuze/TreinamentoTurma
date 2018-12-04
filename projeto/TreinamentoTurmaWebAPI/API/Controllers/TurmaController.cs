using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure.Repository.Interfaces;
using API.Models;
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
            return _turmaRepositorio.ObterTodos();
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

        
    }
}