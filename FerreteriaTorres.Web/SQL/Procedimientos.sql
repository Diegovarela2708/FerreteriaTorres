CREATE PROCEDURE ComboTipoEquipo
AS
 BEGIN
  SELECT -1 AS Clave , 'Seleccione Tipo Equipo' AS Dato 
 UNION
SELECT intIdTipoEquipo as Clave, strDescripcion As Dato
 FROM TipoEquipos
 -- EXEC ComboTipoEquipo;
 END