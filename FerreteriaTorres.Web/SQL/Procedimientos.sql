go

CREATE PROCEDURE ComboTipoEquipo
AS
 BEGIN
  SELECT -1 AS Clave , 'Seleccione Tipo Equipo' AS Dato 
 UNION
SELECT intIdTipoEquipo as Clave, strDescripcion As Dato
 FROM TipoEquipos
 -- EXEC ComboTipoEquipo;
 END

 go

 Create PROCEDURE [dbo].[ComboMarcas]
AS
 BEGIN
  SELECT -1 AS Clave , 'Seleccione una marca' AS Dato 
 UNION
SELECT intIdMarca as Clave, strNombre As Dato
 FROM Marcas
 -- EXEC ComboMarcas;
 END

 go

 Create PROCEDURE BuscarGeneral
AS
 BEGIN
  select e.strIdEquipo as Id,e.strDescripcion as Descripcion,te.strDescripcion as "Tipo Equipo",e.fltVrUnit as "Vr Unit",e.fltVrPrestamo as "Vr Prestamo",
intImpuesto as Iva,intCantExistencia as Stock,m.strNombre as Marca,e.Activo as Estado,e.strCaracteristicas as Caracteristicas,e.strCreadoPor as "Creado por",
e.FechaCreado as "Fecha Creado"
from Equipos e
INNER JOIN TipoEquipos te on te.intIdTipoEquipo = e.intIdTipoEquipo
INNER JOIN Marcas m on m.intIdMarca = e.intIdMarca
order by e.strIdEquipo
 -- EXEC BuscarGeneral;
 END

 go

 Create PROCEDURE GrabarEquipo
@strIdEquipo VARCHAR(20),
@strDescripcion VARCHAR(max),
@intIdTipoEquipo int,
@fltVrUnit float,
@fltVrPrestamo float,
@intImpuesto int,
@intCantExistencia int,
@intIdMarca int,
@Activo bit,
@strCaracteristicas varchar(max),
@strCreadoPor varchar(20),
@FechaCreado datetime

AS
 BEGIN
 IF EXISTS( SELECT * FROM Equipos
 WHERE strIdEquipo = @strIdEquipo  )
 BEGIN
 SELECT -1 AS Rpta
 Return
 END
 ELSE
 BEGIN
 BEGIN TRANSACTION tx
 INSERT INTO Equipos
 VALUES (@strIdEquipo,@strDescripcion ,@intIdTipoEquipo,@fltVrUnit,
 @fltVrPrestamo,@intImpuesto,@intCantExistencia,@intIdMarca,
@Activo,@strCaracteristicas,@strCreadoPor ,@FechaCreado);
 IF ( @@ERROR > 0 )
 BEGIN
 ROLLBACK TRANSACTION tx
 SELECT 0 AS Rpta
 Return
 END
 COMMIT TRANSACTION tx
 SELECT @strIdEquipo AS Rpta
 Return
 END
 

 -- EXEC GrabarEquipo '222','Prueba1 ', 1 ,1500 , 120, 10 , 10,8,1,prueba,' Diego ','02-07-2021 10:15';
 -- EXEC USP_Asoc_BuscarXcodigo '70500600';
 END

 GO
CREATE PROCEDURE EditarEquipo
@strIdEquipo VARCHAR(20),
@strDescripcion VARCHAR(max),
@intIdTipoEquipo int,
@fltVrUnit float,
@fltVrPrestamo float,
@intImpuesto int,
@intCantExistencia int,
@intIdMarca int,
@Activo bit,
@strCaracteristicas varchar(max),
@strCreadoPor varchar(20),
@FechaCreado datetime
As
 BEGIN
 BEGIN TRANSACTION tx
 UPDATE Equipos
 SET
strDescripcion = @strDescripcion ,
intIdTipoEquipo=@intIdTipoEquipo ,
fltVrUnit=@fltVrUnit ,
fltVrPrestamo=@fltVrPrestamo ,
intImpuesto=@intImpuesto ,
intCantExistencia=@intCantExistencia ,
intIdMarca=@intIdMarca ,
Activo=@Activo ,
strCaracteristicas=@strCaracteristicas ,
strCreadoPor =@strCreadoPor ,
FechaCreado=@FechaCreado
 WHERE strIdEquipo = @strIdEquipo
 IF ( @@ERROR > 0 )
 Begin
 ROLLBACK TRANSACTION tx
 SELECT 0 AS Rpta
 Return
 End
 COMMIT TRANSACTION tx
 SELECT @strIdEquipo AS Rpta
 Return
 -- EXEC EditarEquipo '222','Prueba11234546 ', 1 ,1500 , 120, 10 , 10,8,1,prueba,' Diego ','02-07-2021 10:15';
 END

 go

 CREATE PROCEDURE BuscarEquipoCodigo
@strIdEquipo VARCHAR(20)
AS
 BEGIN
 select  strIdEquipo as Id, strDescripcion as Descripcion,intIdTipoEquipo as "Tipo Equipo", fltVrUnit as "Vr Unit", fltVrPrestamo as "Vr Prestamo",
intImpuesto as Iva,intCantExistencia as Stock,intIdMarca as Marca, Activo as Estado, strCaracteristicas as Caracteristicas, strCreadoPor as "Creado por",
 FechaCreado as "Fecha Creado"
from Equipos 
 WHERE strIdEquipo = @strIdEquipo
 -- EXEC BuscarEquipoCodigo '11';
 END