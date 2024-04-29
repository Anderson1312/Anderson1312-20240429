using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RodoNavesTest.Services;

namespace RodoNavesTest.Controllers
{
    public class AutenticacaoController : ControllerBase
    {
        private readonly TokenService _tokenService;
        public AutenticacaoController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("Autenticacao")]
        public IActionResult Login()
        {
            var token = _tokenService.GenerateToken(null);

            return Ok(token);
        }
    }
}
