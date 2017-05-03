
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/03/2017 10:57:49
-- Generated from EDMX file: C:\Users\Onur\Documents\Visual Studio 2015\Projects\AracKiralama\AracKiralama\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Arackiralama];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Arac]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Arac];
GO
IF OBJECT_ID(N'[dbo].[Kiralama]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kiralama];
GO
IF OBJECT_ID(N'[dbo].[Musteri]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Musteri];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Arac'
CREATE TABLE [dbo].[Arac] (
    [Marka] nvarchar(50)  NULL,
    [Model] nvarchar(50)  NULL,
    [Plaka] nvarchar(50)  NULL,
    [Vites] nchar(10)  NULL,
    [Durum] bit  NULL,
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fiyat] nchar(10)  NULL
);
GO

-- Creating table 'Kiralama'
CREATE TABLE [dbo].[Kiralama] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Baslangıc] datetime  NULL,
    [Bitis] datetime  NULL,
    [MüsteriTc] nvarchar(50)  NULL,
    [AracId] int  NULL
);
GO

-- Creating table 'Musteri'
CREATE TABLE [dbo].[Musteri] (
    [AdSoyad] nvarchar(50)  NULL,
    [TC] nvarchar(50)  NOT NULL,
    [Tel] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [password] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Arac'
ALTER TABLE [dbo].[Arac]
ADD CONSTRAINT [PK_Arac]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Kiralama'
ALTER TABLE [dbo].[Kiralama]
ADD CONSTRAINT [PK_Kiralama]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [TC] in table 'Musteri'
ALTER TABLE [dbo].[Musteri]
ADD CONSTRAINT [PK_Musteri]
    PRIMARY KEY CLUSTERED ([TC] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------