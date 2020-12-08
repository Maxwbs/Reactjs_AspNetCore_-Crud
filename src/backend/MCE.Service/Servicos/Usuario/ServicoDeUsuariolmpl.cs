using AutoMapper;
using MCE.Domain.Dtos.Usuario;
using MCE.Domain.Entities.Usuario;
using MCE.Domain.Interfaces.Repositorio.Usuario;
using MCE.Domain.Interfaces.Servicos.Usuario;

namespace MCE.Service.Servicos.Parametrizacao
{
    public class ServicoDeUsuariolmpl : ServicoPadraoImpl<UsuarioEntity, DtoUsuario>, IServicoDeUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        private IMapper _mapper;

        public ServicoDeUsuariolmpl(IRepositorioUsuario repositorioUsuario, IMapper mapper) : base(mapper, repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
            _mapper = mapper;
        }
    }
}
