USE [master]
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = N'CleanGoDB')
BEGIN
    ALTER DATABASE [CleanGoDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [CleanGoDB];
END
GO

CREATE DATABASE [CleanGoDB]
GO

USE [CleanGoDB]
GO

CREATE TABLE Roles (
    RolId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100) NULL,
    Estado BIT NOT NULL DEFAULT 1
);

CREATE TABLE Usuarios (
    UsuarioId INT IDENTITY(1,1) PRIMARY KEY,
    RolId INT NOT NULL FOREIGN KEY REFERENCES Roles(RolId),
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Correo VARCHAR(100) NULL,
    UltimoAcceso DATETIME NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    Estado BIT NOT NULL DEFAULT 1
);

CREATE TABLE Clientes (
    ClienteId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Cedula VARCHAR(20) NOT NULL UNIQUE,
    Telefono VARCHAR(20) NULL,
    Correo VARCHAR(100) NULL,
    Direccion VARCHAR(200) NULL,
    TelegramChatId VARCHAR(50) NULL,
    FechaRegistro DATETIME NOT NULL DEFAULT GETDATE(),
    Estado BIT NOT NULL DEFAULT 1
);

CREATE TABLE Servicios (
    ServicioId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100) NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1
);

CREATE TABLE TiposPrenda (
    TipoPrendaId INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100) NULL,
    Estado BIT NOT NULL DEFAULT 1
);

CREATE TABLE EstadosOrden (
    EstadoId INT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Descripcion VARCHAR(100) NULL
);

CREATE TABLE Ordenes (
    OrdenId INT IDENTITY(1,1) PRIMARY KEY,
    NumeroOrden VARCHAR(50) NOT NULL UNIQUE,
    ClienteId INT NOT NULL FOREIGN KEY REFERENCES Clientes(ClienteId),
    UsuarioId INT NOT NULL FOREIGN KEY REFERENCES Usuarios(UsuarioId),
    EstadoId INT NOT NULL FOREIGN KEY REFERENCES EstadosOrden(EstadoId),
    FechaRecepcion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaEntregaEstimada DATETIME NULL,
    Total DECIMAL(10,2) NOT NULL DEFAULT 0.00,
    Observaciones VARCHAR(200) NULL
);

CREATE TABLE DetalleOrden (
    DetalleId INT IDENTITY(1,1) PRIMARY KEY,
    OrdenId INT NOT NULL FOREIGN KEY REFERENCES Ordenes(OrdenId) ON DELETE CASCADE,
    TipoPrendaId INT NOT NULL FOREIGN KEY REFERENCES TiposPrenda(TipoPrendaId),
    ServicioId INT NOT NULL FOREIGN KEY REFERENCES Servicios(ServicioId),
    Cantidad INT NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Observaciones VARCHAR(100) NULL
);

CREATE TABLE HistorialEstados (
    HistorialId INT IDENTITY(1,1) PRIMARY KEY,
    OrdenId INT NOT NULL FOREIGN KEY REFERENCES Ordenes(OrdenId) ON DELETE CASCADE,
    EstadoAnteriorId INT NULL FOREIGN KEY REFERENCES EstadosOrden(EstadoId),
    EstadoNuevoId INT NOT NULL FOREIGN KEY REFERENCES EstadosOrden(EstadoId),
    UsuarioId INT NOT NULL FOREIGN KEY REFERENCES Usuarios(UsuarioId),
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Comentario VARCHAR(200) NULL
);

CREATE TABLE Notificaciones (
    NotificacionId INT IDENTITY(1,1) PRIMARY KEY,
    OrdenId INT NOT NULL FOREIGN KEY REFERENCES Ordenes(OrdenId) ON DELETE CASCADE,
    Mensaje VARCHAR(500) NOT NULL,
    Destinatario VARCHAR(50) NOT NULL,
    TipoNotificacion VARCHAR(20) NOT NULL,
    Intentos INT NOT NULL DEFAULT 0,
    Enviada BIT NOT NULL DEFAULT 0,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE(),
    FechaEnvio DATETIME NULL
);

