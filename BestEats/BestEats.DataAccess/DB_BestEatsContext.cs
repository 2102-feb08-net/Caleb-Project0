using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BestEats.DataAccess
{
    public partial class DB_BestEatsContext : DbContext
    {
        public DB_BestEatsContext()
        {
        }

        public DB_BestEatsContext(DbContextOptions<DB_BestEatsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId)
                    .HasName("PK__Customer__9725F2E6F9041995");

                entity.ToTable("Customer", "BE");

                entity.HasIndex(e => e.FullName, "UQ__Customer__C8B4CE9F43E6AC4C")
                    .IsUnique();

                entity.Property(e => e.CustId).HasColumnName("custID");

                entity.Property(e => e.CustPassword)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("custPassword")
                    .HasDefaultValueSql("('livelaughlove')");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("fullName")
                    .HasDefaultValueSql("('insertname')");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ProductId })
                    .HasName("ck_inventory");

                entity.ToTable("Inventory", "BE");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_Inv_product");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("fk_Inv_store");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders", "BE");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("itemName")
                    .HasDefaultValueSql("('Default Product')");

                entity.Property(e => e.OrderPurchaseDate)
                    .HasColumnName("orderPurchaseDate")
                    .HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductQuantity).HasColumnName("productQuantity");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__customer__52CE3E04");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Orders__productI__54B68676");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Orders__storeId__53C2623D");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Packages", "BE");

                entity.Property(e => e.PackageId).HasColumnName("packageID");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_pack_customer");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pack_orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_pack_product");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("fk_pack_store");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "BE");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("productID");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("productName")
                    .HasDefaultValueSql("('Default Product')");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "BE");

                entity.Property(e => e.StoreId)
                    .ValueGeneratedNever()
                    .HasColumnName("storeID");

                entity.Property(e => e.StoreLocation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("storeLocation")
                    .HasDefaultValueSql("('Store Location')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
