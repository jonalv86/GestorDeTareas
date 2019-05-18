
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/18/2019 13:32:59
-- Generated from EDMX file: C:\Users\jonatan.alvarez\Source\repos\GestorDeTareas\GestorDeTareas\Models\GestorDeTareasModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GestorDeTareas_Desa];
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

-- Creating table 'TareaSet'
CREATE TABLE [dbo].[TareaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [UsuarioAsignadoId] int  NULL,
    [FechaVencimiento] datetime  NULL,
    [UsuarioAltaId] int  NOT NULL,
    [FechaAlta] datetime  NOT NULL,
    [UsuarioBajaId] int  NULL,
    [FechaBaja] datetime  NULL,
    [PrioridadId] int  NOT NULL,
    [EstadoId] int  NOT NULL
);
GO

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ComentarioSet'
CREATE TABLE [dbo].[ComentarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ordinal] int  NOT NULL,
    [ComentarioDescripcion] nvarchar(max)  NOT NULL,
    [ComentarioFecha] datetime  NOT NULL,
    [TareaId] int  NOT NULL,
    [UsuarioId] int  NOT NULL
);
GO

-- Creating table 'PrioridadSet'
CREATE TABLE [dbo].[PrioridadSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PrioridadDesc] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EstadoSet'
CREATE TABLE [dbo].[EstadoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EstadoDesc] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TareaSet'
ALTER TABLE [dbo].[TareaSet]
ADD CONSTRAINT [PK_TareaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComentarioSet'
ALTER TABLE [dbo].[ComentarioSet]
ADD CONSTRAINT [PK_ComentarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PrioridadSet'
ALTER TABLE [dbo].[PrioridadSet]
ADD CONSTRAINT [PK_PrioridadSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EstadoSet'
ALTER TABLE [dbo].[EstadoSet]
ADD CONSTRAINT [PK_EstadoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsuarioAltaId] in table 'TareaSet'
ALTER TABLE [dbo].[TareaSet]
ADD CONSTRAINT [FK_TareaUsuarioAlta]
    FOREIGN KEY ([UsuarioAltaId])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TareaUsuarioAlta'
CREATE INDEX [IX_FK_TareaUsuarioAlta]
ON [dbo].[TareaSet]
    ([UsuarioAltaId]);
GO

-- Creating foreign key on [UsuarioAsignadoId] in table 'TareaSet'
ALTER TABLE [dbo].[TareaSet]
ADD CONSTRAINT [FK_AsignacionTarea]
    FOREIGN KEY ([UsuarioAsignadoId])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AsignacionTarea'
CREATE INDEX [IX_FK_AsignacionTarea]
ON [dbo].[TareaSet]
    ([UsuarioAsignadoId]);
GO

-- Creating foreign key on [UsuarioBajaId] in table 'TareaSet'
ALTER TABLE [dbo].[TareaSet]
ADD CONSTRAINT [FK_TareaUsuarioBaja]
    FOREIGN KEY ([UsuarioBajaId])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TareaUsuarioBaja'
CREATE INDEX [IX_FK_TareaUsuarioBaja]
ON [dbo].[TareaSet]
    ([UsuarioBajaId]);
GO

-- Creating foreign key on [PrioridadId] in table 'TareaSet'
ALTER TABLE [dbo].[TareaSet]
ADD CONSTRAINT [FK_PrioridadTarea]
    FOREIGN KEY ([PrioridadId])
    REFERENCES [dbo].[PrioridadSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PrioridadTarea'
CREATE INDEX [IX_FK_PrioridadTarea]
ON [dbo].[TareaSet]
    ([PrioridadId]);
GO

-- Creating foreign key on [EstadoId] in table 'TareaSet'
ALTER TABLE [dbo].[TareaSet]
ADD CONSTRAINT [FK_EstadoTarea]
    FOREIGN KEY ([EstadoId])
    REFERENCES [dbo].[EstadoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoTarea'
CREATE INDEX [IX_FK_EstadoTarea]
ON [dbo].[TareaSet]
    ([EstadoId]);
GO

-- Creating foreign key on [TareaId] in table 'ComentarioSet'
ALTER TABLE [dbo].[ComentarioSet]
ADD CONSTRAINT [FK_ComentarioTarea]
    FOREIGN KEY ([TareaId])
    REFERENCES [dbo].[TareaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComentarioTarea'
CREATE INDEX [IX_FK_ComentarioTarea]
ON [dbo].[ComentarioSet]
    ([TareaId]);
GO

-- Creating foreign key on [UsuarioId] in table 'ComentarioSet'
ALTER TABLE [dbo].[ComentarioSet]
ADD CONSTRAINT [FK_ComentarioUsuario]
    FOREIGN KEY ([UsuarioId])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComentarioUsuario'
CREATE INDEX [IX_FK_ComentarioUsuario]
ON [dbo].[ComentarioSet]
    ([UsuarioId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------