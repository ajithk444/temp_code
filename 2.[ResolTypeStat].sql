/****** Object:  StoredProcedure [dbo].[ResolTypeStat]    Script Date: 9/15/2018 9:22:10 PM ******/
DROP PROCEDURE [dbo].[ResolTypeStat]
GO

/****** Object:  StoredProcedure [dbo].[ResolTypeStat]    Script Date: 9/15/2018 9:22:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ResolTypeStat]
	@ProjectID int
AS


--DECLARE @ProjectID int

--SET @ProjectID=2

select 
refResol.Value,
COUNT(refResol.Value) as ResCnt
 
from dbo.TASK2DELAY t
inner join dbo.REFERENCE refResol on t.[TaskResolutionID]=refResol.ID
inner join dbo.TASK ts on t.[SwimLaneID]=ts.[SwimLaneID]
where t.IsActive=1 AND t.ProjectID=@ProjectID AND ts.[IsComplete]=0
AND refResol.Value !='New Task'
group by refResol.Value

order by ResCnt desc

GO