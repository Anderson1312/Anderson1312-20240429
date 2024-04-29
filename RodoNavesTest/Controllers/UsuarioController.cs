using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RodoNavesTest.Models;
using RodoNavesTest.Models.ViewModels;
using RodoNavesTest.Services;

namespace RodoNavesTest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("lista/{status}")]
        public async Task<IActionResult> ListagemUsuarioAsync([FromRoute] bool status) 
        {
            var result = await _usuarioService.ListagemUsuarioAsync(status);

            return Ok(result);        
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastroUsuarioAsync(Usuario usuario) 
        {
            if (usuario == null) { return BadRequest("Nada informado"); }
            var result = await _usuarioService.CadastroUsuarioAsync(usuario);
            return Ok(result);
        }

        [HttpPut("atualizar{id}")]
        public async Task<IActionResult> AtualizarUsuarioAsync([FromRoute] int id, AtualizarUsuarioViewModel usuarioModel) 
        {
            var result = await _usuarioService.AtualizarUsuarioAsync(usuarioModel, id);
            if(result == null) { return BadRequest("Erro"); }
            return Ok(result);
        }
    }
}
