﻿CREATE TABLE [dbo].[Administrators] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Email]          NVARCHAR (256) NOT NULL,
    [Password]         NVARCHAR (256) NOT NULL,
    [EmployeeNumber] NVARCHAR (50)  NOT NULL,
    [FirstName]      NVARCHAR (50)  NOT NULL,
    [LastName]       NVARCHAR (50)  NOT NULL,
    [PhoneNumber]    NVARCHAR (15)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

