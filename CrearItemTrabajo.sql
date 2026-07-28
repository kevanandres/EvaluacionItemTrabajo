--CREACION DE LAS BASE DE DATOS, TABLAS Y SP QUE SE UTILIZARON EL EL PROYECTO "ITEMTRABAJO"
Create database ItemTrabajo

Use ItemTrabajo

Create table ItemsTrabajo
(
    IdItem INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(150) NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaEntrega DATETIME NOT NULL,
    Relevancia NVARCHAR(20) NOT NULL,
    Estado NVARCHAR(20) NOT NULL DEFAULT 'PENDIENTE',
    UsuarioAsignado NVARCHAR(100) NULL,
    FechaCompletado DATETIME NULL
)

Select * from ItemsTrabajo

Insert into ItemsTrabajo (Titulo, FechaEntrega, Relevancia, UsuarioAsignado) VALUES
(
    'Revicion',
    DATEADD(DAY, 5, GETDATE()),
    'Alta',
    'j.perez'
),
(
    'Actualizacion',
    DATEADD(DAY, 7, GETDATE()),
    'Baja',
    'a.cardenas'
),
(
    'Eliminacion',
    DATEADD(DAY, 3, GETDATE()),
    'Alta',
    'c.lopez'
)

Drop procedure kc_Items_Obtener

Create procedure kc_Items_Obtener
AS
BEGIN
    Set nocount on

    Select * from ItemsTrabajo order by
    CASE
        WHEN Estado = 'PENDIENTE'
            AND FechaEntrega >= GETDATE()
            AND FechaEntrega < DATEADD(DAY, 3, GETDATE())
        THEN 1
        ELSE 2
    END,
    CASE Relevancia
        WHEN 'Alta' THEN 1
        WHEN 'Baja' THEN 2
        ELSE 3
    END,
    FechaEntrega ASC
END

exec kc_Items_Obtener

Create procedure kc_Items_ObtenerCargaUsuarios
AS
BEGIN
    Set nocount on

    Select
        UsuarioAsignado as NombreUsuario,
        COUNT(*) as CantidadPendientes,
        SUM(
            CASE
                when Relevancia = 'Alta' then 1
                else 0
            END
        ) as CantidadAltos
    from ItemsTrabajo
    where Estado = 'PENDIENTE'
      AND UsuarioAsignado IS NOT NULL
    GROUP BY UsuarioAsignado;
END

exec kc_Items_ObtenerCargaUsuarios

Create procedure kc_Items_Insertar
    @Titulo NVARCHAR(150),
    @FechaEntrega DATETIME,
    @Relevancia NVARCHAR(10),
    @UsuarioAsignado NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON

    INSERT INTO ItemsTrabajo
    (
        Titulo,
        FechaCreacion,
        FechaEntrega,
        Relevancia,
        Estado,
        UsuarioAsignado
    )
    VALUES
    (
        @Titulo,
        GETDATE(),
        @FechaEntrega,
        @Relevancia,
        'PENDIENTE',
        @UsuarioAsignado
    )
END

Create procedure kc_Items_Completar
    @IdItem INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ItemsTrabajo
    SET
        Estado = 'COMPLETADO',
        FechaCompletado = GETDATE()
    WHERE IdItem = @IdItem
      AND Estado = 'PENDIENTE';

    SELECT @@ROWCOUNT;
END