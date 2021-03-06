USE [EPOS-DB]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 06/02/2021 8:11:40 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppPages]    Script Date: 06/02/2021 8:11:41 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 06/02/2021 8:11:41 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 06/02/2021 8:11:41 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Emplyee]    Script Date: 06/02/2021 8:11:41 PM ******/
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
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Emplyee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenceTransaction]    Script Date: 06/02/2021 8:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpenceTransaction](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExpenceDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[Discription] [nvarchar](max) NULL,
	[Amount] [bigint] NULL,
	[Isdeleted] [bit] NULL,
	[ExpenceType] [int] NULL,
 CONSTRAINT [PK_ExpenceTransaction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpenceType]    Script Date: 06/02/2021 8:11:41 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 06/02/2021 8:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Isdeleted] [bit] NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductGroup]    Script Date: 06/02/2021 8:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductGroup](
	[id] [int] NOT NULL,
	[GroupName] [nvarchar](max) NULL,
	[Isdeleted] [bit] NULL,
 CONSTRAINT [PK_ProductGroup] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 06/02/2021 8:11:41 PM ******/
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
	[RetailPrice] [bigint] NULL,
	[Wholesaleprice] [bigint] NULL,
	[PurchasePrice] [bigint] NULL,
	[Lastupdated] [datetime] NULL,
	[Createdby] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSubcategory]    Script Date: 06/02/2021 8:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSubcategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SubcategoryName] [nvarchar](max) NULL,
	[CategoryId] [int] NULL,
	[Isdeleted] [bit] NULL,
 CONSTRAINT [PK_ProductSubcategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale_OrderDetail]    Script Date: 06/02/2021 8:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_OrderDetail](
	[id] [int] NOT NULL,
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
	[item_index] [int] NOT NULL,
	[bill_no] [int] NULL,
	[is_updated] [varchar](20) NOT NULL,
	[is_deleted] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sale_Orders]    Script Date: 06/02/2021 8:11:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_Orders](
	[id] [int] NOT NULL,
	[restaurant_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[order_count] [int] NOT NULL,
	[total] [bigint] NOT NULL,
	[date] [datetime] NOT NULL,
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
	[customer_phone] [varchar](80) NULL,
	[customer_name] [varchar](80) NULL,
	[is_updated] [varchar](20) NOT NULL,
	[is_deleted] [varchar](20) NOT NULL,
	[Cash_Amount] [bigint] NOT NULL,
	[Online_Amount] [bigint] NOT NULL,
	[Is_Printed] [int] NOT NULL,
	[Service_Charge] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShopSetting]    Script Date: 06/02/2021 8:11:41 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 06/02/2021 8:11:41 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPages]    Script Date: 06/02/2021 8:11:41 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 06/02/2021 8:11:41 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (1, N'Lahore', CAST(N'2020-11-15T13:18:30.293' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (2, N'Islamabad', CAST(N'2020-11-15T13:18:30.293' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (4, N'Karachi', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (5, N'Sialkot City', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (6, N'Faisalabad', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (7, N'Rawalpindi', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (8, N'Peshawar', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (9, N'Saidu Sharif', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (10, N'Multan', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (11, N'Gujranwala', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (12, N'Quetta', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (13, N'Bahawalpur', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (14, N'Sargodha', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (15, N'New Mirpur', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (16, N'Chiniot', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (17, N'Sukkur', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (18, N'Larkana', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (19, N'Shekhupura', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (20, N'Jhang City', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (21, N'Rahimyar Khan', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (22, N'Gujrat', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (23, N'Kasur', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (24, N'Mardan', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (25, N'Mingaora', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (26, N'Dera Ghazi Khan', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (27, N'Nawabshah', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (28, N'Sahiwal', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (29, N'Mirpur Khas', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (30, N'Okara', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (31, N'Mandi Burewala', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (32, N'Jacobabad', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (33, N'Saddiqabad', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (34, N'Kohat', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (35, N'Muridke', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (36, N'Muzaffargarh', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (37, N'Khanpur', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (38, N'Gojra', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (39, N'Mandi Bahauddin', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (40, N'Abbottabad', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (41, N'Dadu', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (42, N'Khuzdar', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (43, N'Pakpattan', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (44, N'Tando Allahyar', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (45, N'Vihari', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (46, N'Jaranwala', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (47, N'Kamalia', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (48, N'Kot Addu', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (49, N'Nowshera', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (50, N'Swabi', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (51, N'Dera Ismail Khan', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (52, N'Chaman', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (53, N'Charsadda', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (54, N'Kandhkot', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (55, N'Hasilpur', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (56, N'Muzaffarabad', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (57, N'Mianwali', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (58, N'Jalalpur Jattan', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (59, N'Bhakkar', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (60, N'Zhob', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (61, N'Kharian', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (62, N'Mian Channun', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (63, N'Jamshoro', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (64, N'Pattoki', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (65, N'Harunabad', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (66, N'Toba Tek Singh', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (67, N'Shakargarh', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (68, N'Hujra Shah Muqim', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (69, N'Kabirwala', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (70, N'Mansehra', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (71, N'Lala Musa', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (72, N'Nankana Sahib', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (73, N'Bannu', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (74, N'Timargara', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (75, N'Parachinar', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (76, N'Gwadar', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (77, N'Abdul Hakim', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (78, N'Hassan Abdal', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (79, N'Tank', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (80, N'Hangu', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (81, N'Risalpur Cantonment', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (82, N'Karak', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (83, N'Kundian', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (84, N'Umarkot', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (85, N'Chitral', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (86, N'Dainyor', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (87, N'Kulachi', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (88, N'Kotli', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (89, N'Gilgit', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (90, N'Hyderabad City', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (91, N'Narowal', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (92, N'Khairpur Mir’s', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (93, N'Khanewal', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (94, N'Jhelum', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (95, N'Haripur', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (96, N'Shikarpur', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (97, N'Rawala Kot', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (98, N'Hafizabad', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (99, N'Lodhran', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (100, N'Malakand', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
GO
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (101, N'Attock City', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (102, N'Batgram', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (103, N'Matiari', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (104, N'Ghotki', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (105, N'Naushahro Firoz', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (106, N'Alpurai', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (107, N'Bagh', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (108, N'Daggar', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (109, N'Bahawalnagar', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (110, N'Leiah', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (111, N'Tando Muhammad Khan', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (112, N'Chakwal', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (113, N'Khushab', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (114, N'Badin', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (115, N'Lakki', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (116, N'Rajanpur', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (117, N'Dera Allahyar', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (118, N'Shahdad Kot', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (119, N'Pishin', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (120, N'Sanghar', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (121, N'Upper Dir', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (122, N'Thatta', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (123, N'Dera Murad Jamali', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (124, N'Kohlu', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (125, N'Mastung', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (126, N'Dasu', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (127, N'Athmuqam', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (128, N'Loralai', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (129, N'Barkhan', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (130, N'Musa Khel Bazar', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (131, N'Ziarat', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (132, N'Gandava', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (133, N'Sibi', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (134, N'Dera Bugti', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (135, N'Eidgah', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (136, N'Turbat', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (137, N'Uthal', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (138, N'Khuzdar', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (139, N'Chilas', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (140, N'Kalat', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (141, N'Panjgur', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (142, N'Gakuch', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (143, N'Qila Saifullah', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (144, N'Kharan', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (145, N'Aliabad', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (146, N'Awaran', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
INSERT [dbo].[City] ([Id], [CityName], [Createdon]) VALUES (147, N'Dalbandin', CAST(N'2020-11-15T13:26:04.260' AS DateTime))
SET IDENTITY_INSERT [dbo].[City] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (5, N'bilu barbar', N'00231', N'asd', 9, N'asd', NULL)
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (7, N'bilal khan', N'0321', N'asd', 1, N'asd111', NULL)
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (8, N'nad', N'asd', N'asddd', 1, N'asd', NULL)
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (9, N'asd', N'asd', N'asd', 2, N'asd', NULL)
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (11, N'asd', N'121111', N'Address', 1, N'Mobile', NULL)
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (13, N'a', N'2213', N'asd', 1, N'21111112333', CAST(N'2020-11-13T19:42:57.053' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (14, N'aa', N'11', N'aa', 28, N'11', CAST(N'2020-11-16T01:35:29.737' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (15, N'cc', N'11', N'11', 5, N'11', CAST(N'2020-11-16T01:47:15.530' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (16, N'22', N'22', N'22', 6, N'22', CAST(N'2020-11-16T01:48:06.023' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (17, N'33', N'33', N'33', 11, N'33', CAST(N'2020-11-16T01:48:20.453' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (18, N'111', N'111', N'111', 1, N'111', CAST(N'2020-11-16T04:46:54.793' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (19, N'222', N'222', N'222', 4, N'222', CAST(N'2020-11-16T04:47:09.937' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (20, N'444', N'444', N'444', 6, N'444', CAST(N'2020-11-16T04:48:17.853' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (21, N'bbb', N'1111', N'1111', 4, N'1111', CAST(N'2020-11-16T04:49:18.190' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (22, N'aa', N'11', N'12', 7, N'Mobile', CAST(N'2020-11-16T04:52:39.053' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (23, N'ffff1', N'12', N'12132', 8, N'212132', CAST(N'2020-11-16T07:10:00.830' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (1018, N'ayaz', N'123', N'asd', 14, N'213', CAST(N'2020-12-03T17:54:39.413' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Emplyee] ON 

INSERT [dbo].[Emplyee] ([Id], [UserName], [Role], [City], [CNIC], [Adress], [Phone], [Isdeleted], [Createdon], [Password], [IsLoginAllowed], [Salary], [Image]) VALUES (1, N'Muhammad Ayaz Mehmmood', 1, 1, N'08403', N'saeeeeee', N'03215115527', NULL, CAST(N'2018-06-06T00:00:00.000' AS DateTime), N'123123', 1, 6000, N'file:///E:/EZYPOS-DATA/EZYPOS-PROJECT/EZYPOS/EZYPOS/bin/Debug/net5.0-windows/Assets/EmployeeImages/15112020084056AM.jpg')
INSERT [dbo].[Emplyee] ([Id], [UserName], [Role], [City], [CNIC], [Adress], [Phone], [Isdeleted], [Createdon], [Password], [IsLoginAllowed], [Salary], [Image]) VALUES (2, N'zafar', 2, 1, N'CNIC', N'liaqat colony1', N'03009746167', NULL, CAST(N'2020-11-02T00:00:00.000' AS DateTime), NULL, NULL, 6000, N'file:///E:/EZYPOS-DATA/EZYPOS-PROJECT/EZYPOS/EZYPOS/bin/Debug/net5.0-windows/Assets/EmployeeImages/27012021093519PM.jpg')
INSERT [dbo].[Emplyee] ([Id], [UserName], [Role], [City], [CNIC], [Adress], [Phone], [Isdeleted], [Createdon], [Password], [IsLoginAllowed], [Salary], [Image]) VALUES (3, N'Test', 2, 1, N'38403', N'test address', N'0369', NULL, CAST(N'2020-11-16T00:00:00.000' AS DateTime), NULL, NULL, 8000, N'file:///E:/EZYPOS-DATA/EZYPOS-PROJECT/EZYPOS/EZYPOS/bin/Debug/net5.0-windows/Assets/EmployeeImages/15112020064906AM.jpg')
SET IDENTITY_INSERT [dbo].[Emplyee] OFF
GO
SET IDENTITY_INSERT [dbo].[ExpenceType] ON 

INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (1, N'Fuel-updated', NULL, CAST(N'2020-11-06T00:00:00.000' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (2, N'Lunch', NULL, CAST(N'2020-11-06T00:00:00.000' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (3, N'Tea', NULL, CAST(N'2020-11-06T00:00:00.000' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (6, N'Test 1', NULL, CAST(N'2020-11-14T14:56:57.267' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (7, N'Test 2', NULL, CAST(N'2020-11-14T14:57:03.623' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (8, N'Test 3', NULL, CAST(N'2020-11-14T14:57:09.850' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (9, N'Test 4', NULL, CAST(N'2020-11-14T14:57:15.280' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (10, N'Test 5', NULL, CAST(N'2020-11-14T14:57:21.017' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (11, N'Test 6', NULL, CAST(N'2020-11-14T14:57:28.663' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (12, N'Test 7', NULL, CAST(N'2020-11-14T14:57:40.017' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (13, N'Tet 8', NULL, CAST(N'2020-11-14T14:57:47.967' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (14, N'Test 9', NULL, CAST(N'2020-11-14T14:57:54.703' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (15, N'Test 10', NULL, CAST(N'2020-11-14T14:58:03.790' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (16, N'Test 11', NULL, CAST(N'2020-11-14T14:58:08.993' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (17, N'Test 12', NULL, CAST(N'2020-11-14T14:58:15.213' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (18, N'Test 13', NULL, CAST(N'2020-11-14T14:58:25.017' AS DateTime))
INSERT [dbo].[ExpenceType] ([Id], [ExpenceName], [Isdeleted], [Createdon]) VALUES (19, N'Test 14', NULL, CAST(N'2020-11-14T14:58:32.120' AS DateTime))
SET IDENTITY_INSERT [dbo].[ExpenceType] OFF
GO
SET IDENTITY_INSERT [dbo].[ShopSetting] ON 

INSERT [dbo].[ShopSetting] ([Id], [PIN], [Shop_Id], [Shop_Name]) VALUES (1, 1234, 1, N'EZYPOS_TEST')
SET IDENTITY_INSERT [dbo].[ShopSetting] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (2, N'lab', N'0300', N'ee', 2, N'Mobile', CAST(N'2021-06-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Supplier] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (3, N'Test', N'123', N'sad', 2, N'898794', CAST(N'2020-11-13T17:57:25.270' AS DateTime))
INSERT [dbo].[Supplier] ([Id], [Name], [PhoneNo], [Adress], [City], [MobileNo], [Createdon]) VALUES (5, N'ayaz', N'123', N'kha', 24, N'1231', CAST(N'2020-12-03T17:54:11.703' AS DateTime))
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([Id], [Name]) VALUES (2, N'Employee')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [DF_Account_Isdeleted]  DEFAULT ((0)) FOR [Isdeleted]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  DEFAULT (NULL) FOR [fixed_item_des]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  DEFAULT (NULL) FOR [sub_cat_id]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  DEFAULT (NULL) FOR [sub_cat_name]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  DEFAULT (NULL) FOR [cat_name]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  DEFAULT ('0') FOR [print_sort]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  DEFAULT ('0') FOR [kitchen_lines]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  DEFAULT (NULL) FOR [item_comments]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  DEFAULT ('0') FOR [item_price]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  DEFAULT (NULL) FOR [bill_no]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  DEFAULT ('no') FOR [is_updated]
GO
ALTER TABLE [dbo].[Sale_OrderDetail] ADD  DEFAULT ('no') FOR [is_deleted]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT (NULL) FOR [order_date]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT (NULL) FOR [coupon]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT (NULL) FOR [coupon_value]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT (NULL) FOR [coupon_type]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT (NULL) FOR [coupon_applies_to]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT (NULL) FOR [coupon_categories]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT (NULL) FOR [discount_amount]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT (NULL) FOR [discount_desc]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT ('cash') FOR [payment_mode]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT ('cash') FOR [payment_status]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT (NULL) FOR [customer_phone]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT (NULL) FOR [customer_name]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT ('no') FOR [is_updated]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT ('no') FOR [is_deleted]
GO
ALTER TABLE [dbo].[Sale_Orders] ADD  DEFAULT (NULL) FOR [Service_Charge]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_City] FOREIGN KEY([City])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_City]
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
ALTER TABLE [dbo].[ExpenceTransaction]  WITH CHECK ADD  CONSTRAINT [FK_ExpenceTransaction_ExpenceType] FOREIGN KEY([ExpenceType])
REFERENCES [dbo].[ExpenceType] ([Id])
GO
ALTER TABLE [dbo].[ExpenceTransaction] CHECK CONSTRAINT [FK_ExpenceTransaction_ExpenceType]
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
ALTER TABLE [dbo].[ProductSubcategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductSubcategory_ProductCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ProductCategory] ([Id])
GO
ALTER TABLE [dbo].[ProductSubcategory] CHECK CONSTRAINT [FK_ProductSubcategory_ProductCategory]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_City] FOREIGN KEY([City])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_City]
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
