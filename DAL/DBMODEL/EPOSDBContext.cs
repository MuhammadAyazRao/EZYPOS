using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.DBModel
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
        public virtual DbSet<SaleOrder> SaleOrders { get; set; }
        public virtual DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }
        public virtual DbSet<ShopSetting> ShopSettings { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<UserPage> UserPages { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.1.104;Database=EPOS-DB;Trusted_Connection=False;User ID=admin;Password=A722713yaz@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

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

            modelBuilder.Entity<SaleOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sale_Orders");

                entity.Property(e => e.Addby)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("addby");

                entity.Property(e => e.Addon)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("addon");

                entity.Property(e => e.CashAmount).HasColumnName("Cash_Amount");

                entity.Property(e => e.Coupon)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("coupon");

                entity.Property(e => e.CouponAppliesTo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("coupon_applies_to");

                entity.Property(e => e.CouponCategories)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("coupon_categories");

                entity.Property(e => e.CouponType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("coupon_type");

                entity.Property(e => e.CouponValue)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("coupon_value");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("customer_name");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("customer_phone");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");

                entity.Property(e => e.DiscountDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("discount_desc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('no')");

                entity.Property(e => e.IsPrinted).HasColumnName("Is_Printed");

                entity.Property(e => e.IsUpdated)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("is_updated")
                    .HasDefaultValueSql("('no')");

                entity.Property(e => e.OnlineAmount).HasColumnName("Online_Amount");

                entity.Property(e => e.OrderCount).HasColumnName("order_count");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.PaymentMode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("payment_mode")
                    .HasDefaultValueSql("('cash')");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("payment_status")
                    .HasDefaultValueSql("('cash')");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.Property(e => e.ServiceCharge).HasColumnName("Service_Charge");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<SaleOrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sale_OrderDetail");

                entity.Property(e => e.BillNo).HasColumnName("bill_no");

                entity.Property(e => e.CatName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cat_name");

                entity.Property(e => e.FixedItemDes)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fixed_item_des");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("('no')");

                entity.Property(e => e.IsUpdated)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("is_updated")
                    .HasDefaultValueSql("('no')");

                entity.Property(e => e.ItemComments)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("item_comments");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.ItemIndex).HasColumnName("item_index");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("item_name");

                entity.Property(e => e.ItemPrice)
                    .HasColumnName("item_price")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ItemQty).HasColumnName("item_qty");

                entity.Property(e => e.KitchenLines)
                    .HasColumnName("kitchen_lines")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.PrintSort)
                    .HasColumnName("print_sort")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SubCatId).HasColumnName("sub_cat_id");

                entity.Property(e => e.SubCatName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("sub_cat_name");
            });

            modelBuilder.Entity<ShopSetting>(entity =>
            {
                entity.ToTable("ShopSetting");

                entity.Property(e => e.Pin).HasColumnName("PIN");

                entity.Property(e => e.ShopId).HasColumnName("Shop_Id");

                entity.Property(e => e.ShopName).HasColumnName("Shop_Name");
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
