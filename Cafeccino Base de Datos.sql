USE [master]
GO
/****** Object:  Database [Cafeccino]    Script Date: 20/5/2025 23:32:23 ******/
CREATE DATABASE [Cafeccino]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cafeccino', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Cafeccino.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cafeccino_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Cafeccino_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Cafeccino] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cafeccino].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cafeccino] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cafeccino] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cafeccino] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cafeccino] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cafeccino] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cafeccino] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cafeccino] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cafeccino] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cafeccino] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cafeccino] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cafeccino] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cafeccino] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cafeccino] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cafeccino] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cafeccino] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cafeccino] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cafeccino] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cafeccino] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cafeccino] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cafeccino] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cafeccino] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cafeccino] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cafeccino] SET RECOVERY FULL 
GO
ALTER DATABASE [Cafeccino] SET  MULTI_USER 
GO
ALTER DATABASE [Cafeccino] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cafeccino] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cafeccino] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cafeccino] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cafeccino] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cafeccino] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Cafeccino', N'ON'
GO
ALTER DATABASE [Cafeccino] SET QUERY_STORE = ON
GO
ALTER DATABASE [Cafeccino] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Cafeccino]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[DNI] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](320) NOT NULL,
	[NumTelefono] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Cliente] PRIMARY KEY CLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DV]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DV](
	[Tabla] [nvarchar](20) NOT NULL,
	[DVH] [varchar](64) NULL,
	[DVV] [varchar](64) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evento]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[CodEvento] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](20) NOT NULL,
	[Fecha] [nvarchar](10) NOT NULL,
	[Hora] [nvarchar](8) NOT NULL,
	[Modulo] [nvarchar](50) NOT NULL,
	[Evento] [nvarchar](100) NOT NULL,
	[Criticidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[CodFactura] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[PrecioTotal] [int] NOT NULL,
	[MetodoPago] [nvarchar](20) NOT NULL,
	[Banco] [nvarchar](50) NULL,
	[MarcaTarjeta] [nvarchar](30) NULL,
	[TipoTarjeta] [nvarchar](20) NULL,
	[DNI] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Factura] PRIMARY KEY CLUSTERED 
(
	[CodFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[CodFamilia] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Tipo] [bit] NOT NULL,
	[CodPermiso] [int] NULL,
	[CodComp] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[CodProducto] [nvarchar](17) NOT NULL,
	[CodFactura] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Item] PRIMARY KEY CLUSTERED 
(
	[CodProducto] ASC,
	[CodFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemOrden]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemOrden](
	[CodProducto] [nvarchar](17) NOT NULL,
	[CodOrdenCompra] [int] NOT NULL,
	[Cotizacion] [float] NOT NULL,
	[StockCompra] [int] NOT NULL,
	[StockRecepcion] [int] NULL,
	[FechaEntrega] [datetime] NULL,
	[CodFactura] [nvarchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemSolicitud]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemSolicitud](
	[CodProducto] [nvarchar](17) NOT NULL,
	[CodSolicitud] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrdenCompra]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdenCompra](
	[CodOrdenCompra] [int] IDENTITY(1,1) NOT NULL,
	[CUIT] [nvarchar](11) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[PrecioTotal] [float] NOT NULL,
	[NumTransaccion] [nvarchar](30) NOT NULL,
	[CodFactura] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[CodPermiso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[CodPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[CodProducto] [nvarchar](17) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Precio] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[MaxStock] [int] NOT NULL,
	[MinStock] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Cafe] PRIMARY KEY CLUSTERED 
(
	[CodProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto_C]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto_C](
	[CodProducto] [nvarchar](17) NOT NULL,
	[Fecha] [nvarchar](10) NOT NULL,
	[Hora] [nvarchar](8) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Precio] [int] NOT NULL,
	[Stock] [int] NOT NULL,
	[EstadoActual] [int] NOT NULL,
	[MaxStock] [int] NOT NULL,
	[MinStock] [int] NOT NULL,
	[Activo] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[CUIT] [nvarchar](11) NOT NULL,
	[RazonSocial] [nvarchar](100) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](320) NOT NULL,
	[NumTelefono] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](100) NULL,
	[CuentaBancaria] [nvarchar](34) NULL,
	[Activo] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProveedorSolicitud]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProveedorSolicitud](
	[CUIT] [nvarchar](11) NOT NULL,
	[CodSolicitud] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SolicitudCotizacion]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SolicitudCotizacion](
	[CodSolicitud] [int] IDENTITY(1,1) NOT NULL,
	[FechaEmision] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 20/5/2025 23:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[DNI] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[FechaNac] [date] NOT NULL,
	[Email] [nvarchar](320) NOT NULL,
	[NumTelefono] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Contraseña] [nvarchar](128) NOT NULL,
	[Rol] [nvarchar](20) NOT NULL,
	[Bloqueado] [bit] NOT NULL,
	[Desactivado] [bit] NOT NULL,
	[IntentosFallidos] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[DNI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Cliente] ([DNI], [Nombre], [Apellido], [Direccion], [Email], [NumTelefono], [Activo]) VALUES (10000000, N'joaco', N'joaco', N'X+gRskPsG43FVVBzHhEg0Q==', N'joaco@hotmail.com', N'1169565548', 1)
