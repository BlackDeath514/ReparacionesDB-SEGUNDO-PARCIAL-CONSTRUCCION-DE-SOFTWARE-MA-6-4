-- ================================================
-- Script para la creación de la base de datos y tablas
-- ================================================

-- Crear la base de datos
-- Asegúrate de estar en el servidor correcto antes de ejecutar
CREATE DATABASE DB_POE_FINAL;
USE DB_POE_FINAL;

-- ================================================
-- Crear la tabla CLIENTES
-- ================================================
-- Esta tabla almacena la información de los clientes.
CREATE TABLE CLIENTES (
    ID_CLIENTE INT IDENTITY(1,1) PRIMARY KEY,
    NOMBRE_CLIENTE VARCHAR(15) NOT NULL,
    APELLIDO_CLIENTE VARCHAR(15) NOT NULL,
    CEDULA_CLIENTE VARCHAR(10) NOT NULL,
    NUMERO_CLIENTE VARCHAR(10) NOT NULL,
    DIRECCION_CLIENTE VARCHAR(200) NOT NULL
);

-- ================================================
-- Procedimientos para la tabla CLIENTES
-- ================================================

-- 1. Obtener todos los clientes
-- Este procedimiento devuelve todos los registros de la tabla CLIENTES.
CREATE PROCEDURE SP_GET_ALL_CLIENTE
AS
BEGIN
    SELECT * FROM CLIENTES;
END;

-- 2. Crear un nuevo cliente
-- Este procedimiento permite crear un nuevo cliente en la tabla CLIENTES.
CREATE PROCEDURE SP_CREAR_CLIENTE(
    @n_cliente VARCHAR(15),
    @a_cliente VARCHAR(15),
    @c_cliente VARCHAR(10),
    @num_cliente VARCHAR(10),
    @d_cliente VARCHAR(200)
)
AS
BEGIN
    INSERT INTO CLIENTES (NOMBRE_CLIENTE, APELLIDO_CLIENTE, CEDULA_CLIENTE, NUMERO_CLIENTE, DIRECCION_CLIENTE)
    VALUES (@n_cliente, @a_cliente, @c_cliente, @num_cliente, @d_cliente);
END;

-- 3. Actualizar un cliente existente
-- Este procedimiento actualiza los detalles de un cliente por su ID.
CREATE PROCEDURE SP_ACTUALIZAR_CLIENTE (
    @ID_CLIENTE INT,
    @NOMBRE_CLIENTE VARCHAR(15),
    @APELLIDO_CLIENTE VARCHAR(15),
    @CEDULA_CLIENTE VARCHAR(10),
    @NUMERO_CLIENTE VARCHAR(10),
    @DIRECCION_CLIENTE VARCHAR(200)
)
AS
BEGIN
    UPDATE CLIENTES
    SET 
        NOMBRE_CLIENTE = @NOMBRE_CLIENTE,
        APELLIDO_CLIENTE = @APELLIDO_CLIENTE,
        CEDULA_CLIENTE = @CEDULA_CLIENTE,
        NUMERO_CLIENTE = @NUMERO_CLIENTE,
        DIRECCION_CLIENTE = @DIRECCION_CLIENTE
    WHERE ID_CLIENTE = @ID_CLIENTE;
END;

-- 4. Eliminar un cliente
-- Este procedimiento elimina un cliente de la tabla CLIENTES por su ID.
CREATE PROCEDURE SP_ELIMINAR_CLIENTE
    @ID_CLIENTE INT
AS
BEGIN
    DELETE FROM CLIENTES
    WHERE ID_CLIENTE = @ID_CLIENTE;
END;

-- 5. Obtener el nombre de un cliente
CREATE PROCEDURE SP_GET_NOMBRE_CLIENTE
AS
BEGIN
    SELECT ID_CLIENTE, NOMBRE_CLIENTE FROM CLIENTES;
