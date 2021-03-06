USE [SportsClub]
GO
/****** Object:  Table [dbo].[Playground]    Script Date: 12/23/2015 15:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Playground](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Adminids] [varchar](500) NULL,
	[Playgroundname] [varchar](350) NULL,
	[Playgrounddetails] [varchar](max) NULL,
	[Playgroundlocation] [varchar](max) NULL,
	[Backgroundimage] [varchar](max) NULL,
 CONSTRAINT [PK_Playground] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Buyer]    Script Date: 12/23/2015 15:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Buyer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Firstname] [varchar](50) NULL,
	[Lastname] [varchar](50) NULL,
	[Emailid] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[Pincode] [varchar](50) NULL,
	[Mobilenumber] [varchar](50) NULL,
	[Designatedmaparea] [varchar](max) NULL,
	[Billinginfo] [varchar](max) NULL,
 CONSTRAINT [PK_Buyer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdminUser]    Script Date: 12/23/2015 15:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Firstname] [varchar](50) NULL,
	[Lastname] [varchar](50) NULL,
	[Emailid] [varchar](50) NULL,
	[Address] [varchar](max) NULL,
	[Pincode] [varchar](50) NULL,
	[Mobilenumber] [varchar](50) NULL,
	[Billinginfo] [varchar](max) NULL,
 CONSTRAINT [PK_AdminUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
