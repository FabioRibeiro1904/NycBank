using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NycBank.Domain.Entities;

namespace NycBank.Infra.Mapping
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(x => x.CategoriaId);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(30)")
                .IsRequired();

        }
    }
}
