using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using API.Modelos;
using API.Servicos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginServico _loginServico;

        public LoginController(ILoginServico loginServico)
        {
            _loginServico = loginServico;
        }

        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public IActionResult Autenticar([FromBody]AutenticacaoUsuario autenticacao)
        {
            /*
             O que posso fazer aqui é chegar se o token da autenticação passada
             por parametro não é vazio, e se está válido (ainda não expirou)
             talvez verificar se o usuário atual é o usuário do token

            caso nada disso esteja válidado devidamente, envia pra autenticação, do contrário 
            damos um jeito de salvar o usuário do token na memória, ou usamos a própria claim da prop User
            e retornamos o token novo/atual para o client
             */

            var tok = autenticacao.Token;
            var tokHandler = new JwtSecurityTokenHandler();
            if (tok != string.Empty && tokHandler.CanReadToken(tok))
            {
                var token = tokHandler.ReadJwtToken(tok);
                if( token.ValidTo.CompareTo(DateTime.UtcNow) > 0)
                {
                    // aqui o token expirou no caso
                }
            }

            //var claims = User.Claims.Where(x => x.Value == autenticacao.Usuario.Id.ToString());
            
            var login = _loginServico.Autenticar(autenticacao.Usuario.Codigo, autenticacao.Usuario.Senha);

            if (login == null)
                return BadRequest(new { message = "Codigo ou senha incorretos" });

            return Ok(login);
        }

        [HttpGet("teste")]
        public ActionResult Teste()
        {
            return Ok("Maravilha! Tudo dando certo por aqui");
        }
    }
}