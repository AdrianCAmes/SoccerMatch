-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2019-04-23 04:10:10.889

create database SoccerMatch
-- tables
-- Table: Alquiler
CREATE TABLE Alquiler (
    CAlquiler int  NOT NULL IDENTITY (1,1),
    CEquipo int  NOT NULL,
    CCancha int  NOT NULL,
	DFechaInicio datetime NOT NULL,
    NumHoras int  NOT NULL,
    MDescuento money  NOT NULL,
    MTotal money  NOT NULL,
    FPagado bit  NOT NULL,
    CONSTRAINT Alquiler_pk PRIMARY KEY  (CAlquiler)
);

-- Table: Calle
CREATE TABLE Calle (
    CCalle int  NOT NULL IDENTITY (1,1),
    NCalle varchar(100)  NOT NULL,
    CDistrito int  NOT NULL,
    CONSTRAINT Calle_pk PRIMARY KEY  (CCalle)
);

-- Table: Cancha
CREATE TABLE Cancha (
    CCancha int  NOT NULL IDENTITY (1,1),
    CPropietario int  NOT NULL,
    CCalle int  NOT NULL,
    NCancha varchar(100)  NOT NULL,
    TDireccion text  NOT NULL,
    MPrecioHora money  NOT NULL,
    CONSTRAINT Cancha_pk PRIMARY KEY  (CCancha)
);

-- Table: Ciudad
CREATE TABLE Ciudad (
    CCiudad int  NOT NULL IDENTITY (1,1),
    NCiudad varchar(100)  NOT NULL,
    CDepartamento int  NOT NULL,
    CONSTRAINT Ciudad_pk PRIMARY KEY  (CCiudad)
);

-- Table: Departamento
CREATE TABLE Departamento (
    CDepartamento int  NOT NULL IDENTITY (1,1),
    NDepartamento varchar(100)  NOT NULL,
    CONSTRAINT Departamento_pk PRIMARY KEY  (CDepartamento)
);

-- Table: DetalleParticipante
CREATE TABLE DetalleParticipante (
    CDetalleParticipante int  NOT NULL IDENTITY  (1,1),
    CAlquiler int  NOT NULL,
    CParticipante int  NOT NULL,
    MCuota money  NOT NULL,
    FPartePagada bit  NOT NULL,
    CONSTRAINT DetalleParticipante_pk PRIMARY KEY  (CDetalleParticipante)
);

-- Table: Distrito
CREATE TABLE Distrito (
    CDistrito int  NOT NULL IDENTITY (1,1),
    NDistrito varchar(100)  NOT NULL,
    CCiudad int  NOT NULL,
    CONSTRAINT Distrito_pk PRIMARY KEY  (CDistrito)
);

-- Table: Equipo
CREATE TABLE Equipo (
    CEquipo int  NOT NULL IDENTITY (1,1),
    NEquipo varchar(100)  NOT NULL,
    TDescripcion text  NOT NULL,
    NumParticipantes int  NOT NULL,
    DFechaJuego Date  NOT NULL,
    CDistrito int  NOT NULL,
    CONSTRAINT Equipo_pk PRIMARY KEY  (CEquipo)
);

-- Table: Jugador
CREATE TABLE Jugador (
    CJugador int  NOT NULL,
    CCalle int  NOT NULL,
    TDireccion text  NOT NULL,
    CONSTRAINT Jugador_pk PRIMARY KEY  (CJugador)
);

-- Table: Participante
CREATE TABLE Participante (
    CParticipante int  NOT NULL IDENTITY  (1,1),
    CJugador int  NOT NULL,
    CEquipo int  NOT NULL,
	FEsAdministrador bit NOT NULL,
    CONSTRAINT Participante_pk PRIMARY KEY  (CParticipante)
);

-- Table: Propietario
CREATE TABLE Propietario (
    CPropietario int  NOT NULL,
    CONSTRAINT Propietario_pk PRIMARY KEY  (CPropietario)
);

-- Table: Usuario
CREATE TABLE Usuario (
    CUsuario int  NOT NULL IDENTITY  (1,1),
    CDNI bigint  NOT NULL,
    NUsuario varchar(100)  NOT NULL,
    NumTelefono bigint  NOT NULL,
    CONSTRAINT Usuario_pk PRIMARY KEY  (CUsuario)
);

-- foreign keys
-- Reference: Alquiler_Cancha (table: Alquiler)
ALTER TABLE Alquiler ADD CONSTRAINT Alquiler_Cancha
    FOREIGN KEY (CCancha)
    REFERENCES Cancha (CCancha) on delete cascade;

