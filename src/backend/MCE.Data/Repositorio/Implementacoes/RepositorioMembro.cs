using MCE.Data.Context;
using MCE.Domain.Entities.Membro;
using MCE.Domain.Interfaces.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCE.Data.Repositorio
{
    public class RepositorioMembro : RepositorioBase<MembroEntity>, IRepositorioMembro
    {
        private DbSet<MembroEntity> _dataSet;
        public RepositorioMembro(Contexto contexto) : base(contexto)
        {
            _dataSet = contexto.Set<MembroEntity>();
        }

        public override async Task<IEnumerable<MembroEntity>> SelecioneListaAsync()
        {
            try
            {
                var retorno = await _dataSet
                                        .Include(p => p.Pessoa)
                                        .Include(e => e.Endereco)
                                        .ToListAsync();
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<MembroEntity> AtualizeAsync(MembroEntity pessoaAtualizada)
        {
            try
            {
                var pessoaConsultada = _dataSet
                    .Include(x => x.Endereco)
                    .Include(x => x.Pessoa)
                    .Where(x => x.Id == pessoaAtualizada.Id)
                    .Single();

                if (pessoaConsultada == null)
                {
                    return null;
                }

                pessoaAtualizada.UpdateAt = DateTime.UtcNow;
                pessoaAtualizada.CreateAt = pessoaConsultada.CreateAt;
                pessoaAtualizada.Pessoa.Id = pessoaConsultada.Pessoa.Id;
                pessoaAtualizada.Endereco.Id = pessoaConsultada.Endereco.Id;
                pessoaAtualizada.Pessoa.IdPessoaMembro = pessoaConsultada.Pessoa.IdPessoaMembro;
                pessoaAtualizada.Endereco.IdPessoaEndereco = pessoaConsultada.Endereco.IdPessoaEndereco;
                _contexto.Entry(pessoaConsultada.Pessoa).CurrentValues.SetValues(pessoaAtualizada.Pessoa);
                _contexto.Entry(pessoaConsultada.Endereco).CurrentValues.SetValues(pessoaAtualizada.Endereco);
                _contexto.Entry(pessoaConsultada).CurrentValues.SetValues(pessoaAtualizada);
                
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return pessoaAtualizada;
        }

        public override async Task<MembroEntity> SelecioneAsync(Guid id)
        {
            var retorno = await _dataSet.Include(m => m.Pessoa).Include(e => e.Endereco).SingleOrDefaultAsync(s => s.Id == id);
            return retorno;
        }
    }
}
