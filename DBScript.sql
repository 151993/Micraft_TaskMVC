USE [MicraftTaskDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 30-05-2020 16:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Pincode] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 30-05-2020 16:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [nvarchar](50) NULL,
	[ProductName] [nvarchar](50) NULL,
	[ProductImage] [nvarchar](200) NULL,
	[Unit] [int] NULL,
	[Rate] [decimal](18, 0) NULL,
	[Description] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOrder]    Script Date: 30-05-2020 16:45:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrder](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NULL,
	[CustomerId] [int] NULL,
	[TotalQty] [int] NULL,
	[TotalAmount] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerId], [Name], [Address], [City], [Pincode]) VALUES (1, N'Amol', N'Ameerpet', N'Hyderabad', 500016)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Address], [City], [Pincode]) VALUES (2, N'Akash', N'Latur', N'Latur', 413533)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Address], [City], [Pincode]) VALUES (4, N'weq', N'Ameerpet1', N'Hyderabad', 500016)
INSERT [dbo].[Customer] ([CustomerId], [Name], [Address], [City], [Pincode]) VALUES (5, N'wrre', N'Ameerpet west', N'Hyderabad', 500016)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductCode], [ProductName], [ProductImage], [Unit], [Rate], [Description]) VALUES (1, N'Ip55', N'Iphone1155', N'spt_Ip55.jpg', 55, CAST(55 AS Decimal(18, 0)), N'testsds55')
INSERT [dbo].[Product] ([ProductId], [ProductCode], [ProductName], [ProductImage], [Unit], [Rate], [Description]) VALUES (2, N'fstwach', N'fastrack', NULL, 8, CAST(90 AS Decimal(18, 0)), N'testdd')
INSERT [dbo].[Product] ([ProductId], [ProductCode], [ProductName], [ProductImage], [Unit], [Rate], [Description]) VALUES (3, N'Headi', N'Headphones', N'iphone_Headi.jpg', 3, CAST(5 AS Decimal(18, 0)), N'trst')
INSERT [dbo].[Product] ([ProductId], [ProductCode], [ProductName], [ProductImage], [Unit], [Rate], [Description]) VALUES (4, N'usdfha', N'sdkfk', N'watch_usdfha.jpg', 9, CAST(90 AS Decimal(18, 0)), N'0')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[tblOrder] ON 

INSERT [dbo].[tblOrder] ([OrderId], [OrderDate], [CustomerId], [TotalQty], [TotalAmount]) VALUES (1, CAST(N'2020-12-12T00:00:00.000' AS DateTime), 1, 6, CAST(2 AS Decimal(18, 0)))
INSERT [dbo].[tblOrder] ([OrderId], [OrderDate], [CustomerId], [TotalQty], [TotalAmount]) VALUES (2, CAST(N'2020-05-22T00:00:00.000' AS DateTime), 1, 2, CAST(60 AS Decimal(18, 0)))
INSERT [dbo].[tblOrder] ([OrderId], [OrderDate], [CustomerId], [TotalQty], [TotalAmount]) VALUES (3, CAST(N'2020-05-08T00:00:00.000' AS DateTime), 2, 2, CAST(2 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[tblOrder] OFF
GO
ALTER TABLE [dbo].[tblOrder]  WITH CHECK ADD FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([CustomerId])
GO
