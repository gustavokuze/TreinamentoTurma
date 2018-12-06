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
using API.Uteis.Retornos.API;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : BaseController
    {
        private IAlunoServico _alunoService;

        public AlunoController(IAlunoServico alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public Retorno<List<Aluno>, Falha> Listar()
        {
            var listaAlunos = _alunoService.ListarAlunos();
            return FormataRetorno(listaAlunos.ToList());
        }

        [HttpGet("{id}")]
        public Retorno<Aluno, Falha> Obter(int id)
        {
            var retorno = _alunoService.ObterPeloIdUsuario(id);
            return (retorno.EstaValido)
                ? FormataRetorno(retorno.Sucesso)
                : FormataRetorno(retorno.Sucesso, "Aluno não encontrado");
        }

        [HttpPost]
        public Retorno<Aluno, Falha> Cadastrar([FromBody]Aluno aluno)
        {
            var alunoCadastrado = _alunoService.ObterPeloEmail(aluno.Email);
            if (alunoCadastrado.EstaValido)
            {
                return FormataRetorno(aluno, $"O email {aluno.Email} já está cadastrado.");
            }
            else
            {
                _alunoService.Cadastrar(aluno);
                return FormataRetorno(aluno);
            }
        }

        [HttpPut]
        public Retorno<Aluno, Falha> Atualizar([FromBody]Aluno aluno)
        {
            try
            {
                _alunoService.Atualizar(aluno);
                return FormataRetorno(aluno);
            }
            catch (Exception ex)
            {
                return FormataRetorno(aluno, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public Retorno<int, Falha> Excluir(int id)
        {
            try
            {
                _alunoService.Excluir(id);
                return FormataRetorno(id);
            }
            catch (Exception ex)
            {
                return FormataRetorno(id, ex.Message);
            }
        }
    }
}
