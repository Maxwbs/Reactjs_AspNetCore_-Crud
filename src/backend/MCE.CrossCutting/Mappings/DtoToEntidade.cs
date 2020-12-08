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
    public class DtoToEntidade : Profile
    {
        public DtoToEntidade()
        {
            CreateMap<DtoMembro, MembroEntity>()
             .ForMember(dest => dest.Pessoa, act => act.MapFrom(src => src.DtoPessoa))
             .ForMember(dest => dest.Endereco, act => act.MapFrom(src => src.DtoEndereco));

            CreateMap<DtoPessoa, PessoaEntity>()
           .ForMember(dest => dest.Nome, act => act.MapFrom(src => src.Nome));


            CreateMap<DtoEndereco, EnderecoEntity>()
           .ForMember(dest => dest.Cep, act => act.MapFrom(src => src.Cep));

            CreateMap<DtoParametrizacaoGeral, ParametrizacaoGeralEntity>().ReverseMap();

            CreateMap<DtoUsuario, UsuarioEntity>().ReverseMap();

            CreateMap<DtoLogin, UsuarioEntity>().ReverseMap();
        }
    }
}
