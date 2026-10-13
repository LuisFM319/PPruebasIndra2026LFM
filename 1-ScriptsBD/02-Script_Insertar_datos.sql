USE INSTITUTO

--Insertar Estudiantes:
INSERT INTO Estudiantes (Nombre,Apellido,Edad,Sexo,Curso,Correo,Observaciones) VALUES ('Fernando','Monsalve',14, 'M','901','Munx@gmail.com',NULL)
INSERT INTO Estudiantes (Nombre,Apellido,Edad,Sexo,Curso,Correo,Observaciones) VALUES ('Laura','Sanchez',15, 'F','1001','Lau3325@gmail.com',NULL)
INSERT INTO Estudiantes (Nombre,Apellido,Edad,Sexo,Curso,Correo,Observaciones) VALUES ('Julian','Arias',13, 'M','801','JUUJI@gmail.com',NULL)
INSERT INTO Estudiantes (Nombre,Apellido,Edad,Sexo,Curso,Correo,Observaciones) VALUES ('Maria','CastiBlanco',16, 'F','1101','Cassi55@gmail.com','Becado')
INSERT INTO Estudiantes (Nombre,Apellido,Edad,Sexo,Curso,Correo,Observaciones) VALUES ('Sebastian','Velez',15, 'M','1002','Sebcdl2@gmail.com',NULL)
INSERT INTO Estudiantes (Nombre,Apellido,Edad,Sexo,Curso,Correo,Observaciones) VALUES ('Natalia','Pedraza',12, 'F','601','Nata1@gmail.com',NULL)
INSERT INTO Estudiantes (Nombre,Apellido,Edad,Sexo,Curso,Correo,Observaciones) VALUES ('Esmeralda','Garcia',15, 'F','1001','Esme778@gmail.com',NULL)

SELECT * FROM Estudiantes

--Insertar Materias:
INSERT INTO Materias (Nombre,Skill)  VALUES('Fisica','5000')
INSERT INTO Materias (Nombre,Skill)  VALUES('Quimica','6000')
INSERT INTO Materias (Nombre,Skill)  VALUES('Matematica','4000')
INSERT INTO Materias (Nombre,Skill)  VALUES('Filosofia','8000')
INSERT INTO Materias (Nombre,Skill)  VALUES('Arte','3000')

SELECT * FROM Materias

--Insertar Calificaciones:
INSERT INTO Calificaciones (ID_Estudiante,ID_Materia,  Periodo,Puntaje,Observaciones,Fecha_Registro)    VALUES(1,3, 2026, 5, NULL,getdate())
INSERT INTO Calificaciones (ID_Estudiante,ID_Materia,  Periodo,Puntaje,Observaciones,Fecha_Registro)    VALUES(2,3, 2026, 7, 'Examen pendiente',getdate())
INSERT INTO Calificaciones (ID_Estudiante,ID_Materia,  Periodo,Puntaje,Observaciones,Fecha_Registro)    VALUES(4,1, 2026, 3, 'Sin Novedad','2026-10-08')
INSERT INTO Calificaciones (ID_Estudiante,ID_Materia,  Periodo,Puntaje,Observaciones,Fecha_Registro)    VALUES(5,2, 2026, 8, 'Examen pendiente','2026-10-07')
INSERT INTO Calificaciones (ID_Estudiante,ID_Materia,  Periodo,Puntaje,Observaciones)                   VALUES(6,4, 2026, 10, NULL)
INSERT INTO Calificaciones (ID_Estudiante,ID_Materia,  Periodo,Puntaje,Observaciones,Fecha_Registro)    VALUES(2,4, 2026, 3, 'Sin Novedad','2026-10-06')
INSERT INTO Calificaciones (ID_Estudiante,ID_Materia,  Periodo,Puntaje,Observaciones)                   VALUES(1,1, 2026, 4, NULL)
INSERT INTO Calificaciones (ID_Estudiante,ID_Materia,  Periodo,Puntaje,Observaciones,Fecha_Registro)    VALUES(3,5, 2026, 7, NULL,'2026-10-05')

SELECT * FROM Calificaciones

/************************************/
--Ver datos relacionados:
	SELECT * FROM Estudiantes
	SELECT * FROM Materias
	SELECT * FROM Calificaciones

	SELECT * FROM Calificaciones C
		INNER JOIN Estudiantes E	ON C.ID_Estudiante = E.ID_Estudiante
		INNER JOIN Materias M		ON C.ID_Materia = M.ID_Materia
	WHERE C.Puntaje <= 5