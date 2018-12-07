using API.Modelos;
using API.Servicos.Interfaces;
using API.Uteis.Login;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Servicos
{
    public class LoginServico : ILoginServico
    {
        /*
         tutorial sobre JWT usado como base para este projeto
         http://jasonwatmore.com/post/2018/08/14/aspnet-core-21-jwt-authentication-tutorial-with-example-api#users-controller-cs */


        public Configuracoes _configuracoes { get; }

        public LoginServico(IOptions<Configuracoes> configuracoes)
        {
            _configuracoes = configuracoes.Value;
        }

        public AutenticacaoUsuario Autenticar(int codigo, string senha)
        {
            //buscar usuario do serviço depois
            Usuario usuario = new Usuario();
            usuario.Codigo = codigo;
            usuario.Senha = usuario.Senha;
            usuario.Id = 27;
            //buscar usuario do serviço depois

            if (usuario == null) return null;

            // autenticação válida, prosseguir com a geração do token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuracoes.ChaveSecreta);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);


            AutenticacaoUsuario autenticacao = new AutenticacaoUsuario();
            autenticacao.Usuario = usuario;
            autenticacao.Token = tokenHandler.WriteToken(token);

            // remover a senha antes de retornar
            autenticacao.Usuario.Senha = null;

            return autenticacao;
        }
    }
}
