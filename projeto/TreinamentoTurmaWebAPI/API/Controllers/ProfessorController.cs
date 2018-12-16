using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infraestrutura.Repositorio;
using API.Infraestrutura.Repositorio.Interfaces;
using API.Modelos;
using API.Servicos.Interfaces;
using API.Uteis.Retornos.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : BaseController
    {
        private IProfessorServico _professorService;

        public ProfessorController(IProfessorServico professorService)
        {
            _professorService = professorService;
        }

        [AllowAnonymous]
        [HttpGet]
        public Retorno<List<Professor>, Falha> Listar()
        {
            var listaProfessores = _professorService.ListarProfessores();
            return FormataRetorno(listaProfessores.ToList());
        }

        [HttpGet("{id}")]
        public Retorno<Professor, Falha> Obter(int id)
        {
            var professor = _professorService.ObterPeloIdUsuario(id);
            if ( professor.EstaValido)
            {
                return FormataRetorno(professor.Sucesso);
            }
            return FormataRetorno(professor.Sucesso, "Professor não encontrado");
        }

        [HttpGet("obter/{cpf}")]
        public Retorno<Professor, Falha> Obter(string cpf)
        {
            var professor = _professorService.ObterPeloCpf(cpf);
            if (professor.EstaValido)
            {
                return FormataRetorno(professor.Sucesso);
            }
            return FormataRetorno(professor.Sucesso, "Professor não encontrado");
        }

        [HttpPost]
        public Retorno<Usuario, Falha> Cadastrar([FromBody]Professor professor)
        {
            var professorCadastrado = _professorService.ObterPeloCpf(professor.Cpf);
            if ( professorCadastrado.EstaValido)
            {
                return FormataRetorno(professor as Usuario, $"O CPF {professor.Cpf} já está cadastrado.");
            }
            else
            {
                var usuario = _professorService.Cadastrar(professor);
                return FormataRetorno(usuario.Sucesso);
            }
        }

        [HttpPut]
        public Retorno<Professor, Falha> Atualizar([FromBody]Professor professor)
        {
            try
            {
                _professorService.Atualizar(professor);
                return FormataRetorno(professor);
            }
            catch (Exception ex)
            {
                return FormataRetorno(professor, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public Retorno<int, Falha> Excluir(int id)
        {
            try
            {
                _professorService.Excluir(id);
                return FormataRetorno(id);
            }
            catch (Exception ex)
            {
                return FormataRetorno(id, ex.Message);
            }
        }
    }
}
