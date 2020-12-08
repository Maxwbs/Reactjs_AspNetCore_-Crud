using MCE.Domain.Dtos.Login;
using System.Threading.Tasks;

namespace MCE.Domain.Interfaces.Servicos.Login
{
    public interface IServicoDeLogin
    {
        Task<object> ConsulteLogin(DtoLogin usuario);
    }
}
