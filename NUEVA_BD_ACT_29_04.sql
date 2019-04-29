USE [SoccerMatch]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 29/04/2019 04:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[CAdministrador] [int] NOT NULL,
 CONSTRAINT [Administrador_pk] PRIMARY KEY CLUSTERED 
(
	[CAdministrador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Alquiler]    Script Date: 29/04/2019 04:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alquiler](
	[CAlquiler] [int] IDENTITY(1,1) NOT NULL,
	[CEquipo] [int] NOT NULL,
	[CCancha] [int] NOT NULL,
	[NumHoras] [int] NOT NULL,
	[MDescuento] [money] NOT NULL,
	[MTotal] [money] NOT NULL,
	[FPagado] [bit] NOT NULL,
	[DHoraInicio] [datetime] NULL,
 CONSTRAINT [Alquiler_pk] PRIMARY KEY CLUSTERED 
(
	[CAlquiler] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Calle]    Script Date: 29/04/2019 04:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cancha]    Script Date: 29/04/2019 04:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ciudad]    Script Date: 29/04/2019 04:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 29/04/2019 04:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DetalleParticipante]    Script Date: 29/04/2019 04:56:37 ******/
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
 CONSTRAINT [DetalleParticipante_pk] PRIMARY KEY CLUSTERED 
(
	[CDetalleParticipante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 29/04/2019 04:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Equipo]    Script Date: 29/04/2019 04:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Equipo](
	[CEquipo] [int] IDENTITY(1,1) NOT NULL,
	[NEquipo] [varchar](100) NOT NULL,
	[TDescripcion] [text] NOT NULL,
	[NumParticipantes] [int] NOT NULL,
	[DFechaJuego] [datetime] NOT NULL,
	[CDistrito] [int] NOT NULL,
 CONSTRAINT [Equipo_pk] PRIMARY KEY CLUSTERED 
(
	[CEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Jugador]    Script Date: 29/04/2019 04:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugador](
	[CJugador] [int] NOT NULL,
	[CCalle] [int] NOT NULL,
	[TDireccion] [text] NOT NULL,
 CONSTRAINT [Jugador_pk] PRIMARY KEY CLUSTERED 
(
	[CJugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Participante]    Script Date: 29/04/2019 04:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Participante](
	[CParticipante] [int] IDENTITY(1,1) NOT NULL,
	[CJugador] [int] NOT NULL,
	[CEquipo] [int] NOT NULL,
 CONSTRAINT [Participante_pk] PRIMARY KEY CLUSTERED 
(
	[CParticipante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Propietario]    Script Date: 29/04/2019 04:56:37 ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/04/2019 04:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Administrador]  WITH CHECK ADD  CONSTRAINT [Administrador_Jugador] FOREIGN KEY([CAdministrador])
REFERENCES [dbo].[Jugador] ([CJugador])
GO
ALTER TABLE [dbo].[Administrador] CHECK CONSTRAINT [Administrador_Jugador]
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD  CONSTRAINT [Alquiler_Cancha] FOREIGN KEY([CCancha])
REFERENCES [dbo].[Cancha] ([CCancha])
GO
ALTER TABLE [dbo].[Alquiler] CHECK CONSTRAINT [Alquiler_Cancha]
GO
ALTER TABLE [dbo].[Alquiler]  WITH CHECK ADD  CONSTRAINT [Alquiler_Grupo] FOREIGN KEY([CEquipo])
REFERENCES [dbo].[Equipo] ([CEquipo])
GO
ALTER TABLE [dbo].[Alquiler] CHECK CONSTRAINT [Alquiler_Grupo]
GO
ALTER TABLE [dbo].[Calle]  WITH CHECK ADD  CONSTRAINT [Calle_Distrito] FOREIGN KEY([CDistrito])
REFERENCES [dbo].[Distrito] ([CDistrito])
GO
ALTER TABLE [dbo].[Calle] CHECK CONSTRAINT [Calle_Distrito]
GO
ALTER TABLE [dbo].[Cancha]  WITH CHECK ADD  CONSTRAINT [Cancha_Calle] FOREIGN KEY([CCalle])
REFERENCES [dbo].[Calle] ([CCalle])
GO
ALTER TABLE [dbo].[Cancha] CHECK CONSTRAINT [Cancha_Calle]
GO
ALTER TABLE [dbo].[Cancha]  WITH CHECK ADD  CONSTRAINT [Cancha_Propietario] FOREIGN KEY([CPropietario])
REFERENCES [dbo].[Propietario] ([CPropietario])
GO
ALTER TABLE [dbo].[Cancha] CHECK CONSTRAINT [Cancha_Propietario]
GO
ALTER TABLE [dbo].[Ciudad]  WITH CHECK ADD  CONSTRAINT [Ciudad_Departamento] FOREIGN KEY([CDepartamento])
REFERENCES [dbo].[Departamento] ([CDepartamento])
GO
ALTER TABLE [dbo].[Ciudad] CHECK CONSTRAINT [Ciudad_Departamento]
GO
ALTER TABLE [dbo].[DetalleParticipante]  WITH CHECK ADD  CONSTRAINT [Alquiler_Jugador_Equipo_Alquiler] FOREIGN KEY([CAlquiler])
REFERENCES [dbo].[Alquiler] ([CAlquiler])
GO
ALTER TABLE [dbo].[DetalleParticipante] CHECK CONSTRAINT [Alquiler_Jugador_Equipo_Alquiler]
GO
ALTER TABLE [dbo].[DetalleParticipante]  WITH CHECK ADD  CONSTRAINT [Alquiler_Jugador_Equipo_Participante] FOREIGN KEY([CParticipante])
REFERENCES [dbo].[Participante] ([CParticipante])
GO
ALTER TABLE [dbo].[DetalleParticipante] CHECK CONSTRAINT [Alquiler_Jugador_Equipo_Participante]
GO
ALTER TABLE [dbo].[Distrito]  WITH CHECK ADD  CONSTRAINT [Distrito_Ciudad] FOREIGN KEY([CCiudad])
REFERENCES [dbo].[Ciudad] ([CCiudad])
GO
ALTER TABLE [dbo].[Distrito] CHECK CONSTRAINT [Distrito_Ciudad]
GO
ALTER TABLE [dbo].[Equipo]  WITH CHECK ADD  CONSTRAINT [Grupo_Distrito] FOREIGN KEY([CDistrito])
REFERENCES [dbo].[Distrito] ([CDistrito])
GO
ALTER TABLE [dbo].[Equipo] CHECK CONSTRAINT [Grupo_Distrito]
GO
ALTER TABLE [dbo].[Jugador]  WITH CHECK ADD  CONSTRAINT [Jugador_Calle] FOREIGN KEY([CCalle])
REFERENCES [dbo].[Calle] ([CCalle])
GO
ALTER TABLE [dbo].[Jugador] CHECK CONSTRAINT [Jugador_Calle]
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
GO
ALTER TABLE [dbo].[Propietario] CHECK CONSTRAINT [Propietario_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[pr_FindBy]    Script Date: 29/04/2019 04:56:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[pr_FindBy] @id int
as begin
select * 
from Ciudad ci
WHERE ci.CCiudad=@id
end
GO