INSERT [dbo].[Cliente] ([DNI], [Nombre], [Apellido], [Direccion], [Email], [NumTelefono], [Activo]) VALUES (43092388, N'matias', N'elebi', N'8hjouSNtkZpU/eT9EbenQg==', N'mati@hotmail.com', N'1169565548', 1)
GO
INSERT [dbo].[DV] ([Tabla], [DVH], [DVV]) VALUES (N'Cliente', N'bfd4aa0f30336536d776f812e0c1a1d31685571cdc3c8c9229b3d5d3aaa9b3a3', N'e3ba10b0206c20119cf8e9d451ca9d049c3736e935b948e4994cac7f2fcfb4eb')
INSERT [dbo].[DV] ([Tabla], [DVH], [DVV]) VALUES (N'Factura', N'975bc2826a87fa14833b64ca67e36a57f7525bd845c45b355be10cf640568ad0', N'98e084182caa1d021b70aab759aecb6822263b767381827fe433e2217f3b09f4')
INSERT [dbo].[DV] ([Tabla], [DVH], [DVV]) VALUES (N'Item', N'9c6cb5c3020616fe34a04dd81dbe8244dfe493206391be8f42648f1135c6efd3', N'18ec4680b1d8280690c776eb9990c256b6eddbc3978679e8ffa5eed4685e36db')
INSERT [dbo].[DV] ([Tabla], [DVH], [DVV]) VALUES (N'ItemOrden', N'f941ca6138d4ce5ce681dd995d0feca2af4297a3ba56918aadda3cc6fa344256', N'f941ca6138d4ce5ce681dd995d0feca2af4297a3ba56918aadda3cc6fa344256')
INSERT [dbo].[DV] ([Tabla], [DVH], [DVV]) VALUES (N'ItemSolicitud', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855')
INSERT [dbo].[DV] ([Tabla], [DVH], [DVV]) VALUES (N'Producto', N'321f95529b9a2a7205352200d537c50fa755cbf9398f6f09ec497bf0d2646385', N'c715e02ec758b376d01fe2600a35447741f3ac70297a98fe4824237923768409')
INSERT [dbo].[DV] ([Tabla], [DVH], [DVV]) VALUES (N'Producto_C', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855')
INSERT [dbo].[DV] ([Tabla], [DVH], [DVV]) VALUES (N'OrdenCompra', N'd4c61f693b9be372ebbadb31e5eb31894b6623c1fe5ac6674f72c536632ceaa8', N'd4c61f693b9be372ebbadb31e5eb31894b6623c1fe5ac6674f72c536632ceaa8')
INSERT [dbo].[DV] ([Tabla], [DVH], [DVV]) VALUES (N'Proveedor', N'571112374ef3c39f7b2da0b803527b434cbd28c9effde00f41187d1a6656aa09', N'571112374ef3c39f7b2da0b803527b434cbd28c9effde00f41187d1a6656aa09')
INSERT [dbo].[DV] ([Tabla], [DVH], [DVV]) VALUES (N'ProveedorSolicitud', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855')
INSERT [dbo].[DV] ([Tabla], [DVH], [DVV]) VALUES (N'SolicitudCotizacion', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855')
GO
SET IDENTITY_INSERT [dbo].[Evento] ON 

INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (1, N'mati', N'2025-03-03', N'18:51:07', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (2, N'mati', N'2025-03-08', N'02:18:46', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (3, N'mati', N'2025-03-08', N'02:19:01', N'Sesiones', N'Cierre de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (4, N'mati', N'2025-03-08', N'02:19:09', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (24, N'mati', N'2025-03-08', N'03:50:49', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (33, N'mati', N'2025-03-09', N'17:45:44', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (34, N'mati', N'2025-03-18', N'22:18:09', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (35, N'mati', N'2025-03-18', N'22:19:10', N'Cliente', N'Registro de cliente', 4)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (36, N'mati', N'2025-03-18', N'22:19:16', N'Ventas', N'Generación de factura', 3)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (37, N'mati', N'2025-03-18', N'22:22:02', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (38, N'mati', N'2025-03-20', N'16:27:45', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (39, N'mati', N'2025-03-20', N'16:29:59', N'Productos', N'Registro de producto', 4)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (40, N'mati', N'2025-03-20', N'16:30:05', N'Productos', N'Borrado lógico de producto', 4)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (41, N'mati', N'2025-03-20', N'16:30:14', N'Productos', N'Restauración de producto', 4)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (42, N'mati', N'2025-03-20', N'16:34:17', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (43, N'mati', N'2025-03-20', N'16:35:39', N'Ventas', N'Generación de factura', 3)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (44, N'mati', N'2025-03-20', N'16:37:46', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (45, N'mati', N'2025-03-20', N'16:39:33', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (46, N'mati', N'2025-03-20', N'16:42:30', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (47, N'mati', N'2025-03-20', N'16:49:22', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (54, N'mati', N'2025-03-20', N'17:54:43', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (55, N'mati', N'2025-03-20', N'17:55:50', N'Clientes', N'Serialización XML de clientes', 5)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (56, N'mati', N'2025-03-20', N'17:56:24', N'Clientes', N'Des-serialización XML de clientes', 5)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (57, N'mati', N'2025-03-20', N'18:38:11', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (58, N'mati', N'2025-03-20', N'18:38:24', N'Clientes', N'Borrado lógico de cliente', 4)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (59, N'mati', N'2025-03-20', N'18:38:36', N'Clientes', N'Restauración de cliente', 4)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (64, N'mati', N'2025-03-20', N'18:51:22', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (65, N'mati', N'2025-03-20', N'18:51:42', N'Clientes', N'Serialización XML de clientes', 5)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (66, N'mati', N'2025-03-20', N'18:52:21', N'Clientes', N'Des-serialización XML de clientes', 5)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (5, N'mati', N'2025-03-08', N'02:19:13', N'Sesiones', N'Cierre de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (6, N'mati', N'2025-03-08', N'02:19:20', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (7, N'mati', N'2025-03-08', N'02:20:47', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (8, N'mati', N'2025-03-08', N'02:20:50', N'Sesiones', N'Cierre de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (9, N'mati', N'2025-03-08', N'02:21:00', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (10, N'mati', N'2025-03-08', N'02:21:26', N'Sesiones', N'Cierre de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (11, N'mati', N'2025-03-08', N'02:21:36', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (12, N'mati', N'2025-03-08', N'02:23:33', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (13, N'mati', N'2025-03-08', N'02:23:37', N'Sesiones', N'Cierre de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (14, N'mati', N'2025-03-08', N'02:23:44', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (15, N'mati', N'2025-03-08', N'02:24:17', N'Sesiones', N'Cierre de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (16, N'mati', N'2025-03-08', N'02:24:24', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (17, N'mati', N'2025-03-08', N'02:50:32', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (18, N'mati', N'2025-03-08', N'02:55:06', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (19, N'mati', N'2025-03-08', N'03:00:12', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (20, N'mati', N'2025-03-08', N'03:06:06', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (21, N'mati', N'2025-03-08', N'03:08:45', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (22, N'mati', N'2025-03-08', N'03:09:47', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (23, N'mati', N'2025-03-08', N'03:19:58', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (25, N'mati', N'2025-03-09', N'17:15:53', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (26, N'mati', N'2025-03-09', N'17:17:09', N'Productos', N'Registro de producto', 4)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (27, N'mati', N'2025-03-09', N'17:17:19', N'Productos', N'Borrado lógico de producto', 4)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (28, N'mati', N'2025-03-09', N'17:17:27', N'Productos', N'Restauración de producto', 4)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (29, N'mati', N'2025-03-09', N'17:18:16', N'Proveedores', N'Registro de proveedor', 4)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (30, N'mati', N'2025-03-09', N'17:19:11', N'Compras', N'Registro de orden de compra', 3)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (31, N'mati', N'2025-03-09', N'17:20:57', N'Cliente', N'Registro de cliente', 4)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (32, N'mati', N'2025-03-09', N'17:21:02', N'Ventas', N'Generación de factura', 3)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (48, N'mati', N'2025-03-20', N'17:04:29', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (49, N'mati', N'2025-03-20', N'17:07:41', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (50, N'mati', N'2025-03-20', N'17:09:03', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (51, N'mati', N'2025-03-20', N'17:12:01', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (52, N'mati', N'2025-03-20', N'17:20:34', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (53, N'mati', N'2025-03-20', N'17:21:32', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (60, N'mati', N'2025-03-20', N'18:41:14', N'Sesiones', N'Inicio de sesión', 1)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (61, N'mati', N'2025-03-20', N'18:41:30', N'Clientes', N'Serialización XML de clientes', 5)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (62, N'mati', N'2025-03-20', N'18:41:42', N'Clientes', N'Des-serialización XML de clientes', 5)
INSERT [dbo].[Evento] ([CodEvento], [Login], [Fecha], [Hora], [Modulo], [Evento], [Criticidad]) VALUES (63, N'mati', N'2025-03-20', N'18:41:52', N'Clientes', N'Serialización XML de clientes', 5)
SET IDENTITY_INSERT [dbo].[Evento] OFF
GO
SET IDENTITY_INSERT [dbo].[Factura] ON 

INSERT [dbo].[Factura] ([CodFactura], [Fecha], [PrecioTotal], [MetodoPago], [Banco], [MarcaTarjeta], [TipoTarjeta], [DNI]) VALUES (1, CAST(N'2025-03-09T17:21:00' AS SmallDateTime), 500, N'Efectivo', NULL, NULL, NULL, 43092388)
INSERT [dbo].[Factura] ([CodFactura], [Fecha], [PrecioTotal], [MetodoPago], [Banco], [MarcaTarjeta], [TipoTarjeta], [DNI]) VALUES (2, CAST(N'2025-03-18T22:19:00' AS SmallDateTime), 300, N'Efectivo', NULL, NULL, NULL, 10000000)
INSERT [dbo].[Factura] ([CodFactura], [Fecha], [PrecioTotal], [MetodoPago], [Banco], [MarcaTarjeta], [TipoTarjeta], [DNI]) VALUES (3, CAST(N'2025-03-20T16:36:00' AS SmallDateTime), 300, N'Efectivo', NULL, NULL, NULL, 10000000)
SET IDENTITY_INSERT [dbo].[Factura] OFF
GO
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 1, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 2, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 3, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 4, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 5, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 6, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 7, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 8, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (100, N'Vendedor1', 0, NULL, 104)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 9, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (103, N'Administrador', 0, 1, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (103, N'Administrador', 0, 2, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (103, N'Administrador', 0, 3, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (103, N'Administrador', 0, 4, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (103, N'Administrador', 0, 5, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (103, N'Administrador', 0, 6, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (103, N'Administrador', 0, 7, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 10, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 11, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 12, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 13, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 14, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (102, N'Vendedor', 1, NULL, 100)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (105, N'Vendedor2', 0, 5, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (104, N'Comprador1', 0, 6, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (104, N'Comprador1', 0, 3, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (104, N'Comprador1', 0, NULL, 105)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (105, N'Vendedor2', 0, 10, NULL)
INSERT [dbo].[Familia] ([CodFamilia], [Nombre], [Tipo], [CodPermiso], [CodComp]) VALUES (101, N'Admin', 1, 15, NULL)
GO
INSERT [dbo].[Item] ([CodProducto], [CodFactura], [Cantidad]) VALUES (N'1', 1, 5)
INSERT [dbo].[Item] ([CodProducto], [CodFactura], [Cantidad]) VALUES (N'1', 2, 3)
INSERT [dbo].[Item] ([CodProducto], [CodFactura], [Cantidad]) VALUES (N'2', 3, 3)
GO
INSERT [dbo].[ItemOrden] ([CodProducto], [CodOrdenCompra], [Cotizacion], [StockCompra], [StockRecepcion], [FechaEntrega], [CodFactura]) VALUES (N'1', 1, 100, 2, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[OrdenCompra] ON 

INSERT [dbo].[OrdenCompra] ([CodOrdenCompra], [CUIT], [FechaCreacion], [PrecioTotal], [NumTransaccion], [CodFactura]) VALUES (1, N'20430923898', CAST(N'2025-03-09T17:19:11.340' AS DateTime), 242, N'12', N'321')
SET IDENTITY_INSERT [dbo].[OrdenCompra] OFF
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (1, N'gestionDeUsuarios')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (2, N'gestionDePerfiles')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (3, N'gestionDeProductos')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (4, N'gestionDeClientes')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (5, N'facturar')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (6, N'registrarCompra')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (7, N'generarReporte')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (8, N'bitacoraDeEventos')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (9, N'bitacoraDeCambios')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (10, N'respaldos')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (11, N'generarSolicitudDeCotizacion')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (12, N'generarOrdenDeCompra')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (13, N'verificarRecepciónDeProductos')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (14, N'gestionDeProveedores')
INSERT [dbo].[Permiso] ([CodPermiso], [Nombre]) VALUES (15, N'generarReporteInteligente')
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
INSERT [dbo].[Producto] ([CodProducto], [Tipo], [Nombre], [Precio], [Stock], [Activo], [MaxStock], [MinStock]) VALUES (N'1', N'cafe', N'cafe con leche', 100, 42, 1, 100, 5)
INSERT [dbo].[Producto] ([CodProducto], [Tipo], [Nombre], [Precio], [Stock], [Activo], [MaxStock], [MinStock]) VALUES (N'2', N'Cafe', N'Cafe moka', 100, 47, 1, 100, 5)
GO
INSERT [dbo].[Proveedor] ([CUIT], [RazonSocial], [Nombre], [Email], [NumTelefono], [Direccion], [CuentaBancaria], [Activo]) VALUES (N'20430923898', N'asd', N'matias', N'matiaselebi@hotmail.com', N'1169565548', N'lorai', N'asdsad', 1)
GO
INSERT [dbo].[Usuario] ([DNI], [Nombre], [Apellido], [FechaNac], [Email], [NumTelefono], [Username], [Contraseña], [Rol], [Bloqueado], [Desactivado], [IntentosFallidos]) VALUES (43092389, N'Matias', N'Elebi', CAST(N'2000-12-15' AS Date), N'matias@hotmail.com', N'1169565548', N'mati', N'754068f93ca0903e1db7f0ad3ec5a616179c738f462959dd2380b6e2743680db', N'Admin', 0, 0, 0)
GO
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF__Producto__Activo__01142BA1]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([DNI])
REFERENCES [dbo].[Cliente] ([DNI])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[Familia]  WITH CHECK ADD  CONSTRAINT [FK_Familia_Permiso] FOREIGN KEY([CodPermiso])
REFERENCES [dbo].[Permiso] ([CodPermiso])
GO
ALTER TABLE [dbo].[Familia] CHECK CONSTRAINT [FK_Familia_Permiso]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Cafe] FOREIGN KEY([CodProducto])
REFERENCES [dbo].[Producto] ([CodProducto])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Cafe]
GO
ALTER TABLE [dbo].[Item]  WITH CHECK ADD  CONSTRAINT [FK_Item_Factura] FOREIGN KEY([CodFactura])
REFERENCES [dbo].[Factura] ([CodFactura])
GO
ALTER TABLE [dbo].[Item] CHECK CONSTRAINT [FK_Item_Factura]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarEstadoProducto]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActualizarEstadoProducto]
	-- Add the parameters for the stored procedure here
	@CodProducto nvarchar(17),
	@Tipo nvarchar(50),
	@Nombre nvarchar(50),
	@Precio int,
	@Stock int,
	@MaxStock int,
	@MinStock int,
	@Activo bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Producto SET Tipo = @Tipo, Nombre = @Nombre, Precio = @Precio, Stock = @Stock, MaxStock = @MaxStock, MinStock = @MinStock, Activo = @Activo WHERE CodProducto = @CodProducto

END
GO
/****** Object:  StoredProcedure [dbo].[BloqueoUsuarioDNI]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BloqueoUsuarioDNI]
	-- Add the parameters for the stored procedure here
	@DNI int,
	@Bloqueado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Usuario SET Bloqueado = @Bloqueado, IntentosFallidos = 0 WHERE DNI = @DNI
END
GO
/****** Object:  StoredProcedure [dbo].[BloqueoUsuarioUsername]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BloqueoUsuarioUsername]
	-- Add the parameters for the stored procedure here
	@Username nvarchar(20),
	@Bloqueado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Usuario SET Bloqueado = @Bloqueado WHERE Username = @Username
END
GO
/****** Object:  StoredProcedure [dbo].[DesactivacionCliente]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CrEATE PROCEDURE [dbo].[DesactivacionCliente]
	-- Add the parameters for the stored procedure here
	@DNI int,
	@Activo bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Cliente SET Activo = @Activo WHERE DNI = @DNI
END
GO
/****** Object:  StoredProcedure [dbo].[DesactivacionProducto]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DesactivacionProducto]
	-- Add the parameters for the stored procedure here
	@CodProducto nvarchar(17),
	@Activo bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Producto SET Activo = @Activo WHERE CodProducto = @CodProducto
END
GO
/****** Object:  StoredProcedure [dbo].[DesactivacionUsuario]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DesactivacionUsuario]
	-- Add the parameters for the stored procedure here
	@DNI int,
	@Desactivado bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Usuario SET Desactivado = @Desactivado WHERE DNI = @DNI
END
GO
/****** Object:  StoredProcedure [dbo].[DesactivarUsuario]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DesactivarUsuario]
	-- Add the parameters for the stored procedure here
	@DNI int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Usuario SET Desactivado = 1 WHERE DNI = @DNI
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarCliente]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarCliente]
	-- Add the parameters for the stored procedure here
	@DNI int,
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
	@Direccion nvarchar(100),
	@Email nvarchar(320),
	@NumTelefono nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Cliente(DNI, Nombre, Apellido, Direccion, Email, NumTelefono, Activo) VALUES (@DNI, @Nombre, @Apellido, @Direccion, @Email, @NumTelefono, 1)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarEvento]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarEvento]
	-- Add the parameters for the stored procedure here
	@Login nvarchar(20),
	@Fecha nvarchar(50),
	@Hora nvarchar(50),
	@Modulo nvarchar(50),
	@Evento nvarchar(100),
	@Criticidad int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Evento(Login, Fecha, Hora, Modulo, Evento, Criticidad) VALUES (@Login, @Fecha, @Hora, @Modulo, @Evento, @Criticidad)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarFacturaEfectivo]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarFacturaEfectivo]
	-- Add the parameters for the stored procedure here
	@Fecha smalldatetime,
	@PrecioTotal int,
	@MetodoPago nvarchar(20),
	@DNI int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Factura(Fecha, PrecioTotal, MetodoPago, DNI) VALUES (@Fecha, @PrecioTotal, @MetodoPago, @DNI)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarFacturaTarjeta]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarFacturaTarjeta]
	-- Add the parameters for the stored procedure here
	@Fecha smalldatetime,
	@PrecioTotal int,
	@MetodoPago nvarchar(20),
	@Banco nvarchar(50),
	@MarcaTarjeta nvarchar(30),
	@TipoTarjeta nvarchar(20),
	@DNI int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Factura(Fecha, PrecioTotal, MetodoPago, Banco, MarcaTarjeta, TipoTarjeta, DNI) VALUES (@Fecha, @PrecioTotal, @MetodoPago, @Banco, @MarcaTarjeta, @TipoTarjeta, @DNI)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarOrdenCompra]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarOrdenCompra]
	-- Add the parameters for the stored procedure here
	@CUIT nvarchar(11),
	@FechaCreacion datetime,
	@PrecioTotal float,
	@NumTransaccion nvarchar(30),
	@CodFactura nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO OrdenCompra(CUIT, FechaCreacion, PrecioTotal, NumTransaccion, CodFactura) VALUES (@CUIT, @FechaCreacion, @PrecioTotal, @NumTransaccion, @CodFactura)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarProducto]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarProducto]
	-- Add the parameters for the stored procedure here
	@CodProducto nvarchar(17),
	@Tipo nvarchar(50),
	@Nombre nvarchar(50),
	@Precio int,
	@Stock int,
	@MaxStock int,
	@MinStock int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Producto(CodProducto, Tipo, Nombre, Precio, Stock, Activo, MaxStock, MinStock) VALUES (@CodProducto, @Tipo, @Nombre, @Precio, @Stock, 1, @MaxStock, @MinStock)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarSolicitudCotizacion]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarSolicitudCotizacion]
	-- Add the parameters for the stored procedure here
	@Fecha datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO SolicitudCotizacion(FechaEmision) VALUES (@Fecha)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertarUsuario]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertarUsuario]
	-- Add the parameters for the stored procedure here
	@DNI int,
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
	@FechaNac date,
	@Email nvarchar(320),
	@NumTelefono nvarchar(50),
	@Username nvarchar(20),
	@Contraseña nvarchar(128),
	@Rol nvarchar(20)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Usuario(DNI, Nombre, Apellido, FechaNac, Email, NumTelefono, Username, Contraseña, Rol, Bloqueado, Desactivado, IntentosFallidos) VALUES (@DNI, @Nombre, @Apellido, @FechaNac, @Email, @NumTelefono, @Username, @Contraseña, @Rol, 0, 0, 0)
END
GO
/****** Object:  StoredProcedure [dbo].[IntentoFallido]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IntentoFallido]
	-- Add the parameters for the stored procedure here
	@Username nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Usuario SET IntentosFallidos = IntentosFallidos+1 WHERE Username = @Username
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarCliente]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarCliente]
	-- Add the parameters for the stored procedure here
	@DNI int,
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
	@Direccion nvarchar(100),
	@Email nvarchar(320),
	@NumTelefono nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Cliente SET Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Email = @Email, NumTelefono = @NumTelefono WHERE DNI = @DNI
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarPassword]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarPassword]
	-- Add the parameters for the stored procedure here
	@DNI int,
	@Contraseña nvarchar(128)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Usuario SET Contraseña = @Contraseña WHERE DNI = @DNI
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarProducto]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarProducto]
	-- Add the parameters for the stored procedure here
	@CodProducto nvarchar(17),
	@Tipo nvarchar(50),
	@Nombre nvarchar(50),
	@Precio int,
	@Stock int,
	@MaxStock int,
	@MinStock int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Producto SET Tipo = @Tipo, Nombre = @Nombre, Precio = @Precio, Stock = @Stock, MaxStock = @MaxStock, MinStock = @MinStock WHERE CodProducto = @CodProducto
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarProveedor]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarProveedor]
	-- Add the parameters for the stored procedure here
	@CUIT nvarchar(11),
	@RazonSocial nvarchar(100),
	@Nombre nvarchar(50),
	@Email nvarchar(320),
	@NumTelefono nvarchar(50),
	@Direccion nvarchar(100),
	@CuentaBancaria nvarchar(34)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Proveedor SET RazonSocial = @RazonSocial, Nombre = @Nombre, Email = @Email, NumTelefono = @NumTelefono, Direccion = @Direccion, CuentaBancaria = @CuentaBancaria WHERE CUIT = @CUIT

END
GO
/****** Object:  StoredProcedure [dbo].[ModificarUsuario]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ModificarUsuario]
	-- Add the parameters for the stored procedure here
	@DNI int,
	@Nombre nvarchar(50),
	@Apellido nvarchar(50),
	@FechaNac date,
	@Email nvarchar(320),
	@NumTelefono nvarchar(50),
	@Username nvarchar(20),
	@Rol nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, FechaNac = @FechaNac, Email = @Email, NumTelefono = @NumTelefono, Username = @Username, Rol = @Rol WHERE DNI = @DNI
END
GO
/****** Object:  StoredProcedure [dbo].[PreRegistrarProveedor]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PreRegistrarProveedor]
	-- Add the parameters for the stored procedure here
	@CUIT nvarchar(11),
	@RazonSocial nvarchar(100),
	@Nombre nvarchar(50),
	@Email nvarchar(320),
	@NumTelefono nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Proveedor(CUIT, RazonSocial, Nombre, Email, NumTelefono, Activo) VALUES (@CUIT, @RazonSocial, @Nombre, @Email, @NumTelefono, 1)
END
GO
/****** Object:  StoredProcedure [dbo].[RecibirCompra]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RecibirCompra]
	-- Add the parameters for the stored procedure here
	@CodProducto nvarchar(17),
	@StockRecepcion int,
	@FechaEntrega datetime,
	@CodFactura nvarchar(30)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE ItemOrden SET StockRecepcion = @StockRecepcion, FechaEntrega = @FechaEntrega, CodFactura = @CodFactura WHERE CodProducto = @CodProducto
	UPDATE Producto SET Stock += @StockRecepcion WHERE CodProducto = @CodProducto
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarFamilia]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RegistrarFamilia]
	-- Add the parameters for the stored procedure here
	@CodFamilia int,
	@Nombre nvarchar(50),
	@Tipo bit,
	@CodPermiso int,
	@CodComp int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Familia(CodFamilia, Nombre, Tipo, CodPermiso, CodComp) VALUES (@CodFamilia, @Nombre, @Tipo, @CodPermiso, @CodComp)
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarItem]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RegistrarItem] 
	-- Add the parameters for the stored procedure here
	@CodFact int,
	@CodProducto nvarchar(17),
	@Cantidad int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Item (CodFactura, CodProducto, Cantidad) VALUES (@CodFact, @CodProducto, @Cantidad)
	UPDATE Producto SET Stock = Stock-@Cantidad WHERE CodProducto = @CodProducto
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarItemOrden]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RegistrarItemOrden]
	-- Add the parameters for the stored procedure here
	@CodProducto nvarchar(17),
	@CodOrdenCompra int,
	@Cotizacion int,
	@StockCompra int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO ItemOrden (CodProducto, CodOrdenCompra, Cotizacion, StockCompra) VALUES (@CodOrdenCompra, @CodOrdenCompra, @Cotizacion, @StockCompra)
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarItemSolicitud]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RegistrarItemSolicitud]
	-- Add the parameters for the stored procedure here
	@CodSolicitud int,
	@CodProducto nvarchar(17)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO ItemSolicitud (CodSolicitud, CodProducto) VALUES (@CodSolicitud, @CodProducto)
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarProveedor]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RegistrarProveedor]
	-- Add the parameters for the stored procedure here
	@CUIT nvarchar(11),
	@Direccion nvarchar(100),
	@CuentaBancaria nvarchar(34)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Proveedor SET Direccion = @Direccion, CuentaBancaria = @CuentaBancaria WHERE CUIT = @CUIT

END

GO
/****** Object:  StoredProcedure [dbo].[RegistrarProveedorCompleto]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RegistrarProveedorCompleto]
	-- Add the parameters for the stored procedure here
	@CUIT nvarchar(11),
	@RazonSocial nvarchar(100),
	@Nombre nvarchar(50),
	@Email nvarchar(320),
	@NumTelefono nvarchar(50),
	@Direccion nvarchar(100),
	@CuentaBancaria nvarchar(34)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Proveedor(CUIT, RazonSocial, Nombre, Email, NumTelefono, Direccion, CuentaBancaria, Activo) VALUES (@CUIT, @RazonSocial, @Nombre, @Email, @NumTelefono, @Direccion, @CuentaBancaria, 1)

END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarProveedorSolicitud]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RegistrarProveedorSolicitud]
	-- Add the parameters for the stored procedure here
	@CodSolicitud int,
	@CUIT nvarchar(11)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO ProveedorSolicitud(CodSolicitud, CUIT) VALUES (@CodSolicitud, @CUIT)
END
GO
/****** Object:  StoredProcedure [dbo].[ReiniciarIntentosFallidos]    Script Date: 20/5/2025 23:32:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ReiniciarIntentosFallidos]
	-- Add the parameters for the stored procedure here
	@Username varchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Usuario SET IntentosFallidos = 0 WHERE Username = @Username
END
GO
USE [master]
GO
ALTER DATABASE [Cafeccino] SET  READ_WRITE 
GO
