using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace JsDesenvolvimento.Eshopping.Api.Authentication.Model
{
    public class UsuarioAplicacao
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public int Codigo { get; set; }
        public List<string> Roles { get; set; }
        public Claim Claims { get; set; }
    }
}
