using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RodoNavesTest.Models;
using RodoNavesTest.Models.ViewModels;
using RodoNavesTest.Services;

namespace RodoNavesTest.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Unidades")]
    public class UnidadeController : ControllerBase
    {
        private readonly IUnidadeService _unidadeService;

        public UnidadeController(IUnidadeService unidadeService)
        {
            _unidadeService = unidadeService;
        }

        [HttpGet("listagem")]
        public async Task<IActionResult> ListagemUnidadeAsync() 
        {
            var result = await _unidadeService.ListagemUnidadeAsync();
            return Ok(result);
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastroUnidadeAsync([FromBody] Unidades unidade) 
        {
            var result = await _unidadeService.CadastroUnidadeAsync(unidade);
            return Ok(result);
        }

        [HttpPut("Atualizar{id}")]
        public async Task<IActionResult> AtualizarUnidadeAsync([FromRoute] int id, AtualizarUnidadeViewModel unidadeModel) 
        {
            var result = await _unidadeService.AtualizarUnidadeAsync(unidadeModel, id);
            if (result == null) { NotFound("Erro ao encontrar unidade"); }

            return Ok(result);
        }
    }
}
