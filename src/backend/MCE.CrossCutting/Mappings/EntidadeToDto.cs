using AutoMapper;
using MCE.Domain.Dtos;
using MCE.Domain.Dtos.Login;
using MCE.Domain.Dtos.ParametrizacaoGeral;
using MCE.Domain.Dtos.Usuario;
using MCE.Domain.Entities.Endereco;
using MCE.Domain.Entities.Membro;
using MCE.Domain.Entities.Parametrizacao;
using MCE.Domain.Entities.Pessoa;
using MCE.Domain.Entities.Usuario;

namespace MCE.CrossCutting.Mappings
{
    public class EntidadeToDto : Profile
    {
        public EntidadeToDto()
        {
            CreateMap<MembroEntity, DtoMembro>()
            .ForMember(dest => dest.DtoPessoa, act => act.MapFrom(src => src.Pessoa))
            .ForMember(dest => dest.DtoEndereco, act => act.MapFrom(src => src.Endereco));

            CreateMap<PessoaEntity, DtoPessoa>()
           .ForMember(dest => dest.Nome, act => act.MapFrom(src => src.Nome));

            CreateMap<EnderecoEntity, DtoEndereco>()
           .ForMember(dest => dest.Cep, act => act.MapFrom(src => src.Cep));

            CreateMap<ParametrizacaoGeralEntity, DtoParametrizacaoGeral>().ReverseMap();

            CreateMap<UsuarioEntity, DtoUsuario>().ReverseMap();

            CreateMap<UsuarioEntity, DtoLogin>().ReverseMap();
        }
    }
}
