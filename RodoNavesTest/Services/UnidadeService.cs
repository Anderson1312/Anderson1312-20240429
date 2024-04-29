using RodoNavesTest.Data.Repositories;
using RodoNavesTest.Models;
using RodoNavesTest.Models.ViewModels;

namespace RodoNavesTest.Services
{
    public interface IUnidadeService 
    {
        Task<IEnumerable<Unidades>> ListagemUnidadeAsync();
        Task<bool> CadastroUnidadeAsync(Unidades unidade);
        Task<Unidades?> AtualizarUnidadeAsync(AtualizarUnidadeViewModel unidadeModel, int id);
    }

    public class UnidadeService : IUnidadeService
    {
        private readonly IUnidadeRepository _unidadeRepository;

        public UnidadeService(IUnidadeRepository unidadeRepository)
        {
            _unidadeRepository = unidadeRepository; 
        }

        public async Task<IEnumerable<Unidades>> ListagemUnidadeAsync()
        {
            return await _unidadeRepository.ListagemUnidadeAsync();
        }

        public async Task<bool> CadastroUnidadeAsync(Unidades unidade)
        {
            return await _unidadeRepository.CadastroUnidadeAsync(unidade);
        }

        public async Task<Unidades?> AtualizarUnidadeAsync(AtualizarUnidadeViewModel unidadeModel, int id)
        {
            return await _unidadeRepository.AtualizarUsuarioAsync(unidadeModel, id);
        }

    }
}
