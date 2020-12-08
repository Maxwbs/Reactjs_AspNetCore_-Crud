using MCE.Domain.Entities.Endereco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCE.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoEntity>
    {
        public void Configure(EntityTypeBuilder<EnderecoEntity> builder)
        {
            builder.ToTable("MCE_ENDERECO");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Cep)
                    .HasMaxLength(50);

            builder.Property(e => e.Logradouro)
                    .HasMaxLength(200);

            builder.Property(e => e.Complemento)
                    .HasMaxLength(200); 

            builder.Property(e => e.Bairro)
                    .HasMaxLength(200); 
           
           builder.Property(e => e.Localidade)
                    .HasMaxLength(200); 
           
           builder.Property(e => e.Uf)
                    .HasMaxLength(10);

            builder.Property(e => e.Ddd)
                    .HasMaxLength(10);         

        }
    }
}
