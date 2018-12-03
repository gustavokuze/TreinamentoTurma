using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure.Repository;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private IConfiguration _configuration;
        private AlunoRepositorio repositorio;
        
        public AlunoController(IConfiguration configuration)
        {
            _configuration = configuration;
            repositorio = new AlunoRepositorio(_configuration);
        }

        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return repositorio.ObterTodos();
        }

        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return repositorio.ObterPeloIdUsuario(id); ;
        }

        [HttpPost]
        public string Cadastrar([FromBody]Aluno aluno)
        {
            try
            {
                aluno.GerarCodigoESenha(new UsuarioRepositorio(_configuration));
                repositorio.Inserir(aluno);
                return "Aluno cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPut]
        public string Atualizar([FromBody]Aluno aluno)
        {
            try
            {
                repositorio.Atualizar(aluno);
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
                repositorio.Excluir(id);
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
