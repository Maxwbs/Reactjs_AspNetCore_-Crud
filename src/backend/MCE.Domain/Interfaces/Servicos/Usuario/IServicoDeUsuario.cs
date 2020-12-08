using MCE.Domain.Entities.Usuario;
using MCE.Domain.Dtos.Usuario;
using MCE.Domain.Interfaces.Servicos;

namespace MCE.Domain.Interfaces.Servicos.Usuario
{
    public interface IServicoDeUsuario: IServicoPadrao<UsuarioEntity, DtoUsuario>
    {
         
    }
}
