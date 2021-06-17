using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NycBank.Domain.Entities;

namespace NycBank.Infra.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(x => x.Preco)
                .HasPrecision(18, 2);
            //HasColumnType("decimal(18,2)") ;
        }
    }
}
