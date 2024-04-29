using RodoNavesTest.Data.Repositories;
using RodoNavesTest.Models;
using RodoNavesTest.Models.ViewModels;
using System.Threading.Tasks;

namespace RodoNavesTest.Services
{
    public interface IColaboradorService 
    {
        Task<IEnumerable<Colaboradores>> ListagemColaboradoresAsync();
        Task<Colaboradores> CadastroColaboradorAsync(Colaboradores colaborador);
        Task<Colaboradores?> AtualizarColaboradorAsync(int id, AtualizarColaboradorViewModel colaborador);
        Task<Colaboradores?> DeletarColaboradorAsync(int id);
    }

    public class ColaboradorService : IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<IEnumerable<Colaboradores>> ListagemColaboradoresAsync() 
        {
            return await _colaboradorRepository.ListagemColaboradoresAsync();
        }

        public async Task<Colaboradores?> CadastroColaboradorAsync(Colaboradores colaborador) 
        {
            return await _colaboradorRepository.CadastroColaboradorAsync(colaborador);
        }

        public async Task<Colaboradores?> AtualizarColaboradorAsync(int id, AtualizarColaboradorViewModel colaborador) 
        {
            return await _colaboradorRepository.AtualizarColaboradorAsync(id, colaborador);
        }

        public async Task<Colaboradores?> DeletarColaboradorAsync(int id) 
        {
            return await _colaboradorRepository.DeletarColaboradorAsync(id); 
        }

    }
}
