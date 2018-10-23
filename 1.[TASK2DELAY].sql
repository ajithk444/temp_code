USE [DBPullPlanTest]
GO

/****** Object:  Table [dbo].[TASK2DELAY]    Script Date: 23-10-2018 12:43:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TASK2DELAY](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaskId] [int] NOT NULL,
	[Duration] [int] NOT NULL,
	[TaskResolutionID] [int] NOT NULL,
	[ResolutionText] [varchar](200) NULL,
	[ProjectId] [int] NOT NULL,
	[SwimLaneID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TASK2DELAY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


