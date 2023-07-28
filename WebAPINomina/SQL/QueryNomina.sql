CREATE DATABASE NominaCoppel

USE NominaCoppel

CREATE TABLE Cat_puestos (
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	nombre VARCHAR(30) NOT NULL,
	sueldo_hora DECIMAL(10,2),
	bono_hora DECIMAL(10,2)
);

CREATE TABLE Cat_empleados (
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	apellido_pat VARCHAR(30) NOT NULL,
	apellido_mat VARCHAR(30) NOT NULL,
	nombre VARCHAR(40) NOT NULL,
	telefono NVARCHAR(10),
	domicilio NVARCHAR(120),
	id_puesto INT NOT NULL,
	fecha_nac DATE NOT NULL
);

CREATE TABLE Mov_NominaMensual(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	id_empleado INT NOT NULL, 
	mes INT NOT NULL,
	ano INT NOT NULL,
	horas_trabajadas INT NOT NULL,
	cant_entregas INT NOT NULL,
	pago_entregas DECIMAL(10,2) NOT NULL,
	pago_bonos DECIMAL(10,2) NOT NULL,
	sueldo_horas DECIMAL(10,2) NOT NULL,
	sueldo_bruto DECIMAL(10,2) NOT NULL,
	retencion_ISR DECIMAL(10,2) NOT NULL,
	saldo_vales DECIMAL(10,2) NOT NULL,
	sueldo_neto DECIMAL(10,2) NOT NULL
);

ALTER TABLE Cat_empleados ADD FOREIGN KEY (id_puesto) REFERENCES Cat_puestos(id) 
ALTER TABLE Mov_NominaMensual ADD FOREIGN KEY (id_empleado) REFERENCES Cat_empleados(id) 

INSERT INTO Cat_puestos (nombre,sueldo_hora,bono_hora) VALUES('Chofer',30,10)
INSERT INTO Cat_puestos (nombre,sueldo_hora,bono_hora) VALUES('Cargador',30,5)
INSERT INTO Cat_puestos (nombre,sueldo_hora,bono_hora) VALUES('Auxiliar',30,0)

SELECT * FROM Cat_puestos

INSERT INTO Cat_empleados (apellido_pat, apellido_mat, nombre, telefono, domicilio, id_puesto, fecha_nac) VALUES('Garcia','Hernandez','Roberto Marco','6673030950','Paseo Shiraz 988',1,'1999-04-09')
