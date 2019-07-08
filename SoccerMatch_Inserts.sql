Use SoccerMatch
--------------------------------TABLES
insert into Usuario values (73456712, 'Jesus Alvarado', 974874521, 'JesusUsuario', 123456),
							(72146321, 'Enrique Acevedo', 987452167, 'EnriqueUsuario', 123456),
							(69874541, 'Irma Aguilar', 954780123, 'IrmaUsuario', 123456),
							(70154213, 'Fredy Acosta', 98741254, 'FredyUsuario', 123456),
							(68745596, 'Adolfo Alderete', 965478852, 'AdolfoUsuario', 123456),
							(71245325, 'Victor Hugo Baltazar', 954123678, 'VictorUsuario', 123456),
							(71458792, 'Juan Caballero', 998745545, 'JuanUsuario', 123456),
							(72031458, 'Marcos Cardona', 945443621, 'MarcosUsuario', 123456),
							(74589621, 'Luis Castro', 97441123, 'LuisUsuario', 123456),
							(73557889, 'Jesús Cuellar', 999521002, 'JessyUsuario', 123456),
							(69225478, 'Roberto De La Fuente', 987441436, 'RobertoUsuario', 123456),
							(68541123, 'Adán De Lira', 963362584, 'AdanUsuario', 123456),
							(71412458, 'Vicente Díaz', 954123698, 'VicenteUsuario', 123456),
							(70125336, 'Romo Dominguez', 987654321, 'RomoUsuario', 123456),
							(71102365, 'Ángel Ferreira', 987321654, 'AngelUsuario', 123456),
							(73216599, 'Ernesto Altamirano', 963852741, 'ErnestoUsuario', 123456),
							(72100012, 'Fernando Gallegos', 963741852, 'FernandoUsuario', 123456),
							(69992214, 'Carlos García', 951753654, 'CarlosUsuario', 123456),
							(71452365, 'Jorge Gamarra', 987455541, 'JorgeUsuario', 123456),
							(73321444, 'Alberto Huaman', 95566644, 'AlbertoUsuario', 123456)
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
insert into Jugador values (1,'Av. Universitaria 1745'),
							(4,'Jr. Puno 478'),
							(6,'Av. Juan de Arona 1255'),
							(7,'Calle Los Alamos 78'),
							(8,'Av. La Marina 1236'),
							(9,'Calle Micaela Bastidas 23'),
							(10,'Jr. Los Rubies 65'),
							(12,'Jr. Los Topacios 14'),
							(13,'Jr. Vizcardo y Guzman 74'),
							(14,'Jr. Jorge Gabriel Aguilar 236'),
							(15,'Av. Universitaria 1456'),
							(16,'Jr. Puno 512'),
							(18,'Av. Juan de Arona 447'),
							(19,'Calle Los Alamos 777'),
							(20,'Av. La Marina 2460')
------------------------------------------									
insert into Cancha values (2, 2, 'La Cantera', 'Jr. Puno 751', 50),
							(3, 4, 'Planeta Futbol', 'Calle Los Alamos 996', 60),
							(5, 6, 'Tiro Libre', 'Calle Micaela Bastidas 57', 55),
							(11, 8, 'La Cancha', 'Jr. Los Topacios 1234', 65),
							(17, 10, 'Olimpus Futbol', 'Jr. Jose Gabriel Aguilar 4321', 50)
------------------------------------------							
insert into Equipo values ('Los Supercampeones', 'Equipo de futbol de 5 personas', 6, '2019-05-25', 3),
							('FC Pichanga', 'Pichanga todos los jueves', 8, '2019-05-15', 4),
							('Los Diablos Rojos', 'Grupo de futbol amateur', 6, '2019-04-30', 5)
------------------------------------------							
insert into Participante values (1, 1, 1, '2019-07-07'),
								(4, 1, 0, '2019-06-10'),
								(6, 1, 0, '2019-06-10'),
								(7, 1, 0, '2019-07-07'),
								(8, 1, 0, '2019-06-10'),
								(9, 2, 1, '2019-07-07'),
								(10, 2, 0, '2019-07-07'),
								(12, 2, 0, '2019-06-10'),
								(13, 2, 0, '2019-07-07'),
								(14, 2, 0, '2019-07-07'),
								(15, 3, 1, '2019-06-10'),
								(16, 3, 0, '2019-06-10'),
								(18, 3, 0, '2019-07-07'),
								(19, 3, 0, '2019-07-07'),
								(20, 3, 0, '2019-06-10')
------------------------------------------
insert into Alquiler values (1, 1, '2019-05-25 09:00:00.000', '2019-06-21',1, 0, 50, 1),
							(2, 3, '2019-05-15 13:00:00.000', '2019-06-21',1, 0, 55, 1),
							(3, 5, '2019-04-30 15:00:00.000', '2019-06-21',1, 0, 50, 1)
------------------------------------------							
insert into DetalleParticipante values (1, 1, 10, 1, 1),
										(1, 2, 10, 1, 1),
										(1, 3, 10, 1, 1),
										(1, 4, 10, 1, 1),
										(1, 5, 10, 1, 1),
										(2, 6, 11, 1, 1),
										(2, 7, 11, 1, 1),
										(2, 8, 11, 1, 1),
										(2, 9, 11, 1, 1),
										(2, 10, 11, 1, 1),
										(3, 11, 10, 1, 1),
										(3, 12, 10, 1, 1),
										(3, 13, 10, 1, 1),
										(3, 14, 10, 1, 1),
										(3, 15, 10, 1, 1)
-- End of file.
select * from Equipo

select * from Participante

Select * from Alquiler

select * from DetalleParticipante

