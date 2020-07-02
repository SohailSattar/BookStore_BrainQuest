USE [BookStore]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 02 July, 2020 3:00:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](150) NOT NULL,
	[LastName] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK__Authors__70DAFC14573D89A2] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 02 July, 2020 3:00:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](150) NOT NULL,
	[AuthorID] [int] NOT NULL,
	[Pages] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[ISBN] [varchar](17) NOT NULL,
	[PublishedOn] [date] NULL,
 CONSTRAINT [PK__Books__3DE0C227EB31ED86] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookSales]    Script Date: 02 July, 2020 3:00:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookSales](
	[SaleID] [bigint] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[SoldOn] [datetime] NOT NULL,
 CONSTRAINT [PK_BookSales] PRIMARY KEY CLUSTERED 
(
	[SaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 
GO
INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName]) VALUES (1, N'Rhonda', N' Byrne')
GO
INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName]) VALUES (2, N'Sohail', N'Sattar')
GO
INSERT [dbo].[Authors] ([AuthorID], [FirstName], [LastName]) VALUES (3, N'Mark', N'Twain')
GO
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([BookID], [BookName], [AuthorID], [Pages], [Price], [ISBN], [PublishedOn]) VALUES (1, N'The Secret', 1, 198, CAST(250 AS Decimal(18, 0)), N'978-1-58270-170-7', NULL)
GO
INSERT [dbo].[Books] ([BookID], [BookName], [AuthorID], [Pages], [Price], [ISBN], [PublishedOn]) VALUES (2, N'The Gilded Age', 2, 200, CAST(25 AS Decimal(18, 0)), N'978-1-795-411783', CAST(N'1882-10-25' AS Date))
GO
INSERT [dbo].[Books] ([BookID], [BookName], [AuthorID], [Pages], [Price], [ISBN], [PublishedOn]) VALUES (3, N'A Connecticut Yankee in King Arthur’s Court ', 2, 1000, CAST(75 AS Decimal(18, 0)), N'978-0-55-3211436', CAST(N'1889-12-31' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[BookSales] ON 
GO
INSERT [dbo].[BookSales] ([SaleID], [BookID], [Quantity], [SoldOn]) VALUES (1, 3, 5, CAST(N'2020-07-02T13:19:11.807' AS DateTime))
GO
INSERT [dbo].[BookSales] ([SaleID], [BookID], [Quantity], [SoldOn]) VALUES (2, 3, 1, CAST(N'2020-07-02T13:17:53.143' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[BookSales] OFF
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Authors] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([AuthorID])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Authors]
GO
ALTER TABLE [dbo].[BookSales]  WITH CHECK ADD  CONSTRAINT [FK_BookSales_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
GO
ALTER TABLE [dbo].[BookSales] CHECK CONSTRAINT [FK_BookSales_Books]
GO
