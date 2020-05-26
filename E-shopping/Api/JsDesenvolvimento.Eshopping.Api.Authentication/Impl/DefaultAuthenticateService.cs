﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JsDesenvolvimento.Eshopping.Api.Authentication.Model;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace JsDesenvolvimento.Eshopping.Api.Authentication.Impl
{
    public class DefaultAuthenticateService : IAuthenticateService
    {
        private IConfiguration Configuration { get; set; }

        public DefaultAuthenticateService(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public InformacoesLogin Authenticate(string username, string password)
        {
            var user = new UsuarioAplicacao()
            {
                Codigo = 1,
                Login = "Admin"
            };

            user.Roles = new List<string>();
            user.Roles.Add("Admin");

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.Configuration["SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim("Admin", user.Roles.First())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new InformacoesLogin()
            {
                TokenAssinado = tokenHandler.WriteToken(token),
                Login = user.Login
            };
        }
    }
}
