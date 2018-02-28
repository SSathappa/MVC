USE [Knightfury]
GO

/****** Object:  Table [dbo].[M_Students]    Script Date: 2/28/2018 4:06:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[M_Students](
	[Student_TblRefID] [int] IDENTITY(1,1) NOT NULL,
	[Student_Name] [nvarchar](64) NOT NULL,
	[Student_City] [nvarchar](64) NOT NULL,
	[Student_Address] [nvarchar](128) NOT NULL,
	[EntryDateTime] [datetime] NOT NULL,
	[UpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_M_Students] PRIMARY KEY CLUSTERED 
(
	[Student_TblRefID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[M_Students] ADD  CONSTRAINT [DF_M_Students_EntryDateTime]  DEFAULT (getdate()) FOR [EntryDateTime]
GO