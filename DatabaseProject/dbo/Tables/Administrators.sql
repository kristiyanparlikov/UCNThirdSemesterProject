﻿CREATE TABLE [dbo].[Administrators]
(
	[Id]  INT IDENTITY PRIMARY KEY NOT NULL,
	[EmployeeNumber]  NVARCHAR (50) NOT NULL,
	[FName]  NVARCHAR (50) NOT NULL,
	[LName]  NVARCHAR (50) NOT NULL,
	[PhoneNumber]  NVARCHAR (15) NOT NULL,
	[Email]  NVARCHAR (256) NOT NULL,
	

)
