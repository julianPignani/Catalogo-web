USE [master]
GO
/****** Object:  Database [CATALOGO_WEB_DB]    Script Date: 20/1/2024 18:06:03 ******/
CREATE DATABASE [CATALOGO_WEB_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CATALOGO_WEB_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\CATALOGO_WEB_DB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CATALOGO_WEB_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS01\MSSQL\DATA\CATALOGO_WEB_DB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CATALOGO_WEB_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET  MULTI_USER 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET QUERY_STORE = ON
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CATALOGO_WEB_DB]
GO
/****** Object:  Table [dbo].[ARTICULOS]    Script Date: 20/1/2024 18:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ARTICULOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	[IdMarca] [int] NULL,
	[IdCategoria] [int] NULL,
	[ImagenUrl] [varchar](1000) NULL,
	[Precio] [money] NULL,
 CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 20/1/2024 18:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAVORITOS]    Script Date: 20/1/2024 18:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAVORITOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[IdArticulo] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MARCAS]    Script Date: 20/1/2024 18:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MARCAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_MARCAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 20/1/2024 18:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[pass] [varchar](20) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[urlImagenPerfil] [varchar](500) NULL,
	[admin] [bit] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ARTICULOS] ON 

INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (1, N'S01', N'Galaxy S10', N'Con Bluetooth, Audio Avanzado', 1, 1, N'https://media.revistagq.com/photos/5ca5f0f3f464888999f49149/master/w_1600%2Cc_limit/samsung_galaxy_s', 170000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (2, N'M03', N'Moto G Play 7ma Gen', N'Asistente Google, más inteligente.', 5, 1, N'https://i.ebayimg.com/images/g/6KUAAOSwUKddgMC7/s-l400.jpg', 140000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (3, N'S99', N'Play 4', N'Un Juego de Regalo!', 3, 3, N'https://http2.mlstatic.com/D_NQ_NP_832387-MLA71032100437_082023-O.webp', 350000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (4, N'S56', N'Bravia 55', N'4K FULL HD', 3, 2, N'https://intercompras.com/images/productgallery/SONY_KDL-55W950A_ICECAT_4092388.jpg', 1649000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (5, N'A23', N'Apple TV', N'Conversor HDMI a Smart', 2, 3, N'https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/rfb-apple-tv-4k?wid=1144&hei=114', 7850.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (6, N'AU23', N'Auriculares Inalámbricos', N'Con Bluetooth, Audio Avanzado', 2, 4, N'https://topesdegama.com/app/uploads-topesdegama.com/2018/10/auriculares-de-Apple.jpg', 480000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (7, N'AU01', N'Auriculares Inalámbricos', N'Con Bluetooth, 12H batería.', 3, 4, N'https://www.sony.com.ar/image/7179b15fa957563d895189432c5d11ab?fmt=png-alpha&wid=960', 125000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (8, N'JP12', N'Parlante portátil', N'Con Bluetooth, Audio Avanzado', 3, 4, N'https://www.sony.com.ar/image/eb7d3b309fe5e6c87e13ff313879d850?fmt=pjpeg&wid=1200&hei=470&bgcolor=F1', 170000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (9, N'JP56', N'Parlante', N'Lo más nuevo!', 1, 4, N'https://images.fravega.com/f300/2f13f7b41a99c6631de179054477344d.jpg.webp', 470000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (10, N'JP69', N'Parlante portátil', N'Cómodo y practico!', 5, 4, N'https://images.fravega.com/f500/c97798c8b161f468b078f727a565a74b.jpg', 100000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (11, N'JP14', N'Parlante portátil', N'Cómodo y Practico!', 4, 4, N'https://digify.com.ar/wp-content/uploads/D_NQ_NP_2X_960388-MLU69494862395_052023-F-jpg.webp', 110000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (12, N'S59', N'Televisor Curvo', N'Full HD y Smart', 1, 2, N'https://images.fravega.com/f500/bc75e8546ef98a49a1d2b94f6ef0d672.jpg', 500000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (13, N'R12', N'FIT Running', N'Con Bluetooth.', 4, 3, N'https://elektragt.vtexassets.com/arquivos/ids/164779/HUAWEI-WATCH-FIT-BLACK--2-.jpg?v=63750580308723', 370000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (14, N'R74', N'SmartWatch', N'Con Bluetooth.', 1, 3, N'https://falabella.scene7.com/is/image/FalabellaPE/gsc_122167936_3258926_1?wid=800&hei=800&qlt=70', 270000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (15, N'R99', N'SmartWatch 3', N'Ideal para correr.', 3, 3, N'https://fscl01.fonpit.de/devices/19/519.png', 270000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (16, N'R03', N'Moto Watch 360', N'Ideal para nntrenamientos.', 5, 3, N'https://http2.mlstatic.com/D_NQ_NP_899321-MLA20759202082_062016-O.webp', 350000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (17, N'M88', N'Monitor ', N'Full HD', 4, 3, N'https://i.blogs.es/7f0241/huawei-monitores/1366_2000.jpg', 670000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (18, N'M77', N'Monitor LED', N'Led, Full HD.', 1, 3, N'https://http2.mlstatic.com/D_Q_NP_992802-MLU72746216408_112023-O.webp', 340000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (19, N'M66', N'Monitor', N'Nuevos Monitores Sony!', 3, 3, N'https://i.blogs.es/8551b0/m9/450_1000.jpeg', 360000.0000)
INSERT [dbo].[ARTICULOS] ([Id], [Codigo], [Nombre], [Descripcion], [IdMarca], [IdCategoria], [ImagenUrl], [Precio]) VALUES (20, N'M31', N'Monitor', N'Los Mejores Monitores!', 2, 3, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0JRcFXAUprOUJOgbtPEzcXXPBVnzOzQWOjg&usqp=CAU', 980000.0000)
SET IDENTITY_INSERT [dbo].[ARTICULOS] OFF
GO
SET IDENTITY_INSERT [dbo].[CATEGORIAS] ON 

INSERT [dbo].[CATEGORIAS] ([Id], [Descripcion]) VALUES (1, N'Celulares')
INSERT [dbo].[CATEGORIAS] ([Id], [Descripcion]) VALUES (2, N'Televisores')
INSERT [dbo].[CATEGORIAS] ([Id], [Descripcion]) VALUES (3, N'Media')
INSERT [dbo].[CATEGORIAS] ([Id], [Descripcion]) VALUES (4, N'Audio')
SET IDENTITY_INSERT [dbo].[CATEGORIAS] OFF
GO
SET IDENTITY_INSERT [dbo].[FAVORITOS] ON 

INSERT [dbo].[FAVORITOS] ([Id], [IdUser], [IdArticulo]) VALUES (5, 3, 4)
SET IDENTITY_INSERT [dbo].[FAVORITOS] OFF
GO
SET IDENTITY_INSERT [dbo].[MARCAS] ON 

INSERT [dbo].[MARCAS] ([Id], [Descripcion]) VALUES (1, N'Samsung')
INSERT [dbo].[MARCAS] ([Id], [Descripcion]) VALUES (2, N'Apple')
INSERT [dbo].[MARCAS] ([Id], [Descripcion]) VALUES (3, N'Sony')
INSERT [dbo].[MARCAS] ([Id], [Descripcion]) VALUES (4, N'Huawei')
INSERT [dbo].[MARCAS] ([Id], [Descripcion]) VALUES (5, N'Motorola')
SET IDENTITY_INSERT [dbo].[MARCAS] OFF
GO
SET IDENTITY_INSERT [dbo].[USERS] ON 

INSERT [dbo].[USERS] ([Id], [email], [pass], [nombre], [apellido], [urlImagenPerfil], [admin]) VALUES (1, N'admin@admin.com', N'admin', NULL, NULL, NULL, 1)
INSERT [dbo].[USERS] ([Id], [email], [pass], [nombre], [apellido], [urlImagenPerfil], [admin]) VALUES (2, N'user@user.com', N'user', NULL, NULL, NULL, 0)
INSERT [dbo].[USERS] ([Id], [email], [pass], [nombre], [apellido], [urlImagenPerfil], [admin]) VALUES (3, N'pignanijulian@gmail.com', N'haypoti123', N'Julián', N'Pignani', N'perfil-3-20240116232555108.jpg', 0)
INSERT [dbo].[USERS] ([Id], [email], [pass], [nombre], [apellido], [urlImagenPerfil], [admin]) VALUES (4, N'julian@marta.com', N'123456789', NULL, NULL, NULL, 0)
INSERT [dbo].[USERS] ([Id], [email], [pass], [nombre], [apellido], [urlImagenPerfil], [admin]) VALUES (5, N'julian_pignani10@gmail.com', N'julian123', NULL, NULL, NULL, 0)
INSERT [dbo].[USERS] ([Id], [email], [pass], [nombre], [apellido], [urlImagenPerfil], [admin]) VALUES (6, N'administrador@gmail.com', N'julian123', N'Julián', N'Pignani', N'perfil-6-20240118185517669.jpg', 1)
INSERT [dbo].[USERS] ([Id], [email], [pass], [nombre], [apellido], [urlImagenPerfil], [admin]) VALUES (7, N'lucia@gmail.com', N'luli123456', NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[USERS] OFF
GO
ALTER TABLE [dbo].[USERS] ADD  DEFAULT ((0)) FOR [admin]
GO
/****** Object:  StoredProcedure [dbo].[storedAltaArticulo]    Script Date: 20/1/2024 18:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[storedAltaArticulo] 
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(150),
@idMarca int,
@idCategoria int,
@imagenUrl varchar(100),
@precio money
as
insert into ARTICULOS values (@codigo , @nombre , @descripcion , @idMarca , @idCategoria , @imagenUrl, @precio );
GO
/****** Object:  StoredProcedure [dbo].[storedEliminarArticulo]    Script Date: 20/1/2024 18:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[storedEliminarArticulo]
@id int
as
DELETE FROM ARTICULOS where id = @id
GO
/****** Object:  StoredProcedure [dbo].[storedListar]    Script Date: 20/1/2024 18:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[storedListar] as
SELECT A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, M.Descripcion as Marca, M.Id as IdMarca, C.Id as IdCategoria, C.Descripcion as Categoria
FROM ARTICULOS A, MARCAS M, CATEGORIAS C 
WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria
GO
/****** Object:  StoredProcedure [dbo].[storedModificarArticulo]    Script Date: 20/1/2024 18:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[storedModificarArticulo]
@codigo varchar(50),
@nombre varchar(50),
@idMarca int,
@idCategoria int,
@precio money,
@descripcion varchar(150),
@imagenUrl varchar(100),
@id int
as
UPDATE ARTICULOS SET Codigo = @codigo, Nombre = @nombre, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio , Descripcion = @descripcion, ImagenUrl = @imagenUrl
where id = @id
GO
/****** Object:  StoredProcedure [dbo].[storedregistrarNuevo]    Script Date: 20/1/2024 18:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[storedregistrarNuevo]
    @email VARCHAR(50),
    @pass VARCHAR(50),
	@admin BIT
AS
    INSERT INTO USERS (Email, Pass, Admin)
    OUTPUT inserted.Id
    VALUES (@email, @pass, @admin );




GO
USE [master]
GO
ALTER DATABASE [CATALOGO_WEB_DB] SET  READ_WRITE 
GO
