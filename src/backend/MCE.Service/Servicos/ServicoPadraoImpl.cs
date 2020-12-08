using AutoMapper;
using MCE.Domain.Entities;
using MCE.Domain.Interfaces;
using MCE.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCE.Service.Servicos
{
    public abstract class ServicoPadraoImpl<TEntidade, TDto> : IServicoPadrao<TEntidade, TDto>
         where TEntidade : EntidadeBase
         where TDto : class
    {
        private readonly IMapper _mapper;
        private readonly IRepositorioBase<TEntidade> _repositorioBase;
        public ServicoPadraoImpl(IMapper mapper, IRepositorioBase<TEntidade> repositorioBase)
        {
            _mapper = mapper;
            _repositorioBase = repositorioBase;
        }

        public virtual async Task<TDto> Atualize(TDto dto)
        {
            try
            {
                if (dto != null)
                {
                    var objetoConvertido = _mapper.Map<TEntidade>(dto);
                    var existe = await _repositorioBase.ExistsAsync(objetoConvertido.Id);
                    if (existe)
                    {
                        objetoConvertido.UpdateAt = DateTime.UtcNow;
                        var dtoAtualizado = _mapper.Map<TDto>(await _repositorioBase.AtualizeAsync(objetoConvertido));

                        return dtoAtualizado;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return null;
        }

        public virtual async Task<TDto> Cadastre(TDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return null;
                }

                var objetoConvertido = _mapper.Map<TEntidade>(dto);

                var existe = await _repositorioBase.ExistsAsync(objetoConvertido.Id);
                if (!existe)
                {
                    objetoConvertido.UpdateAt = DateTime.UtcNow;
                    var dtoCadasrado = _mapper.Map<TDto>(await _repositorioBase.SalvarAsync(objetoConvertido));

                    return dtoCadasrado;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return null;
        }

        public virtual async Task<bool> Exclua(Guid id)
        {
            try
            {
                var existe = await _repositorioBase.ExistsAsync(id);
                if (existe)
                {
                    return await _repositorioBase.DeleteAsync(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return false;
        }

        public virtual async Task<TDto> ObtenhaPorId(Guid id)
        {
            try
            {
                var membro = await _repositorioBase.SelecioneAsync(id);

                if (membro != null)
                {
                    return _mapper.Map<TDto>(membro);
                }

                return null;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual async Task<IEnumerable<TDto>> ObtenhaTodos()
        {
            try
            {
                var lista = await _repositorioBase.SelecioneListaAsync();

                return _mapper.Map<IEnumerable<TDto>>(lista);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
