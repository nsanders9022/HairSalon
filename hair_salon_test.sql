USE [hair_salon_test]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 3/2/2017 6:29:41 PM ******/
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
/****** Object:  Table [dbo].[stylists]    Script Date: 3/2/2017 6:29:41 PM ******/
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
