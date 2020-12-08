
using MCE.Domain.Entities.Parametrizacao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCE.Domain.Interfaces.Repositorio.Parametrizacao
{
    public interface IRepositorioParametrizacaoGeral : IRepositorioBase<ParametrizacaoGeralEntity>  
    {        
        Task<bool> DeleteAll();
    }
}
