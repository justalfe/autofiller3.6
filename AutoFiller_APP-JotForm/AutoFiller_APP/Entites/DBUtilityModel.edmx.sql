
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/17/2023 22:22:10
-- Generated from EDMX file: D:\Project\VisualStudio\multistep-webform\Autofiller-3.0\AutoFiller_APP-master\AutoFiller_APP\Entites\DBUtilityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AutoFiller_APP_DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CivilSurgeon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CivilSurgeon];
GO
IF OBJECT_ID(N'[dbo].[Patient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Patient];
GO
IF OBJECT_ID(N'[dbo].[Preparer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Preparer];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CivilSurgeons'
CREATE TABLE [dbo].[CivilSurgeons] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FormId] nvarchar(max)  NULL,
    [FormData] nvarchar(max)  NULL,
    [CreatedDate] datetime  NULL,
    [LastUpdated] datetime  NULL
);
GO

-- Creating table 'Preparers'
CREATE TABLE [dbo].[Preparers] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FormId] nvarchar(max)  NULL,
    [FormData] nvarchar(max)  NULL,
    [CreatedDate] datetime  NULL,
    [LastUpdated] datetime  NULL
);
GO

-- Creating table 'Patients'
CREATE TABLE [dbo].[Patients] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UniqueId] nvarchar(max)  NULL,
    [I693Data] nvarchar(max)  NULL,
    [CreatedDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CivilSurgeons'
ALTER TABLE [dbo].[CivilSurgeons]
ADD CONSTRAINT [PK_CivilSurgeons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Preparers'
ALTER TABLE [dbo].[Preparers]
ADD CONSTRAINT [PK_Preparers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Patients'
ALTER TABLE [dbo].[Patients]
ADD CONSTRAINT [PK_Patients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------