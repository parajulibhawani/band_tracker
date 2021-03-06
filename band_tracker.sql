USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 7/22/2016 6:51:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 7/22/2016 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_id] [int] NULL,
	[venue_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 7/22/2016 6:51:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[venue_name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[bands] ON 

INSERT [dbo].[bands] ([id], [band_name]) VALUES (1, N'The Band')
INSERT [dbo].[bands] ([id], [band_name]) VALUES (2, N'A band')
INSERT [dbo].[bands] ([id], [band_name]) VALUES (3, N'new band')
INSERT [dbo].[bands] ([id], [band_name]) VALUES (4, N'old band')
SET IDENTITY_INSERT [dbo].[bands] OFF
SET IDENTITY_INSERT [dbo].[bands_venues] ON 

INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (1, 1, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (2, 2, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (3, 3, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (4, 3, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (5, 3, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (6, 3, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (7, 2, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (8, 2, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (9, 2, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (10, 4, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (11, 4, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (12, 1, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (13, 4, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (14, 4, 1)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (15, 1, 2)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (16, 2, 3)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (17, 2, 3)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (18, 2, 3)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (20, 1, 5)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (21, 1, 5)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (19, 1, 5)
SET IDENTITY_INSERT [dbo].[bands_venues] OFF
SET IDENTITY_INSERT [dbo].[venues] ON 

INSERT [dbo].[venues] ([id], [venue_name]) VALUES (5, N'Madison Square Garden')
SET IDENTITY_INSERT [dbo].[venues] OFF
