-- Verificar si la base de datos existe antes de crearla
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QualaDB')
BEGIN
    -- Crear la base de datos
    CREATE DATABASE QualaDB;
    PRINT 'La base de datos QualaDB ha sido creada.';
END
ELSE
BEGIN
    PRINT 'La base de datos QualaDB ya existe. No se realizará la creación.';
END

-- Utilizar la base de datos
USE QualaDB;

-- Verificar si la tabla Moneda existe antes de crearla
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Moneda]') AND type in (N'U'))
BEGIN
    -- Crear tabla Moneda
    CREATE TABLE [dbo].[Moneda](
        [MonedaId] [int] IDENTITY(1,1) NOT NULL,
        [Moneda] [nvarchar](100) NOT NULL,
        CONSTRAINT [PK_Moneda] PRIMARY KEY CLUSTERED ([MonedaId] ASC)
    );
    PRINT 'La tabla Moneda ha sido creada.';
END
ELSE
BEGIN
    PRINT 'La tabla Moneda ya existe. No se realizará la creación.';
END

-- Verificar si la tabla Sucursal existe antes de crearla
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sucursal]') AND type in (N'U'))
BEGIN
    -- Crear tabla Sucursal
    CREATE TABLE [dbo].[Sucursal](
        [Codigo] [int] IDENTITY(1,1) NOT NULL,
        [Descripcion] [nvarchar](250) NOT NULL,
        [Direccion] [nvarchar](250) NOT NULL,
        [Identificacion] [nvarchar](50) NOT NULL,
        [Fecha] [datetime] NOT NULL,
        [MonedaId] [int] NOT NULL,
        CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED ([Codigo] ASC),
        CONSTRAINT [FK_Sucursal_Moneda] FOREIGN KEY ([MonedaId]) REFERENCES [dbo].[Moneda] ([MonedaId])
    );
    PRINT 'La tabla Sucursal ha sido creada.';
END
ELSE
BEGIN
    PRINT 'La tabla Sucursal ya existe. No se realizará la creación.';
END
