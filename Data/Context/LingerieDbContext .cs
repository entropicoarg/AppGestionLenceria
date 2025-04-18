using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class LingerieDbContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }

        public LingerieDbContext(DbContextOptions<LingerieDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Entity configuration

            // Supplier
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CreationDate).IsRequired();
                entity.Property(e => e.LastModificationDate).IsRequired();
            });

            // Color
            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });

            // Size
            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
            });

            // Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            // ProductColor (Junction table)
            modelBuilder.Entity<ProductColor>(entity =>
            {
                entity.HasKey(pc => new { pc.ProductId, pc.ColorId });

                entity.HasOne(pc => pc.Product)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(pc => pc.ProductId);

                entity.HasOne(pc => pc.Color)
                    .WithMany(c => c.ProductColors)
                    .HasForeignKey(pc => pc.ColorId);
            });

            // ProductCategory (Junction table)
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(pc => new { pc.ProductId, pc.CategoryId });

                entity.HasOne(pc => pc.Product)
                    .WithMany(p => p.ProductCategories)
                    .HasForeignKey(pc => pc.ProductId);

                entity.HasOne(pc => pc.Category)
                    .WithMany(c => c.ProductCategories)
                    .HasForeignKey(pc => pc.CategoryId);
            });

            // Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.CreationDate).IsRequired();
                entity.Property(e => e.LastModificationDate).IsRequired();
                entity.Property(e => e.Cost).HasColumnType("decimal(18,2)");
                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.RoundedPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Profitability).HasColumnType("decimal(18,2)");
                entity.Property(e => e.SKU).HasMaxLength(50);
                entity.Property(e => e.OrderNumber).HasMaxLength(50);

                // Relationships
                entity.HasOne(e => e.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(e => e.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Size)
                    .WithMany(t => t.Products)
                    .HasForeignKey(e => e.SizeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.SocialMedia).HasMaxLength(500);
            });

            // Sale
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SaleDate).IsRequired();
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TicketNumber).HasMaxLength(50);
                entity.Property(e => e.InvoiceNumber).HasMaxLength(50);
                entity.Property(e => e.PaymentMethodDetail).HasMaxLength(100);

                // Relationship with Customer
                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.Sales)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // SaleDetail
            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");

                // Relationships
                entity.HasOne(e => e.Sale)
                    .WithMany(v => v.SaleDetails)
                    .HasForeignKey(e => e.SaleId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(e => e.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