END;
-- ================================================
-- Crear la tabla EQUIPOSCELULARES
-- ================================================
-- Esta tabla almacena la información sobre los equipos celulares de los clientes.
CREATE TABLE EQUIPOSCELULARES (
    ID_EQUIPO INT IDENTITY(1,1) PRIMARY KEY,
    MODELO_EQUIPO VARCHAR(50) NOT NULL,
    MARCA_EQUIPO VARCHAR(50) NOT NULL,
    DETALLE_EQUIPO VARCHAR(255) NOT NULL,
    CLIENTE_ID INT NOT NULL,
    CONSTRAINT FK_EQUIPOS_CLIENTES FOREIGN KEY (CLIENTE_ID) 
    REFERENCES CLIENTES(ID_CLIENTE) ON DELETE CASCADE
);

-- ================================================
-- Procedimientos para la tabla EQUIPOS CELULARES
-- ================================================

-- 1. Obtener todos los equipos celulares
-- Este procedimiento devuelve todos los equipos celulares.
CREATE PROCEDURE SP_GET_ALL_CELULAR
AS
BEGIN
    SELECT * FROM EQUIPOSCELULARES;
END;

-- 2. Crear un nuevo equipo celular
-- Este procedimiento crea un nuevo equipo celular asociado a un cliente.
CREATE PROCEDURE SP_CREAR_CELULAR(
    @modelo VARCHAR(50),
    @marca VARCHAR(50),
    @detalle VARCHAR(255),
    @cliente_id INT
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM CLIENTES WHERE ID_CLIENTE = @cliente_id)
    BEGIN
        INSERT INTO EQUIPOSCELULARES (MODELO_EQUIPO, MARCA_EQUIPO, DETALLE_EQUIPO, CLIENTE_ID)
        VALUES (@modelo, @marca, @detalle, @cliente_id);
    END
    ELSE
    BEGIN
        RAISERROR ('El CLIENTE_ID no existe.', 16, 1);
    END
END;

-- 3. Eliminar un equipo celular
-- Este procedimiento elimina un equipo celular por su ID.
CREATE PROCEDURE SP_ELIMINAR_CELULAR
    @ID_EQUIPO INT
AS
BEGIN
    DELETE FROM EQUIPOSCELULARES
    WHERE ID_EQUIPO = @ID_EQUIPO;
END;

-- 4. Actualizar un equipo celular
-- Este procedimiento actualiza los detalles de un equipo celular.
CREATE PROCEDURE SP_ACTUALIZAR_EQUIPO
    @ID_EQUIPO INT,
    @MODELO_EQUIPO VARCHAR(50),
    @MARCA_EQUIPO VARCHAR(50),
    @DETALLE_EQUIPO VARCHAR(255),
    @CLIENTE_ID INT
AS
BEGIN
    UPDATE EQUIPOSCELULARES
    SET 
        MODELO_EQUIPO = @MODELO_EQUIPO,
        MARCA_EQUIPO = @MARCA_EQUIPO,
        DETALLE_EQUIPO = @DETALLE_EQUIPO,
        CLIENTE_ID = @CLIENTE_ID
    WHERE ID_EQUIPO = @ID_EQUIPO;
END;

--5. Mostrar celulares con nombre de cliente
CREATE PROCEDURE SP_CELULAR_CLIENTE
    @CLIENTE_ID INT
AS
BEGIN
    SELECT CLIENTE_ID, CONCAT(MARCA_EQUIPO, ' ', MODELO_EQUIPO) AS DESCRIPCION_CELL
    FROM EQUIPOSCELULARES
    WHERE CLIENTE_ID = @CLIENTE_ID;
END;

-- ================================================
-- Crear la tabla USUARIOS (session)
-- ================================================
-- Esta tabla almacena la información de los usuarios para iniciar sesión.
CREATE TABLE USER_SESSION (
    ID_USER INT IDENTITY(1,1) PRIMARY KEY,
    USUARIO VARCHAR(10) NOT NULL,
    CONTRASENA VARCHAR(10) NOT NULL
);

-- ================================================
-- Procedimientos para la tabla USUARIOS
-- ================================================

-- 1. Crear un nuevo usuario
-- Este procedimiento permite la creación de un nuevo usuario.
CREATE PROCEDURE SP_CREAR_USERS
    @Usuario VARCHAR(10),
    @Contrasena VARCHAR(10)
AS
BEGIN
    INSERT INTO USER_SESSION (USUARIO, CONTRASENA) VALUES (@Usuario, @Contrasena);
