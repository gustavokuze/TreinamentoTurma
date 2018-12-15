using System;
using System.Collections.Generic;
using System.Linq;
using API.Modelos;
using API.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using API.Uteis.Retornos.API;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [AllowAnonymous]
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

        [HttpGet("obter/{email}")]
        public Retorno<Aluno, Falha> Obter(string email)
        {
            var retorno = _alunoService.ObterPeloEmail(email);
            return (retorno.EstaValido)
                ? FormataRetorno(retorno.Sucesso)
                : FormataRetorno(retorno.Sucesso, "Aluno não encontrado");
        }

        [HttpPost]
        public Retorno<Usuario, Falha> Cadastrar([FromBody]Aluno aluno)
        {
            var alunoCadastrado = _alunoService.ObterPeloEmail(aluno.Email);
            if (alunoCadastrado.EstaValido)
            {
                return FormataRetorno(aluno as Usuario, $"O email {aluno.Email} já está cadastrado.");
            }
            else
            {
                var usuario =_alunoService.Cadastrar(aluno);
                return FormataRetorno(usuario.Sucesso);
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
