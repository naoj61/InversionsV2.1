
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/13/2015 19:31:23
-- Generated from EDMX file: C:\SIGIOC\Repositoris\Altres\Inversions\InversionsBD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [InversionsBD];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EmpresaGestor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gestors] DROP CONSTRAINT [FK_EmpresaGestor];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaP2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Productes] DROP CONSTRAINT [FK_EmpresaP2];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdFonsGestor_ProdFons]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdFonsGestor] DROP CONSTRAINT [FK_ProdFonsGestor_ProdFons];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdFonsGestor_Gestor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProdFonsGestor] DROP CONSTRAINT [FK_ProdFonsGestor_Gestor];
GO
IF OBJECT_ID(N'[dbo].[FK_MercatProdAccions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Productes_ProdAccions] DROP CONSTRAINT [FK_MercatProdAccions];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdMov]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Moviments] DROP CONSTRAINT [FK_ProdMov];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdValoracio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Valoracions] DROP CONSTRAINT [FK_ProdValoracio];
GO
IF OBJECT_ID(N'[dbo].[FK_ProducteMoviment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Moviments] DROP CONSTRAINT [FK_ProducteMoviment];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdFons_inherits_Producte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Productes_ProdFons] DROP CONSTRAINT [FK_ProdFons_inherits_Producte];
GO
IF OBJECT_ID(N'[dbo].[FK_ProdAccions_inherits_Producte]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Productes_ProdAccions] DROP CONSTRAINT [FK_ProdAccions_inherits_Producte];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Empreses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empreses];
GO
IF OBJECT_ID(N'[dbo].[Gestors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gestors];
GO
IF OBJECT_ID(N'[dbo].[Valoracions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Valoracions];
GO
IF OBJECT_ID(N'[dbo].[Productes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productes];
GO
IF OBJECT_ID(N'[dbo].[Mercats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mercats];
GO
IF OBJECT_ID(N'[dbo].[Moviments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Moviments];
GO
IF OBJECT_ID(N'[dbo].[Productes_ProdFons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productes_ProdFons];
GO
IF OBJECT_ID(N'[dbo].[Productes_ProdAccions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productes_ProdAccions];
GO
IF OBJECT_ID(N'[dbo].[ProdFonsGestor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdFonsGestor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Empreses'
CREATE TABLE [dbo].[Empreses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(50)  NOT NULL,
    [TipusEmpresa] int  NOT NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'Gestors'
CREATE TABLE [dbo].[Gestors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmpresaId] int  NOT NULL,
    [ProducteId] int  NULL,
    [Nom] nvarchar(50)  NOT NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'Valoracions'
CREATE TABLE [dbo].[Valoracions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProdId] int  NOT NULL,
    [Data] datetime  NOT NULL,
    [Import] float  NOT NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'Productes'
CREATE TABLE [dbo].[Productes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmpresaId] int  NOT NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'Mercats'
CREATE TABLE [dbo].[Mercats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(50)  NOT NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'Moviments'
CREATE TABLE [dbo].[Moviments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProdId] int  NOT NULL,
    [TipusMoviment] int  NOT NULL,
    [Data] datetime  NOT NULL,
    [Participacions] float  NOT NULL,
    [Import] float  NOT NULL,
    [Despeses] float  NULL,
    [ProducteTraspasId] int  NULL,
    [Descripcio] nvarchar(max)  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'Productes_ProdFons'
CREATE TABLE [dbo].[Productes_ProdFons] (
    [Nom] nvarchar(50)  NOT NULL,
    [ISIN] nvarchar(25)  NOT NULL,
    [Descripcio] nvarchar(max)  NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Productes_ProdAccions'
CREATE TABLE [dbo].[Productes_ProdAccions] (
    [MercatId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'ProdFonsGestor'
CREATE TABLE [dbo].[ProdFonsGestor] (
    [ProdFons_Id] int  NOT NULL,
    [Gestors_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Empreses'
ALTER TABLE [dbo].[Empreses]
ADD CONSTRAINT [PK_Empreses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Gestors'
ALTER TABLE [dbo].[Gestors]
ADD CONSTRAINT [PK_Gestors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Valoracions'
ALTER TABLE [dbo].[Valoracions]
ADD CONSTRAINT [PK_Valoracions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Productes'
ALTER TABLE [dbo].[Productes]
ADD CONSTRAINT [PK_Productes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Mercats'
ALTER TABLE [dbo].[Mercats]
ADD CONSTRAINT [PK_Mercats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Moviments'
ALTER TABLE [dbo].[Moviments]
ADD CONSTRAINT [PK_Moviments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Productes_ProdFons'
ALTER TABLE [dbo].[Productes_ProdFons]
ADD CONSTRAINT [PK_Productes_ProdFons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Productes_ProdAccions'
ALTER TABLE [dbo].[Productes_ProdAccions]
ADD CONSTRAINT [PK_Productes_ProdAccions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ProdFons_Id], [Gestors_Id] in table 'ProdFonsGestor'
ALTER TABLE [dbo].[ProdFonsGestor]
ADD CONSTRAINT [PK_ProdFonsGestor]
    PRIMARY KEY CLUSTERED ([ProdFons_Id], [Gestors_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmpresaId] in table 'Gestors'
ALTER TABLE [dbo].[Gestors]
ADD CONSTRAINT [FK_EmpresaGestor]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empreses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaGestor'
CREATE INDEX [IX_FK_EmpresaGestor]
ON [dbo].[Gestors]
    ([EmpresaId]);
GO

-- Creating foreign key on [EmpresaId] in table 'Productes'
ALTER TABLE [dbo].[Productes]
ADD CONSTRAINT [FK_EmpresaP2]
    FOREIGN KEY ([EmpresaId])
    REFERENCES [dbo].[Empreses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaP2'
CREATE INDEX [IX_FK_EmpresaP2]
ON [dbo].[Productes]
    ([EmpresaId]);
GO

-- Creating foreign key on [ProdFons_Id] in table 'ProdFonsGestor'
ALTER TABLE [dbo].[ProdFonsGestor]
ADD CONSTRAINT [FK_ProdFonsGestor_ProdFons]
    FOREIGN KEY ([ProdFons_Id])
    REFERENCES [dbo].[Productes_ProdFons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Gestors_Id] in table 'ProdFonsGestor'
ALTER TABLE [dbo].[ProdFonsGestor]
ADD CONSTRAINT [FK_ProdFonsGestor_Gestor]
    FOREIGN KEY ([Gestors_Id])
    REFERENCES [dbo].[Gestors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdFonsGestor_Gestor'
CREATE INDEX [IX_FK_ProdFonsGestor_Gestor]
ON [dbo].[ProdFonsGestor]
    ([Gestors_Id]);
GO

-- Creating foreign key on [MercatId] in table 'Productes_ProdAccions'
ALTER TABLE [dbo].[Productes_ProdAccions]
ADD CONSTRAINT [FK_MercatProdAccions]
    FOREIGN KEY ([MercatId])
    REFERENCES [dbo].[Mercats]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MercatProdAccions'
CREATE INDEX [IX_FK_MercatProdAccions]
ON [dbo].[Productes_ProdAccions]
    ([MercatId]);
GO

-- Creating foreign key on [ProdId] in table 'Moviments'
ALTER TABLE [dbo].[Moviments]
ADD CONSTRAINT [FK_ProdMov]
    FOREIGN KEY ([ProdId])
    REFERENCES [dbo].[Productes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdMov'
CREATE INDEX [IX_FK_ProdMov]
ON [dbo].[Moviments]
    ([ProdId]);
GO

-- Creating foreign key on [ProdId] in table 'Valoracions'
ALTER TABLE [dbo].[Valoracions]
ADD CONSTRAINT [FK_ProdValoracio]
    FOREIGN KEY ([ProdId])
    REFERENCES [dbo].[Productes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProdValoracio'
CREATE INDEX [IX_FK_ProdValoracio]
ON [dbo].[Valoracions]
    ([ProdId]);
GO

-- Creating foreign key on [ProducteTraspasId] in table 'Moviments'
ALTER TABLE [dbo].[Moviments]
ADD CONSTRAINT [FK_ProducteMoviment]
    FOREIGN KEY ([ProducteTraspasId])
    REFERENCES [dbo].[Productes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProducteMoviment'
CREATE INDEX [IX_FK_ProducteMoviment]
ON [dbo].[Moviments]
    ([ProducteTraspasId]);
GO

-- Creating foreign key on [Id] in table 'Productes_ProdFons'
ALTER TABLE [dbo].[Productes_ProdFons]
ADD CONSTRAINT [FK_ProdFons_inherits_Producte]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Productes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Productes_ProdAccions'
ALTER TABLE [dbo].[Productes_ProdAccions]
ADD CONSTRAINT [FK_ProdAccions_inherits_Producte]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Productes]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------