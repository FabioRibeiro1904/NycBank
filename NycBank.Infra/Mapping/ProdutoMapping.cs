using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NycBank.Domain.Entities;
using System.Collections.Generic;

namespace NycBank.Infra.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.ProdutoId);
            builder.Property(x => x.Nome)
                .HasColumnType("varchar(30)")
                .IsRequired();

            builder.Property(x => x.Preco)
                .HasPrecision(18, 2);
            //HasColumnType("decimal(18,2)") ;


            builder.HasMany(x => x.Categorias)
                .WithMany(x => x.Produtos)
                 .UsingEntity<Dictionary<string, object>>("ProdutoCategoria",
                 x=>x.HasOne<Categoria>()
                 .WithMany()
                 .HasForeignKey("CategoriaId")
                 .HasConstraintName("FK_ProdutoCategoria_Categoria_CategoriaId")
                 .OnDelete(DeleteBehavior.Cascade),
                 x=>x.HasOne<Produto>()
                 .WithMany()
                 .HasForeignKey("ProdutoId")
                 .HasConstraintName("FK_CategoriaProduto_Produto_ProdutoId")
                 .OnDelete(DeleteBehavior.Cascade));



        }
    }
}
