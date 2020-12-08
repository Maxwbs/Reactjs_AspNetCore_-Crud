using MCE.Data.Context;
using MCE.Data.Repositorio;
using MCE.Domain.Interfaces;
using MCE.Domain.Interfaces.Repositorio;
using MCE.Domain.Interfaces.Repositorio.Parametrizacao;
using MCE.Domain.Interfaces.Repositorio.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MCE.CrossCutting.DependenciasInjetadas
{
    public class ConfigureDependenciasDeRepositorios
    {
        public static void ConfiguracaoDeDependenciaDeRepositorios(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped(typeof(IRepositorioMembro), typeof(RepositorioMembro));
            services.AddScoped(typeof(IRepositorioParametrizacaoGeral), typeof(RepositorioParametrizacaoCredencial));
            services.AddScoped(typeof(IRepositorioUsuario), typeof(RepositorioUsuario));

            services.AddDbContext<Contexto>
            (
                options => options.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=CLI_MCE;Integrated Security=False;User ID=sa;Password=fpw;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;MultipleActiveResultSets=True;")
            );

        }
    }
}
