USE [master]
GO
/****** Object:  Database [EPOS-DB]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[AdvancedSalary]    Script Date: 26/02/2022 10:48:07 pm ******/
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
	[Amount] [bigint] NULL,
	[IsAdvance] [bit] NULL,
 CONSTRAINT [PK_AdvancedSalary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppPages]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[CashBookLead]    Script Date: 26/02/2022 10:48:07 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashBookLead](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Transaction_Id] [bigint] NULL,
	[Transaction_date] [datetime] NULL,
	[Transaction_type] [nvarchar](50) NULL,
	[Transaction_detail] [nvarchar](max) NULL,
	[CashBook_Id] [bigint] NULL,
	[DR_Amt] [numeric](18, 0) NULL,
	[CR_Amt] [numeric](18, 0) NULL,
	[User_Id] [bigint] NULL,
	[POS_Id] [bigint] NULL,
 CONSTRAINT [PK_CashBookLead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[CustomerDRNote]    Script Date: 26/02/2022 10:48:07 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerDRNote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Discription] [nvarchar](100) NULL,
	[ReceiptAmount] [nvarchar](100) NULL,
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
/****** Object:  Table [dbo].[CustomerLead]    Script Date: 26/02/2022 10:48:07 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerLead](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_id] [int] NULL,
	[Transaction_date] [datetime] NULL,
	[Transaction_id] [int] NULL,
	[Transaction_type] [nvarchar](50) NULL,
	[Transaction_detail] [nvarchar](max) NULL,
	[DR] [int] NULL,
	[CR] [int] NULL,
 CONSTRAINT [PK_CustomerLead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerReceipt]    Script Date: 26/02/2022 10:48:07 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerReceipt](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Discription] [varchar](100) NULL,
	[ReceiptAmount] [int] NULL,
	[TransactionDate] [date] NOT NULL,
	[CreatedOn] [date] NULL,
	[CustomerId] [int] NULL,
	[EmployeeId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_CustomerReceipt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Emplyee]    Script Date: 26/02/2022 10:48:07 pm ******/
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
	[Createdon] [datetime] NULL,
	[Password] [nvarchar](max) NULL,
	[IsLoginAllowed] [bit] NULL,
	[Salary] [bigint] NULL,
	[SalaryType] [nvarchar](50) NULL,
	[Working Hours] [decimal](18, 0) NULL,
	[Image] [nvarchar](max) NULL,
	[LoginName] [nvarchar](500) NULL,
 CONSTRAINT [PK_Emplyee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenceTransaction]    Script Date: 26/02/2022 10:48:07 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenceTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExpenceDate] [datetime] NULL,
	[EmployeeId] [int] NULL,
	[CreatedBy] [int] NULL,
	[Discription] [nvarchar](max) NULL,
	[Amount] [bigint] NULL,
	[Isdeleted] [bit] NULL,
	[ExpenceType] [int] NULL,
 CONSTRAINT [PK_ExpenceTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenceType]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[ProductGroup]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 26/02/2022 10:48:07 pm ******/
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
	[RetailPrice] [bigint] NOT NULL,
	[Wholesaleprice] [bigint] NULL,
	[PurchasePrice] [bigint] NOT NULL,
	[Lastupdated] [datetime] NULL,
	[Createdby] [int] NULL,
	[Createdon] [datetime] NULL,
	[Size] [int] NULL,
	[Unit] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductStock]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[ProductSubcategory]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[Purchase_OrderDetail]    Script Date: 26/02/2022 10:48:07 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase_OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[itemName] [nvarchar](1000) NULL,
	[ProductId] [int] NOT NULL,
	[PurchasePrice] [int] NOT NULL,
	[SalePrice] [bigint] NULL,
	[Qty] [int] NOT NULL,
	[StockId] [int] NULL,
	[PurchaseOrderId] [int] NOT NULL,
	[ExpiryDate] [datetime] NULL,
	[StartDate] [datetime] NULL,
	[Discount] [int] NULL,
	[Total] [int] NULL,
 CONSTRAINT [PK_Purchase_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 26/02/2022 10:48:07 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SupplierId] [int] NOT NULL,
	[EmployeeId] [int] NULL,
	[UserId] [int] NULL,
	[Date] [datetime] NOT NULL,
	[PaymentStatus] [nvarchar](50) NULL,
	[PaymentMode] [nvarchar](50) NULL,
	[TotalAmount] [int] NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale_OrderDetail]    Script Date: 26/02/2022 10:48:07 pm ******/
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
	[item_price] [bigint] NULL,
	[PurchasePrice] [bigint] NULL,
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
/****** Object:  Table [dbo].[Sale_Orders]    Script Date: 26/02/2022 10:48:07 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[restaurant_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[order_count] [int] NOT NULL,
	[total] [bigint] NOT NULL,
	[date] [date] NOT NULL,
	[order_date] [date] NULL,
	[description] [text] NULL,
	[coupon] [varchar](80) NULL,
	[coupon_value] [varchar](255) NULL,
	[coupon_type] [varchar](255) NULL,
	[coupon_applies_to] [varchar](255) NULL,
	[coupon_categories] [varchar](255) NULL,
	[discount_amount] [bigint] NULL,
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
	[Cash_Amount] [bigint] NOT NULL,
	[Online_Amount] [bigint] NOT NULL,
	[Is_Printed] [int] NOT NULL,
	[Service_Charge] [bigint] NULL,
 CONSTRAINT [PK_Sale_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[ShopSetting]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[Stock_OderDetail]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[StockLead]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[Supplier]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[SupplierCRNote]    Script Date: 26/02/2022 10:48:07 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierCRNote](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Discription] [nvarchar](100) NULL,
	[ReceiptAmount] [nvarchar](100) NULL,
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
/****** Object:  Table [dbo].[SupplierLead]    Script Date: 26/02/2022 10:48:07 pm ******/
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
	[DR] [numeric](18, 0) NULL,
	[CR] [numeric](18, 0) NULL,
	[Transaction_date] [datetime] NULL,
 CONSTRAINT [PK_SupplierLead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierPayment]    Script Date: 26/02/2022 10:48:07 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierPayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [int] NULL,
	[Discription] [varchar](500) NULL,
	[TransactionDate] [date] NOT NULL,
	[CreatedOn] [date] NULL,
	[SupplierId] [int] NULL,
	[EmployeeId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_SupplierPayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblShelf]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[Unit]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[UserPages]    Script Date: 26/02/2022 10:48:07 pm ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 26/02/2022 10:48:07 pm ******/
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

INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6025, 5042, CAST(N'2022-02-25T00:00:00.000' AS DateTime), N'PurchaseInvoice', N'Cash Purchase Order No: 5042
Shugar 250 grams:  4 * 40 = 160
Shugar 1 kg :  5 * 160 = 800
Total Amount: 960
', NULL, NULL, CAST(960 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6026, 7103, CAST(N'2022-02-25T14:28:40.597' AS DateTime), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7103', NULL, CAST(1000 AS Numeric(18, 0)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6027, 5043, CAST(N'2022-02-26T00:00:00.000' AS DateTime), N'PurchaseInvoice', N'Cash Purchase Order No: 5043
lux 100 g:  4 * 100 = 400
lifeboye 500 ml:  4 * 200 = 800
Shugar 1 kg :  4 * 160 = 640
Total Amount: 1840
', NULL, NULL, CAST(1840 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6028, 5044, CAST(N'2022-02-26T00:00:00.000' AS DateTime), N'PurchaseInvoice', N'Cash Purchase Order No: 5044
lux 100 g:  1 * 100 = 100
lifeboye 500 ml:  1 * 200 = 200
Shugar 250 grams:  1 * 40 = 40
Shugar 1 kg :  1 * 160 = 160
Total Amount: 500
', NULL, NULL, CAST(500 AS Numeric(18, 0)), NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id]) VALUES (6029, 7104, CAST(N'2022-02-26T19:24:57.200' AS DateTime), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7104', NULL, CAST(200 AS Numeric(18, 0)), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[CashBookLead] OFF
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (4150, N'Sargodha', CAST(N'2022-02-25T00:00:00.000' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (4151, N'lahore', CAST(N'2022-02-25T12:59:16.303' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (4152, N'Khushab', CAST(N'2022-02-26T18:30:36.953' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (4153, N'Karachi', CAST(N'2022-02-26T18:30:44.080' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (4154, N'Multan', CAST(N'2022-02-26T18:30:52.887' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (4155, N'Peshawar', CAST(N'2022-02-26T18:31:02.960' AS DateTime))
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (5022, N'walking customer', N'0300', N'sargodha', 4150, N'0300', CAST(N'2022-02-25T12:59:58.153' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (5023, N'sikandar ', N'0300', N'sargodha punjab', 4150, N'0345', CAST(N'2022-02-26T18:26:07.033' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (5024, N'samar ', N'0345', N'lahore ', 4151, N'03000', CAST(N'2022-02-26T18:26:31.343' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerDRNote] ON 

INSERT [dbo].[CustomerDRNote] ([Id], [Discription], [ReceiptAmount], [TransactionDate], [CreatedOn], [CustomerId], [ReceivedBy], [UserId]) VALUES (6, N'sikandar admin ', N'2000', CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 5023, 2009, NULL)
INSERT [dbo].[CustomerDRNote] ([Id], [Discription], [ReceiptAmount], [TransactionDate], [CreatedOn], [CustomerId], [ReceivedBy], [UserId]) VALUES (7, N'samar to samar ', N'2000', CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 5024, 2010, NULL)
INSERT [dbo].[CustomerDRNote] ([Id], [Discription], [ReceiptAmount], [TransactionDate], [CreatedOn], [CustomerId], [ReceivedBy], [UserId]) VALUES (8, N'sikandar 200', N'200', CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 5023, 2009, NULL)
SET IDENTITY_INSERT [dbo].[CustomerDRNote] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerLead] ON 

INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8050, 5022, CAST(N'2022-02-25T14:28:40.567' AS DateTime), 7103, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7103', 1000, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8051, 5022, CAST(N'2022-02-25T14:28:40.593' AS DateTime), 7103, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7103', NULL, 1000)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8052, 5023, CAST(N'2022-02-26T00:00:00.000' AS DateTime), 6, N'CustomerDrNote', N'sikandar admin  against DR Invoice Number # 6', 2000, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8053, 5024, CAST(N'2022-02-26T00:00:00.000' AS DateTime), 7, N'CustomerDrNote', N'samar to samar  against DR Invoice Number # 7', 2000, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8054, 5023, CAST(N'2022-02-26T19:24:57.197' AS DateTime), 7104, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7104', 200, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8055, 5023, CAST(N'2022-02-26T19:24:57.197' AS DateTime), 7104, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7104', NULL, 200)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8056, 5023, CAST(N'2022-02-26T00:00:00.000' AS DateTime), 8, N'CustomerDrNote', N'sikandar 200 against DR Invoice Number # 8', 200, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8057, 5022, CAST(N'2022-02-26T19:34:30.153' AS DateTime), 7105, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7105', 400, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8058, 5023, CAST(N'2022-02-26T00:00:00.000' AS DateTime), 2006, N'CustomerReceipt', N'sikandar  against DR Invoice Number # 2006', NULL, 250)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR]) VALUES (8060, 5023, CAST(N'2022-02-26T00:00:00.000' AS DateTime), 2008, N'CustomerReceipt', N'admin to sikandar  against Customer Receipt Invoice Number # 2008', NULL, 1500)
SET IDENTITY_INSERT [dbo].[CustomerLead] OFF
GO
SET IDENTITY_INSERT [dbo].[CustomerReceipt] ON 

INSERT [dbo].[CustomerReceipt] ([Id], [Discription], [ReceiptAmount], [TransactionDate], [CreatedOn], [CustomerId], [EmployeeId], [UserId]) VALUES (2003, N'admin to sikandar ', 2600, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 5023, 2009, NULL)
INSERT [dbo].[CustomerReceipt] ([Id], [Discription], [ReceiptAmount], [TransactionDate], [CreatedOn], [CustomerId], [EmployeeId], [UserId]) VALUES (2004, N'admin to samar ', 2700, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 5024, 2009, NULL)
INSERT [dbo].[CustomerReceipt] ([Id], [Discription], [ReceiptAmount], [TransactionDate], [CreatedOn], [CustomerId], [EmployeeId], [UserId]) VALUES (2005, N'sikandar 100', 100, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 5023, 2009, NULL)
INSERT [dbo].[CustomerReceipt] ([Id], [Discription], [ReceiptAmount], [TransactionDate], [CreatedOn], [CustomerId], [EmployeeId], [UserId]) VALUES (2008, N'admin to sikandar ', 1500, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 5023, 2009, NULL)
SET IDENTITY_INSERT [dbo].[CustomerReceipt] OFF
GO
SET IDENTITY_INSERT [dbo].[Emplyee] ON 

INSERT [dbo].[Emplyee] ([Id], [UserName], [Role], [City], [CNIC], [Adress], [Phone], [Isdeleted], [Createdon], [Password], [IsLoginAllowed], [Salary], [SalaryType], [Working Hours], [Image], [LoginName]) VALUES (2009, N'admin', 1, 4150, N'38403', N'sargodha', N'0300', NULL, CAST(N'2022-02-25T00:00:00.000' AS DateTime), N'123', 1, 25000, N'Monthly', NULL, NULL, N'123')
INSERT [dbo].[Emplyee] ([Id], [UserName], [Role], [City], [CNIC], [Adress], [Phone], [Isdeleted], [Createdon], [Password], [IsLoginAllowed], [Salary], [SalaryType], [Working Hours], [Image], [LoginName]) VALUES (2010, N'Samar ', 1, 4151, N'38403', N'sargodha', N'0300', NULL, CAST(N'2022-02-25T00:00:00.000' AS DateTime), N'786', 1, 25000, N'Hourly', CAST(6 AS Decimal(18, 0)), N'file:///G:/EZYPOS/EZYPOS/EZYPOS/bin/Debug/net5.0-windows/Assets/EmployeeImages/No_Image.jpg', N'786')
SET IDENTITY_INSERT [dbo].[Emplyee] OFF
GO
SET IDENTITY_INSERT [dbo].[ExpenceType] ON 

INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (2022, N'Fuel', NULL, CAST(N'2022-02-25T14:02:08.317' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (2023, N'Food', NULL, CAST(N'2022-02-25T14:02:13.827' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (2024, N'stationary ', NULL, CAST(N'2022-02-25T14:02:22.290' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (2026, N'Rent', NULL, CAST(N'2022-02-26T18:31:30.110' AS DateTime))
SET IDENTITY_INSERT [dbo].[ExpenceType] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([Id], [Name], [Isdeleted], [Createdon]) VALUES (3008, N'kitchen', NULL, NULL)
INSERT [dbo].[ProductCategory] ([Id], [Name], [Isdeleted], [Createdon]) VALUES (3009, N'cosmatics', NULL, NULL)
INSERT [dbo].[ProductCategory] ([Id], [Name], [Isdeleted], [Createdon]) VALUES (3010, N'Cold Drinks', NULL, NULL)
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductGroup] ON 

INSERT [dbo].[ProductGroup] ([id], [GroupName], [Isdeleted], [Createdon]) VALUES (1005, N'Group A', NULL, NULL)
INSERT [dbo].[ProductGroup] ([id], [GroupName], [Isdeleted], [Createdon]) VALUES (1006, N'Group B', NULL, NULL)
SET IDENTITY_INSERT [dbo].[ProductGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit]) VALUES (2014, N'Shugar 1 kg ', N'123456', 3008, 3009, NULL, 1005, 2006, 200, 200, 160, NULL, NULL, CAST(N'2022-02-25T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit]) VALUES (2016, N'Shugar 250 grams', N'456123', 3008, 3009, NULL, 1005, 2006, 50, 50, 40, NULL, NULL, CAST(N'2022-02-25T13:55:04.447' AS DateTime), 250, 2)
INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit]) VALUES (2017, N'lifeboye 500 ml', N'786786', 3009, 3012, NULL, 1006, 2005, 250, 250, 200, NULL, NULL, CAST(N'2022-02-25T00:00:00.000' AS DateTime), 500, 3)
INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit]) VALUES (2018, N'lux 100 g', N'112233', 3009, 3014, NULL, 1006, 2005, 150, 150, 100, NULL, NULL, CAST(N'2022-02-25T00:00:00.000' AS DateTime), 100, 2)
INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit]) VALUES (2019, N'Sunsilk ', N'159159', 3009, 3012, NULL, 1005, 2005, 250, 250, 200, NULL, NULL, CAST(N'2022-02-26T00:00:00.000' AS DateTime), 250, 3)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductStock] ON 

INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70058, 2016, CAST(N'2022-02-25' AS Date), CAST(N'2022-02-25' AS Date), 4, 0, 0, 5042)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70059, 2014, CAST(N'2022-02-25' AS Date), CAST(N'2022-02-25' AS Date), 5, 0, 0, 5042)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70060, 2018, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 4, 0, 0, 5043)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70061, 2017, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 4, 0, 0, 5043)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70062, 2014, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 4, 0, 0, 5043)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70063, 2018, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 1, 0, 0, 5044)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70064, 2017, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 1, 0, 0, 5044)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70065, 2016, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 1, 1, 0, 5044)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70066, 2014, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 1, 0, 0, 5044)
SET IDENTITY_INSERT [dbo].[ProductStock] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductSubcategory] ON 

INSERT [dbo].[ProductSubcategory] ([id], [SubcategoryName], [CategoryId], [Isdeleted], [Createdon]) VALUES (3009, N'Shugar ', 3008, NULL, NULL)
INSERT [dbo].[ProductSubcategory] ([id], [SubcategoryName], [CategoryId], [Isdeleted], [Createdon]) VALUES (3010, N'Salt', 3008, NULL, NULL)
INSERT [dbo].[ProductSubcategory] ([id], [SubcategoryName], [CategoryId], [Isdeleted], [Createdon]) VALUES (3011, N'Rice', 3008, NULL, NULL)
INSERT [dbo].[ProductSubcategory] ([id], [SubcategoryName], [CategoryId], [Isdeleted], [Createdon]) VALUES (3012, N'Shampoo', 3009, NULL, NULL)
INSERT [dbo].[ProductSubcategory] ([id], [SubcategoryName], [CategoryId], [Isdeleted], [Createdon]) VALUES (3014, N'Soap', 3009, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ProductSubcategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Purchase_OrderDetail] ON 

INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [Discount], [Total]) VALUES (7055, N'Shugar 250 grams', 2016, 40, NULL, 4, NULL, 5042, CAST(N'2022-02-25T14:12:14.740' AS DateTime), CAST(N'2022-02-25T14:12:14.740' AS DateTime), NULL, 160)
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [Discount], [Total]) VALUES (7056, N'Shugar 1 kg ', 2014, 160, NULL, 5, NULL, 5042, CAST(N'2022-02-25T14:11:53.477' AS DateTime), CAST(N'2022-02-25T14:11:53.477' AS DateTime), NULL, 800)
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [Discount], [Total]) VALUES (7057, N'lux 100 g', 2018, 100, NULL, 4, NULL, 5043, CAST(N'2022-02-26T18:21:02.737' AS DateTime), CAST(N'2022-02-26T18:21:02.737' AS DateTime), NULL, 400)
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [Discount], [Total]) VALUES (7058, N'lifeboye 500 ml', 2017, 200, NULL, 4, NULL, 5043, CAST(N'2022-02-26T18:21:01.783' AS DateTime), CAST(N'2022-02-26T18:21:01.783' AS DateTime), NULL, 800)
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [Discount], [Total]) VALUES (7059, N'Shugar 1 kg ', 2014, 160, NULL, 4, NULL, 5043, CAST(N'2022-02-26T18:20:59.750' AS DateTime), CAST(N'2022-02-26T18:20:59.750' AS DateTime), NULL, 640)
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [Discount], [Total]) VALUES (7060, N'lux 100 g', 2018, 100, NULL, 1, NULL, 5044, CAST(N'2022-02-26T18:24:38.120' AS DateTime), CAST(N'2022-02-26T18:24:38.120' AS DateTime), NULL, 100)
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [Discount], [Total]) VALUES (7061, N'lifeboye 500 ml', 2017, 200, NULL, 1, NULL, 5044, CAST(N'2022-02-26T18:24:37.640' AS DateTime), CAST(N'2022-02-26T18:24:37.640' AS DateTime), NULL, 200)
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [Discount], [Total]) VALUES (7062, N'Shugar 250 grams', 2016, 40, NULL, 1, NULL, 5044, CAST(N'2022-02-26T18:24:36.800' AS DateTime), CAST(N'2022-02-26T18:24:36.800' AS DateTime), NULL, 40)
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [Discount], [Total]) VALUES (7063, N'Shugar 1 kg ', 2014, 160, NULL, 1, NULL, 5044, CAST(N'2022-02-26T18:24:36.313' AS DateTime), CAST(N'2022-02-26T18:24:36.310' AS DateTime), NULL, 160)
SET IDENTITY_INSERT [dbo].[Purchase_OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchaseOrder] ON 

INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [TotalAmount]) VALUES (5042, 3006, 2009, NULL, CAST(N'2022-02-25T00:00:00.000' AS DateTime), N'Paid', N'CASH', 960)
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [TotalAmount]) VALUES (5043, 3006, 2009, NULL, CAST(N'2022-02-26T00:00:00.000' AS DateTime), N'Paid', N'CASH', 1840)
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [TotalAmount]) VALUES (5044, 3006, 2009, NULL, CAST(N'2022-02-26T00:00:00.000' AS DateTime), N'Paid', N'CASH', 500)
SET IDENTITY_INSERT [dbo].[PurchaseOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale_OrderDetail] ON 

INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7102, 7103, 2014, N'Shugar 1 kg ', NULL, NULL, NULL, NULL, 0, 1, NULL, 5, 200, 160, 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7103, 7104, 2014, N'Shugar 1 kg ', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, 200, 160, 1, NULL, N'', N'')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [item_price], [PurchasePrice], [item_index], [bill_no], [is_updated], [is_deleted]) VALUES (7104, 7105, 2014, N'Shugar 1 kg ', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, 200, 160, 1, NULL, N'', N'')
SET IDENTITY_INSERT [dbo].[Sale_OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale_Orders] ON 

INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge]) VALUES (7103, 1, 1, 1, 1000, CAST(N'2022-02-25' AS Date), CAST(N'2022-02-25' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'CASH', N'Paid', N'Admin', N'', 2009, 5022, NULL, N'no', N'no', 1000, 0, 0, NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge]) VALUES (7104, 1, 1, 1, 200, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'CASH', N'Paid', N'Admin', N'', 2009, 5023, NULL, N'no', N'no', 200, 0, 0, NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge]) VALUES (7105, 1, 1, 1, 400, CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'CREDIT', N'Paid', N'Admin', N'', 2009, 5022, NULL, N'no', N'no', 400, 0, 0, NULL)
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
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock_OderDetail] ON 

INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70105, 70059, 7102, 5, 2014, 7103)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70106, 70062, 7103, 1, 2014, 7104)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70107, 70062, 7104, 2, 2014, 7105)
SET IDENTITY_INSERT [dbo].[Stock_OderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[StockLead] ON 

INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9047, 5042, CAST(N'2022-02-25' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5042', 2016, CAST(4.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9048, 5042, CAST(N'2022-02-25' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5042', 2014, CAST(5.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9049, 7103, CAST(N'2022-02-25' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7103', 2014, NULL, CAST(5.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9050, 5043, CAST(N'2022-02-26' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5043', 2018, CAST(4.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9051, 5043, CAST(N'2022-02-26' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5043', 2017, CAST(4.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9052, 5043, CAST(N'2022-02-26' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5043', 2014, CAST(4.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9053, 5044, CAST(N'2022-02-26' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5044', 2018, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9054, 5044, CAST(N'2022-02-26' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5044', 2017, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9055, 5044, CAST(N'2022-02-26' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5044', 2016, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9056, 5044, CAST(N'2022-02-26' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5044', 2014, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9057, 7104, CAST(N'2022-02-26' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7104', 2014, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode]) VALUES (9058, 7105, CAST(N'2022-02-26' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7105', 2014, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[StockLead] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (3006, N'Default Supplier', N'0300', N'shahpur sargodha', 4151, N'0345', CAST(N'2022-02-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Supplier] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (3008, N'ayaz ', N'0313', N'sargodha punjab pakistan ', 4150, N'0346', CAST(N'2022-02-26T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
SET IDENTITY_INSERT [dbo].[SupplierCRNote] ON 

INSERT [dbo].[SupplierCRNote] ([Id], [Discription], [ReceiptAmount], [TransactionDate], [CreatedOn], [SupplierId], [PayedBy], [UserId]) VALUES (3, N'admin to ayaz ', N'20000', CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 3008, 2009, NULL)
INSERT [dbo].[SupplierCRNote] ([Id], [Discription], [ReceiptAmount], [TransactionDate], [CreatedOn], [SupplierId], [PayedBy], [UserId]) VALUES (4, N'admin to default ', N'50000', CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 3006, 2009, NULL)
SET IDENTITY_INSERT [dbo].[SupplierCRNote] OFF
GO
SET IDENTITY_INSERT [dbo].[SupplierLead] ON 

INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6018, 3006, 5042, N'PurchaseInvoice', N'CASH Purchase Order No: 5042
Shugar 250 grams:  4 * 40 = 160
Shugar 1 kg :  5 * 160 = 800
Total Amount: 960
', CAST(960 AS Numeric(18, 0)), NULL, CAST(N'2022-02-25T00:00:00.000' AS DateTime))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6019, 3006, 5042, N'PurchaseInvoice', N'Cash Purchase Order No: 5042
Shugar 250 grams:  4 * 40 = 160
Shugar 1 kg :  5 * 160 = 800
Total Amount: 960
', NULL, CAST(960 AS Numeric(18, 0)), CAST(N'2022-02-25T00:00:00.000' AS DateTime))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6020, 3006, 5043, N'PurchaseInvoice', N'CASH Purchase Order No: 5043
lux 100 g:  4 * 100 = 400
lifeboye 500 ml:  4 * 200 = 800
Shugar 1 kg :  4 * 160 = 640
Total Amount: 1840
', CAST(1840 AS Numeric(18, 0)), NULL, CAST(N'2022-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6021, 3006, 5043, N'PurchaseInvoice', N'Cash Purchase Order No: 5043
lux 100 g:  4 * 100 = 400
lifeboye 500 ml:  4 * 200 = 800
Shugar 1 kg :  4 * 160 = 640
Total Amount: 1840
', NULL, CAST(1840 AS Numeric(18, 0)), CAST(N'2022-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6022, 3006, 5044, N'PurchaseInvoice', N'CASH Purchase Order No: 5044
lux 100 g:  1 * 100 = 100
lifeboye 500 ml:  1 * 200 = 200
Shugar 250 grams:  1 * 40 = 40
Shugar 1 kg :  1 * 160 = 160
Total Amount: 500
', CAST(500 AS Numeric(18, 0)), NULL, CAST(N'2022-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6023, 3006, 5044, N'PurchaseInvoice', N'Cash Purchase Order No: 5044
lux 100 g:  1 * 100 = 100
lifeboye 500 ml:  1 * 200 = 200
Shugar 250 grams:  1 * 40 = 40
Shugar 1 kg :  1 * 160 = 160
Total Amount: 500
', NULL, CAST(500 AS Numeric(18, 0)), CAST(N'2022-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6024, 3008, 3, N'SupplierCRNote', N'admin to ayaz  against CR Invoice Number # 3', CAST(20000 AS Numeric(18, 0)), NULL, CAST(N'2022-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6025, 3006, 4, N'SupplierCRNote', N'admin to default  against CR Invoice Number # 4', CAST(50000 AS Numeric(18, 0)), NULL, CAST(N'2022-02-26T00:00:00.000' AS DateTime))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6027, 3006, 2006, N'SupplierPayment', N'admin to default Supplier Payment Invoice Number # 2006', CAST(1500 AS Numeric(18, 0)), NULL, CAST(N'2022-02-26T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[SupplierLead] OFF
GO
SET IDENTITY_INSERT [dbo].[SupplierPayment] ON 

INSERT [dbo].[SupplierPayment] ([Id], [Amount], [Discription], [TransactionDate], [CreatedOn], [SupplierId], [EmployeeId], [UserId]) VALUES (2003, 30000, N'samar to ayaz ', CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 3008, 2010, NULL)
INSERT [dbo].[SupplierPayment] ([Id], [Amount], [Discription], [TransactionDate], [CreatedOn], [SupplierId], [EmployeeId], [UserId]) VALUES (2004, 50000, N'admin', CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 3006, 2009, NULL)
INSERT [dbo].[SupplierPayment] ([Id], [Amount], [Discription], [TransactionDate], [CreatedOn], [SupplierId], [EmployeeId], [UserId]) VALUES (2006, 1500, N'admin to default', CAST(N'2022-02-26' AS Date), CAST(N'2022-02-26' AS Date), 3006, 2009, NULL)
SET IDENTITY_INSERT [dbo].[SupplierPayment] OFF
GO
SET IDENTITY_INSERT [dbo].[TblShelf] ON 

INSERT [dbo].[TblShelf] ([Id], [ShelfName], [ShelfCode]) VALUES (2005, N'Shelf a', N'aaa')
INSERT [dbo].[TblShelf] ([Id], [ShelfName], [ShelfCode]) VALUES (2006, N'Shelf b', N'bbb')
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
/****** Object:  StoredProcedure [dbo].[GetStockDetail]    Script Date: 26/02/2022 10:48:07 pm ******/
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
