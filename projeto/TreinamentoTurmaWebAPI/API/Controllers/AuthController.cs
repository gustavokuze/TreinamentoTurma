using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public ActionResult ObterToken()
        {
            string chaveDeSeguranca = "chave_de_segurança_extremamente_segura_pra_testar_o_algoritmo_06-12-2018";

            var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveDeSeguranca));

            var credenciaisEntrada = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credenciaisEntrada
            );

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}