-- Reference: Alquiler_Grupo (table: Alquiler)
ALTER TABLE Alquiler ADD CONSTRAINT Alquiler_Grupo
    FOREIGN KEY (CEquipo)
    REFERENCES Equipo (CEquipo) on delete cascade;

-- Reference: Alquiler_Jugador_Equipo_Alquiler (table: DetalleParticipante)
ALTER TABLE DetalleParticipante ADD CONSTRAINT Alquiler_Jugador_Equipo_Alquiler
    FOREIGN KEY (CAlquiler)
    REFERENCES Alquiler (CAlquiler) on delete cascade;

-- Reference: Alquiler_Jugador_Equipo_Participante (table: DetalleParticipante)
ALTER TABLE DetalleParticipante ADD CONSTRAINT Alquiler_Jugador_Equipo_Participante
    FOREIGN KEY (CParticipante)
    REFERENCES Participante (CParticipante) on delete cascade;

-- Reference: Calle_Distrito (table: Calle)
ALTER TABLE Calle ADD CONSTRAINT Calle_Distrito
    FOREIGN KEY (CDistrito)
    REFERENCES Distrito (CDistrito) on delete cascade;

-- Reference: Cancha_Calle (table: Cancha)
ALTER TABLE Cancha ADD CONSTRAINT Cancha_Calle
    FOREIGN KEY (CCalle)
    REFERENCES Calle (CCalle) on delete cascade;

-- Reference: Cancha_Propietario (table: Cancha)
ALTER TABLE Cancha ADD CONSTRAINT Cancha_Propietario
    FOREIGN KEY (CPropietario)
    REFERENCES Propietario (CPropietario) on delete cascade;

-- Reference: Ciudad_Departamento (table: Ciudad)
ALTER TABLE Ciudad ADD CONSTRAINT Ciudad_Departamento
    FOREIGN KEY (CDepartamento)
    REFERENCES Departamento (CDepartamento) on delete cascade;

-- Reference: Distrito_Ciudad (table: Distrito)
ALTER TABLE Distrito ADD CONSTRAINT Distrito_Ciudad
    FOREIGN KEY (CCiudad)
    REFERENCES Ciudad (CCiudad) on delete cascade;

-- Reference: Grupo_Distrito (table: Equipo)
ALTER TABLE Equipo ADD CONSTRAINT Grupo_Distrito
    FOREIGN KEY (CDistrito)
    REFERENCES Distrito (CDistrito);

-- Reference: Jugador_Calle (table: Jugador)
ALTER TABLE Jugador ADD CONSTRAINT Jugador_Calle
    FOREIGN KEY (CCalle)
    REFERENCES Calle (CCalle) on delete cascade;

-- Reference: Jugador_Equipo_Jugador (table: Participante)
ALTER TABLE Participante ADD CONSTRAINT Jugador_Equipo_Jugador
    FOREIGN KEY (CJugador)
    REFERENCES Jugador (CJugador);

-- Reference: Jugador_Usuario (table: Jugador)
ALTER TABLE Jugador ADD CONSTRAINT Jugador_Usuario
    FOREIGN KEY (CJugador)
    REFERENCES Usuario (CUsuario) on delete cascade;

-- Reference: Propietario_Usuario (table: Propietario)
ALTER TABLE Propietario ADD CONSTRAINT Propietario_Usuario
    FOREIGN KEY (CPropietario)
    REFERENCES Usuario (CUsuario) on delete cascade;

-- Reference: Usuario_Grupo_Grupo (table: Participante)
ALTER TABLE Participante ADD CONSTRAINT Usuario_Grupo_Grupo
    FOREIGN KEY (CEquipo)
    REFERENCES Equipo (CEquipo);

--------------------------------TABLES
insert into Usuario values (73456712, 'Jesus Alvarado', 974874521),
							(72146321, 'Enrique Acevedo', 987452167),
							(69874541, 'Irma Aguilar', 954780123),
							(70154213, 'Fredy Acosta', 98741254),
							(68745596, 'Adolfo Alderete', 965478852),
							(71245325, 'Victor Hugo Baltazar', 954123678),
							(71458792, 'Juan Caballero', 998745545),
							(72031458, 'Marcos Cardona', 945443621),
							(74589621, 'Luis Castro', 97441123),
							(73557889, 'Jesús Cuellar', 999521002),
							(69225478, 'Roberto De La Fuente', 987441436),
							(68541123, 'Adán De Lira', 963362584),
							(71412458, 'Vicente Díaz', 954123698),
							(70125336, 'Romo Dominguez', 987654321),
							(71102365, 'Ángel Ferreira', 987321654),
							(73216599, 'Ernesto Altamirano', 963852741),
							(72100012, 'Fernando Gallegos', 963741852),
							(69992214, 'Carlos García', 951753654),
							(71452365, 'Jorge Gamarra', 987455541),
							(73321444, 'Alberto Huaman', 95566644)
