using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infraestrutura.Repositorio;
using API.Infraestrutura.Repositorio.Interfaces;
using API.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private IAlunoRepositorio _alunoRepositorio;
        private IUsuarioRepositorio _usuarioRepositorio;
        
        public AlunoController(IAlunoRepositorio alunoRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IEnumerable<Aluno> Listar()
        {
            return _alunoRepositorio.ObterTodos();
        }

        [HttpGet("{id}")]
        public Aluno Obter(int id)
        {
            return _alunoRepositorio.ObterPeloIdUsuario(id);
        }

        [HttpPost]
        public ObjectResult Cadastrar([FromBody]Aluno aluno)
        {
            if(_alunoRepositorio.ObterPeloEmail(aluno.Email) is var resultado && resultado.EstaValido)
            {
                return BadRequest($"O email {aluno.Email} já está cadastrado.");
            }
            else
            {
                aluno.GerarCodigoESenha(_usuarioRepositorio);
                _alunoRepositorio.Inserir(aluno);
                return Ok( "Aluno cadastrado com sucesso!");
            }
        }

        [HttpPut]
        public string Atualizar([FromBody]Aluno aluno)
        {
            try
            {
                _alunoRepositorio.Atualizar(aluno);
                return "Aluno atualizado com sucesso!";
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
                _alunoRepositorio.Excluir(id);
                return "Aluno excluído com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}


/*
    [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            List<Aluno> alunos = new List<Aluno>();
            Aluno carlos = new Aluno()
            {
                Id = 1,
                Codigo = 78273823,
                DataNascimento = DateTime.Now,
                Email = "carlinhos@gmail.com",
                Endereco = "Rua sei la das quantas",
                Nome = "Carlos Ruas",
                Senha = "KJASHDh82",
                Telefone = "(51)99999-9999"
            };
            Aluno ana = new Aluno()
            {
                Id = 2,
                Codigo = 78663824,
                DataNascimento = DateTime.Now,
                Email = "anarocha@gmail.com",
                Endereco = "Rua da vila do lado",
                Nome = "Ana Rocha",
                Senha = "lkkkdjsjd",
                Telefone = "(51)99987-9999"
            };
            alunos.Add(carlos);
            alunos.Add(ana);

            return alunos;
        }
     
     */
