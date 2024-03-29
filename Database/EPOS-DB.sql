USE [master]
GO
/****** Object:  Database [EPOS-DB]    Script Date: 16/06/2022 3:36:38 pm ******/
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
/****** Object:  User [EzyposAdmin]    Script Date: 16/06/2022 3:36:39 pm ******/
CREATE USER [EzyposAdmin] FOR LOGIN [EzyposAdmin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[AdvancedSalary]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[AppPages]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[CashBookLead]    Script Date: 16/06/2022 3:36:39 pm ******/
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
	[Is_Deleted] [bit] NULL,
 CONSTRAINT [PK_CashBookLead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CashSummary]    Script Date: 16/06/2022 3:36:39 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashSummary](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[StartAmount] [decimal](18, 3) NULL,
	[EndAmount] [decimal](18, 3) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[StartedBy] [nvarchar](100) NULL,
	[EndedBy] [nvarchar](100) NULL,
	[POSId] [nvarchar](50) NULL,
 CONSTRAINT [PK_CashSummary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[CustomerDRNote]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[CustomerLead]    Script Date: 16/06/2022 3:36:39 pm ******/
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
	[Is_Deleted] [bit] NULL,
 CONSTRAINT [PK_CustomerLead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerReceipt]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[Emplyee]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[ExpenceTransaction]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[ExpenceType]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[Pages]    Script Date: 16/06/2022 3:36:39 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PageName] [nvarchar](max) NULL,
	[Tag] [nvarchar](max) NULL,
	[ClickEvent] [nvarchar](max) NULL,
	[Isclickable] [bit] NULL,
	[Template] [nvarchar](max) NULL,
	[ParentId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Icon] [nvarchar](500) NULL,
 CONSTRAINT [PK_Pages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[POS]    Script Date: 16/06/2022 3:36:39 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[POS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_POS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[ProductGroup]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 16/06/2022 3:36:39 pm ******/
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
	[TaxType] [nvarchar](50) NULL,
	[Tax] [decimal](18, 3) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductStock]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[ProductSubcategory]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[Purchase_OrderDetail]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[Sale_OrderDetail]    Script Date: 16/06/2022 3:36:39 pm ******/
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
	[TaxType] [varchar](50) NULL,
	[ItemTax] [decimal](18, 3) NULL,
	[item_index] [int] NOT NULL,
	[bill_no] [int] NULL,
	[is_updated] [varchar](20) NOT NULL,
	[is_deleted] [bit] NOT NULL,
	[POSId] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sale_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale_Orders]    Script Date: 16/06/2022 3:36:39 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[restaurant_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[POSId] [nvarchar](50) NULL,
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
	[is_updated] [bit] NULL,
	[is_deleted] [bit] NULL,
	[TaxPercentage] [decimal](18, 3) NULL,
	[Tax] [decimal](18, 3) NULL,
	[Cash_Amount] [decimal](18, 3) NOT NULL,
	[Online_Amount] [decimal](18, 3) NOT NULL,
	[Is_Printed] [bit] NULL,
	[Service_Charge] [decimal](18, 3) NULL,
	[DeliveryCharges] [decimal](18, 3) NULL,
	[OrderStatus] [nvarchar](50) NULL,
	[ParentOrderId] [int] NULL,
 CONSTRAINT [PK_Sale_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[ShopSetting]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[Stock_OderDetail]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[StockLead]    Script Date: 16/06/2022 3:36:39 pm ******/
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
	[Is_Deleted] [bit] NULL,
 CONSTRAINT [PK_StockLead] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[SupplierCRNote]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[SupplierLead]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[SupplierPayment]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[TblShelf]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[Unit]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[UserPages]    Script Date: 16/06/2022 3:36:39 pm ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 16/06/2022 3:36:39 pm ******/
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

INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6058, 5059, CAST(N'2022-03-24' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5059
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 400.150
', NULL, NULL, CAST(400.150 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6059, 5060, CAST(N'2022-03-26' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5060
Lux 250g:  2 * 80.100 = 160.200
Total Amount: 139.850
', NULL, NULL, CAST(139.850 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6060, 7123, CAST(N'2022-03-26' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7123', NULL, CAST(105.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6061, 7124, CAST(N'2022-03-26' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7124', NULL, CAST(510.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6062, 5061, CAST(N'2022-04-07' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5061
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 723.650
', NULL, NULL, CAST(723.650 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6063, 7125, CAST(N'2022-04-07' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7125', NULL, CAST(818.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6064, 5062, CAST(N'2022-04-09' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5062
check:  6 * 250.000 = 1500.000
Lux 250g:  6 * 80.100 = 480.600
Head & Shoulder 500 ml:  6 * 400.150 = 2400.900
Total Amount: 4381.500
', NULL, NULL, CAST(4381.500 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6065, 5063, CAST(N'2022-04-15' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5063
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 730.250
', NULL, NULL, CAST(730.250 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6066, 7126, CAST(N'2022-04-16' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7126', NULL, CAST(500.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6067, 7127, CAST(N'2022-04-16' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7127', NULL, CAST(125.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6068, 5064, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5064
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 480.250
', NULL, NULL, CAST(480.250 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6069, 7128, CAST(N'2022-04-16' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7128', NULL, CAST(500.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6070, 5065, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5065
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 400.150
', NULL, NULL, CAST(400.150 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6071, 5066, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5066
check:  1 * 250.000 = 250.000
Total Amount: 250.000
', NULL, NULL, CAST(250.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6072, 7129, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7129', NULL, CAST(625.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6073, 7130, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7130', NULL, CAST(625.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6074, 7131, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7131', NULL, CAST(500.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6075, 7132, CAST(N'2022-04-25' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7132', NULL, CAST(-25.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6076, 7133, CAST(N'2022-04-26' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7133', NULL, CAST(125.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6077, 7134, CAST(N'2022-05-01' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7134', NULL, CAST(557.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6078, 7135, CAST(N'2022-05-01' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7135', NULL, CAST(506.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6079, 7137, CAST(N'2022-05-15' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7137', NULL, CAST(405.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6080, 5070, CAST(N'2022-05-19' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5070
oil 100g:  1 * 250.000 = 250.000
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 980.250
', NULL, NULL, CAST(980.250 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6081, 5071, CAST(N'2022-05-20' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5071
Head & Shoulder 500 ml:  4 * 400.150 = 1600.600
Total Amount: 1600.600
', NULL, NULL, CAST(1600.600 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6082, 7139, CAST(N'2022-05-20' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7139', NULL, CAST(420.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6083, 7140, CAST(N'2022-06-08' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7140', NULL, CAST(499.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6084, 7141, CAST(N'2022-06-08' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7141', NULL, CAST(470.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6085, 7142, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7142', NULL, CAST(609.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6086, 7143, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7143', NULL, CAST(131.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6087, 7144, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7144', NULL, CAST(131.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6088, 5072, CAST(N'2022-06-09' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5072
Lux 250g:  6 * 80.100 = 480.600
Total Amount: 480.600
', NULL, NULL, CAST(480.600 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6089, 7146, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7146', NULL, CAST(125.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6090, 7147, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7147', NULL, CAST(581.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6091, 7148, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7148', NULL, CAST(341.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6092, 7149, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7149', NULL, CAST(341.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6093, 7150, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7150', NULL, CAST(551.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6094, 5073, CAST(N'2022-06-10' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5073
check123:  12 * 12.000 = 144.000
oil 100g:  12 * 250.000 = 3000.000
check:  12 * 250.000 = 3000.000
Lux 250g:  12 * 80.100 = 961.200
Head & Shoulder 500 ml:  13 * 400.150 = 5201.950
Total Amount: 12307.150
', NULL, NULL, CAST(12307.150 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6095, 7151, CAST(N'2022-06-10' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7151', NULL, CAST(525.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6096, 7152, CAST(N'2022-06-11' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7152', NULL, CAST(131.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6097, 7160, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7160', NULL, CAST(1575.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6098, 7161, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7161', NULL, CAST(525.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6099, 7162, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7162', NULL, CAST(1154.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6100, 7163, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7163', NULL, CAST(866.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6101, 7164, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7164', NULL, CAST(1667.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6102, 7165, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Cash Return Transaction against Invoice Number # 7165', NULL, NULL, CAST(375.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6103, 7165, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7165', NULL, CAST(375.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6104, 7166, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Cash Return Transaction against Invoice Number # 7166', NULL, NULL, CAST(325.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6105, 7166, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7166', NULL, CAST(325.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6106, 5074, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5074
check123:  1 * 12.000 = 12.000
oil 100g:  1 * 250.000 = 250.000
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 992.250
', NULL, NULL, CAST(992.250 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6107, 5075, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5075
check123:  10 * 12.000 = 120.000
oil 100g:  10 * 250.000 = 2500.000
check:  10 * 250.000 = 2500.000
Lux 250g:  10 * 80.100 = 801.000
Head & Shoulder 500 ml:  10 * 400.150 = 4001.500
Total Amount: 9922.500
', NULL, NULL, CAST(9922.500 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6108, 7167, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7167', NULL, CAST(1707.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6109, 7168, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7168', NULL, CAST(919.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6110, 7169, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7169', NULL, CAST(656.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6111, 7170, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7170', NULL, CAST(525.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6112, 7171, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7171', NULL, CAST(12.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6113, 7172, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7172', NULL, CAST(12.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6114, 5076, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5076
Head & Shoulder 500 ml:  20 * 400.150 = 8003.000
Total Amount: 8003.000
', NULL, NULL, CAST(8003.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6115, 7173, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7173', NULL, CAST(1050.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6116, 5077, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5077
check:  9 * 250.000 = 2250.000
Lux 250g:  7 * 80.100 = 560.700
Head & Shoulder 500 ml:  9 * 400.150 = 3601.350
Total Amount: 6412.050
', NULL, NULL, CAST(6412.050 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6117, 7174, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7174', NULL, CAST(1313.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6118, 7175, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7175', NULL, CAST(525.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6119, 7176, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7176', NULL, CAST(2232.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6120, 7177, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7177', NULL, CAST(656.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6121, 7178, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7178', NULL, CAST(1995.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6122, 7179, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7179', NULL, CAST(866.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6123, 5078, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5078
check123:  4 * 12.000 = 48.000
oil 100g:  3 * 250.000 = 750.000
check:  5 * 250.000 = 1250.000
Lux 250g:  5 * 80.100 = 400.500
Head & Shoulder 500 ml:  6 * 400.150 = 2400.900
Total Amount: 4849.400
', NULL, NULL, CAST(4849.400 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6124, 7181, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7181', NULL, CAST(866.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6125, 7182, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7182', NULL, CAST(866.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6126, 7183, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Cash Return Transaction against Invoice Number # 7183', NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6127, 7183, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7183', NULL, CAST(0.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6128, 7184, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7184', NULL, CAST(866.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6129, 7185, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Cash Return Transaction against Invoice Number # 7185', NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6130, 7185, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7185', NULL, CAST(0.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6131, 7186, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7186', NULL, CAST(866.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6132, 7187, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Cash Return Transaction against Invoice Number # 7187', NULL, NULL, CAST(200.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6133, 7187, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7187', NULL, CAST(200.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6134, 7188, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7188', NULL, CAST(656.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6135, 7189, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7189', NULL, CAST(125.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6136, 7190, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7190', NULL, CAST(1470.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6137, 7191, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Cash Return Transaction against Invoice Number # 7191', NULL, NULL, CAST(400.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6138, 7191, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7191', NULL, CAST(400.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6139, 5079, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5079
check:  2 * 250.000 = 500.000
Lux 250g:  15 * 80.100 = 1201.500
Head & Shoulder 500 ml:  12 * 400.150 = 4801.800
Total Amount: 6503.300
', NULL, NULL, CAST(6503.300 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6140, 5080, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Cash Purchase Order No: 5080
check123:  2 * 12.000 = 24.000
oil 100g:  7 * 250.000 = 1750.000
Total Amount: 1774.000
', NULL, NULL, CAST(1774.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6141, 7192, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7192', NULL, CAST(5709.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6142, 7193, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Cash Return Transaction against Invoice Number # 7193', NULL, NULL, CAST(2476.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6143, 7193, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7193', NULL, CAST(2476.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6144, 7194, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7194', NULL, CAST(1050.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6145, 7195, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Cash Return Transaction against Invoice Number # 7195', NULL, NULL, CAST(1000.000 AS Decimal(18, 3)), NULL, NULL, NULL)
INSERT [dbo].[CashBookLead] ([Id], [Transaction_Id], [Transaction_date], [Transaction_type], [Transaction_detail], [CashBook_Id], [DR_Amt], [CR_Amt], [User_Id], [POS_Id], [Is_Deleted]) VALUES (6146, 7195, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7195', NULL, CAST(1000.000 AS Decimal(18, 3)), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[CashBookLead] OFF
GO
SET IDENTITY_INSERT [dbo].[CashSummary] ON 

INSERT [dbo].[CashSummary] ([id], [StartAmount], [EndAmount], [StartDate], [EndDate], [IsActive], [StartedBy], [EndedBy], [POSId]) VALUES (7, CAST(1000.000 AS Decimal(18, 3)), CAST(1200.000 AS Decimal(18, 3)), CAST(N'2022-06-11T14:21:54.473' AS DateTime), CAST(N'2022-06-11T14:22:18.317' AS DateTime), 0, N'sikandar 12', N'sikandar 12', N'POS1')
INSERT [dbo].[CashSummary] ([id], [StartAmount], [EndAmount], [StartDate], [EndDate], [IsActive], [StartedBy], [EndedBy], [POSId]) VALUES (8, CAST(10000.000 AS Decimal(18, 3)), CAST(10001.000 AS Decimal(18, 3)), CAST(N'2022-06-11T14:24:25.530' AS DateTime), CAST(N'2022-06-11T14:24:41.507' AS DateTime), 0, N'sikandar 12', N'sikandar 12', N'POS1')
INSERT [dbo].[CashSummary] ([id], [StartAmount], [EndAmount], [StartDate], [EndDate], [IsActive], [StartedBy], [EndedBy], [POSId]) VALUES (9, CAST(10700.000 AS Decimal(18, 3)), CAST(144680.000 AS Decimal(18, 3)), CAST(N'2022-06-14T10:50:32.560' AS DateTime), CAST(N'2022-06-14T10:52:07.620' AS DateTime), 0, N'sikandar 12', N'sikandar 12', N'POS1')
INSERT [dbo].[CashSummary] ([id], [StartAmount], [EndAmount], [StartDate], [EndDate], [IsActive], [StartedBy], [EndedBy], [POSId]) VALUES (10, CAST(1100.000 AS Decimal(18, 3)), NULL, CAST(N'2022-06-14T11:57:19.013' AS DateTime), NULL, 1, N'sikandar 12', NULL, N'POS1')
SET IDENTITY_INSERT [dbo].[CashSummary] OFF
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

INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8095, 5022, CAST(N'2022-03-26' AS Date), 7123, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7123', CAST(105.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8096, 5022, CAST(N'2022-03-26' AS Date), 7123, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7123', NULL, CAST(105.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8097, 5022, CAST(N'2022-03-26' AS Date), 7124, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7124', CAST(510.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8098, 5022, CAST(N'2022-03-26' AS Date), 7124, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7124', NULL, CAST(510.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8099, 5022, CAST(N'2022-04-07' AS Date), 7125, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7125', CAST(818.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8100, 5022, CAST(N'2022-04-07' AS Date), 7125, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7125', NULL, CAST(818.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8101, 5022, CAST(N'2022-04-16' AS Date), 7126, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7126', CAST(500.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8102, 5022, CAST(N'2022-04-16' AS Date), 7126, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7126', NULL, CAST(500.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8103, 5022, CAST(N'2022-04-16' AS Date), 7127, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7127', CAST(125.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8104, 5022, CAST(N'2022-04-16' AS Date), 7127, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7127', NULL, CAST(125.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8105, 5022, CAST(N'2022-04-16' AS Date), 7128, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7128', CAST(500.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8106, 5022, CAST(N'2022-04-16' AS Date), 7128, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7128', NULL, CAST(500.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8107, 5022, CAST(N'2022-04-17' AS Date), 7129, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7129', CAST(625.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8108, 5022, CAST(N'2022-04-17' AS Date), 7129, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7129', NULL, CAST(625.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8109, 5022, CAST(N'2022-04-17' AS Date), 7130, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7130', CAST(625.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8110, 5022, CAST(N'2022-04-17' AS Date), 7130, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7130', NULL, CAST(625.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8111, 5022, CAST(N'2022-04-17' AS Date), 7131, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7131', CAST(500.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8112, 5022, CAST(N'2022-04-17' AS Date), 7131, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7131', NULL, CAST(500.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8113, 5022, CAST(N'2022-04-25' AS Date), 7132, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7132', CAST(-25.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8114, 5022, CAST(N'2022-04-25' AS Date), 7132, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7132', NULL, CAST(-25.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8115, 5022, CAST(N'2022-04-26' AS Date), 7133, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7133', CAST(125.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8116, 5022, CAST(N'2022-04-26' AS Date), 7133, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7133', NULL, CAST(125.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8117, 5022, CAST(N'2022-05-01' AS Date), 7134, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7134', CAST(557.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8118, 5022, CAST(N'2022-05-01' AS Date), 7134, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7134', NULL, CAST(557.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8119, 5022, CAST(N'2022-05-01' AS Date), 7135, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7135', CAST(506.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8120, 5022, CAST(N'2022-05-01' AS Date), 7135, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7135', NULL, CAST(506.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8121, 5022, CAST(N'2022-05-15' AS Date), 7137, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7137', CAST(405.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8122, 5022, CAST(N'2022-05-15' AS Date), 7137, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7137', NULL, CAST(405.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8123, 5022, CAST(N'2022-05-20' AS Date), 7139, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7139', CAST(420.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8124, 5022, CAST(N'2022-05-20' AS Date), 7139, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7139', NULL, CAST(420.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8125, 5022, CAST(N'2022-06-08' AS Date), 7140, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7140', CAST(499.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8126, 5022, CAST(N'2022-06-08' AS Date), 7140, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7140', NULL, CAST(499.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8127, 5022, CAST(N'2022-06-08' AS Date), 7141, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7141', CAST(470.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8128, 5022, CAST(N'2022-06-08' AS Date), 7141, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7141', NULL, CAST(470.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8129, 5022, CAST(N'2022-06-09' AS Date), 7142, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7142', CAST(609.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8130, 5022, CAST(N'2022-06-09' AS Date), 7142, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7142', NULL, CAST(609.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8131, 5022, CAST(N'2022-06-09' AS Date), 7143, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7143', CAST(131.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8132, 5022, CAST(N'2022-06-09' AS Date), 7143, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7143', NULL, CAST(131.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8133, 5022, CAST(N'2022-06-09' AS Date), 7144, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7144', CAST(131.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8134, 5022, CAST(N'2022-06-09' AS Date), 7144, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7144', NULL, CAST(131.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8135, 5022, CAST(N'2022-06-09' AS Date), 7146, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7146', CAST(125.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8136, 5022, CAST(N'2022-06-09' AS Date), 7146, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7146', NULL, CAST(125.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8137, 5022, CAST(N'2022-06-09' AS Date), 7147, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7147', CAST(581.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8138, 5022, CAST(N'2022-06-09' AS Date), 7147, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7147', NULL, CAST(581.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8139, 5022, CAST(N'2022-06-09' AS Date), 7148, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7148', CAST(341.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8140, 5022, CAST(N'2022-06-09' AS Date), 7148, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7148', NULL, CAST(341.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8141, 5022, CAST(N'2022-06-09' AS Date), 7149, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7149', CAST(341.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8142, 5022, CAST(N'2022-06-09' AS Date), 7149, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7149', NULL, CAST(341.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8143, 5022, CAST(N'2022-06-09' AS Date), 7150, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7150', CAST(551.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8144, 5022, CAST(N'2022-06-09' AS Date), 7150, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7150', NULL, CAST(551.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8145, 5022, CAST(N'2022-06-10' AS Date), 7151, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7151', CAST(525.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8146, 5022, CAST(N'2022-06-10' AS Date), 7151, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7151', NULL, CAST(525.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8147, 5022, CAST(N'2022-06-11' AS Date), 7152, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7152', CAST(131.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8148, 5022, CAST(N'2022-06-11' AS Date), 7152, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7152', NULL, CAST(131.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8149, 5022, CAST(N'2022-06-14' AS Date), 7160, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7160', CAST(1575.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8150, 5022, CAST(N'2022-06-14' AS Date), 7160, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7160', NULL, CAST(1575.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8151, 5022, CAST(N'2022-06-14' AS Date), 7161, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7161', CAST(525.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8152, 5022, CAST(N'2022-06-14' AS Date), 7161, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7161', NULL, CAST(525.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8153, 5022, CAST(N'2022-06-14' AS Date), 7162, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7162', CAST(1154.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8154, 5022, CAST(N'2022-06-14' AS Date), 7162, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7162', NULL, CAST(1154.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8155, 5022, CAST(N'2022-06-14' AS Date), 7163, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7163', CAST(866.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8156, 5022, CAST(N'2022-06-14' AS Date), 7163, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7163', NULL, CAST(866.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8157, 5022, CAST(N'2022-06-14' AS Date), 7164, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7164', CAST(1667.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8158, 5022, CAST(N'2022-06-14' AS Date), 7164, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7164', NULL, CAST(1667.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8159, 5022, CAST(N'2022-06-14' AS Date), 7165, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7165', NULL, CAST(375.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8160, 5022, CAST(N'2022-06-14' AS Date), 7166, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7166', NULL, CAST(325.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8161, 5022, CAST(N'2022-06-14' AS Date), 7167, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7167', CAST(1707.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8162, 5022, CAST(N'2022-06-14' AS Date), 7167, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7167', NULL, CAST(1707.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8163, 5022, CAST(N'2022-06-14' AS Date), 7168, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7168', CAST(919.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8164, 5022, CAST(N'2022-06-14' AS Date), 7168, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7168', NULL, CAST(919.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8165, 5022, CAST(N'2022-06-14' AS Date), 7169, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7169', CAST(656.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8166, 5022, CAST(N'2022-06-14' AS Date), 7169, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7169', NULL, CAST(656.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8167, 5022, CAST(N'2022-06-14' AS Date), 7170, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7170', CAST(525.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8168, 5022, CAST(N'2022-06-14' AS Date), 7170, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7170', NULL, CAST(525.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8169, 5022, CAST(N'2022-06-14' AS Date), 7171, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7171', CAST(12.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8170, 5022, CAST(N'2022-06-14' AS Date), 7171, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7171', NULL, CAST(12.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8171, 5022, CAST(N'2022-06-14' AS Date), 7172, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7172', CAST(12.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8172, 5022, CAST(N'2022-06-14' AS Date), 7172, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7172', NULL, CAST(12.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8173, 5022, CAST(N'2022-06-14' AS Date), 7173, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7173', CAST(1050.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8174, 5022, CAST(N'2022-06-14' AS Date), 7173, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7173', NULL, CAST(1050.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8175, 5022, CAST(N'2022-06-14' AS Date), 7174, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7174', CAST(1313.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8176, 5022, CAST(N'2022-06-14' AS Date), 7174, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7174', NULL, CAST(1313.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8177, 5022, CAST(N'2022-06-14' AS Date), 7175, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7175', CAST(525.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8178, 5022, CAST(N'2022-06-14' AS Date), 7175, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7175', NULL, CAST(525.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8179, 5022, CAST(N'2022-06-14' AS Date), 7176, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7176', CAST(2232.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8180, 5022, CAST(N'2022-06-14' AS Date), 7176, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7176', NULL, CAST(2232.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8181, 5022, CAST(N'2022-06-14' AS Date), 7177, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7177', CAST(656.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8182, 5022, CAST(N'2022-06-14' AS Date), 7177, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7177', NULL, CAST(656.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8183, 5022, CAST(N'2022-06-14' AS Date), 7178, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7178', CAST(1995.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8184, 5022, CAST(N'2022-06-14' AS Date), 7178, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7178', NULL, CAST(1995.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8185, 5022, CAST(N'2022-06-14' AS Date), 7179, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7179', CAST(866.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8186, 5022, CAST(N'2022-06-14' AS Date), 7179, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7179', NULL, CAST(866.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8187, 5022, CAST(N'2022-06-14' AS Date), 7181, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7181', CAST(866.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8188, 5022, CAST(N'2022-06-14' AS Date), 7181, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7181', NULL, CAST(866.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8189, 5022, CAST(N'2022-06-14' AS Date), 7182, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7182', CAST(866.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8190, 5022, CAST(N'2022-06-14' AS Date), 7182, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7182', NULL, CAST(866.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8191, 5022, CAST(N'2022-06-14' AS Date), 7183, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7183', NULL, CAST(0.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8192, 5022, CAST(N'2022-06-14' AS Date), 7184, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7184', CAST(866.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8193, 5022, CAST(N'2022-06-14' AS Date), 7184, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7184', NULL, CAST(866.000 AS Decimal(18, 3)), NULL)
GO
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8194, 5022, CAST(N'2022-06-14' AS Date), 7185, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7185', NULL, CAST(0.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8195, 5022, CAST(N'2022-06-14' AS Date), 7186, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7186', CAST(866.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8196, 5022, CAST(N'2022-06-14' AS Date), 7186, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7186', NULL, CAST(866.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8197, 5022, CAST(N'2022-06-14' AS Date), 7187, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7187', NULL, CAST(200.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8198, 5022, CAST(N'2022-06-14' AS Date), 7188, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7188', CAST(656.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8199, 5022, CAST(N'2022-06-14' AS Date), 7188, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7188', NULL, CAST(656.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8200, 5022, CAST(N'2022-06-14' AS Date), 7189, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7189', CAST(125.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8201, 5022, CAST(N'2022-06-14' AS Date), 7189, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7189', NULL, CAST(125.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8202, 5022, CAST(N'2022-06-14' AS Date), 7190, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7190', CAST(1470.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8203, 5022, CAST(N'2022-06-14' AS Date), 7190, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7190', NULL, CAST(1470.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8204, 5022, CAST(N'2022-06-14' AS Date), 7191, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7191', NULL, CAST(400.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8205, 5022, CAST(N'2022-06-14' AS Date), 7192, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7192', CAST(5709.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8206, 5022, CAST(N'2022-06-14' AS Date), 7192, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7192', NULL, CAST(5709.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8207, 5022, CAST(N'2022-06-14' AS Date), 7193, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7193', NULL, CAST(2476.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8208, 5022, CAST(N'2022-06-14' AS Date), 7194, N'SaleInvoice', N'Sale Transaction against Invoice Number # 7194', CAST(1050.000 AS Decimal(18, 3)), NULL, NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8209, 5022, CAST(N'2022-06-14' AS Date), 7194, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7194', NULL, CAST(1050.000 AS Decimal(18, 3)), NULL)
INSERT [dbo].[CustomerLead] ([Id], [Customer_id], [Transaction_date], [Transaction_id], [Transaction_type], [Transaction_detail], [DR], [CR], [Is_Deleted]) VALUES (8210, 5022, CAST(N'2022-06-14' AS Date), 7195, N'SaleInvoice', N'Cash Sale Transaction against Invoice Number # 7195', NULL, CAST(1000.000 AS Decimal(18, 3)), NULL)
SET IDENTITY_INSERT [dbo].[CustomerLead] OFF
GO
SET IDENTITY_INSERT [dbo].[Emplyee] ON 

INSERT [dbo].[Emplyee] ([Id], [UserName], [Role], [City], [CNIC], [Adress], [Phone], [Isdeleted], [Createdon], [Password], [IsLoginAllowed], [Salary], [SalaryType], [Working Hours], [Image], [LoginName]) VALUES (2011, N'sikandar 12', 1, 4150, N'3840312', N'sargodha 12', N'030212', NULL, CAST(N'2022-03-08' AS Date), N'4420', 1, CAST(30000.120 AS Decimal(18, 3)), N'Hourly', CAST(5.120 AS Decimal(18, 3)), N'file:///G:/EZYPOS/EZYPOS/EZYPOS/bin/Debug/net5.0-windows/Assets/EmployeeImages/07042022111259pm.jpg', NULL)
INSERT [dbo].[Emplyee] ([Id], [UserName], [Role], [City], [CNIC], [Adress], [Phone], [Isdeleted], [Createdon], [Password], [IsLoginAllowed], [Salary], [SalaryType], [Working Hours], [Image], [LoginName]) VALUES (2012, N'samar', 2, 4150, N'38402', N'dharema', N'0321', NULL, CAST(N'2022-04-05' AS Date), NULL, NULL, CAST(26000.000 AS Decimal(18, 3)), N'Monthly', NULL, N'file:///G:/EZYPOS/EZYPOS/EZYPOS/bin/Debug/net5.0-windows/Assets/EmployeeImages/05042022114332pm.jpg', NULL)
INSERT [dbo].[Emplyee] ([Id], [UserName], [Role], [City], [CNIC], [Adress], [Phone], [Isdeleted], [Createdon], [Password], [IsLoginAllowed], [Salary], [SalaryType], [Working Hours], [Image], [LoginName]) VALUES (2013, N'ali', 1, 4150, N'38603', N'dharema', N'0340', NULL, CAST(N'2022-04-06' AS Date), NULL, NULL, CAST(22000.000 AS Decimal(18, 3)), N'Monthly', NULL, N'file:///C:/Users/Sikandar Abbas/Desktop/100D3300/DSC_0250.JPG', NULL)
SET IDENTITY_INSERT [dbo].[Emplyee] OFF
GO
SET IDENTITY_INSERT [dbo].[Pages] ON 

INSERT [dbo].[Pages] ([Id], [PageName], [Tag], [ClickEvent], [Isclickable], [Template], [ParentId], [Name], [Icon]) VALUES (1, N'Test 2', N'EZYPOS.UserControls.UserControlListCustomer', NULL, 0, N'VsMenuTop', 0, NULL, NULL)
INSERT [dbo].[Pages] ([Id], [PageName], [Tag], [ClickEvent], [Isclickable], [Template], [ParentId], [Name], [Icon]) VALUES (2, N'test 3', N'EZYPOS.UserControls.UserControlListCustomer', NULL, 0, N'VsMenuSub', 1, NULL, NULL)
INSERT [dbo].[Pages] ([Id], [PageName], [Tag], [ClickEvent], [Isclickable], [Template], [ParentId], [Name], [Icon]) VALUES (3, N'test 4', N'EZYPOS.UserControls.UserControlListCustomer', NULL, 1, N'VsMenuSub', 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Pages] OFF
GO
SET IDENTITY_INSERT [dbo].[POS] ON 

INSERT [dbo].[POS] ([id], [Name]) VALUES (1, N'POS1')
INSERT [dbo].[POS] ([id], [Name]) VALUES (2, N'POS2')
INSERT [dbo].[POS] ([id], [Name]) VALUES (3, N'POS3')
SET IDENTITY_INSERT [dbo].[POS] OFF
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

INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit], [TaxType], [Tax]) VALUES (2021, N'Head & Shoulder 500 ml', N'0011', 3013, 3017, NULL, 1008, 2008, CAST(500.250 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), NULL, NULL, CAST(N'2022-03-30' AS Date), CAST(500.00 AS Decimal(18, 2)), 3, N'GST', CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit], [TaxType], [Tax]) VALUES (2022, N'Lux 250g', N'002', 3013, 3018, NULL, NULL, NULL, CAST(125.300 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), NULL, NULL, CAST(N'2022-03-24' AS Date), CAST(250.00 AS Decimal(18, 2)), 2, N'GST', CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit], [TaxType], [Tax]) VALUES (2025, N'check', N'003', 3012, 3019, NULL, 1008, 2008, CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), NULL, NULL, CAST(N'2022-03-30' AS Date), CAST(1.25 AS Decimal(18, 2)), 1, N'GST', CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit], [TaxType], [Tax]) VALUES (2026, N'oil 100g', N'123459678974', 3012, 3019, NULL, 1008, 2008, CAST(250.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), NULL, NULL, CAST(N'2022-06-08' AS Date), CAST(100.00 AS Decimal(18, 2)), 2, N'HST', CAST(2.000 AS Decimal(18, 3)))
INSERT [dbo].[Products] ([Id], [ProductName], [Barcode], [CategoryId], [SubcategoryId], [Isdeleted], [GroupId], [ShelfId], [RetailPrice], [Wholesaleprice], [PurchasePrice], [Lastupdated], [Createdby], [Createdon], [Size], [Unit], [TaxType], [Tax]) VALUES (2027, N'check123', N'115566998899', 3012, 3019, NULL, 1008, 2008, CAST(12.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), NULL, NULL, CAST(N'2022-06-08' AS Date), CAST(1.00 AS Decimal(18, 2)), 1, N'GST', CAST(2.000 AS Decimal(18, 3)))
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
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70101, 2026, CAST(N'2022-05-19' AS Date), CAST(N'2022-05-19' AS Date), 1, 0, 0, 5070)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70102, 2025, CAST(N'2022-05-19' AS Date), CAST(N'2022-05-19' AS Date), 1, 0, 0, 5070)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70103, 2022, CAST(N'2022-05-19' AS Date), CAST(N'2022-05-19' AS Date), 1, 0, 0, 5070)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70104, 2021, CAST(N'2022-05-19' AS Date), CAST(N'2022-05-19' AS Date), 1, 0, 0, 5070)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70105, 2021, CAST(N'2022-05-20' AS Date), CAST(N'2022-05-20' AS Date), 4, 0, 0, 5071)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70106, 2022, CAST(N'2022-06-09' AS Date), CAST(N'2022-06-09' AS Date), 6, 0, 0, 5072)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70107, 2027, CAST(N'2022-06-10' AS Date), CAST(N'2022-06-10' AS Date), 12, 0, 0, 5073)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70108, 2026, CAST(N'2022-06-10' AS Date), CAST(N'2022-06-10' AS Date), 12, 0, 0, 5073)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70109, 2025, CAST(N'2022-06-10' AS Date), CAST(N'2022-06-10' AS Date), 12, 0, 0, 5073)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70110, 2022, CAST(N'2022-06-10' AS Date), CAST(N'2022-06-10' AS Date), 12, 0, 0, 5073)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70111, 2021, CAST(N'2022-06-10' AS Date), CAST(N'2022-06-10' AS Date), 13, 0, 0, 5073)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70112, 2027, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 1, 0, 0, 5074)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70113, 2026, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 1, 0, 0, 5074)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70114, 2025, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 1, 0, 0, 5074)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70115, 2022, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 1, 0, 0, 5074)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70116, 2021, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 1, 0, 0, 5074)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70117, 2027, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 10, 0, 0, 5075)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70118, 2026, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 10, 0, 0, 5075)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70119, 2025, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 10, 0, 0, 5075)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70120, 2022, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 10, 0, 0, 5075)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70121, 2021, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 10, 0, 0, 5075)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70122, 2021, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 20, 0, 0, 5076)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70123, 2025, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 9, 0, 0, 5077)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70124, 2022, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 7, 0, 0, 5077)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70125, 2021, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 9, 0, 0, 5077)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70126, 2027, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 4, 0, 0, 5078)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70127, 2026, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 3, 0, 0, 5078)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70128, 2025, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 5, 0, 0, 5078)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70129, 2022, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 5, 0, 0, 5078)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70130, 2021, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 6, 0, 0, 5078)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70131, 2025, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 2, 0, 0, 5079)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70132, 2022, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 15, 0, 0, 5079)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70133, 2021, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 12, 0, 0, 5079)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70134, 2027, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 2, 0, 0, 5080)
INSERT [dbo].[ProductStock] ([Id], [ProductId], [StartDate], [ExpiryDate], [Qty], [Adjustment], [Conversion], [PurchaseOrderId]) VALUES (70135, 2026, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), 7, 0, 0, 5080)
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
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7098, N'oil 100g', 2026, CAST(250.000 AS Decimal(18, 3)), NULL, 1, NULL, 5070, CAST(N'2022-05-19' AS Date), CAST(N'2022-05-19' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7099, N'check', 2025, CAST(250.000 AS Decimal(18, 3)), NULL, 1, NULL, 5070, CAST(N'2022-05-19' AS Date), CAST(N'2022-05-19' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7100, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 1, NULL, 5070, CAST(N'2022-05-19' AS Date), CAST(N'2022-05-19' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7101, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 1, NULL, 5070, CAST(N'2022-05-19' AS Date), CAST(N'2022-05-19' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7102, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 4, NULL, 5071, CAST(N'2022-05-20' AS Date), CAST(N'2022-05-20' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(1600.600 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7103, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 6, NULL, 5072, CAST(N'2022-06-09' AS Date), CAST(N'2022-06-09' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(480.600 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7104, N'check123', 2027, CAST(12.000 AS Decimal(18, 3)), NULL, 12, NULL, 5073, CAST(N'2022-06-10' AS Date), CAST(N'2022-06-10' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(144.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7105, N'oil 100g', 2026, CAST(250.000 AS Decimal(18, 3)), NULL, 12, NULL, 5073, CAST(N'2022-06-10' AS Date), CAST(N'2022-06-10' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(3000.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7106, N'check', 2025, CAST(250.000 AS Decimal(18, 3)), NULL, 12, NULL, 5073, CAST(N'2022-06-10' AS Date), CAST(N'2022-06-10' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(3000.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7107, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 12, NULL, 5073, CAST(N'2022-06-10' AS Date), CAST(N'2022-06-10' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(961.200 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7108, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 13, NULL, 5073, CAST(N'2022-06-10' AS Date), CAST(N'2022-06-10' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(5201.950 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7109, N'check123', 2027, CAST(12.000 AS Decimal(18, 3)), NULL, 1, NULL, 5074, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7110, N'oil 100g', 2026, CAST(250.000 AS Decimal(18, 3)), NULL, 1, NULL, 5074, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7111, N'check', 2025, CAST(250.000 AS Decimal(18, 3)), NULL, 1, NULL, 5074, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7112, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 1, NULL, 5074, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7113, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 1, NULL, 5074, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7114, N'check123', 2027, CAST(12.000 AS Decimal(18, 3)), NULL, 10, NULL, 5075, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(120.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7115, N'oil 100g', 2026, CAST(250.000 AS Decimal(18, 3)), NULL, 10, NULL, 5075, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(2500.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7116, N'check', 2025, CAST(250.000 AS Decimal(18, 3)), NULL, 10, NULL, 5075, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(2500.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7117, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 10, NULL, 5075, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(801.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7118, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 10, NULL, 5075, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(4001.500 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7119, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 20, NULL, 5076, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(8003.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7120, N'check', 2025, CAST(250.000 AS Decimal(18, 3)), NULL, 9, NULL, 5077, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(2250.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7121, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 7, NULL, 5077, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(560.700 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7122, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 9, NULL, 5077, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(3601.350 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7123, N'check123', 2027, CAST(12.000 AS Decimal(18, 3)), NULL, 4, NULL, 5078, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(48.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7124, N'oil 100g', 2026, CAST(250.000 AS Decimal(18, 3)), NULL, 3, NULL, 5078, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(750.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7125, N'check', 2025, CAST(250.000 AS Decimal(18, 3)), NULL, 5, NULL, 5078, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(1250.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7126, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 5, NULL, 5078, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(400.500 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7127, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 6, NULL, 5078, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(2400.900 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7128, N'check', 2025, CAST(250.000 AS Decimal(18, 3)), NULL, 2, NULL, 5079, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(500.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7129, N'Lux 250g', 2022, CAST(80.100 AS Decimal(18, 3)), NULL, 15, NULL, 5079, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(1201.500 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7130, N'Head & Shoulder 500 ml', 2021, CAST(400.150 AS Decimal(18, 3)), NULL, 12, NULL, 5079, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(4801.800 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7131, N'check123', 2027, CAST(12.000 AS Decimal(18, 3)), NULL, 2, NULL, 5080, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(24.000 AS Decimal(18, 3)))
INSERT [dbo].[Purchase_OrderDetail] ([Id], [itemName], [ProductId], [PurchasePrice], [SalePrice], [Qty], [StockId], [PurchaseOrderId], [ExpiryDate], [StartDate], [itemDiscount], [Total]) VALUES (7132, N'oil 100g', 2026, CAST(250.000 AS Decimal(18, 3)), NULL, 7, NULL, 5080, CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), CAST(0.000 AS Decimal(18, 3)), CAST(1750.000 AS Decimal(18, 3)))
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
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5070, 3006, 2011, NULL, CAST(N'2022-05-19' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(980.250 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5071, 3006, 2011, NULL, CAST(N'2022-05-20' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(1600.600 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5072, 3006, 2011, NULL, CAST(N'2022-06-09' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(480.600 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5073, 3006, 2011, NULL, CAST(N'2022-06-10' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(12307.150 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5074, 3006, 2011, NULL, CAST(N'2022-06-14' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(992.250 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5075, 3006, 2011, NULL, CAST(N'2022-06-14' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(9922.500 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5076, 3006, 2011, NULL, CAST(N'2022-06-14' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(8003.000 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5077, 3006, 2011, NULL, CAST(N'2022-06-14' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(6412.050 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5078, 3006, 2011, NULL, CAST(N'2022-06-14' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(4849.400 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5079, 3006, 2011, NULL, CAST(N'2022-06-14' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(6503.300 AS Decimal(18, 3)))
INSERT [dbo].[PurchaseOrder] ([Id], [SupplierId], [EmployeeId], [UserId], [Date], [PaymentStatus], [PaymentMode], [Discount], [DeliveryCharges], [TotalAmount]) VALUES (5080, 3006, 2011, NULL, CAST(N'2022-06-14' AS Date), N'Paid', N'CASH', CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(1774.000 AS Decimal(18, 3)))
SET IDENTITY_INSERT [dbo].[PurchaseOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale_OrderDetail] ON 

INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7123, 7124, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7124, 7125, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(3.300 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7125, 7125, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(2.200 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7126, 7125, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(1.100 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7127, 7126, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7128, 7127, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7129, 7128, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7130, 7129, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7131, 7129, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7132, 7130, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7133, 7130, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7134, 7131, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7135, 7133, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.690 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7136, 7134, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7137, 7135, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7139, 7137, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7140, 7139, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(100.250 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7142, 7141, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(30.123 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7143, 7142, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(10.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7144, 7142, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(15.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(0.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7147, 7146, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 1, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7148, 7147, 2026, N'oil 100g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'HST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7149, 7147, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7150, 7147, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7155, 7150, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7156, 7150, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7157, 7151, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, NULL)
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7158, 7152, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7159, 7161, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 1, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7160, 7162, 2027, N'check123', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7161, 7162, 2026, N'oil 100g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'HST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7162, 7162, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7163, 7162, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7164, 7162, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7165, 7163, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7166, 7163, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7167, 7163, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7168, 7164, 2027, N'check123', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7169, 7164, 2026, N'oil 100g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'HST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7170, 7164, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7171, 7164, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7172, 7164, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7173, 7165, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7174, 7165, 2026, N'oil 100g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'HST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7175, 7166, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7176, 7166, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7177, 7167, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7178, 7167, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 3, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7179, 7168, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 3, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7180, 7168, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7181, 7169, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7182, 7169, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7183, 7170, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7184, 7171, 2027, N'check123', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7185, 7172, 2027, N'check123', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7186, 7173, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7187, 7174, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7188, 7174, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7189, 7175, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7190, 7176, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7191, 7176, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 4, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7192, 7177, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7193, 7177, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7194, 7178, 2026, N'oil 100g', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'HST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7195, 7178, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7196, 7178, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7197, 7179, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7198, 7179, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7199, 7179, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7201, 7181, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7202, 7181, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7203, 7181, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7204, 7182, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7205, 7182, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7206, 7182, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7207, 7184, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7208, 7184, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7209, 7184, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7210, 7186, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7211, 7186, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7212, 7186, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7213, 7187, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7214, 7188, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 1, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7215, 7188, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 1, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7216, 7189, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7217, 7190, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7218, 7190, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7219, 7191, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7220, 7192, 2027, N'check123', NULL, NULL, NULL, NULL, 0, 1, NULL, 5, CAST(0.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7221, 7192, 2026, N'oil 100g', NULL, NULL, NULL, NULL, 0, 1, NULL, 5, CAST(0.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'HST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7222, 7192, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 5, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7223, 7192, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 5, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7224, 7192, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 5, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7225, 7193, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 3, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7226, 7193, 2022, N'Lux 250g', NULL, NULL, NULL, NULL, 0, 1, NULL, 3, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(80.100 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7227, 7193, 2025, N'check', NULL, NULL, NULL, NULL, 0, 1, NULL, 3, CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(250.000 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7228, 7194, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
INSERT [dbo].[Sale_OrderDetail] ([id], [order_id], [item_id], [item_name], [fixed_item_des], [sub_cat_id], [sub_cat_name], [cat_name], [print_sort], [kitchen_lines], [item_comments], [item_qty], [itemDiscount], [item_price], [PurchasePrice], [TaxType], [ItemTax], [item_index], [bill_no], [is_updated], [is_deleted], [POSId]) VALUES (7229, 7195, 2021, N'Head & Shoulder 500 ml', NULL, NULL, NULL, NULL, 0, 1, NULL, 2, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(400.150 AS Decimal(18, 3)), N'GST', CAST(2.000 AS Decimal(18, 3)), 1, NULL, N'', 0, N'POS1')
SET IDENTITY_INSERT [dbo].[Sale_OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Sale_Orders] ON 

INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7124, 1, 1, NULL, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-03-26' AS Date), CAST(N'2022-03-26' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(10.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(510.250 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(20.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7125, 1, 1, NULL, 1, CAST(818.950 AS Decimal(18, 3)), CAST(N'2022-04-07' AS Date), CAST(N'2022-04-07' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(818.950 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7126, 1, 1, NULL, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7127, 1, 1, NULL, 1, CAST(125.300 AS Decimal(18, 3)), CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7128, 1, 1, NULL, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-04-16' AS Date), CAST(N'2022-04-16' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7129, 1, 1, NULL, 1, CAST(625.550 AS Decimal(18, 3)), CAST(N'2022-04-17' AS Date), CAST(N'2022-04-17' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(625.550 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7130, 1, 1, NULL, 1, CAST(625.550 AS Decimal(18, 3)), CAST(N'2022-04-17' AS Date), CAST(N'2022-04-17' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(625.550 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7131, 1, 1, NULL, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-04-17' AS Date), CAST(N'2022-04-17' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(500.250 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7132, 1, 1, NULL, 1, CAST(0.000 AS Decimal(18, 3)), CAST(N'2022-04-25' AS Date), CAST(N'2022-04-25' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(-25.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7133, 1, 1, NULL, 1, CAST(125.690 AS Decimal(18, 3)), CAST(N'2022-03-26' AS Date), CAST(N'2022-03-26' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(125.690 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7134, 1, 1, NULL, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-05-01' AS Date), CAST(N'2022-05-01' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, CAST(1.250 AS Decimal(18, 3)), CAST(6.878 AS Decimal(18, 3)), CAST(557.128 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(50.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7135, 1, 1, NULL, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-05-01' AS Date), CAST(N'2022-05-01' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, CAST(1.250 AS Decimal(18, 3)), CAST(6.253 AS Decimal(18, 3)), CAST(506.503 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7137, 1, 1, NULL, 1, CAST(400.000 AS Decimal(18, 3)), CAST(N'2022-05-15' AS Date), CAST(N'2022-05-15' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, CAST(1.250 AS Decimal(18, 3)), CAST(5.000 AS Decimal(18, 3)), CAST(405.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7139, 1, 1, NULL, 1, CAST(400.000 AS Decimal(18, 3)), CAST(N'2022-05-20' AS Date), CAST(N'2022-05-20' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, CAST(5.000 AS Decimal(18, 3)), CAST(20.000 AS Decimal(18, 3)), CAST(420.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7141, 1, 1, NULL, 1, CAST(470.127 AS Decimal(18, 3)), CAST(N'2022-06-08' AS Date), CAST(N'2022-06-08' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(470.127 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7142, 1, 1, NULL, 1, CAST(600.550 AS Decimal(18, 3)), CAST(N'2022-06-09' AS Date), CAST(N'2022-06-09' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(20.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, CAST(5.000 AS Decimal(18, 3)), CAST(29.028 AS Decimal(18, 3)), CAST(609.578 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7146, 1, 1, NULL, 1, CAST(125.300 AS Decimal(18, 3)), CAST(N'2022-06-09' AS Date), CAST(N'2022-06-09' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 1, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'Canceled', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7147, 1, 1, NULL, 1, CAST(575.300 AS Decimal(18, 3)), CAST(N'2022-06-09' AS Date), CAST(N'2022-06-09' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, CAST(0.000 AS Decimal(18, 3)), CAST(6.000 AS Decimal(18, 3)), CAST(581.300 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7150, 1, 1, NULL, 1, CAST(525.300 AS Decimal(18, 3)), CAST(N'2022-06-09' AS Date), CAST(N'2022-06-09' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, CAST(5.000 AS Decimal(18, 3)), CAST(26.265 AS Decimal(18, 3)), CAST(551.565 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7151, 1, 1, NULL, 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-06-10' AS Date), CAST(N'2022-06-10' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, CAST(5.000 AS Decimal(18, 3)), CAST(25.013 AS Decimal(18, 3)), CAST(525.263 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7152, 1, 1, N'POS1', 1, CAST(125.300 AS Decimal(18, 3)), CAST(N'2022-06-11' AS Date), CAST(N'2022-06-11' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, 0, 0, CAST(5.000 AS Decimal(18, 3)), CAST(6.265 AS Decimal(18, 3)), CAST(131.565 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), 0, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7161, 1, 1, N'POS1', 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, 1, CAST(5.000 AS Decimal(18, 3)), CAST(25.013 AS Decimal(18, 3)), CAST(525.263 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'Deleted', NULL)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7162, 1, 1, N'POS1', 1, CAST(1099.550 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(54.978 AS Decimal(18, 3)), CAST(1154.528 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7163, 1, 1, N'POS1', 1, CAST(825.550 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(41.278 AS Decimal(18, 3)), CAST(866.828 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7164, 1, 1, N'POS1', 1, CAST(1587.800 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(79.390 AS Decimal(18, 3)), CAST(1667.190 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7165, 1, 1, N'POS1', 1, CAST(375.300 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(375.300 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'Refunded', 7164)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7166, 1, 1, N'POS1', 1, CAST(325.300 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(325.300 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'Refunded', 7164)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7167, 1, 1, N'POS1', 1, CAST(1626.050 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(81.303 AS Decimal(18, 3)), CAST(1707.353 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7168, 1, 1, N'POS1', 1, CAST(876.150 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(43.808 AS Decimal(18, 3)), CAST(919.958 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7169, 1, 1, N'POS1', 1, CAST(625.550 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(31.278 AS Decimal(18, 3)), CAST(656.828 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7170, 1, 1, N'POS1', 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(25.013 AS Decimal(18, 3)), CAST(525.263 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7171, 1, 1, N'POS1', 1, CAST(12.000 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7172, 1, 1, N'POS1', 1, CAST(12.000 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(12.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7173, 1, 1, N'POS1', 1, CAST(1000.500 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(50.025 AS Decimal(18, 3)), CAST(1050.525 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7174, 1, 1, N'POS1', 1, CAST(1251.100 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(62.555 AS Decimal(18, 3)), CAST(1313.655 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7175, 1, 1, N'POS1', 1, CAST(500.250 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(25.013 AS Decimal(18, 3)), CAST(525.263 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7176, 1, 1, N'POS1', 1, CAST(2126.300 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(106.315 AS Decimal(18, 3)), CAST(2232.615 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7177, 1, 1, N'POS1', 1, CAST(625.550 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(31.278 AS Decimal(18, 3)), CAST(656.828 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7178, 1, 1, N'POS1', 1, CAST(1900.500 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(95.025 AS Decimal(18, 3)), CAST(1995.525 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7179, 1, 1, N'POS1', 1, CAST(825.550 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(41.278 AS Decimal(18, 3)), CAST(866.828 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7181, 1, 1, N'POS1', 1, CAST(825.550 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(41.278 AS Decimal(18, 3)), CAST(866.828 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7182, 1, 1, N'POS1', 1, CAST(825.550 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(41.278 AS Decimal(18, 3)), CAST(866.828 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7183, 1, 1, N'POS1', 1, CAST(0.000 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'Refunded', 7182)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7184, 1, 1, N'POS1', 1, CAST(825.550 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(41.278 AS Decimal(18, 3)), CAST(866.828 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7185, 1, 1, N'POS1', 1, CAST(0.000 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'Refunded', 7184)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7186, 1, 1, N'POS1', 1, CAST(825.550 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(41.278 AS Decimal(18, 3)), CAST(866.828 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7187, 1, 1, N'POS1', 1, CAST(200.000 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(200.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'Refunded', 7186)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7188, 1, 1, N'POS1', 1, CAST(625.550 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, 1, CAST(5.000 AS Decimal(18, 3)), CAST(31.278 AS Decimal(18, 3)), CAST(656.828 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'Edited', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7189, 1, 1, N'POS1', 1, CAST(125.300 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(125.300 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'Edited', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7190, 1, 1, N'POS1', 1, CAST(1400.500 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(70.025 AS Decimal(18, 3)), CAST(1470.525 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7191, 1, 1, N'POS1', 1, CAST(400.000 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(400.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'Refunded', 7190)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7192, 1, 1, N'POS1', 1, CAST(5437.750 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(271.888 AS Decimal(18, 3)), CAST(5709.638 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7193, 1, 1, N'POS1', 1, CAST(2476.650 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(2476.650 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'Refunded', 7192)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7194, 1, 1, N'POS1', 1, CAST(1000.500 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(5.000 AS Decimal(18, 3)), CAST(50.025 AS Decimal(18, 3)), CAST(1050.525 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'New', 0)
INSERT [dbo].[Sale_Orders] ([id], [restaurant_id], [user_id], [POSId], [order_count], [total], [date], [order_date], [description], [coupon], [coupon_value], [coupon_type], [coupon_applies_to], [coupon_categories], [discount_amount], [discount_desc], [payment_mode], [payment_status], [addby], [addon], [EmployeeId], [customer_id], [customer_phone], [is_updated], [is_deleted], [TaxPercentage], [Tax], [Cash_Amount], [Online_Amount], [Is_Printed], [Service_Charge], [DeliveryCharges], [OrderStatus], [ParentOrderId]) VALUES (7195, 1, 1, N'POS1', 1, CAST(1000.500 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date), CAST(N'2022-06-14' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), NULL, N'CASH', N'Paid', N'Admin', N'', 2011, 5022, NULL, NULL, NULL, CAST(0.000 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), CAST(1000.500 AS Decimal(18, 3)), CAST(0.000 AS Decimal(18, 3)), NULL, NULL, CAST(0.000 AS Decimal(18, 3)), N'Refunded', 7194)
SET IDENTITY_INSERT [dbo].[Sale_Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 

INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (1, N'PrintInvoice', N'False')
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
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2010, N'TaxPercentage', N'5')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2011, N'MinimumTaxLimit', N'125')
INSERT [dbo].[Setting] ([id], [AppKey], [AppValue]) VALUES (2012, N'ItemBaseTax', N'False')
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
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70147, 70088, 7139, 2, 2025, 7137)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70148, 70104, 7140, 1, 2021, 7139)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70150, 70105, 7142, 1, 2021, 7141)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70151, 70089, 7143, 1, 2022, 7142)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70152, 70105, 7143, 1, 2021, 7142)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70153, 70092, 7144, 1, 2022, 7142)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70154, 70105, 7144, 1, 2021, 7142)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70158, 70101, 7148, 1, 2026, 7147)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70159, 70088, 7148, 1, 2025, 7147)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70160, 70103, 7148, 1, 2022, 7147)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70161, 70088, 7149, 1, 2025, 7147)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70162, 70106, 7149, 1, 2022, 7147)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70163, 70088, 7150, 1, 2025, 7147)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70164, 70106, 7150, 1, 2022, 7147)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70173, 70088, 7155, 1, 2025, 7150)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70174, 70091, 7155, 1, 2025, 7150)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70175, 70106, 7155, 1, 2022, 7150)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70176, 70097, 7156, 1, 2025, 7150)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70177, 70102, 7156, 1, 2025, 7150)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70178, 70106, 7156, 1, 2022, 7150)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70179, 70105, 7157, 1, 2021, 7151)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70180, 70106, 7158, 1, 2022, 7152)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70183, 70107, 7160, 2, 2027, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70184, 70108, 7160, 1, 2026, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70185, 70109, 7160, 1, 2025, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70186, 70106, 7160, 1, 2022, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70187, 70111, 7160, 1, 2021, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70188, 70107, 7161, 2, 2027, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70189, 70108, 7161, 1, 2026, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70190, 70109, 7161, 1, 2025, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70191, 70110, 7161, 1, 2022, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70192, 70111, 7161, 1, 2021, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70193, 70107, 7162, 2, 2027, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70194, 70108, 7162, 1, 2026, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70195, 70109, 7162, 1, 2025, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70196, 70110, 7162, 1, 2022, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70197, 70111, 7162, 1, 2021, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70198, 70107, 7163, 2, 2027, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70199, 70108, 7163, 1, 2026, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70200, 70109, 7163, 1, 2025, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70201, 70110, 7163, 1, 2022, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70202, 70111, 7163, 1, 2021, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70203, 70107, 7164, 2, 2027, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70204, 70108, 7164, 1, 2026, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70205, 70109, 7164, 1, 2025, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70206, 70110, 7164, 1, 2022, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70207, 70111, 7164, 1, 2021, 7162)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70208, 70109, 7165, 1, 2025, 7163)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70209, 70110, 7165, 1, 2022, 7163)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70210, 70111, 7165, 1, 2021, 7163)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70211, 70109, 7166, 1, 2025, 7163)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70212, 70110, 7166, 1, 2022, 7163)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70213, 70111, 7166, 1, 2021, 7163)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70214, 70109, 7167, 1, 2025, 7163)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70215, 70110, 7167, 1, 2022, 7163)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70216, 70111, 7167, 1, 2021, 7163)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70217, 70107, 7168, 1, 2027, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70218, 70108, 7168, 1, 2026, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70219, 70109, 7168, 1, 2025, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70220, 70110, 7168, 1, 2022, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70221, 70111, 7168, 2, 2021, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70222, 70107, 7169, 1, 2027, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70223, 70108, 7169, 1, 2026, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70224, 70109, 7169, 1, 2025, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70225, 70110, 7169, 1, 2022, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70226, 70111, 7169, 2, 2021, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70227, 70108, 7170, 1, 2026, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70228, 70109, 7170, 1, 2025, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70229, 70110, 7170, 1, 2022, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70230, 70111, 7170, 1, 2021, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70231, 70108, 7171, 1, 2026, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70232, 70109, 7171, 1, 2025, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70233, 70110, 7171, 1, 2022, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70234, 70108, 7172, 1, 2026, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70235, 70110, 7172, 1, 2022, 7164)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70236, 70108, 7173, 1, 2026, 7165)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70237, 70108, 7174, 1, 2026, 7165)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70238, 70094, 7177, 1, 2022, 7167)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70239, 70116, 7177, 1, 2021, 7167)
GO
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70240, 70121, 7177, 2, 2021, 7167)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70241, 70115, 7178, 1, 2022, 7167)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70242, 70121, 7178, 3, 2021, 7167)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70243, 70120, 7179, 3, 2022, 7168)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70244, 70121, 7179, 1, 2021, 7168)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70245, 70120, 7180, 3, 2022, 7168)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70246, 70121, 7180, 1, 2021, 7168)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70247, 70120, 7181, 1, 2022, 7169)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70248, 70121, 7181, 1, 2021, 7169)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70249, 70120, 7182, 1, 2022, 7169)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70250, 70121, 7182, 1, 2021, 7169)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70251, 70121, 7183, 1, 2021, 7170)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70252, 70112, 7184, 1, 2027, 7171)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70253, 70117, 7185, 1, 2027, 7172)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70254, 70122, 7186, 2, 2021, 7173)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70255, 70120, 7187, 2, 2022, 7174)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70256, 70122, 7187, 2, 2021, 7174)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70257, 70124, 7188, 2, 2022, 7174)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70258, 70122, 7188, 2, 2021, 7174)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70259, 70122, 7189, 1, 2021, 7175)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70260, 70124, 7190, 1, 2022, 7176)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70261, 70122, 7190, 4, 2021, 7176)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70262, 70124, 7191, 1, 2022, 7176)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70263, 70122, 7191, 4, 2021, 7176)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70264, 70124, 7192, 1, 2022, 7177)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70265, 70122, 7192, 1, 2021, 7177)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70266, 70124, 7193, 1, 2022, 7177)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70267, 70122, 7193, 1, 2021, 7177)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70268, 70113, 7194, 1, 2026, 7178)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70269, 70118, 7194, 1, 2026, 7178)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70270, 70114, 7194, 1, 2025, 7178)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70271, 70119, 7194, 1, 2025, 7178)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70272, 70122, 7194, 2, 2021, 7178)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70273, 70118, 7195, 2, 2026, 7178)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70274, 70119, 7195, 2, 2025, 7178)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70275, 70122, 7195, 1, 2021, 7178)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70276, 70125, 7195, 1, 2021, 7178)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70277, 70118, 7196, 2, 2026, 7178)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70278, 70119, 7196, 2, 2025, 7178)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70279, 70125, 7196, 2, 2021, 7178)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70280, 70119, 7197, 1, 2025, 7179)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70281, 70124, 7197, 1, 2022, 7179)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70282, 70125, 7197, 1, 2021, 7179)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70283, 70119, 7198, 1, 2025, 7179)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70284, 70125, 7198, 1, 2021, 7179)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70285, 70119, 7199, 1, 2025, 7179)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70286, 70125, 7199, 1, 2021, 7179)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70287, 70119, 7201, 1, 2025, 7181)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70288, 70129, 7202, 1, 2022, 7181)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70289, 70125, 7203, 1, 2021, 7181)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70290, 70119, 7204, 1, 2025, 7182)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70291, 70129, 7205, 1, 2022, 7182)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70292, 70125, 7206, 1, 2021, 7182)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70293, 70123, 7207, 1, 2025, 7184)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70294, 70129, 7208, 1, 2022, 7184)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70295, 70125, 7209, 1, 2021, 7184)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70296, 70123, 7210, 0, 2025, 7186)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70297, 70129, 7211, 1, 2022, 7186)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70298, 70130, 7212, 1, 2021, 7186)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70301, 70129, 7216, 1, 2022, 7189)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70302, 70123, 7217, 0, 2025, 7190)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70303, 70130, 7218, 2, 2021, 7190)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70304, 70117, 7220, 5, 2027, 7192)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70305, 70118, 7221, 5, 2026, 7192)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70306, 70123, 7222, 2, 2025, 7192)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70307, 70132, 7223, 2, 2022, 7192)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70308, 70130, 7224, 0, 2021, 7192)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70309, 70133, 7224, 2, 2021, 7192)
INSERT [dbo].[Stock_OderDetail] ([Id], [StockId], [OrderDetail_Id], [Qty], [ProductId], [OrderId]) VALUES (70310, 70130, 7228, 0, 2021, 7194)
SET IDENTITY_INSERT [dbo].[Stock_OderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[StockLead] ON 

INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9092, 5059, CAST(N'2022-03-24' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5059', 2021, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9093, 5060, CAST(N'2022-03-26' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5060', 2022, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9094, 7123, CAST(N'2022-03-26' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7123', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9095, 7124, CAST(N'2022-03-26' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7124', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9096, 5061, CAST(N'2022-04-07' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5061', 2025, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9097, 5061, CAST(N'2022-04-07' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5061', 2022, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9098, 5061, CAST(N'2022-04-07' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5061', 2021, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9099, 7125, CAST(N'2022-04-07' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7125', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9100, 7125, CAST(N'2022-04-07' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7125', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9101, 7125, CAST(N'2022-04-07' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7125', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9102, 5062, CAST(N'2022-04-09' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5062', 2025, CAST(6.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9103, 5062, CAST(N'2022-04-09' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5062', 2022, CAST(6.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9104, 5062, CAST(N'2022-04-09' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5062', 2021, CAST(6.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9105, 5063, CAST(N'2022-04-15' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5063', 2025, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9106, 5063, CAST(N'2022-04-15' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5063', 2022, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9107, 5063, CAST(N'2022-04-15' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5063', 2021, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9108, 7126, CAST(N'2022-04-16' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7126', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9109, 7127, CAST(N'2022-04-16' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7127', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9110, 5064, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5064', 2022, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9111, 5064, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5064', 2021, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9112, 7128, CAST(N'2022-04-16' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7128', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9113, 5065, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5065', 2021, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9114, 5066, CAST(N'2022-04-16' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5066', 2025, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9115, 7129, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7129', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9116, 7129, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7129', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9117, 7130, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7130', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9118, 7130, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7130', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9119, 7131, CAST(N'2022-04-17' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7131', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9120, 7133, CAST(N'2022-04-26' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7133', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9121, 7134, CAST(N'2022-05-01' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7134', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9122, 7135, CAST(N'2022-05-01' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7135', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9124, 7137, CAST(N'2022-05-15' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7137', 2025, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9125, 5070, CAST(N'2022-05-19' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5070', 2026, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9126, 5070, CAST(N'2022-05-19' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5070', 2025, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9127, 5070, CAST(N'2022-05-19' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5070', 2022, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9128, 5070, CAST(N'2022-05-19' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5070', 2021, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9129, 5071, CAST(N'2022-05-20' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5071', 2021, CAST(4.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9130, 7139, CAST(N'2022-05-20' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7139', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9131, 7140, CAST(N'2022-06-08' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7140', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9132, 7141, CAST(N'2022-06-08' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7141', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9133, 7142, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7142', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9134, 7142, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7142', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9135, 7143, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7143', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9136, 7144, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7144', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9137, 5072, CAST(N'2022-06-09' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5072', 2022, CAST(6.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9138, 7146, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7146', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9139, 7147, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7147', 2026, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9140, 7147, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7147', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9141, 7147, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7147', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9142, 7148, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7148', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9143, 7148, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7148', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9144, 7149, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7149', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9145, 7149, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7149', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9146, 7150, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7150', 2025, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9147, 7150, CAST(N'2022-06-09' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7150', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9148, 5073, CAST(N'2022-06-10' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5073', 2027, CAST(12.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9149, 5073, CAST(N'2022-06-10' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5073', 2026, CAST(12.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9150, 5073, CAST(N'2022-06-10' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5073', 2025, CAST(12.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9151, 5073, CAST(N'2022-06-10' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5073', 2022, CAST(12.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9152, 5073, CAST(N'2022-06-10' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5073', 2021, CAST(13.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9153, 7151, CAST(N'2022-06-10' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7151', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9154, 7152, CAST(N'2022-06-11' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7152', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9155, 7160, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7160', 2021, NULL, CAST(3.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9156, 7161, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7161', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9157, 7162, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7162', 2027, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9158, 7162, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7162', 2026, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9159, 7162, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7162', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9160, 7162, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7162', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9161, 7162, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7162', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9162, 7163, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7163', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9163, 7163, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7163', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9164, 7163, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7163', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9165, 7164, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7164', 2027, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9166, 7164, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7164', 2026, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9167, 7164, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7164', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9168, 7164, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7164', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9169, 7164, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7164', 2021, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9170, 7165, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Return Transaction against Invoice Number # 7165', 2022, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9171, 7165, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Return Transaction against Invoice Number # 7165', 2026, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9172, 7166, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Return Transaction against Invoice Number # 7166', 2022, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9173, 7166, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Return Transaction against Invoice Number # 7166', 2025, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9174, 5074, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5074', 2027, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9175, 5074, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5074', 2026, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9176, 5074, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5074', 2025, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9177, 5074, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5074', 2022, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9178, 5074, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5074', 2021, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9179, 5075, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5075', 2027, CAST(10.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9180, 5075, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5075', 2026, CAST(10.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9181, 5075, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5075', 2025, CAST(10.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9182, 5075, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5075', 2022, CAST(10.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9183, 5075, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5075', 2021, CAST(10.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9184, 7167, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7167', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9185, 7167, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7167', 2021, NULL, CAST(3.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9186, 7168, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7168', 2022, NULL, CAST(3.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9187, 7168, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7168', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9188, 7169, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7169', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9189, 7169, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7169', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9190, 7170, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7170', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9191, 7171, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7171', 2027, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9192, 7172, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7172', 2027, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9193, 5076, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5076', 2021, CAST(20.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9194, 7173, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7173', 2021, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9195, 5077, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5077', 2025, CAST(9.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9196, 5077, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5077', 2022, CAST(7.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9197, 5077, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5077', 2021, CAST(9.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9198, 7174, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7174', 2022, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9199, 7174, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7174', 2021, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9200, 7175, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7175', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9201, 7176, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7176', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9202, 7176, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7176', 2021, NULL, CAST(4.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9203, 7177, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7177', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9204, 7177, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7177', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9205, 7178, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7178', 2026, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9206, 7178, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7178', 2025, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9207, 7178, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7178', 2021, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9208, 7179, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7179', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9209, 7179, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7179', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9210, 7179, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7179', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9211, 5078, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5078', 2027, CAST(4.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9212, 5078, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5078', 2026, CAST(3.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9213, 5078, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5078', 2025, CAST(5.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9214, 5078, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5078', 2022, CAST(5.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9215, 5078, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5078', 2021, CAST(6.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9216, 7181, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7181', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9217, 7181, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7181', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9218, 7181, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7181', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9219, 7182, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7182', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9220, 7182, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7182', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9221, 7182, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7182', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9222, 7184, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7184', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9223, 7184, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7184', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9224, 7184, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7184', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9225, 7186, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7186', 2025, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9226, 7186, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7186', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9227, 7186, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7186', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9228, 7187, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Return Transaction against Invoice Number # 7187', 2025, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9229, 7188, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7188', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9230, 7188, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7188', 2021, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9231, 7189, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7189', 2022, NULL, CAST(1.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9232, 7190, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7190', 2025, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9233, 7190, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7190', 2021, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9234, 7191, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Return Transaction against Invoice Number # 7191', 2025, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9235, 5079, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5079', 2025, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9236, 5079, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5079', 2022, CAST(15.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9237, 5079, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5079', 2021, CAST(12.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9238, 5080, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5080', 2027, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9239, 5080, CAST(N'2022-06-14' AS Date), N'PurchaseInvoice', N'Purchase Transaction against Invoice Number # 5080', 2026, CAST(7.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9240, 7192, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7192', 2027, NULL, CAST(5.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9241, 7192, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7192', 2026, NULL, CAST(5.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9242, 7192, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7192', 2025, NULL, CAST(5.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9243, 7192, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7192', 2022, NULL, CAST(5.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9244, 7192, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7192', 2021, NULL, CAST(5.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9245, 7193, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Return Transaction against Invoice Number # 7193', 2021, CAST(3.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9246, 7193, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Return Transaction against Invoice Number # 7193', 2022, CAST(3.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9247, 7193, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Return Transaction against Invoice Number # 7193', 2025, CAST(3.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9248, 7194, CAST(N'2022-06-14' AS Date), N'SaleInvoice', N'Sale Transaction against Invoice Number # 7194', 2021, NULL, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
INSERT [dbo].[StockLead] ([Id], [Transaction_id], [Transaction_date], [Transaction_type], [Transaction_detail], [Product_id], [DR_qty], [CR_qty], [User_id], [POS_id], [PaymentMode], [Is_Deleted]) VALUES (9249, 7195, CAST(N'2022-06-14' AS Date), N'ReturnInvoice', N'Return Transaction against Invoice Number # 7195', 2021, CAST(2.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL)
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
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6066, 3006, 5070, N'PurchaseInvoice', N'CASH Purchase Order No: 5070
oil 100g:  1 * 250.000 = 250.000
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 980.250
', CAST(980.250 AS Decimal(18, 3)), NULL, CAST(N'2022-05-19' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6067, 3006, 5070, N'PurchaseInvoice', N'Cash Purchase Order No: 5070
oil 100g:  1 * 250.000 = 250.000
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 980.250
', NULL, CAST(980.250 AS Decimal(18, 3)), CAST(N'2022-05-19' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6068, 3006, 5071, N'PurchaseInvoice', N'CASH Purchase Order No: 5071
Head & Shoulder 500 ml:  4 * 400.150 = 1600.600
Total Amount: 1600.600
', CAST(1600.600 AS Decimal(18, 3)), NULL, CAST(N'2022-05-20' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6069, 3006, 5071, N'PurchaseInvoice', N'Cash Purchase Order No: 5071
Head & Shoulder 500 ml:  4 * 400.150 = 1600.600
Total Amount: 1600.600
', NULL, CAST(1600.600 AS Decimal(18, 3)), CAST(N'2022-05-20' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6070, 3006, 5072, N'PurchaseInvoice', N'CASH Purchase Order No: 5072
Lux 250g:  6 * 80.100 = 480.600
Total Amount: 480.600
', CAST(480.600 AS Decimal(18, 3)), NULL, CAST(N'2022-06-09' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6071, 3006, 5072, N'PurchaseInvoice', N'Cash Purchase Order No: 5072
Lux 250g:  6 * 80.100 = 480.600
Total Amount: 480.600
', NULL, CAST(480.600 AS Decimal(18, 3)), CAST(N'2022-06-09' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6072, 3006, 5073, N'PurchaseInvoice', N'CASH Purchase Order No: 5073
check123:  12 * 12.000 = 144.000
oil 100g:  12 * 250.000 = 3000.000
check:  12 * 250.000 = 3000.000
Lux 250g:  12 * 80.100 = 961.200
Head & Shoulder 500 ml:  13 * 400.150 = 5201.950
Total Amount: 12307.150
', CAST(12307.150 AS Decimal(18, 3)), NULL, CAST(N'2022-06-10' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6073, 3006, 5073, N'PurchaseInvoice', N'Cash Purchase Order No: 5073
check123:  12 * 12.000 = 144.000
oil 100g:  12 * 250.000 = 3000.000
check:  12 * 250.000 = 3000.000
Lux 250g:  12 * 80.100 = 961.200
Head & Shoulder 500 ml:  13 * 400.150 = 5201.950
Total Amount: 12307.150
', NULL, CAST(12307.150 AS Decimal(18, 3)), CAST(N'2022-06-10' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6074, 3006, 5074, N'PurchaseInvoice', N'CASH Purchase Order No: 5074
check123:  1 * 12.000 = 12.000
oil 100g:  1 * 250.000 = 250.000
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 992.250
', CAST(992.250 AS Decimal(18, 3)), NULL, CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6075, 3006, 5074, N'PurchaseInvoice', N'Cash Purchase Order No: 5074
check123:  1 * 12.000 = 12.000
oil 100g:  1 * 250.000 = 250.000
check:  1 * 250.000 = 250.000
Lux 250g:  1 * 80.100 = 80.100
Head & Shoulder 500 ml:  1 * 400.150 = 400.150
Total Amount: 992.250
', NULL, CAST(992.250 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6076, 3006, 5075, N'PurchaseInvoice', N'CASH Purchase Order No: 5075
check123:  10 * 12.000 = 120.000
oil 100g:  10 * 250.000 = 2500.000
check:  10 * 250.000 = 2500.000
Lux 250g:  10 * 80.100 = 801.000
Head & Shoulder 500 ml:  10 * 400.150 = 4001.500
Total Amount: 9922.500
', CAST(9922.500 AS Decimal(18, 3)), NULL, CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6077, 3006, 5075, N'PurchaseInvoice', N'Cash Purchase Order No: 5075
check123:  10 * 12.000 = 120.000
oil 100g:  10 * 250.000 = 2500.000
check:  10 * 250.000 = 2500.000
Lux 250g:  10 * 80.100 = 801.000
Head & Shoulder 500 ml:  10 * 400.150 = 4001.500
Total Amount: 9922.500
', NULL, CAST(9922.500 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6078, 3006, 5076, N'PurchaseInvoice', N'CASH Purchase Order No: 5076
Head & Shoulder 500 ml:  20 * 400.150 = 8003.000
Total Amount: 8003.000
', CAST(8003.000 AS Decimal(18, 3)), NULL, CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6079, 3006, 5076, N'PurchaseInvoice', N'Cash Purchase Order No: 5076
Head & Shoulder 500 ml:  20 * 400.150 = 8003.000
Total Amount: 8003.000
', NULL, CAST(8003.000 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6080, 3006, 5077, N'PurchaseInvoice', N'CASH Purchase Order No: 5077
check:  9 * 250.000 = 2250.000
Lux 250g:  7 * 80.100 = 560.700
Head & Shoulder 500 ml:  9 * 400.150 = 3601.350
Total Amount: 6412.050
', CAST(6412.050 AS Decimal(18, 3)), NULL, CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6081, 3006, 5077, N'PurchaseInvoice', N'Cash Purchase Order No: 5077
check:  9 * 250.000 = 2250.000
Lux 250g:  7 * 80.100 = 560.700
Head & Shoulder 500 ml:  9 * 400.150 = 3601.350
Total Amount: 6412.050
', NULL, CAST(6412.050 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6082, 3006, 5078, N'PurchaseInvoice', N'CASH Purchase Order No: 5078
check123:  4 * 12.000 = 48.000
oil 100g:  3 * 250.000 = 750.000
check:  5 * 250.000 = 1250.000
Lux 250g:  5 * 80.100 = 400.500
Head & Shoulder 500 ml:  6 * 400.150 = 2400.900
Total Amount: 4849.400
', CAST(4849.400 AS Decimal(18, 3)), NULL, CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6083, 3006, 5078, N'PurchaseInvoice', N'Cash Purchase Order No: 5078
check123:  4 * 12.000 = 48.000
oil 100g:  3 * 250.000 = 750.000
check:  5 * 250.000 = 1250.000
Lux 250g:  5 * 80.100 = 400.500
Head & Shoulder 500 ml:  6 * 400.150 = 2400.900
Total Amount: 4849.400
', NULL, CAST(4849.400 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6084, 3006, 5079, N'PurchaseInvoice', N'CASH Purchase Order No: 5079
check:  2 * 250.000 = 500.000
Lux 250g:  15 * 80.100 = 1201.500
Head & Shoulder 500 ml:  12 * 400.150 = 4801.800
Total Amount: 6503.300
', CAST(6503.300 AS Decimal(18, 3)), NULL, CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6085, 3006, 5079, N'PurchaseInvoice', N'Cash Purchase Order No: 5079
check:  2 * 250.000 = 500.000
Lux 250g:  15 * 80.100 = 1201.500
Head & Shoulder 500 ml:  12 * 400.150 = 4801.800
Total Amount: 6503.300
', NULL, CAST(6503.300 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6086, 3006, 5080, N'PurchaseInvoice', N'CASH Purchase Order No: 5080
check123:  2 * 12.000 = 24.000
oil 100g:  7 * 250.000 = 1750.000
Total Amount: 1774.000
', CAST(1774.000 AS Decimal(18, 3)), NULL, CAST(N'2022-06-14' AS Date))
INSERT [dbo].[SupplierLead] ([Id], [Suplier_id], [Transaction_id], [Transaction_type], [Transaction_det], [DR], [CR], [Transaction_date]) VALUES (6087, 3006, 5080, N'PurchaseInvoice', N'Cash Purchase Order No: 5080
check123:  2 * 12.000 = 24.000
oil 100g:  7 * 250.000 = 1750.000
Total Amount: 1774.000
', NULL, CAST(1774.000 AS Decimal(18, 3)), CAST(N'2022-06-14' AS Date))
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
SET IDENTITY_INSERT [dbo].[UserPages] ON 

INSERT [dbo].[UserPages] ([Id], [UserId], [PageId]) VALUES (11, 2012, 1)
INSERT [dbo].[UserPages] ([Id], [UserId], [PageId]) VALUES (12, 2012, 2)
INSERT [dbo].[UserPages] ([Id], [UserId], [PageId]) VALUES (13, 2013, 3)
INSERT [dbo].[UserPages] ([Id], [UserId], [PageId]) VALUES (14, 2011, 1)
INSERT [dbo].[UserPages] ([Id], [UserId], [PageId]) VALUES (15, 2011, 2)
INSERT [dbo].[UserPages] ([Id], [UserId], [PageId]) VALUES (16, 2011, 3)
SET IDENTITY_INSERT [dbo].[UserPages] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([Id], [Name]) VALUES (2, N'Employee')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Isdeleted]  DEFAULT ((0)) FOR [Isdeleted]
GO
ALTER TABLE [dbo].[CashBookLead] ADD  CONSTRAINT [DF_CashBookLead_Is_Deleted]  DEFAULT ((0)) FOR [Is_Deleted]
GO
ALTER TABLE [dbo].[CustomerLead] ADD  CONSTRAINT [DF_CustomerLead_Is_Deleted]  DEFAULT ((0)) FOR [Is_Deleted]
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
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  CONSTRAINT [DF__Sale_Orde__is_de__4BAC3F29]  DEFAULT ((0)) FOR [is_deleted]
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
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF_Sale_Orders_is_updated]  DEFAULT ((0)) FOR [is_updated]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF_Sale_Orders_is_deleted]  DEFAULT ((0)) FOR [is_deleted]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF_Sale_Orders_Is_Printed]  DEFAULT ((0)) FOR [Is_Printed]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  CONSTRAINT [DF__Sale_Orde__Servi__59FA5E80]  DEFAULT (NULL) FOR [Service_Charge]
GO
ALTER TABLE [dbo].[StockLead] ADD  CONSTRAINT [DF_StockLead_Is_Deleted]  DEFAULT ((0)) FOR [Is_Deleted]
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
/****** Object:  StoredProcedure [dbo].[GetStockDetail]    Script Date: 16/06/2022 3:36:39 pm ******/
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
