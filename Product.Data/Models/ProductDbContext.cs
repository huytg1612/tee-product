using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {

        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductVariant> ProductVariant { get; set; }

        //public const string ConnectionString = "Server=rds-postgresql-10mintutorial.ch7isqdwvyt9.us-west-2.rds.amazonaws.com;Port=5432;Database=dev_product;User Id=huytg;Password=huy123456";
        public const string ConnectionString = "Server=tee-product.postgres.database.azure.com;Database=dev_product;Port=5432;User Id=saleor;Password=Admin123456;";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.Property(p => p.Name).HasMaxLength(250);
                entity.HasIndex(p => p.Slug).IsUnique();
                entity.HasOne(p => p.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<ProductVariant>(entity =>
            {
                entity.ToTable("ProductVariant");
                entity.Property(p => p.Name).HasMaxLength(250);
                entity.HasIndex(p => p.Slug).IsUnique();
                entity.HasOne(p => p.Product)
                    .WithMany(p => p.ProductVariants)
                    .HasForeignKey(p => p.ProductId)
                    .HasConstraintName("FK_ProductVariant_Product");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.Property(p => p.Name).HasMaxLength(250);
                entity.HasIndex(p => p.Slug).IsUnique();
            });
        }
    }
}
