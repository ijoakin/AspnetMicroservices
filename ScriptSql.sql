drop table [Software]

CREATE TABLE [dbo].[Software](
	[id] [int] identity(1,1),
	[typeid] int references SoftwareType(id),
	[locationid] int references [location](id),
	[platformid] int references [platform](id),
	[unc] [nvarchar](350) NULL,
	[softwareDescription] [nvarchar](350) NULL,
	[softwareName] [nvarchar](350) NULL,
	primary key(id)
) 

GO

