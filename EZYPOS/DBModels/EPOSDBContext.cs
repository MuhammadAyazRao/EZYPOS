using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EZYPOS.DBModels
{
    public partial class EPOSDBContext : DbContext
    {
        public EPOSDBContext()
        {
        }

        public EPOSDBContext(DbContextOptions<EPOSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AppPage> AppPages { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Emplyee> Emplyees { get; set; }
        public virtual DbSet<ExpenceTransaction> ExpenceTransactions { get; set; }
        public virtual DbSet<ExpenceType> ExpenceTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<UserPage> UserPages { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-IIIQBQ7\\SQLEXPRESS;Database=EPOS-DB;Trusted_Connection=False;User ID=sa;Password=A722713yaz");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Isdeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Createdon).HasColumnType("datetime");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Createdon).HasColumnType("datetime");

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.City)
                    .HasConstraintName("FK_Customer_City");
            });

            modelBuilder.Entity<Emplyee>(entity =>
            {
                entity.ToTable("Emplyee");

                entity.Property(e => e.Cnic).HasColumnName("CNIC");

                entity.Property(e => e.Createdon).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.Emplyees)
                    .HasForeignKey(d => d.City)
                    .HasConstraintName("FK_Emplyee_City");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Emplyees)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("FK_Emplyee_UserRole");
            });

            modelBuilder.Entity<ExpenceTransaction>(entity =>
            {
                entity.ToTable("ExpenceTransaction");

                entity.Property(e => e.ExpenceDate).HasColumnType("datetime");

                entity.HasOne(d => d.ExpenceTypeNavigation)
                    .WithMany(p => p.ExpenceTransactions)
                    .HasForeignKey(d => d.ExpenceType)
                    .HasConstraintName("FK_ExpenceTransaction_ExpenceType");
            });

            modelBuilder.Entity<ExpenceType>(entity =>
            {
                entity.ToTable("ExpenceType");

                entity.Property(e => e.Createdon).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Lastupdated).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_ProductCategory");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Products_ProductGroup");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SubcategoryId)
                    .HasConstraintName("FK_Products_ProductSubcategory");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.ToTable("ProductGroup");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<ProductSubcategory>(entity =>
            {
                entity.ToTable("ProductSubcategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductSubcategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ProductSubcategory_ProductCategory");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.Createdon).HasColumnType("datetime");

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.City)
                    .HasConstraintName("FK_Supplier_City");
            });

            modelBuilder.Entity<UserPage>(entity =>
            {
                entity.HasOne(d => d.Page)
                    .WithMany(p => p.UserPages)
                    .HasForeignKey(d => d.PageId)
                    .HasConstraintName("FK_UserPages_AppPages");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserPages_Emplyee");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
