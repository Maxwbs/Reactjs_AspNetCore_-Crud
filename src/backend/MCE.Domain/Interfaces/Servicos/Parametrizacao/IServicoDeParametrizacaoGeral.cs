using MCE.Domain.Dtos.ParametrizacaoGeral;
using MCE.Domain.Entities.Parametrizacao;
using MCE.Domain.Interfaces.Servicos;
using System.Threading.Tasks;

namespace MCE.Domain.Interfaces.Parametrizacao
{
    public interface IServicoDeParametrizacaoGeral : IServicoPadrao<ParametrizacaoGeralEntity, DtoParametrizacaoGeral>
    {
        Task<bool> DeleteAll();
    }
}
