USE [AutoFiller_APP_DB]
GO
/****** Object:  Table [dbo].[CivilSurgeons]    Script Date: 2023-08-04 16:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CivilSurgeons](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FormId] [nvarchar](max) NULL,
	[FormData] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_CivilSurgeons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[form]    Script Date: 2023-08-04 16:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[form](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_date] [datetime] NULL,
	[updated_date] [datetime] NULL,
	[form_data] [nvarchar](max) NULL,
	[answer] [int] NULL,
	[extraData] [nvarchar](max) NULL,
	[completed] [bit] NULL,
	[submit_id] [nvarchar](max) NULL,
	[source] [nchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 2023-08-04 16:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UniqueId] [nvarchar](max) NULL,
	[I693Data] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preparers]    Script Date: 2023-08-04 16:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preparers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FormId] [nvarchar](max) NULL,
	[FormData] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[LastUpdated] [datetime] NULL,
 CONSTRAINT [PK_Preparers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[form] ADD  CONSTRAINT [DF_form_completed]  DEFAULT ((0)) FOR [completed]
GO
ALTER TABLE [dbo].[form] ADD  CONSTRAINT [DF_form_source]  DEFAULT (N'office') FOR [source]
GO
