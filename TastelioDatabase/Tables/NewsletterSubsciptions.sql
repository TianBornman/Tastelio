﻿CREATE TABLE [dbo].[NewsletterSubsciptions]
(
	UserId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	CreationDate DATETIME DEFAULT(GETDATE()) NOT NULL,
	ModifiedDate DATETIME NULL,
	Active BIT DEFAULT(1) NOT NULL
)