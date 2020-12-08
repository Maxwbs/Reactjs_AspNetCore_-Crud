using MCE.Domain.Dtos;
using MCE.Domain.Entities.Membro;
using MCE.Domain.Interfaces.Servicos;

namespace MCE.Domain.Interfaces.Membro
{
    public interface IServicoDeMembro : IServicoPadrao<MembroEntity, DtoMembro>
    {         
    }
}
