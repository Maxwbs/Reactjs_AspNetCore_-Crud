using MCE.Data.Context;
using MCE.Domain.Dtos.Usuario;
using MCE.Domain.Entities.Usuario;
using MCE.Domain.Interfaces.Repositorio.Usuario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MCE.Data.Repositorio
{
    public class RepositorioUsuario : RepositorioBase<UsuarioEntity>, IRepositorioUsuario 
    {
        private DbSet<UsuarioEntity> _dataSet;
        
        public RepositorioUsuario(Contexto contexto) : base(contexto)
        {
            _dataSet = contexto.Set<UsuarioEntity>();
        }

        public async Task<UsuarioEntity> ConsulteLogin(UsuarioEntity dtoUsuario)
        {
            try
            {
                return await _dataSet.FirstOrDefaultAsync(c => c.Email.ToUpper() == dtoUsuario.Email.ToUpper() && c.Senha == dtoUsuario.Senha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
