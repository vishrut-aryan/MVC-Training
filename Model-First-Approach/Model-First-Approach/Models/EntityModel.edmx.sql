
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/23/2024 10:13:13
-- Generated from EDMX file: C:\Users\varyan\source\repos\MVC Training\Model-First-Approach\Model-First-Approach\Models\EntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Code-First];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'companies'
CREATE TABLE [dbo].[companies] (
    [Com_Id] int IDENTITY(1,1) NOT NULL,
    [Com_Name] nvarchar(max)  NOT NULL,
    [Scale] int  NOT NULL
);
GO

-- Creating table 'employees'
CREATE TABLE [dbo].[employees] (
    [Emp_Id] int IDENTITY(1,1) NOT NULL,
    [Salary] float  NOT NULL,
    [Emp_Name] nvarchar(max)  NOT NULL,
    [companyCom_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Com_Id] in table 'companies'
ALTER TABLE [dbo].[companies]
ADD CONSTRAINT [PK_companies]
    PRIMARY KEY CLUSTERED ([Com_Id] ASC);
GO

-- Creating primary key on [Emp_Id] in table 'employees'
ALTER TABLE [dbo].[employees]
ADD CONSTRAINT [PK_employees]
    PRIMARY KEY CLUSTERED ([Emp_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [companyCom_Id] in table 'employees'
ALTER TABLE [dbo].[employees]
ADD CONSTRAINT [FK_companyemployee]
    FOREIGN KEY ([companyCom_Id])
    REFERENCES [dbo].[companies]
        ([Com_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_companyemployee'
CREATE INDEX [IX_FK_companyemployee]
ON [dbo].[employees]
    ([companyCom_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------