END;

-- 2. Validar usuario y contraseña
-- Este procedimiento valida si el usuario y la contraseña existen en la tabla.
CREATE PROCEDURE SP_VALIDAR_USER
    @Usuario_u VARCHAR(10),
    @Contrasena_u VARCHAR(50)
AS
BEGIN
    SELECT COUNT(1) 
    FROM USER_SESSION 
    WHERE USUARIO = @Usuario_u AND CONTRASENA = @Contrasena_u;
END;

-- ================================================
-- Crear la tabla TECNICOS
-- ================================================
-- Esta tabla almacena los datos de los técnicos que manejan los equipos celulares.
CREATE TABLE TECNICOS (
    ID_TECNICO INT IDENTITY(1,1) PRIMARY KEY,
    NOMBRE_TECNICO VARCHAR(15) NOT NULL,
    APELLIDO_TECNICO VARCHAR(15) NOT NULL,
    CEDULA_TECNICO VARCHAR(10) NOT NULL,
    NUMERO_TECNICO VARCHAR(10) NOT NULL,
    EXPERIENCIA_TECNICO VARCHAR(50) NOT NULL
);

-- ================================================
-- Procedimientos para la tabla TECNICOS
-- ================================================

-- 1. Obtener todos los técnicos
-- Este procedimiento devuelve todos los técnicos registrados.
CREATE PROCEDURE SP_GET_ALL_TECNICO
AS
BEGIN
    SELECT * FROM TECNICOS;
END;

-- 2. Crear un nuevo técnico
-- Este procedimiento crea un nuevo técnico en la base de datos.
CREATE PROCEDURE SP_CREAR_TECNICO(
    @n_tecnico VARCHAR(15),
    @a_tecnico VARCHAR(15),
    @c_tecnico VARCHAR(10),
    @num_tecnico VARCHAR(10),
    @ex_tecnico VARCHAR(50)
)
AS
BEGIN
    INSERT INTO TECNICOS (NOMBRE_TECNICO, APELLIDO_TECNICO, CEDULA_TECNICO, NUMERO_TECNICO, EXPERIENCIA_TECNICO)
    VALUES (@n_tecnico, @a_tecnico, @c_tecnico, @num_tecnico, @ex_tecnico);
END;

-- 3. Eliminar un técnico
-- Este procedimiento elimina un técnico de la tabla TECNICOS por su ID.
CREATE PROCEDURE SP_ELIMINAR_TECNICO
    @ID_TECNICO INT
AS
BEGIN
    DELETE FROM TECNICOS
    WHERE ID_TECNICO = @ID_TECNICO;
END;

-- 4. Actualizar un técnico
-- Este procedimiento actualiza un técnico de la tabla TECNICOS por su ID.
CREATE PROCEDURE SP_ACTUALIZAR_TECNICO
    @ID_TECNICO INT,
    @NOMBRE_TECNICO VARCHAR(15),
    @APELLIDO_TECNICO VARCHAR(15),
    @CEDULA_TECNICO VARCHAR(10),
    @NUMERO_TECNICO VARCHAR(10),
    @EXPERIENCIA_TECNICO VARCHAR(50)
AS
BEGIN
    -- Actualiza los datos del técnico en la tabla TECNICOS
    UPDATE TECNICOS
    SET 
        NOMBRE_TECNICO = @NOMBRE_TECNICO,
        APELLIDO_TECNICO = @APELLIDO_TECNICO,
        CEDULA_TECNICO = @CEDULA_TECNICO,
        NUMERO_TECNICO = @NUMERO_TECNICO,
        EXPERIENCIA_TECNICO = @EXPERIENCIA_TECNICO
    WHERE ID_TECNICO = @ID_TECNICO;
    
    -- Verifica si la actualización fue exitosa
    IF @@ROWCOUNT = 0
    BEGIN
        PRINT 'No se encontró el técnico con el ID especificado';
    END
    ELSE
    BEGIN
        PRINT 'Técnico actualizado correctamente';
    END
END;

--5. Obtener los nombres de los técnicos
CREATE PROCEDURE SP_GET_NOMBRE_TECNICO
AS
BEGIN
    SELECT ID_TECNICO, NOMBRE_TECNICO FROM TECNICOS;
