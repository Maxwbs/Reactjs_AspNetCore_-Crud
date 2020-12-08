using MCE.Domain.Entities.Parametrizacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCE.Data.Map
{
    public class ParametrizacaoCredencialMap : IEntityTypeConfiguration<ParametrizacaoGeralEntity>
    {
        public void Configure(EntityTypeBuilder<ParametrizacaoGeralEntity> builder)
        {
            builder.ToTable("MCE_PARAMETRIZACAOCREDENCIAL");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Extensao)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(x => x.Tamanho)
                .IsRequired();

            builder.Property(x => x.Imagem);

            builder.Property(x => x.ContentType)
            .IsRequired()
            .HasMaxLength(20);
        }
    }
}
