using JsDesenvolvimento.Eshopping.Api.Authentication;
using JsDesenvolvimento.Eshopping.Api.Authentication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsDesenvolvimento.Eshopping.Api.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticateService AuthenticateService;

        public LoginController(IAuthenticateService authenticateService)
        {
            this.AuthenticateService = authenticateService;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Autenticar([FromBody] UsuarioAplicacao value, [FromServices] IAuthenticateService authenticate)
        {
            try
            {
                var infoLogin = authenticate.Authenticate(value.Login, value.Senha);
                return Ok(infoLogin);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
