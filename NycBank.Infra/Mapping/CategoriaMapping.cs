using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NycBank.Domain.Entities;

namespace NycBank.Infra.Mapping
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("voucher(30)")
                .IsRequired();

            builder.HasMany(x => x.Produtos)
                .WithMany(x => x.Categorias);


        }
    }
}
