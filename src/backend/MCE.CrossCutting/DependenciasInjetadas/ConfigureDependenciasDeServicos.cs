using MCE.Domain.Interfaces.Membro;
using MCE.Domain.Interfaces.Parametrizacao;
using MCE.Domain.Interfaces.Servicos.Login;
using MCE.Domain.Interfaces.Servicos.Usuario;
using MCE.Service.Servicos.Login;
using MCE.Service.Servicos.Membro;
using MCE.Service.Servicos.Parametrizacao;
using Microsoft.Extensions.DependencyInjection;

namespace MCE.CrossCutting.DependenciasInjetadas
{
    public class ConfigureDependenciasDeServicos
    {
        public static void ConfiguracaoDeDependenciaDeServicos(IServiceCollection services)
        {
            services.AddTransient<IServicoDeMembro, ServicoDeMembroImpl>();
            services.AddTransient<IServicoDeParametrizacaoGeral, ServicoDeParametrizacaoGeralmpl>();
            services.AddTransient<IServicoDeLogin, ServicoDeLoginImpl>();
            services.AddTransient<IServicoDeUsuario, ServicoDeUsuariolmpl>();
        }
    }
}
