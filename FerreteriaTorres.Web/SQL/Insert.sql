INSERT INTO TipoEquipos ([strDescripcion])
  VALUES ('Electronicos'),('Mecanicos');

INSERT INTO Marcas (strNombre)
VALUES ('ARDUINO'),
('AVTECH'),
('CISCO'),
('EMINENT'),
('GENIUS'),
('Midland'),
('NEUTRIK')

INSERT INTO Equipos(strIdEquipo,strDescripcion,intIdTipoEquipo,fltVrUnit,fltVrPrestamo,intImpuesto,intCantExistencia,intIdMarca,Activo,strCaracteristicas,strCreadoPor,FechaCreado)
VALUES ('123456','Martillo manual',2,20000,3000,5,5,9,1,'solo sirve para martillar','dalvarezv','01/07/2021 02:31:45')