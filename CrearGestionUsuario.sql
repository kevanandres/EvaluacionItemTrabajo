--CREACION DE LAS BASE DE DATOS, TABLAS Y SP QUE SE UTILIZARON EL EL PROYECTO "GESTIONUSUARIO"
Create database GestionUsuario

Use GestionUsuariosDb

Create table Usuarios
(
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(50) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE()
)

select * from Usuarios

Insert into Usuarios (NombreUsuario, Activo) values 
('j.perez', 1),
('a.cardenas', 1),
('c.lopez', 1)

Drop procedure kc_Usuarios_ObtenerActivos

Create procedure kc_Usuarios_ObtenerActivos
AS
BEGIN
    Set nocount on

    Select *
    from Usuarios
    where Activo = 1
    order by NombreUsuario;
END

exec kc_Usuarios_ObtenerActivos