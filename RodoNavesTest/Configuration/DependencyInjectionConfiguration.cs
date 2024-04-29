using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using RodoNavesTest.Data;
using RodoNavesTest.Data.Repositories;
using RodoNavesTest.Models;
using RodoNavesTest.Services;
using Microsoft.EntityFrameworkCore;

namespace RodoNavesTest.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDI(this IServiceCollection services, IConfiguration configuration)
        {  
            services.AddScoped<ApplicationDbContext>();

            services.AddRepositories();
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IColaboradorService, ColaboradorService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUnidadeService, UnidadeService>();
        }       

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUnidadeRepository, UnidadeRepository>();
        }
    }
}
