USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 3/2/2017 6:28:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[hair_style] [varchar](255) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 3/2/2017 6:28:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[experience] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [hair_style], [stylist_id]) VALUES (3, N'Tim', N'Shaved', 2)
INSERT [dbo].[clients] ([id], [name], [hair_style], [stylist_id]) VALUES (9, N'Lucy', N'frizzy', 4)
INSERT [dbo].[clients] ([id], [name], [hair_style], [stylist_id]) VALUES (8, N'Allison', N'Cut 1 foot off', 4)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name], [experience]) VALUES (5, N'Dave', 5)
INSERT [dbo].[stylists] ([id], [name], [experience]) VALUES (2, N'Susie', 9)
INSERT [dbo].[stylists] ([id], [name], [experience]) VALUES (4, N'Donna', 1)
SET IDENTITY_INSERT [dbo].[stylists] OFF
