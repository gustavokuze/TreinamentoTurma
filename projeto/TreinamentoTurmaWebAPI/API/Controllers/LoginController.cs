using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using API.Modelos;
using API.Servicos.Interfaces;
using API.Uteis.Retornos.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        private ILoginServico _loginServico;

        public LoginController(ILoginServico loginServico)
        {
            _loginServico = loginServico;
        }
        
        /* Curiosidade importante pra vida: Caso a anotação allow anonymous esteja presente, 
         * ou o authorize não tenha sido definido na controller, a propriedade base.User é do tipo WindowsIdentity e não ClaimsIdentity, 
         * e assim não é possível ler o "usuário atual logado" na API */
        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public Retorno<AutenticacaoUsuario, Falha> Autenticar([FromBody]AutenticacaoUsuario autenticacao)
        {
            /*Esse código comentado seria util caso o token precisasse ser validado*/
            //var token = autenticacao.Token;
            //var tokHandler = new JwtSecurityTokenHandler();
            //if (token != string.Empty && tokHandler.CanReadToken(token)) //token formatado adequadamente?
            //{
            //    var jwtTokenLido = tokHandler.ReadJwtToken(token); //deserializa o token
            //    if (jwtTokenLido.ValidTo.CompareTo(DateTime.UtcNow) > 0) // ainda não expirou
            //    {
            //        var jwtTokenLidoClaimsCount = jwtTokenLido.Claims.Where(x => x.Value == autenticacao.Usuario.Id.ToString()).Count(); //conta quantos claims vindos do token possuem o Id do usuário passado

            //        if (jwtTokenLidoClaimsCount > 0)
            //        {
            //            return FormataRetorno(autenticacao); //retorna o mesmo token que ainda está válido
            //        }
            //    }
            //}
              
            //caso o token passado não seja válido, ou não esteja presente, gera um novo token com o usuário e senha passados
            var login = _loginServico.Autenticar(autenticacao.Usuario.Codigo, autenticacao.Usuario.Senha);
            if (!login.EstaValido)
                return FormataRetorno(autenticacao, "Codigo ou senha incorretos");

            return FormataRetorno(login.Sucesso);
        }

        //[HttpGet("claims/{id}")]
        //public ActionResult claims(int id)
        //{
        //    return Ok(User.Claims.Where(x => x.Value == id.ToString()).Count());
        //}

        //[HttpGet("teste")]
        //public ActionResult Teste()
        //{
        //    return Ok("Maravilha! Tudo dando certo por aqui");
        //}
    }
}