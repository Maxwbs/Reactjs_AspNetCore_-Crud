using MCE.Domain.Entities.Pessoa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCE.Data.Map
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {
            builder.ToTable("MCE_PESSOA");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Cpf);

            builder.Property(p => p.Nome)
                    .IsRequired()
                    .HasMaxLength(260);

            builder.Property(p => p.DataNascimento)
                    .IsRequired();

            builder.Property(p => p.EstadoCivil)
                   .IsRequired();

            builder.Property(p => p.Nacionalidade);

            builder.Property(p => p.Naturalidade);

            builder.Property(p => p.NomeMae)
                  .IsRequired()
                  .HasMaxLength(260);

             builder.Property(p => p.NomePai)
                  .IsRequired()
                  .HasMaxLength(260);     

             builder.Property(p => p.OrgaoEmissorRg)
                  .HasMaxLength(160); 

             builder.Property(p => p.Rg)
                  .HasMaxLength(100);

             builder.Property(p => p.Sexo)
                  .IsRequired();            
        }
    }
}
