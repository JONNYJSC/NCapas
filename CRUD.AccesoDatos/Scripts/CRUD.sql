
CREATE DATABASE CRUD
GO
USE CRUD
CREATE TABLE Productos (IdProducto INT IDENTITY (1, 1) PRIMARY KEY,
						Nombre NVARCHAR(100),
						Descripcion NVARCHAR(100),
						Marca NVARCHAR(100),
						Precio DECIMAL(18, 2),
						Cantidad INT)
INSERT INTO Productos
VALUES ('Gaseosa', '3 litros', 'marcacola', 7.5, 24),
	   ('Chocolate', 'Tableta 100 gramos', 'iberica', 12.5, 36)
---PROCEDIMIENTOS ALMACENADOS 
--------------------------MOSTRAR 
CREATE PROC Sp_MostrarProductos
AS
	SELECT *
	  FROM Productos
GO
--------------------------INSERTAR 
CREATE PROC Sp_InsetarProductos
	@Nombre NVARCHAR(100),
	@Descripcion NVARCHAR(100),
	@Marca NVARCHAR(100),
	@Precio DECIMAL(18, 2),
	@Cantidad INT
AS
	INSERT INTO Productos
	VALUES (@Nombre, @Descripcion, @Marca, @Precio, @Cantidad)
GO
------------------------ELIMINAR
CREATE PROC Sp_ProductoEliminar
	@IdProducto INT
AS
	DELETE FROM Productos
	 WHERE IdProducto = @IdProducto
GO
------------------EDITAR
CREATE PROC Sp_EditarProductos
	@IdProducto INT,
	@Nombre NVARCHAR(100),
	@Descripcion NVARCHAR(100),
	@Marca NVARCHAR(100),
	@Precio DECIMAL(18, 2),
	@Cantidad INT
AS
	UPDATE Productos
	   SET Nombre = @Nombre,
		   Descripcion = @Descripcion,
		   Marca = @Marca,
		   Precio = @Precio,
		   Cantidad = @Cantidad
	WHERE IdProducto = @IdProducto
GO