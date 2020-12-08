using MCE.Data.Context;
using MCE.Domain.Entities.Parametrizacao;
using MCE.Domain.Interfaces.Repositorio.Parametrizacao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using MCE.Domain.Dtos.Usuario;

namespace MCE.Data.Repositorio
{
    public class RepositorioParametrizacaoCredencial : RepositorioBase<ParametrizacaoGeralEntity>, IRepositorioParametrizacaoGeral 
    {
        private DbSet<ParametrizacaoGeralEntity> _dataSet;
        public RepositorioParametrizacaoCredencial(Contexto contexto) : base(contexto)
        {
            _dataSet = contexto.Set<ParametrizacaoGeralEntity>();
        }

        public override async Task<ParametrizacaoGeralEntity> SelecioneAsync(Guid id)
        {
            return await _dataSet.SingleOrDefaultAsync();
        }

        public virtual async Task<bool> DeleteAll()
        {            
            try
            {               
                _contexto.Database.ExecuteSqlCommand("TRUNCATE TABLE MCE_PARAMETRIZACAOCREDENCIAL");
                await _contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }

            return true;
        }        
    }
}
