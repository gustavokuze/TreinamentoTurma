using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Modelos;
using API.Servicos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginServico _loginServico;

        public LoginController(ILoginServico loginServico)
        {
            _loginServico = loginServico;
        } 

        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public IActionResult Autenticar([FromBody]Usuario usuario)
        {
            var login = _loginServico.Autenticar(usuario.Codigo, usuario.Senha);

            if (login == null)
                return BadRequest(new { message = "Codigo ou senha incorretos" });

            return Ok(login);
        }
        

        [HttpGet("teste")]
        public ActionResult teste()
        {
            return Ok("Maravilha! Tudo dando certo por aqui");
        }
    }
}