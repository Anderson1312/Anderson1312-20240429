using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RodoNavesTest.Models;
using RodoNavesTest.Models.ViewModels;
using RodoNavesTest.Services;

namespace RodoNavesTest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Colaborador")]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorService _colaboradorService;

        public ColaboradorController(IColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }

        [HttpGet("todos")]
        public async Task<IActionResult> ListagemColaboradorAsync() 
        {
            var result = await _colaboradorService.ListagemColaboradoresAsync();

            return Ok(result);
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastroColaboradorAsync([FromBody] Colaboradores colaboradorCadastro) 
        {
            var colaborador = await _colaboradorService.CadastroColaboradorAsync(colaboradorCadastro);
            if (colaborador == null) { return NotFound("Erro ao encontrar unidade relacionada como ativa"); }
            return Ok("Sucesso");
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> AtualizarColaboradorAsync([FromRoute] int id, AtualizarColaboradorViewModel colaboradorModel) 
        {
            var result = await _colaboradorService.AtualizarColaboradorAsync(id, colaboradorModel);
            if (result == null) { return NotFound("Não encontrado"); }
            return Ok(result);
        }

        [HttpDelete("deletar/{id}")]
        public async Task<IActionResult> DeletarColaboradorAsync([FromRoute] int id) 
        {
            var result = await _colaboradorService.DeletarColaboradorAsync(id);
            return Ok(result);
        }
        
    }
}
