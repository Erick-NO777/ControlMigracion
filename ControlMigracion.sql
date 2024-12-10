-- Crear la base de datos
CREATE DATABASE ControlMigracion;
GO

-- Usar la base de datos creada
USE ControlMigracion;
GO

-- Tabla: VIAJEROS
CREATE TABLE VIAJEROS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    SegundoNombre NVARCHAR(100) NULL,
    Apellido1 NVARCHAR(100) NOT NULL,
    Apellido2 NVARCHAR(100) NULL,
    FechaNacimiento DATETIME NOT NULL,
    Nacionalidad NVARCHAR(50) NOT NULL,
    CorreoElectronico NVARCHAR(100) UNIQUE NOT NULL,
    Genero NVARCHAR(10) NOT NULL, -- Ejemplo: 'Masculino', 'Femenino'
    Telefono NVARCHAR(20) NOT NULL
);

-- Tabla: DOCUMENTO
CREATE TABLE DOCUMENTO (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TipoDocumento NVARCHAR(50) NOT NULL, -- Ejemplo: 'Pasaporte', 'DNI'
    NumeroDocumento NVARCHAR(50) UNIQUE NOT NULL,
    FechaExpiracion DATETIME NOT NULL,
    IdViajero INT NOT NULL,
    CONSTRAINT FK_Documento_Viajero FOREIGN KEY (IdViajero)
        REFERENCES VIAJEROS(Id) ON DELETE CASCADE
);

-- Tabla: USUARIOS
CREATE TABLE USUARIOS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(50) UNIQUE NOT NULL,
    Clave NVARCHAR(100) NOT NULL, -- Se recomienda almacenar hashes
    CorreoElectronico NVARCHAR(100) UNIQUE NOT NULL,
    Rol NVARCHAR(50) NOT NULL -- Ejemplo: 'Administrador', 'Supervisor'
);

-- Tabla: PAISES
CREATE TABLE PAISES (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombrePais NVARCHAR(100) UNIQUE NOT NULL
);

-- Tabla: MOVIMIENTOS
CREATE TABLE MOVIMIENTOS (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdViajero INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Destino INT NOT NULL, -- Relación con tabla PAISES
    Origen INT NOT NULL, -- Relación con tabla PAISES
    TipoSolicitud NVARCHAR(50) NOT NULL, -- Ejemplo: 'Entrada', 'Salida'
    IdUsuario INT NOT NULL,
    CONSTRAINT FK_Movimientos_Viajero FOREIGN KEY (IdViajero)
        REFERENCES VIAJEROS(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Movimientos_Destino FOREIGN KEY (Destino)
        REFERENCES PAISES(Id) ON DELETE NO ACTION, -- Cambio aquí
    CONSTRAINT FK_Movimientos_Origen FOREIGN KEY (Origen)
        REFERENCES PAISES(Id) ON DELETE NO ACTION, -- Cambio aquí
    CONSTRAINT FK_Movimientos_Usuario FOREIGN KEY (IdUsuario)
        REFERENCES USUARIOS(Id) ON DELETE CASCADE
);


-- Insertar datos iniciales en PAISES
INSERT INTO PAISES (NombrePais) VALUES 
('Costa Rica'),
('Panamá'),
('Estados Unidos'),
('México'),
('Canadá');

-- Insertar datos iniciales en VIAJEROS
INSERT INTO VIAJEROS (Nombre, SegundoNombre, Apellido1, Apellido2, FechaNacimiento, Nacionalidad, CorreoElectronico, Genero, Telefono)
VALUES
('Juan', 'Carlos', 'Pérez', 'Rodríguez', '1985-07-15 00:00:00', 'Costa Rica', 'juan.perez@example.com', 'Masculino', '50688887777'),
('Ana', NULL, 'Gómez', 'Cordero', '1990-03-10 00:00:00', 'Panamá', 'ana.gomez@example.com', 'Femenino', '50799991111');

-- Insertar datos iniciales en DOCUMENTO
INSERT INTO DOCUMENTO (TipoDocumento, NumeroDocumento, FechaExpiracion, IdViajero)
VALUES
('Pasaporte', 'A12345678', '2030-01-01 00:00:00', 1),
('Pasaporte', 'B87654321', '2028-12-31 00:00:00', 2);

-- Insertar datos iniciales en USUARIOS
INSERT INTO USUARIOS (NombreUsuario, Clave, CorreoElectronico, Rol)
VALUES
('admin', 'hashed_password_123', 'admin@example.com', 'Administrador'),
('supervisor', 'hashed_password_456', 'supervisor@example.com', 'Supervisor');

-- Insertar datos iniciales en MOVIMIENTOS
INSERT INTO MOVIMIENTOS (IdViajero, Fecha, Destino, Origen, TipoSolicitud, IdUsuario)
VALUES
(1, '2024-12-01 12:00:00', 2, 1, 'Entrada', 1),
(2, '2024-12-02 14:00:00', 3, 2, 'Salida', 2);
