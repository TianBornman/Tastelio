﻿CREATE TABLE [dbo].[Roles]
(
	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()) NOT NULL,
	[Name] NVARCHAR(100) NOT NULL
)
