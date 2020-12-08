using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MCE.Data.Context;
using MCE.Domain.Entities;
using MCE.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCE.Data.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadeBase
    {
        protected readonly Contexto _contexto;
        private DbSet<T> _dataSet;
        
        public RepositorioBase(Contexto contexto)
        {
            _contexto = contexto;
            _dataSet = _contexto.Set<T>();
        }

        public virtual async Task<T> AtualizeAsync(T item)
        {
            try
            {
                var resultado = await SelecioneAsync(item.Id);

                if (resultado == null)
                {
                    return null;
                }

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = resultado.CreateAt;

                _contexto.Entry(resultado).CurrentValues.SetValues(item);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var resultado = await _dataSet.SingleOrDefaultAsync(p => p.Id == id);

                if (resultado == null)
                {
                    return false;
                }

                _dataSet.Remove(resultado);

                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public virtual async Task<bool> ExistsAsync(Guid id)
        {
            return await _dataSet.AnyAsync(p => p.Id == id);
        }

        public virtual async Task<T> SalvarAsync(T item)
        {
            try
            {                
                item.CreateAt = DateTime.UtcNow;
                _dataSet.Add(item);
               await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return item;
        }

        public virtual async Task<T> SelecioneAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<IEnumerable<T>> SelecioneListaAsync()
        {
              try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
