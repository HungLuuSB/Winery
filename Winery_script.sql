USE [Winery]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 11/16/2024 9:23:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressID] [int] IDENTITY(1,1) NOT NULL,
	[AddressCity] [nvarchar](50) NOT NULL,
	[AddressProvince] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK__tmp_ms_x__091C2A1B8819C503] PRIMARY KEY CLUSTERED 
(
	[AddressID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 11/16/2024 9:23:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK__Brand__DAD4F05EF9AD1F37] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BrandCategory]    Script Date: 11/16/2024 9:23:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrandCategory](
	[BrandID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK__BrandCat__7B44601CF83FDA45] PRIMARY KEY CLUSTERED 
(
	[BrandID] ASC,
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/16/2024 9:23:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[CategoryDesc] [text] NULL,
 CONSTRAINT [PK__Category__19093A0BDA66C4E6] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 11/16/2024 9:23:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK__Inventor__B40CC6ED675064BA] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/16/2024 9:23:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[OdrderDate] [datetime] NOT NULL,
	[UserID] [int] NULL,
	[Total] [real] NOT NULL,
	[City] [nvarchar](50) NULL,
	[Province] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK__Order__C3905BAF220FB20D] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 11/16/2024 9:23:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [real] NOT NULL,
 CONSTRAINT [PK__OrderDet__9DD74D9DBE443033] PRIMARY KEY CLUSTERED 
