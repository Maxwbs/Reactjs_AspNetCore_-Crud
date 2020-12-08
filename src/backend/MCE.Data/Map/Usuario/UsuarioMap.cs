using MCE.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MCE.Data.Map.Usuario
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioEntity>
    {
         public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("MCE_USUARIO");

            builder.HasKey(u => u.Id);
            
            builder.HasIndex(u => u.Email)
                    .IsUnique();

            builder.Property(u => u.Nome)
                    .IsRequired()
                    .HasMaxLength(60);

            builder.Property(u => u.Email)
                    .HasMaxLength(150);

            builder.Property(u => u.Senha)
                    .HasMaxLength(150);
        }
    }
}
