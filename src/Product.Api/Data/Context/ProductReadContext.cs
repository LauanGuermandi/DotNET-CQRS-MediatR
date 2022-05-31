using Microsoft.EntityFrameworkCore;
using Products.Api.Domain;

namespace Products.Api.Data.Context
{
    public class ProductReadContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductReadContext(DbContextOptions<ProductReadContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .ToTable("PRODUCTS");

            modelBuilder
                .Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasColumnType("varchar(255)")
                .IsRequired();

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("money")
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
