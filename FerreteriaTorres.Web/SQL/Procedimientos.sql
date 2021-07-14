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
 -- EXEC BuscarEquipoCodigo '1';
 END

 go

 CREATE PROCEDURE GrabarArquiler
@Fecha DATETIME,
@strNroDocumento varchar(15),
@strDireccion varchar(20),
@strCreadoPor varchar(20),
@fltVrBruto float,
@fltVrDescuento float,
@fltVrIva float,
@fltVrNeto float
AS
 BEGIN
 BEGIN TRANSACTION tx
 INSERT INTO Alquiler( Fecha, strNroDocumento,
 strDireccion, strCreadoPor,fltVrBruto,fltVrDescuento,fltVrIva,fltVrNeto)
 VALUES (@Fecha, @strNroDocumento, @strDireccion, @strCreadoPor,
 @fltVrBruto,@fltVrDescuento,@fltVrIva,@fltVrNeto);
 IF ( @@ERROR > 0 )
 BEGIN
 ROLLBACK TRANSACTION tx
 SELECT 0 AS Rpta
 Return
 END
 COMMIT TRANSACTION tx
 SELECT @@IDENTITY AS Rpta
 Return
  -- EXEC GrabarArquiler '7-7-2021','1119217542','cALLE Prueba','DIEGO';
 END
 GO

 CREATE PROCEDURE EliminarEquipo
@strIdEquipo VARCHAR(20)
AS
 BEGIN
 IF EXISTS( SELECT * FROM AlquilerDetalle
 WHERE strIdEquipo = @strIdEquipo )
 BEGIN
 SELECT -1 AS Rpta
 Return
 END
 ELSE
 BEGIN
 BEGIN TRANSACTION tx
 delete Equipos WHERE strIdEquipo = @strIdEquipo
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
 -- EXEC EliminarEquipo '12';

 END

 go
  CREATE PROCEDURE ConsultaHistoriaPorCliente
@strNroDocumento varchar(15)
AS
 BEGIN
 select a.intIdAlquiler as ID, CONVERT(varchar,a.Fecha,20) as Fecha,a.strNroDocumento AS "N° Documento",a.strDireccion AS "Direccion",
 a.strCreadoPor as "Creado Por",COUNT(ad.intIdAlquiler) as "Cantidad Articulos"
 from Alquiler a
 INNER JOIN AlquilerDetalle ad ON a.intIdAlquiler = ad.intIdAlquiler
 WHERE a.strNroDocumento = @strNroDocumento
 Group by a.intIdAlquiler, a.Fecha,a.strNroDocumento,a.strDireccion,
 a.strCreadoPor
 --EXEC ComboDirecciones @strNroDocumento;
 -- EXEC ConsultaHistoriaPorCliente '1119217542';
 END

 go

 Create PROCEDURE ComboDirecciones
 @strNroDocumento varchar(15)
 AS
 BEGIN
 SELECT d.strDireccion as Clave, d.strDireccion As Dato
 FROM Clientes c
 Inner Join Direcciones d on c.strNroDocumento = d.strNroDocumento
 WHERE c.strNroDocumento = @strNroDocumento
 ORDER BY d.strDireccion
 -- EXEC ComboDirecciones '1119217542';
 END
 go
 CREATE PROCEDURE BuscarEquipoCodigoAct
@strIdEquipo VARCHAR(20)
AS
 BEGIN
 select  strDescripcion as Descripcion,  fltVrPrestamo as "Vr Prestamo",
intImpuesto as Iva,intCantExistencia as Stock
from Equipos 
 WHERE strIdEquipo = @strIdEquipo  AND Activo = 1
 -- EXEC BuscarEquipoCodigoAct '1';
 END

GO
CREATE PROCEDURE BuscarClienteNroDocumento
@strNroDocumento VARCHAR(15)
AS
 BEGIN
 select  c.strNroDocumento,j.strRazonSocial,n.Apellidos,n.strNombres,c.TipoCliente
