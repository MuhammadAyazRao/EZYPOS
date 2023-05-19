USE [master]
GO
/****** Object:  Database [EPOS-DB]    Script Date: 19/05/2023 9:37:48 pm ******/
CREATE DATABASE [EPOS-DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EPOS-DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\EPOS-DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EPOS-DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\EPOS-DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
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
/****** Object:  User [admin]    Script Date: 19/05/2023 9:37:48 pm ******/
CREATE USER [admin] FOR LOGIN [admin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [admin]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [admin]
GO
ALTER ROLE [db_datareader] ADD MEMBER [admin]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [admin]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[AdvancedSalary]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[AppPages]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[CashBookLead]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[CashSummary]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[City]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[CustomerDRNote]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[CustomerLead]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[CustomerReceipt]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[Emplyee]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[ExpenceTransaction]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[ExpenceType]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[Pages]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[POS]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[ProductGroup]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[Products]    Script Date: 19/05/2023 9:37:48 pm ******/
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
	[RewardPoints] [decimal](18, 3) NOT NULL,
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
/****** Object:  Table [dbo].[ProductStock]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[ProductSubcategory]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[Purchase_OrderDetail]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[Sale_OrderDetail]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[Sale_Orders]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[Setting]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[ShopSetting]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[Stock_OderDetail]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[StockLead]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[Supplier]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[SupplierCRNote]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[SupplierLead]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[SupplierPayment]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[TblShelf]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[Unit]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[UserPages]    Script Date: 19/05/2023 9:37:48 pm ******/
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
/****** Object:  Table [dbo].[UserRole]    Script Date: 19/05/2023 9:37:48 pm ******/
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
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Isdeleted]  DEFAULT ((0)) FOR [Isdeleted]
GO
ALTER TABLE [dbo].[CashBookLead] ADD  CONSTRAINT [DF_CashBookLead_Is_Deleted]  DEFAULT ((0)) FOR [Is_Deleted]
GO
ALTER TABLE [dbo].[CustomerLead] ADD  CONSTRAINT [DF_CustomerLead_Is_Deleted]  DEFAULT ((0)) FOR [Is_Deleted]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [RewardPoints]
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
/****** Object:  StoredProcedure [dbo].[GetStockDetail]    Script Date: 19/05/2023 9:37:48 pm ******/
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
