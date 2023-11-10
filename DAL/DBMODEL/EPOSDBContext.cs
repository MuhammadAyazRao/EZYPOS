using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.DBMODEL
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
        public virtual DbSet<AdvancedSalary> AdvancedSalaries { get; set; }
        public virtual DbSet<AppPage> AppPages { get; set; }
        public virtual DbSet<CashBookLead> CashBookLeads { get; set; }
        public virtual DbSet<CashSummary> CashSummaries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerDrnote> CustomerDrnotes { get; set; }
        public virtual DbSet<CustomerLead> CustomerLeads { get; set; }
        public virtual DbSet<CustomerReceipt> CustomerReceipts { get; set; }
        public virtual DbSet<Emplyee> Emplyees { get; set; }
        public virtual DbSet<ExpenceTransaction> ExpenceTransactions { get; set; }
        public virtual DbSet<ExpenceType> ExpenceTypes { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Po> Pos { get; set; }
        public virtual DbSet<PriceRule> PriceRules { get; set; }
        public virtual DbSet<PriceRulePriceBreak> PriceRulePriceBreaks { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<ProductStock> ProductStocks { get; set; }
        public virtual DbSet<ProductSubcategory> ProductSubcategories { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<SaleOrder> SaleOrders { get; set; }
        public virtual DbSet<SaleOrderDetail> SaleOrderDetails { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<ShopSetting> ShopSettings { get; set; }
        public virtual DbSet<StockLead> StockLeads { get; set; }
        public virtual DbSet<StockOderDetail> StockOderDetails { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierCrnote> SupplierCrnotes { get; set; }
        public virtual DbSet<SupplierLead> SupplierLeads { get; set; }
        public virtual DbSet<SupplierPayment> SupplierPayments { get; set; }
        public virtual DbSet<TblShelf> TblShelves { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPage> UserPages { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-3RK0A90\\SQLEXPRESS;Database=EPOS-DB;Trusted_Connection=True;");
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

            modelBuilder.Entity<AdvancedSalary>(entity =>
            {
                entity.ToTable("AdvancedSalary");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AdvancedSalaryEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_AdvancedSalary_Emplyee");

                entity.HasOne(d => d.PayedByNavigation)
                    .WithMany(p => p.AdvancedSalaryPayedByNavigations)
                    .HasForeignKey(d => d.PayedBy)
                    .HasConstraintName("FK_AdvancedSalary_Emplyee1");
            });

            modelBuilder.Entity<CashBookLead>(entity =>
            {
                entity.ToTable("CashBookLead");

                entity.Property(e => e.CashBookId).HasColumnName("CashBook_Id");

                entity.Property(e => e.CrAmt)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("CR_Amt");

                entity.Property(e => e.DrAmt)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("DR_Amt");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PosId).HasColumnName("POS_Id");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("date")
                    .HasColumnName("Transaction_date");

                entity.Property(e => e.TransactionDetail).HasColumnName("Transaction_detail");

                entity.Property(e => e.TransactionId).HasColumnName("Transaction_Id");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .HasColumnName("Transaction_type");

                entity.Property(e => e.UserId).HasColumnName("User_Id");
            });

            modelBuilder.Entity<CashSummary>(entity =>
            {
                entity.ToTable("CashSummary");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndedBy).HasMaxLength(100);

                entity.Property(e => e.Posid)
                    .HasMaxLength(50)
                    .HasColumnName("POSId");

                entity.Property(e => e.StartAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartedBy).HasMaxLength(100);
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

                entity.Property(e => e.RewardPoints).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.CityNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.City)
                    .HasConstraintName("FK_Customer_City");
            });

            modelBuilder.Entity<CustomerDrnote>(entity =>
            {
                entity.ToTable("CustomerDRNote");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Discription).HasMaxLength(100);

                entity.Property(e => e.ReceiptAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerDrnotes)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerDRNote_Customer");

                entity.HasOne(d => d.ReceivedByNavigation)
                    .WithMany(p => p.CustomerDrnotes)
                    .HasForeignKey(d => d.ReceivedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerDRNote_Emplyee");
            });

            modelBuilder.Entity<CustomerLead>(entity =>
            {
                entity.ToTable("CustomerLead");

                entity.Property(e => e.Cr)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("CR");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.Dr)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("DR");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("date")
                    .HasColumnName("Transaction_date");

                entity.Property(e => e.TransactionDetail).HasColumnName("Transaction_detail");

                entity.Property(e => e.TransactionId).HasColumnName("Transaction_id");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .HasColumnName("Transaction_type");
            });

            modelBuilder.Entity<CustomerReceipt>(entity =>
            {
                entity.ToTable("CustomerReceipt");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.ReceiptAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerReceipts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CustomerReceipt_Customer");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.CustomerReceipts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_CustomerReceipt_Emplyee");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CustomerReceipts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CustomerReceipt_User");
            });

            modelBuilder.Entity<Emplyee>(entity =>
            {
                entity.ToTable("Emplyee");

                entity.Property(e => e.Cnic).HasColumnName("CNIC");

                entity.Property(e => e.Createdon).HasColumnType("date");

                entity.Property(e => e.LoginName).HasMaxLength(500);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SalaryType).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(100);

                entity.Property(e => e.WorkingHours)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Working Hours");

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

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.ExpenceDate).HasColumnType("date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ExpenceTransactions)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_ExpenceTransaction_User");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ExpenceTransactions)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_ExpenceTransaction_Emplyee");

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

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.Icon).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Po>(entity =>
            {
                entity.ToTable("POS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<PriceRule>(entity =>
            {
                entity.Property(e => e.AddedOn).HasColumnType("date");

                entity.Property(e => e.CoupanCode).HasMaxLength(100);

                entity.Property(e => e.CoupanSpendAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.FixedOff).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.PercentOff).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SpendAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<PriceRulePriceBreak>(entity =>
            {
                entity.Property(e => e.FixedOff).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PercentOff).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.Rule)
                    .WithMany(p => p.PriceRulePriceBreaks)
                    .HasForeignKey(d => d.RuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriceRulePriceBreaks_PriceRules");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Createdon).HasColumnType("date");

                entity.Property(e => e.Lastupdated).HasColumnType("date");

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.RetailPrice).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.RewardPoints).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Size).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tax).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TaxType).HasMaxLength(50);

                entity.Property(e => e.Unit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Wholesaleprice).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_ProductCategory");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Products_ProductGroup");

                entity.HasOne(d => d.Shelf)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ShelfId)
                    .HasConstraintName("FK_Products_TblShelf");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SubcategoryId)
                    .HasConstraintName("FK_Products_ProductSubcategory");

                entity.HasOne(d => d.UnitNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Unit)
                    .HasConstraintName("FK_Products_Unit");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("ProductCategory");

                entity.Property(e => e.Createdon).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.ToTable("ProductGroup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdon).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProductStock>(entity =>
            {
                entity.ToTable("ProductStock");

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductStocks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductStock_Products");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.ProductStocks)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .HasConstraintName("FK_ProductStock_PurchaseOrder");
            });

            modelBuilder.Entity<ProductSubcategory>(entity =>
            {
                entity.ToTable("ProductSubcategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdon).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductSubcategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_ProductSubcategory_ProductCategory");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.ToTable("PurchaseOrder");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DeliveryCharges).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.PaymentMode).HasMaxLength(50);

                entity.Property(e => e.PaymentStatus).HasMaxLength(50);

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_PurchaseOrder_Emplyee");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOrder_Supplier");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_PurchaseOrder_Unit");
            });

            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.ToTable("Purchase_OrderDetail");

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.ItemDiscount)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("itemDiscount");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(1000)
                    .HasColumnName("itemName");

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<SaleOrder>(entity =>
            {
                entity.ToTable("Sale_Orders");

                entity.Property(e => e.Id).HasColumnName("id");

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

                entity.Property(e => e.CashAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Cash_Amount");

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

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(50)
                    .HasColumnName("customer_phone");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.DeliveryCharges).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.DiscountAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("discount_amount");

                entity.Property(e => e.DiscountDesc)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("discount_desc");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPrinted)
                    .HasColumnName("Is_Printed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsUpdated)
                    .HasColumnName("is_updated")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OnlineAmount)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Online_Amount");

                entity.Property(e => e.OrderCount).HasColumnName("order_count");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderStatus).HasMaxLength(50);

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

                entity.Property(e => e.Posid)
                    .HasMaxLength(50)
                    .HasColumnName("POSId");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.Property(e => e.ServiceCharge)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("Service_Charge");

                entity.Property(e => e.Tax).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TaxPercentage).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("total");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Sale_Orders_Customer");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Sale_Orders_Emplyee");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SaleOrders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sale_Orders_User");
            });

            modelBuilder.Entity<SaleOrderDetail>(entity =>
            {
                entity.ToTable("Sale_OrderDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BillNo).HasColumnName("bill_no");

                entity.Property(e => e.CatName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cat_name");

                entity.Property(e => e.FixedItemDes)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fixed_item_des");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

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

                entity.Property(e => e.ItemDiscount)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("itemDiscount");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.ItemIndex).HasColumnName("item_index");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("item_name");

                entity.Property(e => e.ItemPrice)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("item_price")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ItemQty).HasColumnName("item_qty");

                entity.Property(e => e.ItemTax).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.KitchenLines)
                    .HasColumnName("kitchen_lines")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Posid)
                    .HasMaxLength(50)
                    .HasColumnName("POSId");

                entity.Property(e => e.PrintSort)
                    .HasColumnName("print_sort")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.SubCatId).HasColumnName("sub_cat_id");

                entity.Property(e => e.SubCatName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("sub_cat_name");

                entity.Property(e => e.TaxType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.SaleOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sale_OrderDetail_Sale_Orders");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.ToTable("Setting");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppKey).HasMaxLength(100);

                entity.Property(e => e.AppValue).HasMaxLength(500);
            });

            modelBuilder.Entity<ShopSetting>(entity =>
            {
                entity.ToTable("ShopSetting");

                entity.Property(e => e.Pin).HasColumnName("PIN");

                entity.Property(e => e.ShopId).HasColumnName("Shop_Id");

                entity.Property(e => e.ShopName).HasColumnName("Shop_Name");
            });

            modelBuilder.Entity<StockLead>(entity =>
            {
                entity.ToTable("StockLead");

                entity.Property(e => e.CrQty)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CR_qty");

                entity.Property(e => e.DrQty)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("DR_qty");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentMode).HasMaxLength(50);

                entity.Property(e => e.PosId).HasColumnName("POS_id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("date")
                    .HasColumnName("Transaction_date");

                entity.Property(e => e.TransactionDetail).HasColumnName("Transaction_detail");

                entity.Property(e => e.TransactionId).HasColumnName("Transaction_id");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .HasColumnName("Transaction_type");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StockLeads)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StockLead_Products");
            });

            modelBuilder.Entity<StockOderDetail>(entity =>
            {
                entity.ToTable("Stock_OderDetail");

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetail_Id");

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.StockOderDetails)
                    .HasForeignKey(d => d.OrderDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_OderDetail_Sale_OrderDetail");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StockOderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_OderDetail_Products");

                entity.HasOne(d => d.Stock)
                    .WithMany(p => p.StockOderDetails)
                    .HasForeignKey(d => d.StockId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stock_OderDetail_ProductStock");
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

            modelBuilder.Entity<SupplierCrnote>(entity =>
            {
                entity.ToTable("SupplierCRNote");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Discription).HasMaxLength(100);

                entity.Property(e => e.ReceiptAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.HasOne(d => d.PayedByNavigation)
                    .WithMany(p => p.SupplierCrnotes)
                    .HasForeignKey(d => d.PayedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierCRNote_Emplyee");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierCrnotes)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierCRNote_Supplier");
            });

            modelBuilder.Entity<SupplierLead>(entity =>
            {
                entity.ToTable("SupplierLead");

                entity.Property(e => e.Cr)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("CR");

                entity.Property(e => e.Dr)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("DR");

                entity.Property(e => e.SuplierId).HasColumnName("Suplier_id");

                entity.Property(e => e.TransactionDate)
                    .HasColumnType("date")
                    .HasColumnName("Transaction_date");

                entity.Property(e => e.TransactionDet)
                    .HasMaxLength(500)
                    .HasColumnName("Transaction_det");

                entity.Property(e => e.TransactionId).HasColumnName("Transaction_id");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .HasColumnName("Transaction_type");

                entity.HasOne(d => d.Suplier)
                    .WithMany(p => p.SupplierLeads)
                    .HasForeignKey(d => d.SuplierId)
                    .HasConstraintName("FK_SupplierLead_Supplier");
            });

            modelBuilder.Entity<SupplierPayment>(entity =>
            {
                entity.ToTable("SupplierPayment");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SupplierPayments)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_SupplierPayment_Emplyee");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierPayments)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_SupplierPayment_Supplier");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SupplierPayments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_SupplierPayment_User");
            });

            modelBuilder.Entity<TblShelf>(entity =>
            {
                entity.ToTable("TblShelf");

                entity.Property(e => e.ShelfCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShelfName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserRole");
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
