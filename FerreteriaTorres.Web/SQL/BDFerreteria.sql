go
Create Database Ferreteria
go
Use Ferreteria
go
Create Table TipoEquipos(
intIdTipoEquipo int identity Primary key,
strDescripcion varchar(20) not null
);
go
Create Table Marcas(
intIdMarca int identity primary key,
strNombre varchar(12) not null
);
go
Create Table Equipos(
strIdEquipo varchar(20)  primary key, 
strDescripcion Varchar(max),
intIdTipoEquipo int not null,
CONSTRAINT fk_intIdTipoEquipo FOREIGN KEY (intIdTipoEquipo) REFERENCES TipoEquipos (intIdTipoEquipo),
fltVrUnit money not null,
fltVrPrestamo money not null,
intImpuesto int null,
intCantExistencia int not null,
intIdMarca int not null,
CONSTRAINT fk_intIdMarca FOREIGN KEY (intIdMarca) REFERENCES Marcas (intIdMarca),
Activo bit not null,
strCaracteristicas varchar(max) not null,
strCreadoPor Varchar(20) not null,
FechaCreado datetime not null
);
go
Create Table Departamentos(
intIdDepartamento int primary key,
strNombre Varchar(20) not null
);
go
Create Table Ciudades(
intIdCiudad int primary key,
strDescripcion varchar(20) not null,
intIdDepartamento int not null,
CONSTRAINT fk_intIdDepartamento FOREIGN KEY (intIdDepartamento) REFERENCES Departamentos(intIdDepartamento),
);
go
create Table TipoDocumentos(
intIdTipoDocumento int  identity primary key,
strDescripcion varchar(20) not null,
strCreadoPor Varchar(20) not null,
FechaCreado datetime not null
);
go
Create Table Empleados(
strNroDocumento varchar(15) not null,
intIdTipoDocumento int not null,
CONSTRAINT fk_intIdTipoDocumento FOREIGN KEY (intIdTipoDocumento) REFERENCES TipoDocumentos(intIdTipoDocumento),
strNombres varchar(20) not null,
strApellidos varchar(20) not null,
strTelefono varchar(20) not null,
strDireccion varchar(20) not null,
intIdCiudad int not null,
CONSTRAINT fk_intIdCiudad FOREIGN KEY (intIdCiudad) REFERENCES Ciudades(intIdCiudad),
strUsuario varchar(20) unique,
strContrasena varchar(20),
Activo bit not null,
strCreadoPor Varchar(20) not null,
FechaCreado datetime not null,
primary key(strNroDocumento,intIdTipoDocumento)

);
go

Create Table Clientes (
intIdTipoDocumento int not null,
CONSTRAINT fk_intIdTipoDocumento2 FOREIGN KEY (intIdTipoDocumento) REFERENCES TipoDocumentos(intIdTipoDocumento),
strNroDocumento varchar(15) primary key,
strCorreo varchar(20) null,
strCreadoPor varchar(20) not null,
FechaCreado datetime not null,
TipoCliente char(1) not null

);
go
Create Table Direcciones(
intIdDirecciones int identity primary key,
strNroDocumento varchar(15),
CONSTRAINT fk_strNroDocumento FOREIGN KEY (strNroDocumento) REFERENCES Clientes(strNroDocumento),
strDireccion varchar(20) not null,
intIdCiudad int not null,
CONSTRAINT fk_intIdCiudad2 FOREIGN KEY (intIdCiudad) REFERENCES Ciudades(intIdCiudad)
)
go 

Create Table TipoTelefonos(
intIdTipoTelefono int identity primary key,
strDescripcion varchar(15) not null
)
go
Create table TelefonosClientes(
strNroTelefonico varchar(15) not null,
strNroDocumento varchar(15) not null,
intIdTipoTelefono int,
CONSTRAINT fk_intIdTipoTelefono FOREIGN KEY (intIdTipoTelefono) REFERENCES TipoTelefonos(intIdTipoTelefono),
CONSTRAINT fk_strNroDocumento1 FOREIGN KEY (strNroDocumento) REFERENCES Clientes(strNroDocumento)
)
go
create table Juridico(
strNroDocumento varchar(15) not null,
CONSTRAINT fk_strNroDocumento2 FOREIGN KEY (strNroDocumento) REFERENCES Clientes(strNroDocumento),
strRazonSocial varchar(20) not null,
strContacto varchar (40) not null,
strCargo varchar(20) not null
)
go
create table Natural (
strNroDocumento varchar(15) not null,
CONSTRAINT fk_strNroDocumento3 FOREIGN KEY (strNroDocumento) REFERENCES Clientes(strNroDocumento),
strNombres varchar(20) not null,
Apellidos varchar(20) not null
)
go
create table Alquiler(
intIdAlquiler int identity primary key,
Fecha Datetime not null,
strNroDocumento Varchar(15) not null,
CONSTRAINT fk_strNroDocumento4 FOREIGN KEY (strNroDocumento) REFERENCES Clientes(strNroDocumento),
strDireccion varchar(20) not null,
strCreadoPor varchar(20) not null
)
go
create Table AlquilerDetalle(
intIdArquilerDetalle int identity Primary key,
intIdAlquiler int not null,
CONSTRAINT fk_intIdAlquiler FOREIGN KEY (intIdAlquiler) REFERENCES Alquiler(intIdAlquiler),
strIdEquipo varchar(20) not null,
CONSTRAINT fk_strIdEquipo FOREIGN KEY (strIdEquipo) REFERENCES Equipos(strIdEquipo),
intCantidad int not null,
fltVrUnit money not null,
fltPorcentajeDes money default (0),
fltVrDescuento money default (0),
fltVrIva money default(0),
FechaEntrega datetime not null,
FechaDevolucion datetime not null
)
go
CREATE PROCEDURE ValidarUsuario
@strUsuario varchar (20),
@strContrasena varchar (20)
AS
BEGIN
SELECT strUsuario as Usuario, strContrasena as Clave  FROM Empleados
WHERE strUsuario = @strUsuario and strContrasena = @strContrasena and Activo = 1
--EXEC ValidarUsuario 'dalvarezv','1234'
END


