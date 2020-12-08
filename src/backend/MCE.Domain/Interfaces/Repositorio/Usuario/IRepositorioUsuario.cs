using MCE.Domain.Dtos.Login;
using MCE.Domain.Entities.Usuario;
using System.Threading.Tasks;

namespace MCE.Domain.Interfaces.Repositorio.Usuario
{
    public interface IRepositorioUsuario: IRepositorioBase<UsuarioEntity>
    {
        Task<UsuarioEntity> ConsulteLogin(UsuarioEntity usuario);         
    }
}
