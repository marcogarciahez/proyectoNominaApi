ALTER PROCEDURE sp_capturarMovimientos
@id_empleado INT, @fecha DATE, @cant_entregas INT, @faltas INT
AS
DECLARE
	@sueldo_bruto DECIMAL(10,2),
	@sueldo_horas DECIMAL(10,2),
	@sueldo_horas_bono DECIMAL(10,2),
	@ISR DECIMAL(10,2),
	@sueldo_con_bono DECIMAL(10,2),
	@horas_trabajadas INT,
	@vales DECIMAL(10,2),
	@sueldo_neto DECIMAL(10,2),
	@bono_entregas DECIMAL(10,2)

	SET @horas_trabajadas = ((24 - @faltas) * 8)
	SET @bono_entregas = (@cant_entregas * 5)

	SET @sueldo_horas = (SELECT (Puestos.sueldo_hora * @horas_trabajadas) FROM Cat_empleados
						INNER JOIN Cat_puestos AS Puestos ON Puestos.id = Cat_empleados.id_puesto
						WHERE @id_empleado = Cat_empleados.id)

	SET @sueldo_horas_bono = (SELECT (Puestos.bono_hora * @horas_trabajadas) FROM Cat_empleados
						INNER JOIN Cat_puestos AS Puestos ON Puestos.id = Cat_empleados.id_puesto
						WHERE @id_empleado = Cat_empleados.id)

	SET @sueldo_bruto = @sueldo_horas + @sueldo_horas_bono + @bono_entregas

	IF @sueldo_bruto > 10000
		BEGIN
			SET @ISR = (@sueldo_bruto * 0.12)
		END
	ELSE
		BEGIN
			SET @ISR = (@sueldo_bruto * 0.09)
		END

	SET @sueldo_neto = @sueldo_bruto - @ISR
	SET @vales = (@sueldo_bruto * 0.04)

	INSERT INTO Mov_NominaMensual (id_empleado, mes, ano, horas_trabajadas, cant_entregas, pago_entregas, pago_bonos, sueldo_horas, sueldo_bruto, retencion_ISR, saldo_vales, sueldo_neto)
	VALUES (@id_empleado, MONTH(@fecha), YEAR(@fecha), @horas_trabajadas, @cant_entregas, @bono_entregas, @sueldo_horas_bono, @sueldo_horas,@sueldo_bruto, @ISR, @vales, @sueldo_neto)
	


	EXEC sp_nominaMensual @id_empleado = 1, @fecha = '2023-05-05',@cant_movimientos = 400, @faltas = 0

	SELECT * FROM Mov_NominaMensual

GO

CREATE PROCEDURE sp_nominaMensual
@id_empleado INT, @fecha DATE
AS
	SELECT
			id,
			id_empleado,
			mes,
			ano,
			horas_trabajadas,
			cant_entregas,
			pago_entregas,
			pago_bonos,
			sueldo_horas,
			sueldo_bruto,
			retencion_ISR,
			saldo_vales,
			sueldo_neto
	FROM Mov_NominaMensual
	WHERE @id_empleado = id_empleado AND mes = MONTH(@fecha) AND ano = YEAR(@fecha)

select * from Mov_NominaMensual where id_empleado = 1 AND mes = MONTH('2023-05-05') AND ano = YEAR('2023-05-05')