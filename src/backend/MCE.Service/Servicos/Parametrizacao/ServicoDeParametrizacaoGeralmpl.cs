using MCE.Domain.Dtos.ParametrizacaoGeral;
using MCE.Domain.Entities.Parametrizacao;
using MCE.Domain.Interfaces.Parametrizacao;
using MCE.Domain.Interfaces.Repositorio;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AutoMapper;
using System;
using MCE.Domain.Interfaces;
using MCE.Domain.Interfaces.Repositorio.Parametrizacao;

namespace MCE.Service.Servicos.Parametrizacao
{
    public class ServicoDeParametrizacaoGeralmpl : ServicoPadraoImpl<ParametrizacaoGeralEntity, DtoParametrizacaoGeral>, IServicoDeParametrizacaoGeral
    {
        private IRepositorioParametrizacaoGeral _repositorioParametrizacaoCredencial;
        private IMapper _mapper;

        public ServicoDeParametrizacaoGeralmpl(IRepositorioParametrizacaoGeral repositorioParametrizacaoCredencial, IMapper mapper) : base(mapper, repositorioParametrizacaoCredencial)
        {
            _repositorioParametrizacaoCredencial = repositorioParametrizacaoCredencial;
            _mapper = mapper;
        }

        public override async Task<DtoParametrizacaoGeral> Cadastre(DtoParametrizacaoGeral dto)
        {
            try
            {
                if (dto == null)
            {
                return new DtoParametrizacaoGeral();
            }

            await _repositorioParametrizacaoCredencial.DeleteAll();

            var objetoParametrizacao = _mapper.Map<ParametrizacaoGeralEntity>(dto);
            var parametrizacaoGeralDto = _mapper.Map<DtoParametrizacaoGeral>(await _repositorioParametrizacaoCredencial.SalvarAsync(objetoParametrizacao));
            return parametrizacaoGeralDto;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
            
        }

        public async Task<bool> DeleteAll()
        {
            try
            {
                return await _repositorioParametrizacaoCredencial.DeleteAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
