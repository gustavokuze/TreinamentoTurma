﻿using API.Modelos;
using API.Servicos.Interfaces;
using API.Uteis;
using API.Uteis.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Servicos
{
    public class LoginServico : ILoginServico
    {
        /*
         tutorial sobre JWT usado como base para este projeto
         http://jasonwatmore.com/post/2018/08/14/aspnet-core-21-jwt-authentication-tutorial-with-example-api#users-controller-cs */


        public Configuracoes _configuracoes { get; }
        public IUsuarioServico _usuarioServico { get; }

        public LoginServico(IOptions<Configuracoes> configuracoes, IUsuarioServico usuarioServico)
        {
            _configuracoes = configuracoes.Value;
            _usuarioServico = usuarioServico;
        }

        public Uteis.Retornos.Validacao.Resultado< AutenticacaoUsuario, Uteis.Retornos.Validacao.Falha> Autenticar(int codigo, string senha)
        {

            var senhaBase64 = Base64.ParaBase64(senha);
            var usuario = _usuarioServico.ValidarUsuario(codigo, senhaBase64);
            
            if (!usuario.EstaValido) return new Uteis.Retornos.Validacao.Falha("Codigo ou senha incorretos");

            usuario.Sucesso.Senha = senha;

            var claim = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.Sucesso.Id.ToString())
            });
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuracoes.ChaveSecreta);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claim,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            AutenticacaoUsuario autenticacao = new AutenticacaoUsuario();
            autenticacao.Usuario = usuario.Sucesso;
            autenticacao.Token = tokenHandler.WriteToken(token);
            

            return autenticacao;
        }
    }
}
