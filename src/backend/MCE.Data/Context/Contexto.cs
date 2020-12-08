using MCE.Data.Map;
using MCE.Domain.Entities.Endereco;
using MCE.Domain.Entities.Membro;
using MCE.Domain.Entities.Parametrizacao;
using MCE.Domain.Entities.Pessoa;
using MCE.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using System;

namespace MCE.Data.Context
{
    public class Contexto : DbContext
    {
        public DbSet<EnderecoEntity> Enderecos { get; set; }
        public DbSet<PessoaEntity> Pessoas { get; set; }
        public DbSet<MembroEntity> Membros { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PessoaEntity>(new PessoaMap().Configure);
            modelBuilder.Entity<MembroEntity>(new MembroMap().Configure);
            modelBuilder.Entity<EnderecoEntity>(new EnderecoMap().Configure);
            modelBuilder.Entity<ParametrizacaoGeralEntity>(new ParametrizacaoCredencialMap().Configure);
            modelBuilder.Entity<UsuarioEntity>().HasData(
            new UsuarioEntity
            {
                Id = Guid.NewGuid(),
                Nome = "Administrador",
                Senha= "1234",
                Email = "maxwbs@gmail.com",
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
