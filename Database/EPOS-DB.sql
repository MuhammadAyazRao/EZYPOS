USE [master]
GO
/****** Object:  Database [EPOS-DB]    Script Date: 01/05/2022 2:18:16 am ******/
CREATE DATABASE [EPOS-DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EPOS-DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EPOS-DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EPOS-DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EPOS-DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EPOS-DB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EPOS-DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EPOS-DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EPOS-DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EPOS-DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EPOS-DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EPOS-DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [EPOS-DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EPOS-DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EPOS-DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EPOS-DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EPOS-DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EPOS-DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EPOS-DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EPOS-DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EPOS-DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EPOS-DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EPOS-DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EPOS-DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EPOS-DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EPOS-DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EPOS-DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EPOS-DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EPOS-DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EPOS-DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EPOS-DB] SET  MULTI_USER 
GO
ALTER DATABASE [EPOS-DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EPOS-DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EPOS-DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EPOS-DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EPOS-DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EPOS-DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EPOS-DB] SET QUERY_STORE = OFF
GO
USE [EPOS-DB]
GO
/****** Object:  User [EzyposAdmin]    Script Date: 01/05/2022 2:18:16 am ******/
CREATE USER [EzyposAdmin] FOR LOGIN [EzyposAdmin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](max) NULL,
	[Type] [nvarchar](50) NULL,
	[Isdeleted] [bit] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdvancedSalary]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdvancedSalary](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[PayedBy] [int] NULL,
	[Date] [date] NULL,
	[Month] [int] NULL,
	[Amount] [decimal](18, 3) NULL,
	[IsAdvance] [bit] NULL,
 CONSTRAINT [PK_AdvancedSalary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppPages]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppPages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PageName] [nvarchar](max) NULL,
	[Isdeleted] [bit] NULL,
	[ParentId] [int] NULL,
	[ListingOrder] [int] NULL,
 CONSTRAINT [PK_AppPages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CashBookLead]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashBookLead](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Transaction_Id] [bigint] NULL,
	[Transaction_date] [date] NULL,
	[Transaction_type] [nvarchar](50) NULL,
	[Transaction_detail] [nvarchar](max) NULL,
	[CashBook_Id] [bigint] NULL,
	[DR_Amt] [decimal](18, 3) NULL,
	[CR_Amt] [decimal](18, 3) NULL,
	[User_Id] [bigint] NULL,
	[POS_Id] [bigint] NULL,
 CONSTRAINT [PK_CashBookLead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NULL,
	[Createdon] [datetime] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](max) NULL,
	[Adress] [nvarchar](max) NULL,
	[City] [int] NULL,
	[MobileNo] [nvarchar](max) NULL,
	[Createdon] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerDRNote]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDRNote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Discription] [nvarchar](100) NULL,
	[ReceiptAmount] [decimal](18, 3) NULL,
	[TransactionDate] [date] NOT NULL,
	[CreatedOn] [date] NULL,
	[CustomerId] [int] NOT NULL,
	[ReceivedBy] [int] NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_CustomerCRNote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerLead]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerLead](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_id] [int] NULL,
	[Transaction_date] [date] NULL,
	[Transaction_id] [int] NULL,
	[Transaction_type] [nvarchar](50) NULL,
	[Transaction_detail] [nvarchar](max) NULL,
	[DR] [decimal](18, 3) NULL,
	[CR] [decimal](18, 3) NULL,
 CONSTRAINT [PK_CustomerLead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerReceipt]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerReceipt](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Discription] [nvarchar](max) NULL,
	[ReceiptAmount] [decimal](18, 3) NULL,
	[TransactionDate] [date] NOT NULL,
	[CreatedOn] [date] NULL,
	[CustomerId] [int] NULL,
	[EmployeeId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_CustomerReceipt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Emplyee]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emplyee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[Role] [int] NULL,
	[City] [int] NULL,
	[CNIC] [nvarchar](max) NULL,
	[Adress] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Isdeleted] [bit] NULL,
	[Createdon] [date] NULL,
	[Password] [nvarchar](max) NULL,
	[IsLoginAllowed] [bit] NULL,
	[Salary] [decimal](18, 3) NULL,
	[SalaryType] [nvarchar](50) NULL,
	[Working Hours] [decimal](18, 3) NULL,
	[Image] [nvarchar](max) NULL,
	[LoginName] [nvarchar](500) NULL,
 CONSTRAINT [PK_Emplyee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenceTransaction]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenceTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExpenceDate] [date] NULL,
	[EmployeeId] [int] NULL,
	[CreatedBy] [int] NULL,
	[Discription] [nvarchar](max) NULL,
	[Amount] [decimal](18, 3) NULL,
	[Isdeleted] [bit] NULL,
	[ExpenceType] [int] NULL,
 CONSTRAINT [PK_ExpenceTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenceType]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenceType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExpenceName] [nvarchar](max) NULL,
	[Isdeleted] [bit] NULL,
	[Createdon] [datetime] NULL,
 CONSTRAINT [PK_ExpenceType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Isdeleted] [bit] NULL,
	[Createdon] [datetime] NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductGroup]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductGroup](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](max) NULL,
	[Isdeleted] [bit] NULL,
	[Createdon] [datetime] NULL,
 CONSTRAINT [PK_ProductGroup] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NULL,
	[Barcode] [nvarchar](max) NULL,
	[CategoryId] [int] NULL,
	[SubcategoryId] [int] NULL,
	[Isdeleted] [bit] NULL,
	[GroupId] [int] NULL,
	[ShelfId] [int] NULL,
	[RetailPrice] [decimal](18, 3) NOT NULL,
	[Wholesaleprice] [decimal](18, 3) NULL,
	[PurchasePrice] [decimal](18, 3) NOT NULL,
	[Lastupdated] [date] NULL,
	[Createdby] [int] NULL,
	[Createdon] [date] NULL,
	[Size] [decimal](18, 2) NULL,
	[Unit] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductStock]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductStock](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[ExpiryDate] [date] NOT NULL,
	[Qty] [bigint] NOT NULL,
	[Adjustment] [int] NOT NULL,
	[Conversion] [int] NULL,
	[PurchaseOrderId] [int] NULL,
 CONSTRAINT [PK_ProductStock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSubcategory]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSubcategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SubcategoryName] [nvarchar](max) NULL,
	[CategoryId] [int] NULL,
	[Isdeleted] [bit] NULL,
	[Createdon] [datetime] NULL,
 CONSTRAINT [PK_ProductSubcategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase_OrderDetail]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase_OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[itemName] [nvarchar](1000) NULL,
	[ProductId] [int] NOT NULL,
	[PurchasePrice] [decimal](18, 3) NOT NULL,
	[SalePrice] [decimal](18, 3) NULL,
	[Qty] [int] NOT NULL,
	[StockId] [int] NULL,
	[PurchaseOrderId] [int] NOT NULL,
	[ExpiryDate] [date] NULL,
	[StartDate] [date] NULL,
	[itemDiscount] [decimal](18, 3) NULL,
	[Total] [decimal](18, 3) NULL,
 CONSTRAINT [PK_Purchase_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[EmployeeId] [int] NULL,
	[UserId] [int] NULL,
	[Date] [date] NOT NULL,
	[PaymentStatus] [nvarchar](50) NULL,
	[PaymentMode] [nvarchar](50) NULL,
	[Discount] [decimal](18, 3) NULL,
	[DeliveryCharges] [decimal](18, 3) NULL,
	[TotalAmount] [decimal](18, 3) NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale_OrderDetail]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_OrderDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NOT NULL,
	[item_id] [int] NOT NULL,
	[item_name] [varchar](100) NOT NULL,
	[fixed_item_des] [varchar](255) NULL,
	[sub_cat_id] [int] NULL,
	[sub_cat_name] [varchar](255) NULL,
	[cat_name] [varchar](255) NULL,
	[print_sort] [int] NULL,
	[kitchen_lines] [int] NOT NULL,
	[item_comments] [varchar](255) NULL,
	[item_qty] [int] NOT NULL,
	[itemDiscount] [decimal](18, 3) NULL,
	[item_price] [decimal](18, 3) NULL,
	[PurchasePrice] [decimal](18, 3) NULL,
	[item_index] [int] NOT NULL,
	[bill_no] [int] NULL,
	[is_updated] [varchar](20) NOT NULL,
	[is_deleted] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Sale_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale_Orders]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[restaurant_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[order_count] [int] NOT NULL,
	[total] [decimal](18, 3) NOT NULL,
	[date] [date] NOT NULL,
	[order_date] [date] NULL,
	[description] [text] NULL,
	[coupon] [varchar](80) NULL,
	[coupon_value] [varchar](255) NULL,
	[coupon_type] [varchar](255) NULL,
	[coupon_applies_to] [varchar](255) NULL,
	[coupon_categories] [varchar](255) NULL,
	[discount_amount] [decimal](18, 3) NULL,
	[discount_desc] [varchar](255) NULL,
	[payment_mode] [varchar](20) NOT NULL,
	[payment_status] [varchar](20) NOT NULL,
	[addby] [varchar](100) NOT NULL,
	[addon] [varchar](50) NOT NULL,
	[EmployeeId] [int] NULL,
	[customer_id] [int] NULL,
	[customer_phone] [nvarchar](50) NULL,
	[is_updated] [varchar](20) NOT NULL,
	[is_deleted] [varchar](20) NOT NULL,
	[TaxPercentage] [decimal](18, 3) NULL,
	[Tax] [decimal](18, 3) NULL,
	[Cash_Amount] [decimal](18, 3) NOT NULL,
	[Online_Amount] [decimal](18, 3) NOT NULL,
	[Is_Printed] [int] NOT NULL,
	[Service_Charge] [decimal](18, 3) NULL,
	[DeliveryCharges] [decimal](18, 3) NULL,
 CONSTRAINT [PK_Sale_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Setting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AppKey] [nvarchar](100) NULL,
	[AppValue] [nvarchar](500) NULL,
 CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShopSetting]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShopSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PIN] [int] NULL,
	[Shop_Id] [int] NULL,
	[Shop_Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ShopSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock_OderDetail]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock_OderDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StockId] [bigint] NOT NULL,
	[OrderDetail_Id] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderId] [int] NULL,
 CONSTRAINT [PK_Stock_OderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockLead]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockLead](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Transaction_id] [bigint] NULL,
	[Transaction_date] [date] NULL,
	[Transaction_type] [nvarchar](50) NULL,
	[Transaction_detail] [nvarchar](max) NULL,
	[Product_id] [int] NOT NULL,
	[DR_qty] [numeric](18, 2) NULL,
	[CR_qty] [numeric](18, 2) NULL,
	[User_id] [bigint] NULL,
	[POS_id] [bigint] NULL,
	[PaymentMode] [nvarchar](50) NULL,
 CONSTRAINT [PK_StockLead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[PhoneNo] [nvarchar](max) NULL,
	[Adress] [nvarchar](max) NULL,
	[City] [int] NULL,
	[MobileNo] [nvarchar](max) NULL,
	[Createdon] [datetime] NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierCRNote]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierCRNote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Discription] [nvarchar](100) NULL,
	[ReceiptAmount] [decimal](18, 3) NULL,
	[TransactionDate] [date] NOT NULL,
	[CreatedOn] [date] NULL,
	[SupplierId] [int] NOT NULL,
	[PayedBy] [int] NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_SupplierCRNote] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierLead]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierLead](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Suplier_id] [int] NULL,
	[Transaction_id] [int] NULL,
	[Transaction_type] [nvarchar](50) NULL,
	[Transaction_det] [nvarchar](500) NULL,
	[DR] [decimal](18, 3) NULL,
	[CR] [decimal](18, 3) NULL,
	[Transaction_date] [date] NULL,
 CONSTRAINT [PK_SupplierLead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierPayment]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierPayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [decimal](18, 3) NULL,
	[Discription] [nvarchar](max) NULL,
	[TransactionDate] [date] NOT NULL,
	[CreatedOn] [date] NULL,
	[SupplierId] [int] NULL,
	[EmployeeId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_SupplierPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblShelf]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblShelf](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShelfName] [varchar](100) NULL,
	[ShelfCode] [varchar](100) NULL,
 CONSTRAINT [PK_TblShelf] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[UserName] [varchar](500) NULL,
	[Password] [varchar](100) NULL,
	[UserRole] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPages]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[PageId] [int] NULL,
 CONSTRAINT [PK_UserPages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CashBookLead] ON 

INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6058, 5059, CAST(N'2022-03-24' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5059
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 400.150
', NULL, NULL, CAST(400.150 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6059, 5060, CAST(N'2022-03-26' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5060
Lux 250g:  2 * 80.100 = 160.200
Total Amount: 139.850
', NULL, NULL, CAST(139.850 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6060, 7123, CAST(N'2022-03-26' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7123', NULL, CAST(105.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6061, 7124, CAST(N'2022-03-26' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7124', NULL, CAST(510.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6062, 5061, CAST(N'2022-04-07' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5061
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 723.650
', NULL, NULL, CAST(723.650 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6063, 7125, CAST(N'2022-04-07' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7125', NULL, CAST(818.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6064, 5062, CAST(N'2022-04-09' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5062
check:  6 * 250.000 = 1500.000
Lux 250g:  6 * 80.100 = 480.600
Head & Shoulder 500 ml:  6 * 400.150 = 2400.900
Total Amount: 4381.500
', NULL, NULL, CAST(4381.500 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6065, 5063, CAST(N'2022-04-15' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5063
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 730.250
', NULL, NULL, CAST(730.250 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6066, 7126, CAST(N'2022-04-16' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7126', NULL, CAST(500.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6067, 7127, CAST(N'2022-04-16' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7127', NULL, CAST(125.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6068, 5064, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5064
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 480.250
', NULL, NULL, CAST(480.250 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6069, 7128, CAST(N'2022-04-16' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7128', NULL, CAST(500.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6070, 5065, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5065
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 400.150
', NULL, NULL, CAST(400.150 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6071, 5066, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5066
check:  1 * 250.000 = 250.000
Total Amount: 250.000
', NULL, NULL, CAST(250.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6072, 7129, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7129', NULL, CAST(625.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6073, 7130, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7130', NULL, CAST(625.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6074, 7131, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7131', NULL, CAST(500.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6075, 7132, CAST(N'2022-04-25' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7132', NULL, CAST(-25.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6076, 7133, CAST(N'2022-04-26' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7133', NULL, CAST(125.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6077, 7134, CAST(N'2022-05-01' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7134', NULL, CAST(557.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6078, 7135, CAST(N'2022-05-01' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7135', NULL, CAST(506.000 AS Decimal(18, 3)), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[CashBookLead] OFF
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (4150, N'Sargodha', CAST(N'2022-02-25T00:00:00.000' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (4151, N'lahore', CAST(N'2022-02-25T12:59:16.303' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (4152, N'Khushab', CAST(N'2022-02-26T18:30:36.953' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (4153, N'Karachi', CAST(N'2022-02-26T18:30:44.080' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (4154, N'Multan', CAST(N'2022-02-26T18:30:52.887' AS DateTime))
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (5022, N'walking customer', N'0300', N'sargodha ', 4150, N'0345', CAST(N'2022-02-25T12:59:58.153' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (5026, N'check', N'0302', N'sarg', 4151, N'0331', CAST(N'2022-04-09T23:02:37.587' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerLead] ON 

INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8095, 5022, CAST(N'2022-03-26' AS Date), 7123, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7123', CAST(105.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8096, 5022, CAST(N'2022-03-26' AS Date), 7123, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7123', NULL, CAST(105.000 AS Decimal(18, 3)))
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8097, 5022, CAST(N'2022-03-26' AS Date), 7124, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7124', CAST(510.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8098, 5022, CAST(N'2022-03-26' AS Date), 7124, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7124', NULL, CAST(510.000 AS Decimal(18, 3)))
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8099, 5022, CAST(N'2022-04-07' AS Date), 7125, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7125', CAST(818.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8100, 5022, CAST(N'2022-04-07' AS Date), 7125, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7125', NULL, CAST(818.000 AS Decimal(18, 3)))
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8101, 5022, CAST(N'2022-04-16' AS Date), 7126, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7126', CAST(500.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8102, 5022, CAST(N'2022-04-16' AS Date), 7126, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7126', NULL, CAST(500.000 AS Decimal(18, 3)))
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8103, 5022, CAST(N'2022-04-16' AS Date), 7127, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7127', CAST(125.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8104, 5022, CAST(N'2022-04-16' AS Date), 7127, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7127', NULL, CAST(125.000 AS Decimal(18, 3)))
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8105, 5022, CAST(N'2022-04-16' AS Date), 7128, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7128', CAST(500.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8106, 5022, CAST(N'2022-04-16' AS Date), 7128, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7128', NULL, CAST(500.000 AS Decimal(18, 3)))
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8107, 5022, CAST(N'2022-04-17' AS Date), 7129, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7129', CAST(625.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8108, 5022, CAST(N'2022-04-17' AS Date), 7129, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7129', NULL, CAST(625.000 AS Decimal(18, 3)))
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8109, 5022, CAST(N'2022-04-17' AS Date), 7130, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7130', CAST(625.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8110, 5022, CAST(N'2022-04-17' AS Date), 7130, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7130', NULL, CAST(625.000 AS Decimal(18, 3)))
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8111, 5022, CAST(N'2022-04-17' AS Date), 7131, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7131', CAST(500.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8112, 5022, CAST(N'2022-04-17' AS Date), 7131, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7131', NULL, CAST(500.000 AS Decimal(18, 3)))
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8113, 5022, CAST(N'2022-04-25' AS Date), 7132, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7132', CAST(-25.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8114, 5022, CAST(N'2022-04-25' AS Date), 7132, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7132', NULL, CAST(-25.000 AS Decimal(18, 3)))
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8115, 5022, CAST(N'2022-04-26' AS Date), 7133, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7133', CAST(125.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8116, 5022, CAST(N'2022-04-26' AS Date), 7133, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7133', NULL, CAST(125.000 AS Decimal(18, 3)))
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8117, 5022, CAST(N'2022-05-01' AS Date), 7134, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7134', CAST(557.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8118, 5022, CAST(N'2022-05-01' AS Date), 7134, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7134', NULL, CAST(557.000 AS Decimal(18, 3)))
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8119, 5022, CAST(N'2022-05-01' AS Date), 7135, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7135', CAST(506.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8120, 5022, CAST(N'2022-05-01' AS Date), 7135, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7135', NULL, CAST(506.000 AS Decimal(18, 3)))
SET IDENTITY_INSERT [dbo].[CustomerLead] OFF
GO
SET IDENTITY_INSERT [dbo].[Emplyee] ON 

INSERT [dbo].[Emplyee] ([Id], [UserName], [Role], [City], [CNIC], [Adress], [Phone], [Isdeleted], [Createdon], [Password], [IsLoginAllowed], [Salary], [SalaryType], [Working Hours], [Image], [LoginName]) VALUES (2011, N'sikandar 12', 1, 4150, N'3840312', N'sargodha 12', N'030212', NULL, CAST(N'2022-03-08' AS Date), N'4420', 1, CAST(30000.120 AS Decimal(18, 3)), N'Hourly', CAST(5.120 AS Decimal(18, 3)), N'file:///G:/EZYPOS/EZYPOS/EZYPOS/bin/Debug/net5.0-windows/Assets/EmployeeImages/07042022111259pm.jpg', NULL)
INSERT [dbo].[Emplyee] ([Id], [UserName], [Role], [City], [CNIC], [Adress], [Phone], [Isdeleted], [Createdon], [Password], [IsLoginAllowed], [Salary], [SalaryType], [Working Hours], [Image], [LoginName]) VALUES (2012, N'samar', 2, 4150, N'38402', N'dharema', N'0321', NULL, CAST(N'2022-04-05' AS Date), NULL, NULL, CAST(26000.000 AS Decimal(18, 3)), N'Monthly', NULL, N'file:///G:/EZYPOS/EZYPOS/EZYPOS/bin/Debug/net5.0-windows/Assets/EmployeeImages/05042022114332pm.jpg', NULL)
INSERT [dbo].[Emplyee] ([Id], [UserName], [Role], [City], [CNIC], [Adress], [Phone], [Isdeleted], [Createdon], [Password], [IsLoginAllowed], [Salary], [SalaryType], [Working Hours], [Image], [LoginName]) VALUES (2013, N'ali', 1, 4150, N'38603', N'dharema', N'0340', NULL, CAST(N'2022-04-06' AS Date), NULL, NULL, CAST(22000.000 AS Decimal(18, 3)), N'Monthly', NULL, N'file:///C:/Users/Sikandar Abbas/Desktop/100D3300/DSC_0250.JPG', NULL)
SET IDENTITY_INSERT [dbo].[Emplyee] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([Id], [Name], [Isdeleted], [Createdon]) VALUES (3012, N'kitchen', NULL, NULL)
INSERT [dbo].[ProductCategory] ([Id], [Name], [Isdeleted], [Createdon]) VALUES (3013, N'cosmatics', NULL, NULL)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductGroup] ON 

INSERT [dbo].[ProductGroup] ([id], [GroupName], [Isdeleted], [Createdon]) VALUES (1008, N'General group', NULL, NULL)
SET IDENTITY_INSERT [dbo].[ProductGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit]) VALUES (2021, N'Head & Shoulder 500 ml', N'0011', 3013, 3017, NULL, 1008, 2008, CAST(500.250 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), NULL, NULL, CAST(N'2022-03-30' AS Date), CAST(500.00 AS Decimal(18, 2)), 3)
INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit]) VALUES (2022, N'Lux 250g', N'002', 3013, 3018, NULL, NULL, NULL, CAST(125.300 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), NULL, NULL, CAST(N'2022-03-24' AS Date), CAST(250.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit]) VALUES (2025, N'check', N'003', 3012, 3019, NULL, 1008, 2008, CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), NULL, NULL, CAST(N'2022-03-30' AS Date), CAST(1.25 AS Decimal(18, 2)), 1)
INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit]) VALUES (2026, N'oil 100g', N'123459678974', 3012, 3019, NULL, 1008, 2008, CAST(250.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), NULL, NULL, CAST(N'2022-04-18' AS Date), CAST(100.00 AS Decimal(18, 2)), 2)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductStock] ON 

INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70083, 2021, CAST(N'2022-03-24' AS Date), CAST(N'2022-03-24' AS Date), 1, 0, 0, 5059)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70084, 2022, CAST(N'2022-03-26' AS Date), CAST(N'2022-03-26' AS Date), 2, 0, 0, 5060)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70085, 2025, CAST(N'2022-04-07' AS Date), CAST(N'2022-04-07' AS Date), 1, 0, 0, 5061)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70086, 2022, CAST(N'2022-04-07' AS Date), CAST(N'2022-04-07' AS Date), 1, 0, 0, 5061)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70087, 2021, CAST(N'2022-04-07' AS Date), CAST(N'2022-04-07' AS Date), 1, 0, 0, 5061)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70088, 2025, CAST(N'2022-04-09' AS Date), CAST(N'2022-04-09' AS Date), 6, 0, 0, 5062)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70089, 2022, CAST(N'2022-04-09' AS Date), CAST(N'2022-04-09' AS Date), 6, 0, 0, 5062)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70090, 2021, CAST(N'2022-04-09' AS Date), CAST(N'2022-04-09' AS Date), 6, 0, 0, 5062)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70091, 2025, CAST(N'2022-04-15' AS Date), CAST(N'2022-05-07' AS Date), 1, 0, 0, 5063)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70092, 2022, CAST(N'2022-04-15' AS Date), CAST(N'2022-06-10' AS Date), 1, 0, 0, 5063)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70093, 2021, CAST(N'2022-04-15' AS Date), CAST(N'2022-07-23' AS Date), 1, 0, 0, 5063)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70094, 2022, CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), 1, 0, 0, 5064)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70095, 2021, CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), 1, 0, 0, 5064)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70096, 2021, CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), 1, 0, 0, 5065)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70097, 2025, CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), 1, 0, 0, 5066)
SET IDENTITY_INSERT [dbo].[ProductStock] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductSubcategory] ON 

