using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MCE.Domain.Entities;

namespace MCE.Domain.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<T> SalvarAsync(T item);
        Task<T> AtualizeAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelecioneAsync(Guid id);
        Task<IEnumerable<T>> SelecioneListaAsync();
        Task<bool> ExistsAsync(Guid id);
    }
}
