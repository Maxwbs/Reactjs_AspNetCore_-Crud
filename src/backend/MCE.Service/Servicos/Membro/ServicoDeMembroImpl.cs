using AutoMapper;
using MCE.Domain.Dtos;
using MCE.Domain.Entities.Membro;
using MCE.Domain.Interfaces;
using MCE.Domain.Interfaces.Membro;
using MCE.Domain.Interfaces.Repositorio;

namespace MCE.Service.Servicos.Membro
{
    public class ServicoDeMembroImpl : ServicoPadraoImpl<MembroEntity, DtoMembro>, IServicoDeMembro
    {
        private IRepositorioMembro _repositorioMembro;

        public ServicoDeMembroImpl(IRepositorioMembro repositorioMembro, IMapper mapper) : base(mapper, repositorioMembro)
        {
            _repositorioMembro = repositorioMembro;
        }
    }
}