GO

INSERT INTO Roles (Nombre, Descripcion, Estado) VALUES 
('Administrador', 'Acceso completo al sistema', 1),
('Operador', 'Acceso limitado a transacciones de lavanderia', 1);

INSERT INTO EstadosOrden (EstadoId, Nombre, Descripcion) VALUES 
(1, 'Recibida', 'Orden registrada en el sistema'),
(2, 'En Proceso', 'Prendas en etapa de lavado o secado'),
(3, 'Lista para Entrega', 'Prendas listas para ser devueltas al cliente'),
(4, 'Entregada', 'Orden pagada y retirada por el cliente'),
(5, 'Cancelada', 'Orden anulada por el operador');

INSERT INTO Usuarios (RolId, Nombre, Apellido, NombreUsuario, PasswordHash, Correo, Estado) VALUES 
(1, 'Administrador', 'Sistema', 'admin', 'jZae727K0YUXB55c1t4W/5O0Ld551xPJw4r00000000=', 'admin@cleango.com', 1);

GO

GO

CREATE   PROCEDURE Cliente_Buscar
(
    @Busqueda VARCHAR(100)
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ClienteId,
        Nombre,
        Apellido,
        Cedula,
        Telefono,
        Correo
    FROM Clientes
    WHERE
        Nombre LIKE '%' + @Busqueda + '%'
        OR Apellido LIKE '%' + @Busqueda + '%'
        OR Cedula LIKE '%' + @Busqueda + '%'
        OR Telefono LIKE '%' + @Busqueda + '%'
    ORDER BY Nombre, Apellido;
END

GO

CREATE   PROCEDURE Cliente_Create
(
    @Nombre VARCHAR(80),
    @Apellido VARCHAR(80),
    @Cedula VARCHAR(20),
    @Telefono VARCHAR(20),
    @Correo VARCHAR(120),
    @Direccion VARCHAR(250),
    @TelegramChatId VARCHAR(100)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Clientes
    (
        Nombre,
        Apellido,
        Cedula,
        Telefono,
        Correo,
        Direccion,
        TelegramChatId
    )
    VALUES
    (
        @Nombre,
        @Apellido,
        @Cedula,
        @Telefono,
        @Correo,
        @Direccion,
        @TelegramChatId
    );

    SELECT SCOPE_IDENTITY() AS ClienteId;
END

GO

CREATE   PROCEDURE Cliente_Delete
(
    @ClienteId INT
)
AS
BEGIN
    UPDATE Clientes
    SET Estado = 0
    WHERE ClienteId = @ClienteId;
END

GO
CREATE PROCEDURE Cliente_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ClienteId,
        Nombre,
        Apellido,
        Cedula,
        Telefono,
        Correo,
        Direccion,
        TelegramChatId,
        FechaRegistro,
        Estado
    FROM Clientes
    ORDER BY Nombre, Apellido;
END

GO

CREATE   PROCEDURE Cliente_GetById
(
    @ClienteId INT
)
AS
BEGIN
    SELECT *
    FROM Clientes
    WHERE ClienteId = @ClienteId;
END

GO

CREATE   PROCEDURE Cliente_Update
(
    @ClienteId INT,
    @Nombre VARCHAR(80),
    @Apellido VARCHAR(80),
    @Cedula VARCHAR(20),
    @Telefono VARCHAR(20),
    @Correo VARCHAR(120),
    @Direccion VARCHAR(250),
    @TelegramChatId VARCHAR(100),
    @Estado BIT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Clientes
    SET
        Nombre = @Nombre,
        Apellido = @Apellido,
        Cedula = @Cedula,
        Telefono = @Telefono,
        Correo = @Correo,
        Direccion = @Direccion,
        TelegramChatId = @TelegramChatId,
        Estado = @Estado
    WHERE ClienteId = @ClienteId;
END

GO

CREATE   PROCEDURE DetalleOrden_Create
(
    @OrdenId INT,
    @TipoPrendaId INT,
    @ServicioId INT,
    @Cantidad INT,
    @Precio DECIMAL(10,2),
    @Observaciones VARCHAR(200)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        INSERT INTO DetalleOrden
        (
            OrdenId,
            TipoPrendaId,
            ServicioId,
            Cantidad,
            Precio,
            Observaciones
        )
        VALUES
        (
            @OrdenId,
            @TipoPrendaId,
            @ServicioId,
            @Cantidad,
            @Precio,
            @Observaciones
        );

        EXEC Orden_ActualizarTotal @OrdenId;

        COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION;

        THROW;

    END CATCH

END

GO

CREATE   PROCEDURE DetalleOrden_Delete
(
    @DetalleId INT
)
AS
BEGIN

SET NOCOUNT ON;

DECLARE @OrdenId INT;

SELECT @OrdenId=OrdenId
FROM DetalleOrden
WHERE DetalleId=@DetalleId;

DELETE FROM DetalleOrden

WHERE DetalleId=@DetalleId;

EXEC Orden_ActualizarTotal @OrdenId;

END

GO

CREATE   PROCEDURE DetalleOrden_Existe
(
    @OrdenId INT,
    @TipoPrendaId INT,
    @ServicioId INT
)
AS
BEGIN

SELECT COUNT(*)

FROM DetalleOrden

WHERE OrdenId=@OrdenId
AND TipoPrendaId=@TipoPrendaId
AND ServicioId=@ServicioId;

END

GO

CREATE   PROCEDURE DetalleOrden_GetById
(
    @DetalleId INT
)
AS
BEGIN

SELECT *

FROM DetalleOrden

WHERE DetalleId=@DetalleId;

END

GO

CREATE   PROCEDURE DetalleOrden_GetByOrden
(
    @OrdenId INT
)
AS
BEGIN

SET NOCOUNT ON;

SELECT

d.DetalleId,

tp.Nombre AS Prenda,

s.Nombre AS Servicio,

d.Cantidad,

d.Precio,

(d.Cantidad*d.Precio) AS SubTotal,

d.Observaciones

FROM DetalleOrden d

INNER JOIN TiposPrenda tp
ON d.TipoPrendaId=tp.TipoPrendaId

INNER JOIN Servicios s
ON d.ServicioId=s.ServicioId

WHERE d.OrdenId=@OrdenId;

END

GO

CREATE   PROCEDURE DetalleOrden_Update
(
    @DetalleId INT,
    @TipoPrendaId INT,
    @ServicioId INT,
    @Cantidad INT,
    @Precio DECIMAL(10,2),
    @Observaciones VARCHAR(200)
)
AS
BEGIN

SET NOCOUNT ON;

DECLARE @OrdenId INT;

SELECT @OrdenId = OrdenId
FROM DetalleOrden
WHERE DetalleId=@DetalleId;

UPDATE DetalleOrden

SET

TipoPrendaId=@TipoPrendaId,
ServicioId=@ServicioId,
Cantidad=@Cantidad,
Precio=@Precio,
Observaciones=@Observaciones

WHERE DetalleId=@DetalleId;

EXEC Orden_ActualizarTotal @OrdenId;

END

GO

    CREATE PROCEDURE EstadosOrden_GetAll
    AS
    BEGIN
        SET NOCOUNT ON;
        SELECT EstadoId, Nombre FROM EstadosOrden ORDER BY EstadoId;
    END

GO
CREATE   PROCEDURE HistorialEstados_Create
(
    @OrdenId INT,
    @EstadoAnteriorId INT = NULL,
    @EstadoNuevoId INT,
    @UsuarioId INT,
    @Comentario VARCHAR(250)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO HistorialEstados
    (
        OrdenId,
        EstadoAnteriorId,
        EstadoNuevoId,
        UsuarioId,
        Fecha,
        Comentario
    )
    VALUES
    (
        @OrdenId,
        @EstadoAnteriorId,
        @EstadoNuevoId,
        @UsuarioId,
        GETDATE(),
        @Comentario
    );
END

GO

/*=========================================================*/

CREATE   PROCEDURE HistorialEstados_GetByOrden
(
    @OrdenId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT

        h.HistorialId,

        ea.Nombre AS EstadoAnterior,

        en.Nombre AS EstadoNuevo,

        u.Nombre + ' ' + u.Apellido AS Usuario,

        h.Fecha,

        h.Comentario

    FROM HistorialEstados h

    LEFT JOIN EstadosOrden ea
        ON h.EstadoAnteriorId = ea.EstadoId

    INNER JOIN EstadosOrden en
        ON h.EstadoNuevoId = en.EstadoId

    INNER JOIN Usuarios u
        ON h.UsuarioId = u.UsuarioId

    WHERE h.OrdenId = @OrdenId

    ORDER BY h.Fecha;
END

GO

CREATE   PROCEDURE Notificacion_AumentarIntento
(
    @NotificacionId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Notificaciones

    SET Intentos=Intentos+1

    WHERE NotificacionId=@NotificacionId;

END

GO

CREATE   PROCEDURE Notificacion_Create
(
    @OrdenId INT,
    @ClienteId INT,
    @Mensaje VARCHAR(500)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Notificaciones
    (
        OrdenId,
        ClienteId,
        Mensaje,
        FechaCreacion,
        Estado,
        Intentos
    )
    VALUES
    (
        @OrdenId,
        @ClienteId,
        @Mensaje,
        GETDATE(),
        'Pendiente',
        0
    );
END

GO

CREATE   PROCEDURE Notificacion_GetByOrden
(
    @OrdenId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *

    FROM Notificaciones

    WHERE OrdenId=@OrdenId

    ORDER BY FechaCreacion DESC;

END

GO

CREATE   PROCEDURE Notificacion_GetPendientes
AS
BEGIN
    SET NOCOUNT ON;

    SELECT

        n.NotificacionId,

        n.OrdenId,

        n.ClienteId,

        c.TelegramChatId,

        n.Mensaje,

        n.Intentos

    FROM Notificaciones n

    INNER JOIN Clientes c
        ON n.ClienteId = c.ClienteId

    WHERE n.Estado = 'Pendiente' AND n.Intentos < 3

    ORDER BY n.FechaCreacion;
END

GO

CREATE   PROCEDURE Notificacion_MarcarEnviada
(
    @NotificacionId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Notificaciones

    SET

        Estado='Enviada',
        FechaEnvio=GETDATE()

    WHERE NotificacionId=@NotificacionId;

END

GO

CREATE   PROCEDURE Orden_ActualizarTotal
(
    @OrdenId INT
)
AS
BEGIN

UPDATE Ordenes

SET Total =

(
SELECT SUM(Precio*Cantidad)

FROM DetalleOrden

WHERE OrdenId=@OrdenId
)

WHERE OrdenId=@OrdenId;

END

GO

CREATE   PROCEDURE Orden_Buscar
(
    @Busqueda VARCHAR(100)
)
AS
BEGIN

SELECT

o.OrdenId,
o.NumeroOrden,
c.Nombre+' '+c.Apellido Cliente,
e.Nombre Estado,
o.Total

FROM Ordenes o

INNER JOIN Clientes c
ON o.ClienteId=c.ClienteId

INNER JOIN EstadosOrden e
ON o.EstadoId=e.EstadoId

WHERE

o.NumeroOrden LIKE '%'+@Busqueda+'%'

OR

c.Nombre LIKE '%'+@Busqueda+'%'

OR

c.Apellido LIKE '%'+@Busqueda+'%';

END

GO

CREATE   PROCEDURE Orden_Create
(
    @NumeroOrden VARCHAR(20),
    @ClienteId INT,
    @FechaEntregaEstimada DATETIME,
    @Observaciones VARCHAR(300),
    @UsuarioRegistroId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Ordenes
        (
            NumeroOrden,
            ClienteId,
            EstadoId,
            FechaRecepcion,
            FechaEntregaEstimada,
            Observaciones,
            Total,
            UsuarioRegistroId
        )
        VALUES
        (
            @NumeroOrden,
            @ClienteId,
            1,
            GETDATE(),
            @FechaEntregaEstimada,
            @Observaciones,
            0,
            @UsuarioRegistroId
        );

        DECLARE @OrdenId INT = SCOPE_IDENTITY();

        INSERT INTO HistorialEstados
        (
            OrdenId,
            EstadoAnteriorId,
            EstadoNuevoId,
            UsuarioId,
            Fecha,
            Comentario
        )
        VALUES
        (
            @OrdenId,
            NULL,
            1,
            @UsuarioRegistroId,
            GETDATE(),
            'Orden creada'
        );

        COMMIT TRANSACTION;

        SELECT @OrdenId AS OrdenId;

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION;

        THROW;

    END CATCH

END

GO

CREATE   PROCEDURE Orden_Delete
(
    @OrdenId INT
)
AS
BEGIN

UPDATE Ordenes

SET EstadoId=5

WHERE OrdenId=@OrdenId;

END

GO
CREATE PROCEDURE Orden_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        OrdenId,
        NumeroOrden,
        ClienteId,
        FechaRecepcion,
        FechaEntregaEstimada,
        Observaciones,
        Total,
        EstadoId,
        UsuarioRegistroId
    FROM Ordenes
    ORDER BY OrdenId DESC;
END

GO

CREATE   PROCEDURE Orden_GetById
(
    @OrdenId INT
)
AS
BEGIN

SELECT *

FROM Ordenes

WHERE OrdenId=@OrdenId;

END

GO
CREATE PROCEDURE [dbo].[Orden_GetByNumero]
    @NumeroOrden VARCHAR(50)
AS
BEGIN
    SELECT o.OrdenId, 
           o.NumeroOrden, 
           c.Nombre + ' ' + c.Apellido AS Cliente, 
           e.Nombre AS Estado, 
           o.FechaRecepcion, 
           o.FechaEntregaEstimada, 
           o.Total, 
           o.Observaciones 
    FROM Ordenes o 
    INNER JOIN Clientes c ON o.ClienteId = c.ClienteId 
    INNER JOIN EstadosOrden e ON o.EstadoId = e.EstadoId 
    WHERE o.NumeroOrden = @NumeroOrden
END

GO
CREATE PROCEDURE [dbo].[Orden_GetComboList]
AS
BEGIN
    SELECT o.NumeroOrden, 
           o.NumeroOrden + ' - ' + c.Nombre + ' ' + c.Apellido + ' ($' + CAST(o.Total AS VARCHAR) + ')' AS DisplayLabel 
    FROM Ordenes o 
    INNER JOIN Clientes c ON o.ClienteId = c.ClienteId 
    ORDER BY o.OrdenId DESC
END

GO
CREATE PROCEDURE [dbo].[Orden_GetDetalle]
    @OrdenId INT
AS
BEGIN
    SELECT tp.Nombre AS Prenda, 
           s.Nombre AS Servicio, 
           d.Cantidad, 
           d.Precio, 
           (d.Cantidad * d.Precio) AS SubTotal, 
           d.Observaciones 
    FROM DetalleOrden d 
    INNER JOIN TiposPrenda tp ON d.TipoPrendaId = tp.TipoPrendaId 
    INNER JOIN Servicios s ON d.ServicioId = s.ServicioId 
    WHERE d.OrdenId = @OrdenId
END

GO
CREATE PROCEDURE [dbo].[Orden_GetHistorialEstados]
    @OrdenId INT
AS
BEGIN
    SELECT h.HistorialId, 
           ea.Nombre AS EstadoAnterior, 
           en.Nombre AS EstadoNuevo, 
           u.Nombre + ' ' + u.Apellido AS Usuario, 
           h.Fecha, 
           h.Comentario 
    FROM HistorialEstados h 
    LEFT JOIN EstadosOrden ea ON h.EstadoAnteriorId = ea.EstadoId 
    INNER JOIN EstadosOrden en ON h.EstadoNuevoId = en.EstadoId 
    INNER JOIN Usuarios u ON h.UsuarioId = u.UsuarioId 
    WHERE h.OrdenId = @OrdenId 
    ORDER BY h.Fecha
END

GO
CREATE PROCEDURE [dbo].[Orden_GetReporte]
    @Desde DATETIME = NULL,
    @Hasta DATETIME = NULL,
    @Estado VARCHAR(50) = 'Todos'
AS
BEGIN
    SELECT o.OrdenId, 
           o.NumeroOrden, 
           c.Nombre + ' ' + c.Apellido AS Cliente, 
           e.Nombre AS Estado, 
           o.FechaRecepcion, 
           o.FechaEntregaEstimada, 
           o.Total 
    FROM Ordenes o 
    INNER JOIN Clientes c ON o.ClienteId = c.ClienteId 
    INNER JOIN EstadosOrden e ON o.EstadoId = e.EstadoId 
    WHERE (@Desde IS NULL OR o.FechaRecepcion >= @Desde)
      AND (@Hasta IS NULL OR o.FechaRecepcion <= @Hasta)
      AND (@Estado = 'Todos' OR e.Nombre = @Estado)
    ORDER BY o.FechaRecepcion DESC
END

GO

CREATE   PROCEDURE Orden_UpdateEstado
(
    @OrdenId INT,
    @EstadoNuevo INT,
    @UsuarioId INT,
    @Comentario VARCHAR(250)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        DECLARE @EstadoAnterior INT;

        SELECT @EstadoAnterior = EstadoId
        FROM Ordenes
        WHERE OrdenId = @OrdenId;

        IF(@EstadoNuevo = 4 AND @EstadoAnterior <> 3)
        BEGIN
            RAISERROR('La orden solo puede entregarse cuando esté Lista para Entrega.',16,1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        UPDATE Ordenes
        SET
            EstadoId = @EstadoNuevo,
            FechaEntregaReal = CASE
                                    WHEN @EstadoNuevo = 4
                                    THEN GETDATE()
                                    ELSE FechaEntregaReal
                               END
        WHERE OrdenId = @OrdenId;

        INSERT INTO HistorialEstados
        (
            OrdenId,
            EstadoAnteriorId,
            EstadoNuevoId,
            UsuarioId,
            Fecha,
            Comentario
        )
        VALUES
        (
            @OrdenId,
            @EstadoAnterior,
            @EstadoNuevo,
            @UsuarioId,
            GETDATE(),
            @Comentario
        );

        INSERT INTO Notificaciones
        (
            OrdenId,
            ClienteId,
            Mensaje
        )
        SELECT
            o.OrdenId,
            o.ClienteId,
            'Su orden cambió de estado.'
        FROM Ordenes o
        WHERE o.OrdenId=@OrdenId;

        COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION;

        THROW;

    END CATCH

END

GO

CREATE   PROCEDURE Rol_Create
(
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(200)
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Roles
    (
        Nombre,
        Descripcion
    )
    VALUES
    (
        @Nombre,
        @Descripcion
    );

    SELECT SCOPE_IDENTITY() AS RolId;
END

GO

CREATE   PROCEDURE Rol_Delete
(
    @RolId INT
)
AS
BEGIN
    UPDATE Roles
    SET Estado = 0
    WHERE RolId = @RolId;
END

GO

CREATE   PROCEDURE Rol_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        RolId,
        Nombre,
        Descripcion,
        Estado
    FROM Roles
    ORDER BY Nombre;
END

GO

CREATE   PROCEDURE Rol_GetById
(
    @RolId INT
)
AS
BEGIN
    SELECT *
    FROM Roles
    WHERE RolId = @RolId;
END

GO

CREATE   PROCEDURE Rol_Update
(
    @RolId INT,
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(200),
    @Estado BIT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Roles
    SET
        Nombre = @Nombre,
        Descripcion = @Descripcion,
        Estado = @Estado
    WHERE RolId = @RolId;
END

GO

CREATE   PROCEDURE Servicio_Buscar
(
    @Busqueda VARCHAR(100)
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ServicioId,
        Nombre,
        PrecioBase,
        Descripcion,
        Estado
    FROM Servicios
    WHERE Nombre LIKE '%' + @Busqueda + '%'
    ORDER BY Nombre;
END

GO

CREATE   PROCEDURE Servicio_Create
(
    @Nombre VARCHAR(80),
    @PrecioBase DECIMAL(10,2),
    @Descripcion VARCHAR(200)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        INSERT INTO Servicios
        (
            Nombre,
            PrecioBase,
            Descripcion
        )
        VALUES
        (
            @Nombre,
            @PrecioBase,
            @Descripcion
        );

        SELECT SCOPE_IDENTITY() AS ServicioId;

    END TRY

    BEGIN CATCH

        THROW;

    END CATCH

END

GO

CREATE   PROCEDURE Servicio_Delete
(
    @ServicioId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Servicios
    SET Estado = 0
    WHERE ServicioId = @ServicioId;
END

GO

CREATE   PROCEDURE Servicio_Existe
(
    @Nombre VARCHAR(80)
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*) AS Existe
    FROM Servicios
    WHERE Nombre = @Nombre;
END

GO

CREATE   PROCEDURE Servicio_GetActivos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ServicioId,
        Nombre,
        PrecioBase
    FROM Servicios
    WHERE Estado = 1
    ORDER BY Nombre;
END

GO

CREATE   PROCEDURE Servicio_GetAll
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        ServicioId,
        Nombre,
        PrecioBase,
        Descripcion,
        Estado
    FROM Servicios
    ORDER BY Nombre;
END

GO

CREATE   PROCEDURE Servicio_GetById
(
    @ServicioId INT
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM Servicios
    WHERE ServicioId = @ServicioId;
END

GO

CREATE   PROCEDURE Servicio_Update
(
    @ServicioId INT,
    @Nombre VARCHAR(80),
    @PrecioBase DECIMAL(10,2),
    @Descripcion VARCHAR(200),
    @Estado BIT
)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Servicios
    SET
        Nombre = @Nombre,
        PrecioBase = @PrecioBase,
        Descripcion = @Descripcion,
        Estado = @Estado
    WHERE ServicioId = @ServicioId;
END

GO

CREATE   PROCEDURE TipoPrenda_Buscar
(
    @Busqueda VARCHAR(100)
)
AS
BEGIN

    SET NOCOUNT ON;

    SELECT

        TipoPrendaId,
        Nombre,
        Descripcion,
        Estado

    FROM TiposPrenda

    WHERE Nombre LIKE '%'+@Busqueda+'%'

    ORDER BY Nombre;

END

GO

CREATE   PROCEDURE TipoPrenda_Create
(
    @Nombre VARCHAR(80),
    @Descripcion VARCHAR(200)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        INSERT INTO TiposPrenda
        (
            Nombre,
            Descripcion
        )
        VALUES
        (
            @Nombre,
            @Descripcion
        );

        SELECT SCOPE_IDENTITY() AS TipoPrendaId;

    END TRY
    BEGIN CATCH

        THROW;

    END CATCH
END

GO

CREATE   PROCEDURE TipoPrenda_Delete
(
    @TipoPrendaId INT
)
AS
BEGIN

    SET NOCOUNT ON;

    UPDATE TiposPrenda

    SET Estado=0

    WHERE TipoPrendaId=@TipoPrendaId;

END

GO

CREATE   PROCEDURE TipoPrenda_Existe
(
    @Nombre VARCHAR(80)
)
AS
BEGIN

    SET NOCOUNT ON;

    SELECT COUNT(*) AS Existe

    FROM TiposPrenda

    WHERE Nombre=@Nombre;

END

GO

CREATE   PROCEDURE TipoPrenda_GetActivos
AS
BEGIN

    SET NOCOUNT ON;

    SELECT

        TipoPrendaId,
        Nombre

    FROM TiposPrenda

    WHERE Estado=1

    ORDER BY Nombre;

END

GO

CREATE   PROCEDURE TipoPrenda_GetAll
AS
BEGIN

    SET NOCOUNT ON;

    SELECT

        TipoPrendaId,
        Nombre,
        Descripcion,
        Estado

    FROM TiposPrenda

    ORDER BY Nombre;

END

GO

CREATE   PROCEDURE TipoPrenda_GetById
(
    @TipoPrendaId INT
)
AS
BEGIN

    SET NOCOUNT ON;

    SELECT *

    FROM TiposPrenda

    WHERE TipoPrendaId=@TipoPrendaId;

END

GO

CREATE   PROCEDURE TipoPrenda_Update
(
    @TipoPrendaId INT,
    @Nombre VARCHAR(80),
    @Descripcion VARCHAR(200),
    @Estado BIT
)
AS
BEGIN

    SET NOCOUNT ON;

    UPDATE TiposPrenda
    SET

        Nombre=@Nombre,
        Descripcion=@Descripcion,
        Estado=@Estado

    WHERE TipoPrendaId=@TipoPrendaId;

END

GO

CREATE   PROCEDURE Usuario_Create
(
    @RolId INT,
    @Nombre VARCHAR(80),
    @Apellido VARCHAR(80),
    @Usuario VARCHAR(50),
    @Correo VARCHAR(150),
    @PasswordHash VARCHAR(255)
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY

        INSERT INTO Usuarios
        (
            RolId,
            Nombre,
            Apellido,
            Usuario,
            Correo,
            PasswordHash
        )
        VALUES
        (
            @RolId,
            @Nombre,
            @Apellido,
            @Usuario,
            @Correo,
            @PasswordHash
        );

        SELECT SCOPE_IDENTITY() AS UsuarioId;

    END TRY

    BEGIN CATCH

        THROW;

    END CATCH

END

GO

CREATE   PROCEDURE Usuario_Delete
(
    @UsuarioId INT
)
AS
BEGIN

UPDATE Usuarios

SET Estado=0

WHERE UsuarioId=@UsuarioId;

END

GO

CREATE   PROCEDURE Usuario_GetAll
AS
BEGIN

SET NOCOUNT ON;

SELECT

u.UsuarioId,
u.Nombre,
u.Apellido,
u.Usuario,
u.Correo,
r.Nombre Rol,
u.Estado

FROM Usuarios u

INNER JOIN Roles r
ON u.RolId=r.RolId

ORDER BY u.Nombre;

END

GO

CREATE   PROCEDURE Usuario_GetById
(
    @UsuarioId INT
)
AS
BEGIN

SELECT *

FROM Usuarios

WHERE UsuarioId=@UsuarioId;

END

GO

CREATE   PROCEDURE Usuario_Login
(
    @Usuario VARCHAR(50),
    @PasswordHash VARCHAR(255)
)
AS
BEGIN

SET NOCOUNT ON;

SELECT

u.UsuarioId,
u.Nombre,
u.Apellido,
u.Usuario,
u.RolId,
r.Nombre AS Rol

FROM Usuarios u

INNER JOIN Roles r
ON u.RolId=r.RolId

WHERE

u.Usuario=@Usuario
AND u.PasswordHash=@PasswordHash
AND u.Estado=1;

END

GO

CREATE   PROCEDURE Usuario_Update
(
    @UsuarioId INT,
    @RolId INT,
    @Nombre VARCHAR(80),
    @Apellido VARCHAR(80),
    @Usuario VARCHAR(50),
    @Correo VARCHAR(150),
    @Estado BIT
)
AS
BEGIN

SET NOCOUNT ON;

UPDATE Usuarios
SET

RolId=@RolId,
Nombre=@Nombre,
Apellido=@Apellido,
Usuario=@Usuario,
Correo=@Correo,
Estado=@Estado

WHERE UsuarioId=@UsuarioId;

END

GO

CREATE   PROCEDURE Usuario_UpdateUltimoAcceso
(
    @UsuarioId INT
)
AS
BEGIN

UPDATE Usuarios

SET UltimoAcceso=GETDATE()

WHERE UsuarioId=@UsuarioId;

END
