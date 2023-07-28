CREATE PROCEDURE sp_obtenerPuestos
AS
	SELECT  id,
			nombre,
			sueldo_hora,
			bono_hora
	FROM Cat_puestos