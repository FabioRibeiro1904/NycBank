using Microsoft.EntityFrameworkCore;
using NycBank.Domain.Entities;
using NycBank.Infra.Mapping;

namespace NycBank.Infra.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            modelBuilder.ApplyConfiguration(new CategoriaMapping());
        }
    }
}
