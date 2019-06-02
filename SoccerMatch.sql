USE [master]
GO
/****** Object:  Database [SoccerMatch]    Script Date: 2/06/2019 14:12:23 ******/
CREATE DATABASE [SoccerMatch]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SoccerMatch', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SoccerMatch.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SoccerMatch_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SoccerMatch_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SoccerMatch] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SoccerMatch].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SoccerMatch] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SoccerMatch] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SoccerMatch] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SoccerMatch] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SoccerMatch] SET ARITHABORT OFF 
GO
ALTER DATABASE [SoccerMatch] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SoccerMatch] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SoccerMatch] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SoccerMatch] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SoccerMatch] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SoccerMatch] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SoccerMatch] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SoccerMatch] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SoccerMatch] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SoccerMatch] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SoccerMatch] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SoccerMatch] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SoccerMatch] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SoccerMatch] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SoccerMatch] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SoccerMatch] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SoccerMatch] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SoccerMatch] SET RECOVERY FULL 
GO
ALTER DATABASE [SoccerMatch] SET  MULTI_USER 
GO
ALTER DATABASE [SoccerMatch] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SoccerMatch] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SoccerMatch] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SoccerMatch] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SoccerMatch] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SoccerMatch', N'ON'
GO
ALTER DATABASE [SoccerMatch] SET QUERY_STORE = OFF
GO
USE [SoccerMatch]
GO
/****** Object:  Table [dbo].[Alquiler]    Script Date: 2/06/2019 14:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alquiler](
	[CAlquiler] [int] IDENTITY(1,1) NOT NULL,
	[CEquipo] [int] NOT NULL,
	[CCancha] [int] NOT NULL,
	[DFechaInicio] [datetime] NOT NULL,
	[NumHoras] [int] NOT NULL,
	[MDescuento] [money] NOT NULL,
	[MTotal] [money] NOT NULL,
	[FPagado] [bit] NOT NULL,
 CONSTRAINT [Alquiler_pk] PRIMARY KEY CLUSTERED 
(
	[CAlquiler] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calle]    Script Date: 2/06/2019 14:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calle](
	[CCalle] [int] IDENTITY(1,1) NOT NULL,
	[NCalle] [varchar](100) NOT NULL,
	[CDistrito] [int] NOT NULL,
 CONSTRAINT [Calle_pk] PRIMARY KEY CLUSTERED 
(
	[CCalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cancha]    Script Date: 2/06/2019 14:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cancha](
	[CCancha] [int] IDENTITY(1,1) NOT NULL,
	[CPropietario] [int] NOT NULL,
	[CCalle] [int] NOT NULL,
	[NCancha] [varchar](100) NOT NULL,
	[TDireccion] [text] NOT NULL,
	[MPrecioHora] [money] NOT NULL,
 CONSTRAINT [Cancha_pk] PRIMARY KEY CLUSTERED 
(
	[CCancha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 2/06/2019 14:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ciudad](
	[CCiudad] [int] IDENTITY(1,1) NOT NULL,
	[NCiudad] [varchar](100) NOT NULL,
	[CDepartamento] [int] NOT NULL,
 CONSTRAINT [Ciudad_pk] PRIMARY KEY CLUSTERED 
(
	[CCiudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 2/06/2019 14:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[CDepartamento] [int] IDENTITY(1,1) NOT NULL,
	[NDepartamento] [varchar](100) NOT NULL,
 CONSTRAINT [Departamento_pk] PRIMARY KEY CLUSTERED 
(
	[CDepartamento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleParticipante]    Script Date: 2/06/2019 14:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleParticipante](
	[CDetalleParticipante] [int] IDENTITY(1,1) NOT NULL,
	[CAlquiler] [int] NOT NULL,
	[CParticipante] [int] NOT NULL,
	[MCuota] [money] NOT NULL,
	[FPartePagada] [bit] NOT NULL,
	[NCupos] [int] NULL,
 CONSTRAINT [DetalleParticipante_pk] PRIMARY KEY CLUSTERED 
(
	[CDetalleParticipante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 2/06/2019 14:12:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distrito](
	[CDistrito] [int] IDENTITY(1,1) NOT NULL,
	[NDistrito] [varchar](100) NOT NULL,
	[CCiudad] [int] NOT NULL,
 CONSTRAINT [Distrito_pk] PRIMARY KEY CLUSTERED 
(
	[CDistrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipo]    Script Date: 2/06/2019 14:12:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipo](
	[CEquipo] [int] IDENTITY(1,1) NOT NULL,
	[NEquipo] [varchar](100) NOT NULL,
	[TDescripcion] [text] NOT NULL,
	[NumParticipantes] [int] NOT NULL,
	[DFechaJuego] [date] NOT NULL,
	[CDistrito] [int] NOT NULL,
 CONSTRAINT [Equipo_pk] PRIMARY KEY CLUSTERED 
(
	[CEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugador]    Script Date: 2/06/2019 14:12:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugador](
	[CJugador] [int] NOT NULL,
	[TDireccion] [text] NOT NULL,
 CONSTRAINT [Jugador_pk] PRIMARY KEY CLUSTERED 
(
	[CJugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Participante]    Script Date: 2/06/2019 14:12:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participante](
	[CParticipante] [int] IDENTITY(1,1) NOT NULL,
	[CJugador] [int] NOT NULL,
	[CEquipo] [int] NOT NULL,
	[FEsAdministrador] [bit] NOT NULL,
 CONSTRAINT [Participante_pk] PRIMARY KEY CLUSTERED 
(
	[CParticipante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Propietario]    Script Date: 2/06/2019 14:12:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Propietario](
	[CPropietario] [int] NOT NULL,
 CONSTRAINT [Propietario_pk] PRIMARY KEY CLUSTERED 
(
	[CPropietario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2/06/2019 14:12:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[CUsuario] [int] IDENTITY(1,1) NOT NULL,
	[CDNI] [bigint] NOT NULL,
	[NUsuario] [varchar](100) NOT NULL,
	[NumTelefono] [bigint] NOT NULL,
 CONSTRAINT [Usuario_pk] PRIMARY KEY CLUSTERED 
(
	[CUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD  CONSTRAINT [Alquiler_Cancha] FOREIGN KEY([CCancha])
REFERENCES [dbo].[Cancha] ([CCancha])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Alquiler] CHECK CONSTRAINT [Alquiler_Cancha]
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD  CONSTRAINT [Alquiler_Grupo] FOREIGN KEY([CEquipo])
REFERENCES [dbo].[Equipo] ([CEquipo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Alquiler] CHECK CONSTRAINT [Alquiler_Grupo]
GO
ALTER TABLE [dbo].[Calle]  WITH CHECK ADD  CONSTRAINT [Calle_Distrito] FOREIGN KEY([CDistrito])
REFERENCES [dbo].[Distrito] ([CDistrito])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Calle] CHECK CONSTRAINT [Calle_Distrito]
GO
ALTER TABLE [dbo].[Cancha]  WITH CHECK ADD  CONSTRAINT [Cancha_Calle] FOREIGN KEY([CCalle])
REFERENCES [dbo].[Calle] ([CCalle])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cancha] CHECK CONSTRAINT [Cancha_Calle]
GO
ALTER TABLE [dbo].[Cancha]  WITH CHECK ADD  CONSTRAINT [Cancha_Propietario] FOREIGN KEY([CPropietario])
REFERENCES [dbo].[Propietario] ([CPropietario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cancha] CHECK CONSTRAINT [Cancha_Propietario]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [Ciudad_Departamento] FOREIGN KEY([CDepartamento])
REFERENCES [dbo].[Departamento] ([CDepartamento])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [Ciudad_Departamento]
GO
ALTER TABLE [dbo].[DetalleParticipante]  WITH CHECK ADD  CONSTRAINT [Alquiler_Jugador_Equipo_Alquiler] FOREIGN KEY([CAlquiler])
REFERENCES [dbo].[Alquiler] ([CAlquiler])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleParticipante] CHECK CONSTRAINT [Alquiler_Jugador_Equipo_Alquiler]
GO
ALTER TABLE [dbo].[DetalleParticipante]  WITH CHECK ADD  CONSTRAINT [Alquiler_Jugador_Equipo_Participante] FOREIGN KEY([CParticipante])
REFERENCES [dbo].[Participante] ([CParticipante])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetalleParticipante] CHECK CONSTRAINT [Alquiler_Jugador_Equipo_Participante]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [Distrito_Ciudad] FOREIGN KEY([CCiudad])
REFERENCES [dbo].[Ciudad] ([CCiudad])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [Distrito_Ciudad]
GO
ALTER TABLE [dbo].[Equipo]  WITH CHECK ADD  CONSTRAINT [Grupo_Distrito] FOREIGN KEY([CDistrito])
REFERENCES [dbo].[Distrito] ([CDistrito])
GO
ALTER TABLE [dbo].[Equipo] CHECK CONSTRAINT [Grupo_Distrito]
GO
ALTER TABLE [dbo].[Jugador]  WITH CHECK ADD  CONSTRAINT [Jugador_Usuario] FOREIGN KEY([CJugador])
REFERENCES [dbo].[Usuario] ([CUsuario])
GO
ALTER TABLE [dbo].[Jugador] CHECK CONSTRAINT [Jugador_Usuario]
GO
ALTER TABLE [dbo].[Participante]  WITH CHECK ADD  CONSTRAINT [Jugador_Equipo_Jugador] FOREIGN KEY([CJugador])
REFERENCES [dbo].[Jugador] ([CJugador])
GO
ALTER TABLE [dbo].[Participante] CHECK CONSTRAINT [Jugador_Equipo_Jugador]
GO
ALTER TABLE [dbo].[Participante]  WITH CHECK ADD  CONSTRAINT [Usuario_Grupo_Grupo] FOREIGN KEY([CEquipo])
REFERENCES [dbo].[Equipo] ([CEquipo])
GO
ALTER TABLE [dbo].[Participante] CHECK CONSTRAINT [Usuario_Grupo_Grupo]
GO
ALTER TABLE [dbo].[Propietario]  WITH CHECK ADD  CONSTRAINT [Propietario_Usuario] FOREIGN KEY([CPropietario])
REFERENCES [dbo].[Usuario] ([CUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Propietario] CHECK CONSTRAINT [Propietario_Usuario]
GO
USE [master]
GO
ALTER DATABASE [SoccerMatch] SET  READ_WRITE 
GO