INSERT [dbo].[ProductSubcategory] ([id], [SubcategoryName], [CategoryId], [Isdeleted], [Createdon]) VALUES (3017, N'Shampoo', 3013, NULL, NULL)
INSERT [dbo].[ProductSubcategory] ([id], [SubcategoryName], [CategoryId], [Isdeleted], [Createdon]) VALUES (3018, N'Soap', 3013, NULL, NULL)
INSERT [dbo].[ProductSubcategory] ([id], [SubcategoryName], [CategoryId], [Isdeleted], [Createdon]) VALUES (3019, N'oil', 3012, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ProductSubcategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Purchase_OrderDetail] ON 

INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7080, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 1, NULL, 5059, CAST(N'2022-03-24' AS Date), CAST(N'2022-03-24' AS Date), NULL, CAST(400.150 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7081, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 2, NULL, 5060, CAST(N'2022-03-26' AS Date), CAST(N'2022-03-26' AS Date), NULL, CAST(160.200 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7082, N'check', 2025, CAST(250.000 AS Decimal(18, 3)), NULL, 1, NULL, 5061, CAST(N'2022-04-07' AS Date), CAST(N'2022-04-07' AS Date), CAST(3.300 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7083, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 1, NULL, 5061, CAST(N'2022-04-07' AS Date), CAST(N'2022-04-07' AS Date), CAST(2.200 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7084, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 1, NULL, 5061, CAST(N'2022-04-07' AS Date), CAST(N'2022-04-07' AS Date), CAST(1.100 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7085, N'check', 2025, CAST(250.000 AS Decimal(18, 3)), NULL, 6, NULL, 5062, CAST(N'2022-04-09' AS Date), CAST(N'2022-04-09' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(1500.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7086, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 6, NULL, 5062, CAST(N'2022-04-09' AS Date), CAST(N'2022-04-09' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(480.600 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7087, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 6, NULL, 5062, CAST(N'2022-04-09' AS Date), CAST(N'2022-04-09' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(2400.900 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7088, N'check', 2025, CAST(250.000 AS Decimal(18, 3)), NULL, 1, NULL, 5063, CAST(N'2022-05-07' AS Date), CAST(N'2022-04-15' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7089, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 1, NULL, 5063, CAST(N'2022-06-10' AS Date), CAST(N'2022-04-15' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7090, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 1, NULL, 5063, CAST(N'2022-07-23' AS Date), CAST(N'2022-04-15' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7091, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 1, NULL, 5064, CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7092, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 1, NULL, 5064, CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7093, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 1, NULL, 5065, CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7094, N'check', 2025, CAST(250.000 AS Decimal(18, 3)), NULL, 1, NULL, 5066, CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)))
SET IDENTITY_INSERT [dbo].[Purchase_OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseOrder] ON 

INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5059, 3006, 2011, NULL, CAST(N'2022-03-24' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5060, 3006, 2011, NULL, CAST(N'2022-03-26' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(139.850 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5061, 3006, 2011, NULL, CAST(N'2022-04-07' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(723.650 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5062, 3009, 2011, NULL, CAST(N'2022-04-09' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(4381.500 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5063, 3006, 2011, NULL, CAST(N'2022-04-15' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(730.250 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5064, 3006, 2011, NULL, CAST(N'2022-04-16' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(480.250 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5065, 3006, 2011, NULL, CAST(N'2022-04-16' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5066, 3006, 2011, NULL, CAST(N'2022-04-16' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)))
SET IDENTITY_INSERT [dbo].[PurchaseOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale_OrderDetail] ON 

INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7123, 7124, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, NULL, CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7124, 7125, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(3.300 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7125, 7125, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(2.200 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7126, 7125, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(1.100 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7127, 7126, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7128, 7127, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7129, 7128, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7130, 7129, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7131, 7129, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7132, 7130, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7133, 7130, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7134, 7131, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7135, 7133, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.690 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7136, 7134, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7137, 7135, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), 1, NULL, N'', N'')
SET IDENTITY_INSERT [dbo].[Sale_OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale_Orders] ON 

INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges]) VALUES (7124, 1, 1, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-03-26' AS Date), CAST(N'2022-03-26' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(10.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, N'no', N'no', NULL, NULL, CAST(510.250 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(20.000 AS Decimal(18, 3)))
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges]) VALUES (7125, 1, 1, 1, CAST(818.950 AS Decimal(18, 3)), CAST(N'2022-04-07' AS Date), CAST(N'2022-04-07' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, N'no', N'no', NULL, NULL, CAST(818.950 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)))
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges]) VALUES (7126, 1, 1, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, N'no', N'no', NULL, NULL, CAST(500.250 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)))
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges]) VALUES (7127, 1, 1, 1, CAST(125.300 AS Decimal(18, 3)), CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, N'no', N'no', NULL, NULL, CAST(125.300 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)))
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges]) VALUES (7128, 1, 1, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, N'no', N'no', NULL, NULL, CAST(500.250 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)))
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges]) VALUES (7129, 1, 1, 1, CAST(625.550 AS Decimal(18, 3)), CAST(N'2022-04-17' AS Date), CAST(N'2022-04-17' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, N'no', N'no', NULL, NULL, CAST(625.550 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)))
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges]) VALUES (7130, 1, 1, 1, CAST(625.550 AS Decimal(18, 3)), CAST(N'2022-04-17' AS Date), CAST(N'2022-04-17' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, N'no', N'no', NULL, NULL, CAST(625.550 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)))
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges]) VALUES (7131, 1, 1, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-04-17' AS Date), CAST(N'2022-04-17' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, N'no', N'no', NULL, NULL, CAST(500.250 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)))
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges]) VALUES (7132, 1, 1, 1, CAST(0.000 AS Decimal(18, 3)), CAST(N'2022-04-25' AS Date), CAST(N'2022-04-25' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, N'no', N'no', NULL, NULL, CAST(-25.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)))
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges]) VALUES (7133, 1, 1, 1, CAST(125.690 AS Decimal(18, 3)), CAST(N'2022-03-26' AS Date), CAST(N'2022-03-26' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, N'no', N'no', NULL, NULL, CAST(125.690 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)))
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges]) VALUES (7134, 1, 1, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-05-01' AS Date), CAST(N'2022-05-01' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, N'no', N'no', CAST(1.250 AS Decimal(18, 3)), CAST(6.878 AS Decimal(18, 3)), CAST(557.128 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(50.000 AS Decimal(18, 3)))
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges]) VALUES (7135, 1, 1, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-05-01' AS Date), CAST(N'2022-05-01' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, N'no', N'no', CAST(1.250 AS Decimal(18, 3)), CAST(6.253 AS Decimal(18, 3)), CAST(506.503 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)))
SET IDENTITY_INSERT [dbo].[Sale_Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (1, N'PrintInvoice', N'True')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2, N'PrintLogo', N'True')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (3, N'ShopName', N'Eat & Repeat')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (4, N'ReportHeader', N'Eat & Repeat, SunderLand, UK')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (5, N'ReportFooter', N'Eat & Repeat, SunderLand, UK')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (6, N'InvoicePrinter', N'Fax')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (7, N'ReportPrinter', N'Microsoft Print to PDF')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (1002, N'PrintReport', N'True')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2002, N'Currency', N'en-PK')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2003, N'WalkingCustomer', N'5022')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2004, N'DefaultSupplier', N'3006')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2005, N'PrintConfirmation', N'False')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2006, N'MaxNoPrints', N'2')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2007, N'ExpiryAlertMonths', N'2')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2008, N'ExpiryAlert', N'False')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2009, N'AllowTax', N'True')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2010, N'TaxPercentage', N'1.25')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2011, N'MinimumTaxLimit', N'125')
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock_OderDetail] ON 

INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70127, 70083, 7123, 1, 2021, 7124)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70128, 70085, 7124, 1, 2025, 7125)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70129, 70084, 7124, 1, 2022, 7125)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70130, 70087, 7124, 1, 2021, 7125)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70131, 70086, 7125, 1, 2022, 7125)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70132, 70090, 7127, 1, 2021, 7126)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70133, 70089, 7128, 1, 2022, 7127)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70134, 70090, 7129, 1, 2021, 7128)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70135, 70090, 7130, 1, 2021, 7129)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70136, 70089, 7130, 1, 2022, 7129)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70137, 70090, 7131, 1, 2021, 7129)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70138, 70089, 7131, 1, 2022, 7129)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70139, 70089, 7132, 1, 2022, 7130)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70140, 70090, 7132, 1, 2021, 7130)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70141, 70089, 7133, 1, 2022, 7130)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70142, 70090, 7133, 1, 2021, 7130)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70143, 70093, 7134, 1, 2021, 7131)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70144, 70084, 7135, 1, 2022, 7133)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70145, 70095, 7136, 1, 2021, 7134)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70146, 70096, 7137, 1, 2021, 7135)
SET IDENTITY_INSERT [dbo].[Stock_OderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[StockLead] ON 

INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9092, 5059, CAST(N'2022-03-24' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5059', 2021, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9093, 5060, CAST(N'2022-03-26' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5060', 2022, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9094, 7123, CAST(N'2022-03-26' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7123', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9095, 7124, CAST(N'2022-03-26' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7124', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9096, 5061, CAST(N'2022-04-07' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5061', 2025, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9097, 5061, CAST(N'2022-04-07' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5061', 2022, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9098, 5061, CAST(N'2022-04-07' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5061', 2021, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9099, 7125, CAST(N'2022-04-07' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7125', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9100, 7125, CAST(N'2022-04-07' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7125', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9101, 7125, CAST(N'2022-04-07' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7125', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9102, 5062, CAST(N'2022-04-09' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5062', 2025, CAST(6.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9103, 5062, CAST(N'2022-04-09' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5062', 2022, CAST(6.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9104, 5062, CAST(N'2022-04-09' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5062', 2021, CAST(6.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9105, 5063, CAST(N'2022-04-15' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5063', 2025, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9106, 5063, CAST(N'2022-04-15' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5063', 2022, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9107, 5063, CAST(N'2022-04-15' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5063', 2021, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9108, 7126, CAST(N'2022-04-16' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7126', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9109, 7127, CAST(N'2022-04-16' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7127', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9110, 5064, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5064', 2022, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9111, 5064, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5064', 2021, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9112, 7128, CAST(N'2022-04-16' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7128', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9113, 5065, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5065', 2021, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9114, 5066, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5066', 2025, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9115, 7129, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7129', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9116, 7129, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7129', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9117, 7130, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7130', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9118, 7130, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7130', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9119, 7131, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7131', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9120, 7133, CAST(N'2022-04-26' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7133', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9121, 7134, CAST(N'2022-05-01' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7134', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9122, 7135, CAST(N'2022-05-01' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7135', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[StockLead] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (3006, N'Default Supplier', N'0300', N'sargodha', 4151, N'0345', CAST(N'2022-02-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Supplier] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (3009, N'check', N'03000', N'sargodha', 4150, N'0331', CAST(N'2022-04-09T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
SET IDENTITY_INSERT [dbo].[SupplierLead] ON 

INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6050, 3006, 5059, N'PurchaseInvoice', N'CASH Purchase Order No: 5059
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 400.150
', CAST(400.150 AS Decimal(18, 3)), NULL, CAST(N'2022-03-24' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6051, 3006, 5059, N'PurchaseInvoice', N'Cash Purchase Order No: 5059
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 400.150
', NULL, CAST(400.150 AS Decimal(18, 3)), CAST(N'2022-03-24' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6052, 3006, 5060, N'PurchaseInvoice', N'CASH Purchase Order No: 5060
Lux 250g:  2 * 80.100 = 160.200
Total Amount: 139.850
', CAST(139.850 AS Decimal(18, 3)), NULL, CAST(N'2022-03-26' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6053, 3006, 5060, N'PurchaseInvoice', N'Cash Purchase Order No: 5060
Lux 250g:  2 * 80.100 = 160.200
Total Amount: 139.850
', NULL, CAST(139.850 AS Decimal(18, 3)), CAST(N'2022-03-26' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6054, 3006, 5061, N'PurchaseInvoice', N'CASH Purchase Order No: 5061
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 723.650
', CAST(723.650 AS Decimal(18, 3)), NULL, CAST(N'2022-04-07' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6055, 3006, 5061, N'PurchaseInvoice', N'Cash Purchase Order No: 5061
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 723.650
', NULL, CAST(723.650 AS Decimal(18, 3)), CAST(N'2022-04-07' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6056, 3009, 5062, N'PurchaseInvoice', N'CASH Purchase Order No: 5062
check:  6 * 250.000 = 1500.000
Lux 250g:  6 * 80.100 = 480.600
Head & Shoulder 500 ml:  6 * 400.150 = 2400.900
Total Amount: 4381.500
', CAST(4381.500 AS Decimal(18, 3)), NULL, CAST(N'2022-04-09' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6057, 3009, 5062, N'PurchaseInvoice', N'Cash Purchase Order No: 5062
check:  6 * 250.000 = 1500.000
Lux 250g:  6 * 80.100 = 480.600
Head & Shoulder 500 ml:  6 * 400.150 = 2400.900
Total Amount: 4381.500
', NULL, CAST(4381.500 AS Decimal(18, 3)), CAST(N'2022-04-09' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6058, 3006, 5063, N'PurchaseInvoice', N'CASH Purchase Order No: 5063
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 730.250
', CAST(730.250 AS Decimal(18, 3)), NULL, CAST(N'2022-04-15' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6059, 3006, 5063, N'PurchaseInvoice', N'Cash Purchase Order No: 5063
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 730.250
', NULL, CAST(730.250 AS Decimal(18, 3)), CAST(N'2022-04-15' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6060, 3006, 5064, N'PurchaseInvoice', N'CASH Purchase Order No: 5064
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 480.250
', CAST(480.250 AS Decimal(18, 3)), NULL, CAST(N'2022-04-16' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6061, 3006, 5064, N'PurchaseInvoice', N'Cash Purchase Order No: 5064
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 480.250
', NULL, CAST(480.250 AS Decimal(18, 3)), CAST(N'2022-04-16' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6062, 3006, 5065, N'PurchaseInvoice', N'CASH Purchase Order No: 5065
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 400.150
', CAST(400.150 AS Decimal(18, 3)), NULL, CAST(N'2022-04-16' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6063, 3006, 5065, N'PurchaseInvoice', N'Cash Purchase Order No: 5065
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 400.150
', NULL, CAST(400.150 AS Decimal(18, 3)), CAST(N'2022-04-16' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6064, 3006, 5066, N'PurchaseInvoice', N'CASH Purchase Order No: 5066
check:  1 * 250.000 = 250.000
Total Amount: 250.000
', CAST(250.000 AS Decimal(18, 3)), NULL, CAST(N'2022-04-16' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6065, 3006, 5066, N'PurchaseInvoice', N'Cash Purchase Order No: 5066
check:  1 * 250.000 = 250.000
Total Amount: 250.000
', NULL, CAST(250.000 AS Decimal(18, 3)), CAST(N'2022-04-16' AS Date))
SET IDENTITY_INSERT [dbo].[SupplierLead] OFF
GO
SET IDENTITY_INSERT [dbo].[TblShelf] ON 

INSERT [dbo].[TblShelf] ([Id], [ShelfName], [ShelfCode]) VALUES (2008, N'shelf 1', N'111')
SET IDENTITY_INSERT [dbo].[TblShelf] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([id], [Name]) VALUES (1, N'KG')
INSERT [dbo].[Unit] ([id], [Name]) VALUES (2, N'G')
INSERT [dbo].[Unit] ([id], [Name]) VALUES (3, N'ML')
INSERT [dbo].[Unit] ([id], [Name]) VALUES (4, N'L')
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [UserName], [Password], [UserRole]) VALUES (1, N'ayaz', N'ayaz', N'ayaz', 1)
INSERT [dbo].[User] ([Id], [Name], [UserName], [Password], [UserRole]) VALUES (2, N'sikandar', N'sikandar', N'sikandar', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([Id], [Name]) VALUES (2, N'Employee')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Isdeleted]  DEFAULT ((0)) FOR [Isdeleted]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Unit]  DEFAULT ((0)) FOR [Unit]
GO
ALTER TABLE [dbo].[ProductStock] ADD  CONSTRAINT [DF_ProductStock_Adjustment]  DEFAULT ((0)) FOR [Adjustment]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  CONSTRAINT [DF__Sale_Orde__fixed__4222D4EF]  DEFAULT (NULL) FOR [fixed_item_des]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  CONSTRAINT [DF__Sale_Orde__sub_c__4316F928]  DEFAULT (NULL) FOR [sub_cat_id]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  CONSTRAINT [DF__Sale_Orde__sub_c__440B1D61]  DEFAULT (NULL) FOR [sub_cat_name]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  CONSTRAINT [DF__Sale_Orde__cat_n__44FF419A]  DEFAULT (NULL) FOR [cat_name]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  CONSTRAINT [DF__Sale_Orde__print__45F365D3]  DEFAULT ('0') FOR [print_sort]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  CONSTRAINT [DF__Sale_Orde__kitch__46E78A0C]  DEFAULT ('0') FOR [kitchen_lines]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  CONSTRAINT [DF__Sale_Orde__item___47DBAE45]  DEFAULT (NULL) FOR [item_comments]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  CONSTRAINT [DF__Sale_Orde__item___48CFD27E]  DEFAULT ('0') FOR [item_price]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  CONSTRAINT [DF__Sale_Orde__bill___49C3F6B7]  DEFAULT (NULL) FOR [bill_no]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  CONSTRAINT [DF__Sale_Orde__is_up__4AB81AF0]  DEFAULT ('no') FOR [is_updated]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  CONSTRAINT [DF__Sale_Orde__is_de__4BAC3F29]  DEFAULT ('no') FOR [is_deleted]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__order__4CA06362]  DEFAULT (NULL) FOR [order_date]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__coupo__4D94879B]  DEFAULT (NULL) FOR [coupon]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__coupo__4E88ABD4]  DEFAULT (NULL) FOR [coupon_value]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__coupo__4F7CD00D]  DEFAULT (NULL) FOR [coupon_type]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__coupo__5070F446]  DEFAULT (NULL) FOR [coupon_applies_to]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__coupo__5165187F]  DEFAULT (NULL) FOR [coupon_categories]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__disco__52593CB8]  DEFAULT (NULL) FOR [discount_amount]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__disco__534D60F1]  DEFAULT (NULL) FOR [discount_desc]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__payme__5441852A]  DEFAULT ('cash') FOR [payment_mode]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__payme__5535A963]  DEFAULT ('cash') FOR [payment_status]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__custo__571DF1D5]  DEFAULT (NULL) FOR [customer_id]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__is_up__5812160E]  DEFAULT ('no') FOR [is_updated]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__is_de__59063A47]  DEFAULT ('no') FOR [is_deleted]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__Servi__59FA5E80]  DEFAULT (NULL) FOR [Service_Charge]
GO
ALTER TABLE [dbo].[AdvancedSalary]  WITH CHECK ADD  CONSTRAINT [FK_AdvancedSalary_Emplyee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Emplyee] ([Id])
GO
ALTER TABLE [dbo].[AdvancedSalary] CHECK CONSTRAINT [FK_AdvancedSalary_Emplyee]
GO
ALTER TABLE [dbo].[AdvancedSalary]  WITH CHECK ADD  CONSTRAINT [FK_AdvancedSalary_Emplyee1] FOREIGN KEY([PayedBy])
REFERENCES [dbo].[Emplyee] ([Id])
GO
ALTER TABLE [dbo].[AdvancedSalary] CHECK CONSTRAINT [FK_AdvancedSalary_Emplyee1]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_City] FOREIGN KEY([City])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_City]
GO
ALTER TABLE [dbo].[CustomerDRNote]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDRNote_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[CustomerDRNote] CHECK CONSTRAINT [FK_CustomerDRNote_Customer]
GO
ALTER TABLE [dbo].[CustomerDRNote]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDRNote_Emplyee] FOREIGN KEY([ReceivedBy])
REFERENCES [dbo].[Emplyee] ([Id])
GO
ALTER TABLE [dbo].[CustomerDRNote] CHECK CONSTRAINT [FK_CustomerDRNote_Emplyee]
GO
ALTER TABLE [dbo].[CustomerReceipt]  WITH CHECK ADD  CONSTRAINT [FK_CustomerReceipt_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[CustomerReceipt] CHECK CONSTRAINT [FK_CustomerReceipt_Customer]
GO
ALTER TABLE [dbo].[CustomerReceipt]  WITH CHECK ADD  CONSTRAINT [FK_CustomerReceipt_Emplyee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Emplyee] ([Id])
GO
ALTER TABLE [dbo].[CustomerReceipt] CHECK CONSTRAINT [FK_CustomerReceipt_Emplyee]
GO
ALTER TABLE [dbo].[CustomerReceipt]  WITH CHECK ADD  CONSTRAINT [FK_CustomerReceipt_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[CustomerReceipt] CHECK CONSTRAINT [FK_CustomerReceipt_User]
GO
ALTER TABLE [dbo].[Emplyee]  WITH CHECK ADD  CONSTRAINT [FK_Emplyee_City] FOREIGN KEY([City])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Emplyee] CHECK CONSTRAINT [FK_Emplyee_City]
GO
ALTER TABLE [dbo].[Emplyee]  WITH CHECK ADD  CONSTRAINT [FK_Emplyee_Emplyee] FOREIGN KEY([Id])
REFERENCES [dbo].[Emplyee] ([Id])
GO
ALTER TABLE [dbo].[Emplyee] CHECK CONSTRAINT [FK_Emplyee_Emplyee]
GO
ALTER TABLE [dbo].[Emplyee]  WITH CHECK ADD  CONSTRAINT [FK_Emplyee_UserRole] FOREIGN KEY([Role])
REFERENCES [dbo].[UserRole] ([Id])
GO
ALTER TABLE [dbo].[Emplyee] CHECK CONSTRAINT [FK_Emplyee_UserRole]
GO
ALTER TABLE [dbo].[ExpenceTransaction]  WITH CHECK ADD  CONSTRAINT [FK_ExpenceTransaction_Emplyee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Emplyee] ([Id])
GO
ALTER TABLE [dbo].[ExpenceTransaction] CHECK CONSTRAINT [FK_ExpenceTransaction_Emplyee]
GO
ALTER TABLE [dbo].[ExpenceTransaction]  WITH CHECK ADD  CONSTRAINT [FK_ExpenceTransaction_ExpenceType] FOREIGN KEY([ExpenceType])
REFERENCES [dbo].[ExpenceType] ([Id])
GO
ALTER TABLE [dbo].[ExpenceTransaction] CHECK CONSTRAINT [FK_ExpenceTransaction_ExpenceType]
GO
ALTER TABLE [dbo].[ExpenceTransaction]  WITH CHECK ADD  CONSTRAINT [FK_ExpenceTransaction_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[ExpenceTransaction] CHECK CONSTRAINT [FK_ExpenceTransaction_User]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_ProductCategory] FOREIGN KEY([Id])
REFERENCES [dbo].[ProductCategory] ([Id])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_ProductCategory]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ProductCategory] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCategory]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductGroup] FOREIGN KEY([GroupId])
REFERENCES [dbo].[ProductGroup] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductGroup]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductSubcategory] FOREIGN KEY([SubcategoryId])
REFERENCES [dbo].[ProductSubcategory] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductSubcategory]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_TblShelf] FOREIGN KEY([ShelfId])
REFERENCES [dbo].[TblShelf] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_TblShelf]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Unit] FOREIGN KEY([Unit])
REFERENCES [dbo].[Unit] ([id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Unit]
GO
ALTER TABLE [dbo].[ProductStock]  WITH CHECK ADD  CONSTRAINT [FK_ProductStock_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductStock] CHECK CONSTRAINT [FK_ProductStock_Products]
GO
ALTER TABLE [dbo].[ProductStock]  WITH CHECK ADD  CONSTRAINT [FK_ProductStock_PurchaseOrder] FOREIGN KEY([PurchaseOrderId])
REFERENCES [dbo].[PurchaseOrder] ([Id])
GO
ALTER TABLE [dbo].[ProductStock] CHECK CONSTRAINT [FK_ProductStock_PurchaseOrder]
GO
ALTER TABLE [dbo].[ProductSubcategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductSubcategory_ProductCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ProductCategory] ([Id])
GO
ALTER TABLE [dbo].[ProductSubcategory] CHECK CONSTRAINT [FK_ProductSubcategory_ProductCategory]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Emplyee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Emplyee] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Emplyee]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Supplier]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Unit] FOREIGN KEY([UserId])
REFERENCES [dbo].[Unit] ([id])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Unit]
GO
ALTER TABLE [dbo].[Sale_OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_Sale_OrderDetail_Sale_Orders] FOREIGN KEY([order_id])
REFERENCES [dbo].[Sale_Orders] ([id])
GO
ALTER TABLE [dbo].[Sale_OrderDetail] CHECK CONSTRAINT [FK_Sale_OrderDetail_Sale_Orders]
GO
ALTER TABLE [dbo].[Sale_Orders]  WITH CHECK ADD  CONSTRAINT [FK_Sale_Orders_Customer] FOREIGN KEY([customer_id])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Sale_Orders] CHECK CONSTRAINT [FK_Sale_Orders_Customer]
GO
ALTER TABLE [dbo].[Sale_Orders]  WITH CHECK ADD  CONSTRAINT [FK_Sale_Orders_Emplyee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Emplyee] ([Id])
GO
ALTER TABLE [dbo].[Sale_Orders] CHECK CONSTRAINT [FK_Sale_Orders_Emplyee]
GO
ALTER TABLE [dbo].[Sale_Orders]  WITH CHECK ADD  CONSTRAINT [FK_Sale_Orders_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Sale_Orders] CHECK CONSTRAINT [FK_Sale_Orders_User]
GO
ALTER TABLE [dbo].[Stock_OderDetail]  WITH CHECK ADD  CONSTRAINT [FK_Stock_OderDetail_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Stock_OderDetail] CHECK CONSTRAINT [FK_Stock_OderDetail_Products]
GO
ALTER TABLE [dbo].[Stock_OderDetail]  WITH NOCHECK ADD  CONSTRAINT [FK_Stock_OderDetail_ProductStock] FOREIGN KEY([StockId])
REFERENCES [dbo].[ProductStock] ([Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Stock_OderDetail] CHECK CONSTRAINT [FK_Stock_OderDetail_ProductStock]
GO
ALTER TABLE [dbo].[Stock_OderDetail]  WITH CHECK ADD  CONSTRAINT [FK_Stock_OderDetail_Sale_OrderDetail] FOREIGN KEY([OrderDetail_Id])
REFERENCES [dbo].[Sale_OrderDetail] ([id])
GO
ALTER TABLE [dbo].[Stock_OderDetail] CHECK CONSTRAINT [FK_Stock_OderDetail_Sale_OrderDetail]
GO
ALTER TABLE [dbo].[StockLead]  WITH CHECK ADD  CONSTRAINT [FK_StockLead_Products] FOREIGN KEY([Product_id])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[StockLead] CHECK CONSTRAINT [FK_StockLead_Products]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_City] FOREIGN KEY([City])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_City]
GO
ALTER TABLE [dbo].[SupplierCRNote]  WITH CHECK ADD  CONSTRAINT [FK_SupplierCRNote_Emplyee] FOREIGN KEY([PayedBy])
REFERENCES [dbo].[Emplyee] ([Id])
GO
ALTER TABLE [dbo].[SupplierCRNote] CHECK CONSTRAINT [FK_SupplierCRNote_Emplyee]
GO
ALTER TABLE [dbo].[SupplierCRNote]  WITH CHECK ADD  CONSTRAINT [FK_SupplierCRNote_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[SupplierCRNote] CHECK CONSTRAINT [FK_SupplierCRNote_Supplier]
GO
ALTER TABLE [dbo].[SupplierLead]  WITH CHECK ADD  CONSTRAINT [FK_SupplierLead_Supplier] FOREIGN KEY([Suplier_id])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[SupplierLead] CHECK CONSTRAINT [FK_SupplierLead_Supplier]
GO
ALTER TABLE [dbo].[SupplierPayment]  WITH CHECK ADD  CONSTRAINT [FK_SupplierPayment_Emplyee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Emplyee] ([Id])
GO
ALTER TABLE [dbo].[SupplierPayment] CHECK CONSTRAINT [FK_SupplierPayment_Emplyee]
GO
ALTER TABLE [dbo].[SupplierPayment]  WITH CHECK ADD  CONSTRAINT [FK_SupplierPayment_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[SupplierPayment] CHECK CONSTRAINT [FK_SupplierPayment_Supplier]
GO
ALTER TABLE [dbo].[SupplierPayment]  WITH CHECK ADD  CONSTRAINT [FK_SupplierPayment_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[SupplierPayment] CHECK CONSTRAINT [FK_SupplierPayment_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRole] FOREIGN KEY([UserRole])
REFERENCES [dbo].[UserRole] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserRole]
GO
ALTER TABLE [dbo].[UserPages]  WITH CHECK ADD  CONSTRAINT [FK_UserPages_AppPages] FOREIGN KEY([PageId])
REFERENCES [dbo].[AppPages] ([Id])
GO
ALTER TABLE [dbo].[UserPages] CHECK CONSTRAINT [FK_UserPages_AppPages]
GO
ALTER TABLE [dbo].[UserPages]  WITH CHECK ADD  CONSTRAINT [FK_UserPages_Emplyee] FOREIGN KEY([UserId])
REFERENCES [dbo].[Emplyee] ([Id])
GO
ALTER TABLE [dbo].[UserPages] CHECK CONSTRAINT [FK_UserPages_Emplyee]
GO
/****** Object:  StoredProcedure [dbo].[GetStockDetail]    Script Date: 01/05/2022 2:18:17 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetStockDetail]

	@QtyTosettle int,
	@ProductId int	
AS
BEGIN
	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * From ProductStock;
	
END
GO
USE [master]
GO
ALTER DATABASE [EPOS-DB] SET  READ_WRITE 
GO
