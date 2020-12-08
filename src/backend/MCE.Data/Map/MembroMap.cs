using MCE.Domain.Entities.Endereco;
using MCE.Domain.Entities.Membro;
using MCE.Domain.Entities.Pessoa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCE.Data.Map
{
    public class MembroMap : IEntityTypeConfiguration<MembroEntity>
    {
        public void Configure(EntityTypeBuilder<MembroEntity> builder)
        {
            builder.ToTable("MCE_MEMBRO");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.CargoMinisterial);                   

            builder.Property(m => m.DataBatismoAguas);

            builder.Property(m => m.MembroEhAtivo);

            builder.Property(m => m.GerarCredencial);

            builder.Property(m => m.DataBatismoEspiritoSanto);

            builder.Property(m => m.CredencialMinistro);

            builder.Property(m => m.Congregacao)
                   .HasMaxLength(160);

            builder.Property(m => m.Email)
                    .HasMaxLength(160);

            builder.HasOne(e => e.Endereco)
                   .WithOne()
                   .HasForeignKey<EnderecoEntity>(m => m.IdPessoaEndereco);

            builder.HasOne(p => p.Pessoa)
                    .WithOne()
                    .HasForeignKey<PessoaEntity>(m => m.IdPessoaMembro);
        }
    }
}
