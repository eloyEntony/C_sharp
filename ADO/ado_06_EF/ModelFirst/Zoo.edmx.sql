
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/01/2020 12:51:25
-- Generated from EDMX file: C:\Users\Anton\Cod\C#\ADO\ado_06_EF\ModelFirst\Zoo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Zoo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AnimalKind]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Animals] DROP CONSTRAINT [FK_AnimalKind];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Animals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Animals];
GO
IF OBJECT_ID(N'[dbo].[Kinds]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kinds];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Animals'
CREATE TABLE [dbo].[Animals] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ZooId] int  NOT NULL,
    [Kind_Id] int  NOT NULL
);
GO

-- Creating table 'Kinds'
CREATE TABLE [dbo].[Kinds] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ZooSet'
CREATE TABLE [dbo].[ZooSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nama] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [PK_Animals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Kinds'
ALTER TABLE [dbo].[Kinds]
ADD CONSTRAINT [PK_Kinds]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ZooSet'
ALTER TABLE [dbo].[ZooSet]
ADD CONSTRAINT [PK_ZooSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Kind_Id] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [FK_AnimalKind]
    FOREIGN KEY ([Kind_Id])
    REFERENCES [dbo].[Kinds]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AnimalKind'
CREATE INDEX [IX_FK_AnimalKind]
ON [dbo].[Animals]
    ([Kind_Id]);
GO

-- Creating foreign key on [ZooId] in table 'Animals'
ALTER TABLE [dbo].[Animals]
ADD CONSTRAINT [FK_ZooAnimal]
    FOREIGN KEY ([ZooId])
    REFERENCES [dbo].[ZooSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ZooAnimal'
CREATE INDEX [IX_FK_ZooAnimal]
ON [dbo].[Animals]
    ([ZooId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------