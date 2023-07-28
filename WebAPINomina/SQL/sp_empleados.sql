CREATE PROCEDURE sp_ingresarEmpleado
	@apellido_pat VARCHAR(30),
	@apellido_mat VARCHAR(30),
	@nombre VARCHAR(40),
	@telefono NVARCHAR(10),
	@domicilio NVARCHAR(120),
	@id_puesto INT,
	@fecha_nac DATE
AS
	INSERT INTO Cat_empleados (apellido_pat, apellido_mat, nombre, telefono, domicilio, id_puesto, fecha_nac)
	VALUES(
	@apellido_pat,
	@apellido_mat,
	@nombre,
	@telefono,
	@domicilio,
	@id_puesto,
	@fecha_nac
	)

GO

CREATE PROCEDURE sp_obtenerEmpleado
	@id INT
AS
	SELECT  id,
			apellido_pat,
			apellido_mat,
			nombre,
			telefono,
			domicilio,
			id_puesto,
			fecha_nac
	FROM Cat_empleados
	WHERE id = @id

GO

CREATE PROCEDURE sp_actualizarEmpleado
	@id INT,
	@apellido_pat VARCHAR(30),
	@apellido_mat VARCHAR(30),
	@nombre VARCHAR(40),
	@telefono NVARCHAR(10),
	@domicilio NVARCHAR(120),
	@id_puesto INT,
	@fecha_nac DATE
AS
	UPDATE Cat_empleados SET
	apellido_pat = @apellido_pat,
	apellido_mat = @apellido_mat,
	nombre = @nombre,
	telefono = @telefono,
	domicilio = @domicilio,
	id_puesto = @id_puesto,
	fecha_nac = @fecha_nac
	WHERE Cat_empleados.id = @id
	
GO

CREATE PROCEDURE sp_eliminarEmpleado
	@id INT
AS
	DELETE FROM Cat_empleados
	WHERE id = @id

GO

ALTER PROCEDURE sp_obtenerEmpleados
AS
	SELECT  Empleado.id,
			Empleado.apellido_pat,
			Empleado.apellido_mat,
			Empleado.nombre,
			Empleado.telefono,
			Empleado.domicilio,
			Empleado.id_puesto,
			Puestos.nombre AS nombre_puesto,
			Empleado.fecha_nac
	FROM Cat_empleados as Empleado
	INNER JOIN Cat_puestos AS Puestos ON Puestos.id = id_puesto
GO

CREATE PROCEDURE sp_obtenerEmpleadosFiltro
@nombre VARCHAR(100)
AS
	SELECT  id,
			apellido_pat,
			apellido_mat,
			nombre,
			telefono,
			domicilio,
			id_puesto,
			fecha_nac
	FROM Cat_empleados
	WHERE (nombre+' '+apellido_pat+' '+apellido_mat) like '%'+@nombre+'%'
GO