from Clientes c
left join Juridico j on c.strNroDocumento = j.strNroDocumento
left join Natural n on c.strNroDocumento = n.strNroDocumento
 WHERE c.strNroDocumento = @strNroDocumento
 -- EXEC BuscarClienteNroDocumento '1119217542';
 END
go
 CREATE PROCEDURE DisminuirExistencia
@intCantidad int,
@strIdEquipo varchar(20)
as
BEGIN
SET NOCOUNT OFF;
UPDATE Equipos SET intCantExistencia = intCantExistencia - @intCantidad
WHERE strIdEquipo = @strIdEquipo
--EXEC DisminuirExistencia 10,'1';
END
go

CREATE PROCEDURE GrabarArquilerDetalle
@intIdAlquiler int,
@strIdEquipo varchar(20),
@intCantidad int,
@fltVrUnit float,
@fltPorcentajeDes float,
@fltVrDescuento float,
@fltVrIva float,
@FechaEntrega datetime,
@FechaDevolucion datetime
AS

 BEGIN
 BEGIN TRANSACTION tx
 INSERT INTO AlquilerDetalle (intIdAlquiler,strIdEquipo,intCantidad,fltVrUnit,fltPorcentajeDes,
fltVrDescuento,fltVrIva,FechaEntrega,FechaDevolucion)
 VALUES (@intIdAlquiler, @strIdEquipo, @intCantidad, @fltVrUnit,
 @fltPorcentajeDes,@fltVrDescuento,@fltVrIva,@FechaEntrega,@FechaDevolucion);
 EXEC DisminuirExistencia @intCantidad,@strIdEquipo;
 IF ( @@ERROR > 0 )
 BEGIN
 ROLLBACK TRANSACTION tx
 SELECT 0 AS Rpta
 Return
 END
 COMMIT TRANSACTION tx
 SELECT @@IDENTITY AS Rpta
 Return
  -- EXEC GrabarArquilerDetalle 1,1,5,1500,0,0,0,'3-7-2021 12:22','7-20-2021 12:22';
 END
 

GO

CREATE  PROCEDURE ValidarUsuario
@strUsuario varchar (20),
@strContrasena varchar (20)
AS
BEGIN
SELECT strUsuario, strContrasena,strNroDocumento,
CONCAT(strApellidos,' ',strNombres)as strApellidoNombre,
Activo
FROM Empleados
WHERE strUsuario = @strUsuario and strContrasena = @strContrasena
--exec ValidarUsuario 'dalvarezv', '1234';
END
go
create procedure BuscarDetalleAlquiler
@intIdAlquiler int
as
	Begin
	select intIdArquilerDetalle,ad.strIdEquipo,e.strDescripcion,e.strCaracteristicas,
	intCantidad,ad.fltVrUnit,fltPorcentajeDes,fltVrDescuento,fltVrIva,FechaEntrega,FechaDevolucion 
	from AlquilerDetalle ad
	INNER JOIN Equipos e on ad.strIdEquipo = e.strIdEquipo
	where intIdAlquiler = @intIdAlquiler
	--EXEC BuscarDetalleAlquiler 20
	end
go
CREATE procedure BuscarAlquiler
@intIdAlquiler int
as
	Begin
select intIdAlquiler,Convert (varchar(10), Fecha, 103) As Fecha,a.strNroDocumento,n.Apellidos,n.strNombres,j.strRazonSocial,strDireccion,a.strCreadoPor,c.TipoCliente from alquiler a
INNER JOIN Clientes c on a.strNroDocumento = c.strNroDocumento
LEFT JOIN Natural n on c.strNroDocumento = n.strNroDocumento
left join Juridico j on c.strNroDocumento = j.strNroDocumento
where intIdAlquiler = @intIdAlquiler
EXEC BuscarDetalleAlquiler @intIdAlquiler
--EXEC BuscarAlquiler 20
end

GO

