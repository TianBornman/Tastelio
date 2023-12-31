﻿CREATE TABLE [dbo].[Users]
(
	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT(NEWID()) NOT NULL,
	Email NVARCHAR(100) NOT NULL,
	Firstname NVARCHAR(50) NOT NULL,
	Lastname NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(500) NOT NULL,
	PasswordSalt UNIQUEIDENTIFIER NOT NULL, 
	CreationDate DATETIME DEFAULT(GETDATE()) NOT NULL,
	ModifiedDate DATETIME NULL,
	Active BIT DEFAULT(1) NOT NULL
)
