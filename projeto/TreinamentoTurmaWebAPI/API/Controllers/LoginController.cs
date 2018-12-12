using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using API.Modelos;
using API.Servicos.Interfaces;
using API.Uteis.Retornos.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[authorize] removido para poder usar o método da contagem de claims
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        private ILoginServico _loginServico;

        public LoginController(ILoginServico loginServico)
        {
            _loginServico = loginServico;
        }


        [HttpPost("Autenticar")]
        public Retorno<AutenticacaoUsuario, Falha> Autenticar([FromBody]AutenticacaoUsuario autenticacao)
        {
            var token = autenticacao.Token;
            var tokHandler = new JwtSecurityTokenHandler();
            if (token != string.Empty && tokHandler.CanReadToken(token))
            {
                var jwtTokenLido = tokHandler.ReadJwtToken(token);
                if (jwtTokenLido.ValidTo.CompareTo(DateTime.UtcNow) < 0)
                    return FormataRetorno(autenticacao, "Token inválido, faça login novamente");

                var usuarioAtualClaims = User.Claims.Where(x => x.Value == autenticacao.Usuario.Id.ToString());
                var jwtTokenLidoClaims = jwtTokenLido.Claims.Where(x => x.Value == autenticacao.Usuario.Id.ToString());
                if (usuarioAtualClaims.Count() == 0 || jwtTokenLidoClaims.Count() == 0)
                {
                    return FormataRetorno(autenticacao, $"Faça login novamente {usuarioAtualClaims.Count()} {jwtTokenLidoClaims.Count()}");
                }

                return FormataRetorno(autenticacao);
            }
            else
            {
                var login = _loginServico.Autenticar(autenticacao.Usuario.Codigo, autenticacao.Usuario.Senha);

                if (login == null)
                    return FormataRetorno(autenticacao, "Codigo ou senha incorretos");

                return FormataRetorno(login);
            }
        }

        [HttpGet("claims/{id}")]
        public ActionResult claims(int id)
        {
            return Ok(User.Claims.Where(x => x.Value == id.ToString()).Count());
        }

        [HttpGet("teste")]
        public ActionResult Teste()
        {
            return Ok("Maravilha! Tudo dando certo por aqui");
        }
    }
}