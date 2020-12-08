using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCE.Domain.Interfaces.Servicos
{
    public interface IServicoPadrao<TObjeto, TDto>
    {
         Task<TDto> ObtenhaPorId(Guid id);
         
         Task<IEnumerable<TDto>> ObtenhaTodos();

         Task<TDto> Cadastre(TDto dto);

         Task<TDto> Atualize(TDto dto);

         Task<bool> Exclua(Guid id);         
    }
}