END;

-- ================================================
-- Crear tabla MANTENIMIENTO
-- ================================================
CREATE TABLE MANTENIMIENTO (
    ID_MANTENIMIENTO INT IDENTITY(1,1) PRIMARY KEY, 
    FECHA_MANTENIMIENTO DATETIME,
    DESCRIPCION VARCHAR(255),
    PRECIO FLOAT,
    REPUESTOS VARCHAR(MAX)
);

-- ================================================
-- Procedimientos de mantenimiento
-- ================================================

-- Crear un mantenimiento
CREATE PROCEDURE SP_CREAR_MANTENIMIENTO
    @FECHA_MANTENIMIENTO DATETIME,
    @DESCRIPCION VARCHAR(255),
    @PRECIO FLOAT,
    @REPUESTOS VARCHAR(MAX)
AS
BEGIN
    INSERT INTO MANTENIMIENTO (FECHA_MANTENIMIENTO, DESCRIPCION, PRECIO, REPUESTOS)
    VALUES (@FECHA_MANTENIMIENTO, @DESCRIPCION, @PRECIO, @REPUESTOS);
END;
GO

-- Obtener todos los mantenimientos
CREATE PROCEDURE SP_GET_ALL_MANTENIMIENTO
AS
BEGIN
    SELECT * FROM MANTENIMIENTO;
END;
GO

-- Eliminar un mantenimiento
CREATE PROCEDURE SP_ELIMINAR_MANTENIMIENTO
    @ID_MANTENIMIENTO INT
AS
BEGIN
    DELETE FROM MANTENIMIENTO
    WHERE ID_MANTENIMIENTO = @ID_MANTENIMIENTO;
END;
GO


-- ================================================
-- Insertar Datos de Prueba para la tabla CLIENTES
-- ================================================
-- Insertar algunos clientes para probar las funciones.
INSERT INTO CLIENTES (NOMBRE_CLIENTE, APELLIDO_CLIENTE, CEDULA_CLIENTE, NUMERO_CLIENTE, DIRECCION_CLIENTE)
VALUES 
    ('Carlos', 'Gomez', '1234567890', '0987654321', 'Av. Principal 123, Guayaqui'),
    ('María', 'Pérez', '2345678901', '0998765432', 'Calle Ficticia 456, Quito'),
    ('Juan', 'Sánchez', '3456789012', '0909876543', 'Calle Cero 789, Cuenca');

-- ================================================
-- Insertar Datos de Prueba para la tabla EQUIPOSCELULARES
-- ================================================
-- Insertar algunos equipos celulares asociados a clientes para probar.
INSERT INTO EQUIPOSCELULARES (MODELO_EQUIPO, MARCA_EQUIPO, DETALLE_EQUIPO, CLIENTE_ID)
VALUES 
    ('Galaxy S21', 'Samsung', 'Pantalla rota, reparado en 2 días', 1),
    ('iPhone 12', 'Apple', 'Batería defectuosa, cambio realizado', 2),
    ('Moto G Power', 'Motorola', 'Problema con la cámara', 3);

-- ================================================
-- Insertar Datos de Prueba para la tabla TECNICOS
-- ================================================
-- Insertar algunos técnicos para probar las funciones de manejo de técnicos.
INSERT INTO TECNICOS (NOMBRE_TECNICO, APELLIDO_TECNICO, CEDULA_TECNICO, NUMERO_TECNICO, EXPERIENCIA_TECNICO)
VALUES 
    ('Luis', 'Fernández', '1122334455', '0987456321', '5 años en reparación de smartphones'),
    ('Ana', 'Suárez', '2233445566', '0978654321', '3 años en reparaciones de equipos móviles'),
    ('Carlos', 'Jiménez', '3344556677', '0967453210', '7 años en reparación de pantallas y baterías');

-- ================================================
-- Insertar Datos de Prueba para la tabla USER_SESSION
-- ================================================
-- Insertar usuarios de prueba para las validaciones de sesión.
INSERT INTO USER_SESSION (USUARIO, CONTRASENA)
VALUES 
    ('ADMIN', '12345');