(
	[OrderDetailsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 11/16/2024 9:23:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionId] [int] NOT NULL,
	[PermissionName] [text] NOT NULL,
 CONSTRAINT [PK__Permissi__EFA6FB2FA14E2FFF] PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/16/2024 9:23:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
	[ProductDesc] [nvarchar](max) NOT NULL,
	[ProductYearAging] [int] NULL,
	[ProductABV] [real] NULL,
	[ProductPrice] [real] NOT NULL,
	[ProductSalePrice] [real] NULL,
	[ProductOnSale] [bit] NOT NULL,
	[ProductCapacity] [int] NULL,
	[ProductOrigin] [nvarchar](50) NULL,
	[ProductCategoryID] [int] NOT NULL,
	[ProductBrandID] [int] NOT NULL,
 CONSTRAINT [PK__tmp_ms_x__B40CC6EDA1759E4D] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 11/16/2024 9:23:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Comment] [text] NULL,
	[Rating] [int] NULL,
	[Date] [date] NULL,
 CONSTRAINT [PK__Review__74BC79AEFB5093E6] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/16/2024 9:23:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
	[PhoneNumber] [varchar](11) NULL,
 CONSTRAINT [PK__tmp_ms_x__1788CCAC704C1EBC] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermission]    Script Date: 11/16/2024 9:23:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermission](
	[UserPermissionId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK__tmp_ms_x__A90F88B2D6D3C10B] PRIMARY KEY CLUSTERED 
(
	[UserPermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (1, N'None')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (2, N'Gaja')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (3, N'Musar')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (4, N'La Rioja Atla')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (5, N'Ochoa')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (6, N'Roger Belland')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (7, N'Leflaive')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (8, N'Beaucastel')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (9, N'Avantis Estate')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (10, N'Château de Chausse')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (11, N'Louis Roederer')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (12, N'Ruinart')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (13, N'Dugladze')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (14, N'Cantarutti')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (15, N'Artemis Karamolegos')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (16, N'Cálem')
GO
INSERT [dbo].[Brand] ([BrandId], [BrandName]) VALUES (17, N'Argüeso')
GO
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (1, 1)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (2, 1)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (3, 1)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (4, 1)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (5, 1)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (6, 2)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (7, 2)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (8, 2)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (9, 3)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (10, 3)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (11, 4)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (12, 4)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (13, 5)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (14, 5)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (15, 5)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (16, 6)
GO
INSERT [dbo].[BrandCategory] ([BrandID], [CategoryID]) VALUES (17, 6)
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryDesc]) VALUES (1, N'Red Wine', N'Buy brilliant red wines, from bold Australian shiraz to classic Bordeaux or sophisticated pinot noir from Burgundy.')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryDesc]) VALUES (2, N'White Wine', N'Buy delicious premium white wines from crisp & fresh Marlborough sauvignon blanc to rich & creamy chardonnay from Burgundy.')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryDesc]) VALUES (3, N'Rosé Wine', N'Browse our great selection of Rosé wines, from delicate pale Provence rosé, to fuller Tavel. Rosé is great for paring with a huge aray of food or enjoying on its own.')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryDesc]) VALUES (4, N'Champagne & Sparkling wine', N'Champagne is a type of sparkling wine that comes exclusively from the Champagne region of France. It''s made using the traditional method, which involves a secondary fermentation in the bottle. Other sparkling wines, such as Prosecco, are made using different methods and can come from various regions around the world. While Champagne is often associated with luxury and celebration, there are many other delicious sparkling wines that can be enjoyed at more affordable prices.')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryDesc]) VALUES (5, N'Orange Wine', N'Buy from our selection of Orange wines, usually natural, biodynamic or organically grown. Orange wine is a style of white wine produced by leaving the grape skins and seeds in contact with the juice.')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [CategoryDesc]) VALUES (6, N'Fortified & Sweet Wine', N'Buy luxurious fortified wines, Port, Sherry & Dessert Wines from the classic producing regions, Sauternes, Tokaji, Constantia and some more unusual areas.  These rich styles are great for an after dinner treat.')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 
GO
INSERT [dbo].[Order] ([OrderID], [OdrderDate], [UserID], [Total], [City], [Province], [Address]) VALUES (14, CAST(N'2024-11-15T23:59:49.820' AS DateTime), 4, 8575.6, N'Ha Noi', N'Hoang Mai', N'Ngach 22')
GO
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (8, 14, 25, 1, 7999)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (9, 14, 15, 1, 490)
GO
INSERT [dbo].[OrderDetails] ([OrderDetailsID], [OrderID], [ProductID], [Quantity], [UnitPrice]) VALUES (10, 14, 28, 1, 86.6)
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
INSERT [dbo].[Permission] ([PermissionId], [PermissionName]) VALUES (1, N'OWNER')
GO
INSERT [dbo].[Permission] ([PermissionId], [PermissionName]) VALUES (2, N'ADMIN')
GO
INSERT [dbo].[Permission] ([PermissionId], [PermissionName]) VALUES (3, N'USER')
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (7, N'Gaja Pieve Santa Restituta Brunello di Montalcino', N'Pieve Santa Restituta is Italian icon Gaja''s winery in Brunello, southern Tuscany. This is a top-quality complex expression Sangiovese from drinking over the next 10 years', 2018, 14.5, 78.3, NULL, 0, 75, N'Italy', 1, 2)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (8, N'Gaja Sito Moresco Langhe 2017
', N'Sito Moresco from Italian icon Gaja is an approachable blend of Nebbiolo, Barbera and Merlot from Langhe. This deliciously poised, elegant red encapsulates Gaja''s history of combining tradition with modernity', 2016, 14, 48.7, NULL, 0, 75, N'Italy', 1, 2)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (9, N'Chateau Musar', N'The legendary Chateau Musar propelled Lebanon onto the international wine scene. This medium-bodied, characterful red from the Bekaa Valley is a blend of cabernet, cinsault and carignan, offering up silky textured, ripe flavours of mulberry, blood orange and exotic spices.', 2018, 14, 38.6, NULL, 0, 75, N'Lebanon', 1, 3)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (10, N'Opus One 2014', N'One of the world''s most iconic reds, the legendary Opus 1 is a joint venture between the Mondavi and Rothschild winemaking dynasties, produced from a futuristic winery in California''s Napa Valley. A Cabernet blend of the highest quality with rich yet refined silky black fruits and great ageing potential. The 2014 is another brilliant release, drinking now yet with a long life ahead.', 2014, 14, 448, 399, 1, 75, N'America', 1, 2)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (11, N'Ochoa Calendas Tinto', N'Founded in 1845, Bodegas Ochoa has gained a reputation for being one of Navarra’s most celebrated producers. Winemaker Adriana Ochoa is the sixth generation of her family to make wines in the region.', 2019, 13.5, 14.5, NULL, 0, 75, N'Spain', 1, 3)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (12, N'La Rioja Alta 904 Gran Reserva 2015', N'La Rioja Alta is one of the great producers of Spanish red wine, with a 125-year history. Their 904 Gran Reserva is aged for over 4 years in American oak barrels to lend the wine tremendous complexity with aromas of blackberry, dark coffee, cedar and cinnamon, with soft rounded tannins. A world-class red.', 2015, 14.5, 75, NULL, 0, 75, N'Spain', 1, 2)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (13, N'Roger Belland Croits Batard Montrachet Grand Cru', N'Criots-Batard Montrachet is one of the world''s greatest Chardonnay vineyards. Roger Belland has made an outstanding Grand Cru white Burgundy with compelling aromas of acacia, nectarine, pineapple, toast and fresh ginger. Broad and rich with mouthcoating texture and long mineral finish', 2021, 14, 504, 489, 1, 75, N'France', 2, 6)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (14, N'Roger Belland Puligny-Montrachet 1er Cru Les Champs Gains', N'A top quality white Burgundy from the talented Belland family. Their Puligny Montrachet 1er Cru Les Champs Gains is from an upper hillside vineyard, lending freshness and minerality to the rich, complex array of ripe peach and grilled nut flavours', 2021, 13.5, 127, 97, 1, 75, N'France', 2, 6)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (15, N'Leflaive Puligny Montrachet 1er Cru Clavoillon 18', N'Domaine Leflaive makes some of the world''s most sought-after expression of Chardonnay from their biodynamic vineyards. Their Puligny Montrachet 1er cru Clavoillon displays all the richness, depth, complexity and beautifully balanced interplay between ripe stonefruit, nutty oak and minerals you could wish for.', 2018, 13.5, 520, 490, 1, 75, N'France', 2, 7)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (17, N'Château de Beaucastel Roussanne Vieilles Vignes Châteauneuf-du-Pape Blanc 2015', N'Château de Beaucastel Vieilles Vignes Roussanne is perhaps the greatest Southern Rhône white. From organic, century-old vines, it''s an extraordinary, powerful, broad-textured white, with spicy citrus & stone fruit.', 2022, 0, 185, NULL, 0, 75, N'France', 2, 8)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (20, N'Avantis Estate Falcon''s Hill Rosé', N'Avantis Estate Falcon''s Hill is a top-quality rosé from Evia. Using the local Mavrokoudoura grape from mountain vineyards, it''s food-friendly, dry and full-flavoured, with succulent white peach and red berries.', 2022, 13, 20.5, NULL, 0, 75, N'Greece', 3, 9)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (22, N'Château de Chausse Côtes de Provence Rosé', N'Château de Chausse is a summer classic, pale pink Côtes de Provence Rosé. This delicate, aromatic cuvée reveals elegant scents of white fruit, enhanced by pure minerality.', 2022, 13, 22.5, NULL, 0, 75, N'France', 3, 10)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (24, N'Château de Chausse Côtes de Provence Rosé Magnum', N'Château de Chausse is a summer classic, pale pink Côtes de Provence Rosé. This delicate, aromatic cuvée reveals elegant scents of white fruit, enhanced by pure minerality. Bright and fresh, a magnum size is perfect for a summer barbeque.', 2023, 13, 44, NULL, 0, 150, N'France', 3, 10)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (25, N'Louis Roederer Cristal 2002 Mathusalem Vintage Champagne', N'Louis Roederer Cristal 2002 is a great Champagne from a great vintage. 55% Pinot Noir, this crisp, delicate wine will age magnificently in this 6-litre Methusalah format, ideal for large celebrations.', 2002, 12, 8530, 7999, 1, 600, N'France', 4, 11)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (27, N'Dom Pérignon 2005 Jeroboam Champagne', N'Dom Pérignon is a luxury Champagne that makes greatness look effortless. The 2005, in this 3-litre Jeroboam, is yet another fine example of DP''s elegant style that will grace any party table.', 2010, 12.5, 2950, 2875, 1, 300, N'France', 4, 11)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (28, N'Nyetimber Classic Cuvee 2010 Magnum', N'Nyetimber’s Classic Cuvee is a sumptuous blend of Chardonnay, Pinot Noir and Pinot Meunier with toasty, spicy, complex aromas. A great combination of intensity, delicacy and length.', 2010, 12, 86.6, NULL, 0, 150, N'England', 4, 11)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (30, N'Dom Ruinart Rosé 2007', N'Dom Ruinart Rosé 2007, one of the great Champagnes, blends 80% Grand Cru Chardonnay and 20% Grand Cru Pinot Noir, aged for years before release. Complex, long and satisfying with red fruits, peach and fresh pastry.', 2007, 12.5, 295, NULL, 0, 75, N'France', 4, 12)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (31, N'Dugladze Ranina Kakhuri', N'Dugladze Ranina Kakhuri is a Georgian orange wine made from the Rkatsiteli grape, given 3 months skin contact in traditional qvevri amphora. The results is full bodied, with intense, nutty dried apricot flavours. Exotic and mouthfilling with a dry, gently tannic finish.', 0, 12.5, 13.5, NULL, 0, 75, N'Georgia', 5, 13)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (32, N'Dugladze Qvevri Kisi 2020', N'Dugladze Qvevri Kisi, from one of Georgia''s leading wineries, is a traditional orange wine: Kisi grapes fermented & matured 6 months on skins, in qvevri amphorae. Rich, silky-textured with dried stone fruit notes.', 2020, 12.5, 22, NULL, 0, 75, N'Georgia', 5, 13)
GO
INSERT [dbo].[Product] ([ProductID], [ProductName], [ProductDesc], [ProductYearAging], [ProductABV], [ProductPrice], [ProductSalePrice], [ProductOnSale], [ProductCapacity], [ProductOrigin], [ProductCategoryID], [ProductBrandID]) VALUES (33, N'Cálem Colheita 1961', N'Cálem Colheita 1961, from the great Portuguese house who specialises in Tawny Port, is a rare, trophy-winning, pinnacle of the barrel matured style; a collector''s item of incredible sophistication.', 1961, 20, 254.5, NULL, 0, 75, N'Portugal', 6, 15)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserID], [Email], [Password], [FirstName], [LastName], [MiddleName], [DateOfBirth], [PhoneNumber]) VALUES (1, N'test1@gmail.com', N'123456', N'Hưng', N'Lưu', N'Thái', CAST(N'2005-11-21' AS Date), N'0000000000')
GO
INSERT [dbo].[User] ([UserID], [Email], [Password], [FirstName], [LastName], [MiddleName], [DateOfBirth], [PhoneNumber]) VALUES (2, N'test2@gmail.com', N'123456', N'Huy', N'Phan', N'Trần Quốc', CAST(N'2005-12-05' AS Date), N'0000000000')
GO
INSERT [dbo].[User] ([UserID], [Email], [Password], [FirstName], [LastName], [MiddleName], [DateOfBirth], [PhoneNumber]) VALUES (3, N'test3@gmail.com', N'123456', N'Khánh', N'Mai', N'Van', CAST(N'2005-01-01' AS Date), N'0000000000')
GO
INSERT [dbo].[User] ([UserID], [Email], [Password], [FirstName], [LastName], [MiddleName], [DateOfBirth], [PhoneNumber]) VALUES (4, N'ductrungliu@hotmail.com', N'123456', N'Trung', N'Nguyễn', N'Đức', CAST(N'2005-02-11' AS Date), N'0')
GO
INSERT [dbo].[User] ([UserID], [Email], [Password], [FirstName], [LastName], [MiddleName], [DateOfBirth], [PhoneNumber]) VALUES (5, N'hungluu123@hotmail.com', N'123456', N'Hung', N'Luu', N'Thái', CAST(N'2005-12-21' AS Date), N'0')
GO
INSERT [dbo].[User] ([UserID], [Email], [Password], [FirstName], [LastName], [MiddleName], [DateOfBirth], [PhoneNumber]) VALUES (6, N'dummy@yahoo.com.vn', N'123456', N'A', N'Nguy?n', N'Van', CAST(N'1998-07-22' AS Date), N'0')
GO
INSERT [dbo].[User] ([UserID], [Email], [Password], [FirstName], [LastName], [MiddleName], [DateOfBirth], [PhoneNumber]) VALUES (15, N'hungluu344@gmail.com', N'hungluu12', N'Lưu', N'Hung', N'Thái', NULL, NULL)
GO
INSERT [dbo].[User] ([UserID], [Email], [Password], [FirstName], [LastName], [MiddleName], [DateOfBirth], [PhoneNumber]) VALUES (16, N'testlkkl@gmail.com', N'123456', N'Kim Lợi', N'Lưu', N'Kỳ', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserPermission] ON 
GO
INSERT [dbo].[UserPermission] ([UserPermissionId], [UserId], [PermissionId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[UserPermission] ([UserPermissionId], [UserId], [PermissionId]) VALUES (2, 2, 2)
GO
INSERT [dbo].[UserPermission] ([UserPermissionId], [UserId], [PermissionId]) VALUES (3, 3, 2)
GO
INSERT [dbo].[UserPermission] ([UserPermissionId], [UserId], [PermissionId]) VALUES (4, 4, 3)
GO
INSERT [dbo].[UserPermission] ([UserPermissionId], [UserId], [PermissionId]) VALUES (5, 5, 3)
GO
INSERT [dbo].[UserPermission] ([UserPermissionId], [UserId], [PermissionId]) VALUES (6, 6, 3)
GO
SET IDENTITY_INSERT [dbo].[UserPermission] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__tmp_ms_x__A9D105340B43EAE7]    Script Date: 11/16/2024 9:23:37 AM ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [UQ__tmp_ms_x__A9D105340B43EAE7] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Inventory] ADD  CONSTRAINT [DF__Inventory__Quant__3864608B]  DEFAULT ((100)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__tmp_ms_xx__Produ__4F47C5E3]  DEFAULT ((0)) FOR [ProductOnSale]
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF__tmp_ms_xx__Produ__503BEA1C]  DEFAULT ((1)) FOR [ProductBrandID]
GO
ALTER TABLE [dbo].[UserPermission] ADD  CONSTRAINT [DF__tmp_ms_xx__Permi__03F0984C]  DEFAULT ((3)) FOR [PermissionId]
GO
ALTER TABLE [dbo].[Address]  WITH NOCHECK ADD  CONSTRAINT [FK__Address__UserID__681373AD] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK__Address__UserID__681373AD]
GO
ALTER TABLE [dbo].[BrandCategory]  WITH NOCHECK ADD  CONSTRAINT [FK__BrandCate__Brand__2DE6D218] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brand] ([BrandId])
GO
ALTER TABLE [dbo].[BrandCategory] CHECK CONSTRAINT [FK__BrandCate__Brand__2DE6D218]
GO
ALTER TABLE [dbo].[BrandCategory]  WITH NOCHECK ADD  CONSTRAINT [FK__BrandCate__Categ__2EDAF651] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[BrandCategory] CHECK CONSTRAINT [FK__BrandCate__Categ__2EDAF651]
GO
ALTER TABLE [dbo].[Inventory]  WITH NOCHECK ADD  CONSTRAINT [FK__Inventory__Produ__531856C7] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK__Inventory__Produ__531856C7]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__Order__395884C4] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK__OrderDeta__Order__395884C4]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH NOCHECK ADD  CONSTRAINT [FK__OrderDeta__Produ__540C7B00] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK__OrderDeta__Produ__540C7B00]
GO
ALTER TABLE [dbo].[Product]  WITH NOCHECK ADD  CONSTRAINT [FK__Product__Product__51300E55] FOREIGN KEY([ProductCategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Product__51300E55]
GO
ALTER TABLE [dbo].[Product]  WITH NOCHECK ADD  CONSTRAINT [FK__Product__Product__5224328E] FOREIGN KEY([ProductBrandID])
REFERENCES [dbo].[Brand] ([BrandId])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Product__5224328E]
GO
ALTER TABLE [dbo].[Review]  WITH NOCHECK ADD  CONSTRAINT [FK__Review__ProductI__55009F39] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ProductID])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK__Review__ProductI__55009F39]
GO
ALTER TABLE [dbo].[Review]  WITH NOCHECK ADD  CONSTRAINT [FK__Review__UserID__690797E6] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [FK__Review__UserID__690797E6]
GO
ALTER TABLE [dbo].[UserPermission]  WITH NOCHECK ADD  CONSTRAINT [FK__UserPermi__Permi__05D8E0BE] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([PermissionId])
GO
ALTER TABLE [dbo].[UserPermission] CHECK CONSTRAINT [FK__UserPermi__Permi__05D8E0BE]
GO
ALTER TABLE [dbo].[UserPermission]  WITH NOCHECK ADD  CONSTRAINT [FK__UserPermi__UserI__662B2B3B] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserPermission] CHECK CONSTRAINT [FK__UserPermi__UserI__662B2B3B]
GO