------------------------------------------
insert into Propietario values (2),
								(3),
								(5),
								(11),
								(17)
------------------------------------------
insert into Departamento values ('Lima'),
								('Junin'),
								('Arequipa')
------------------------------------------
insert into Ciudad values ('Lima', 1),
							('Huaral', 1),
							('Huancayo', 2),
							('Chanchamayo', 2),
							('Arequipa', 3),
							('Camana', 3)
------------------------------------------
insert into Distrito values ('El Agustino', 1),
								('Cercado de Lima', 1),
								('San Isidro', 1),
								('San Miguel', 1),
								('San Juan de Miraflores', 1),
								('San Juan de Lurigancho', 1),
								('Los Olivos', 1),
								('Comas', 1),
								('Huaral', 2),
								('Chancay', 2),
								('Huancayo', 3),
								('Ingenio', 3),
								('Chanchamayo', 4),
								('Pichanaqui', 4),
								('Arquipa', 5),
								('Cayma', 5),
								('Camana', 6)
------------------------------------------								
insert into Calle values ('Av. Universitaria', 2),
							('Jr. Puno', 2),
							('Av. Juan de Arona', 3),
							('Calle Los Alamos', 3),
							('Av. La Marina', 4),
							('Calle Micaela Bastidas', 4),
							('Jr. Los Rubies', 6),
							('Jr. Los Topacios', 6),
							('Jr. Vizcardo y Guzman', 8),
							('Jr. Jose Gabriel Aguilar', 8)
------------------------------------------
insert into Jugador values (1, 1,'Av. Universitaria 1745'),
							(4, 2,'Jr. Puno 478'),
							(6, 3,'Av. Juan de Arona 1255'),
							(7, 4,'Calle Los Alamos 78'),
							(8, 5,'Av. La Marina 1236'),
							(9, 6,'Calle Micaela Bastidas 23'),
							(10, 7,'Jr. Los Rubies 65'),
							(12, 8,'Jr. Los Topacios 14'),
							(13, 9,'Jr. Vizcardo y Guzman 74'),
							(14, 10,'Jr. Jorge Gabriel Aguilar 236'),
							(15, 1,'Av. Universitaria 1456'),
							(16, 2,'Jr. Puno 512'),
							(18, 3,'Av. Juan de Arona 447'),
							(19, 4,'Calle Los Alamos 777'),
							(20, 5,'Av. La Marina 2460')
------------------------------------------									
insert into Cancha values (2, 2, 'La Cantera', 'Jr. Puno 751', 50),
							(3, 4, 'Planeta Futbol', 'Calle Los Alamos 996', 60),
							(5, 6, 'Tiro Libre', 'Calle Micaela Bastidas 57', 55),
							(11, 8, 'La Cancha', 'Jr. Los Topacios 1234', 65),
							(17, 10, 'Olimpus Futbol', 'Jr. Jose Gabriel Aguilar 4321', 50)
------------------------------------------							
insert into Equipo values ('Los Supercampeones', 'Equipo de futbol de 5 personas', 5, '2019-05-25', 3),
							('FC Pichanga', 'Pichanga todos los jueves', 5, '2019-05-15', 4),
							('Los Diablos Rojos', 'Grupo de futbol amateur', 5, '2019-04-30', 5)
------------------------------------------							
insert into Participante values (1, 1, 1),
								(4, 1, 0),
								(6, 1, 0),
								(7, 1, 0),
								(8, 1, 0),
								(9, 2, 1),
								(10, 2, 0),
								(12, 2, 0),
								(13, 2, 0),
								(14, 2, 0),
								(15, 3, 1),
								(16, 3, 0),
								(18, 3, 0),
								(19, 3, 0),
								(20, 3, 0)
------------------------------------------
insert into Alquiler values (1, 1, '2019-05-25 09:00:00.000',1, 0, 50, 1),
							(2, 3, '2019-05-15 13:00:00.000',1, 0, 55, 1),
							(3, 5, '2019-04-30 15:00:00.000',1, 0, 50, 1)
------------------------------------------							
insert into DetalleParticipante values (1, 1, 10, 1),
										(1, 2, 10, 1),
										(1, 3, 10, 1),
										(1, 4, 10, 1),
										(1, 5, 10, 1),
										(2, 6, 11, 1),
										(2, 7, 11, 1),
										(2, 8, 11, 1),
										(2, 9, 11, 1),
										(2, 10, 11, 1),
										(3, 11, 10, 1),
										(3, 12, 10, 1),
										(3, 13, 10, 1),
										(3, 14, 10, 1),
										(3, 15, 10, 1)
-- End of file.

