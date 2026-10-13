/*** CRUD para la tabla: estudiantes ***********************************************/
--1-- Consultar todos los estudiantes
EXEC sp_Estudiantes_CRUD 'SELECT'

--2-- Insertar estudiante
EXEC sp_Estudiantes_CRUD 'INSERT', NULL, 'Doris', 'Hidalgo', 15, 'F', '802', 'Doriww@mail.com', 'sin novedad'

--3-- Actualizar estudiante
EXEC sp_Estudiantes_CRUD 'UPDATE', 20, 'Nicolas', 'Asprillas', 13, 'M', '1003', 'niki887@mail.com', 'Actualizado'

--4-- Eliminar estudiante
EXEC sp_Estudiantes_CRUD 'DELETE', 12


/*** CRUD para la tabla: Materias *************************************************/
--1-- Consultar todos las materia
EXEC sp_Materias_CRUD 'SELECT'

--2-- Insertar materia
EXEC sp_Materias_CRUD 'INSERT', NULL, 'Educacion Fisica', 3200
EXEC sp_Materias_CRUD 'INSERT', NULL, 'Literatura', 2250

--3-- Actualizar materia
EXEC sp_Materias_CRUD 'UPDATE', 9, 'Literaturas', 2250

--4-- Eliminar materia
EXEC sp_Materias_CRUD 'DELETE', 6

/*** CRUD para la tabla: Calificaciones *************************************************/
--1-- Consultar todos las Calificaciones
EXEC sp_Calificaciones_CRUD 'SELECT'

--2-- Insertar Calificaciones
EXEC sp_Calificaciones_CRUD 'INSERT', NULL, 4, 2, 2025, 6, 'Pendiente Examen'
EXEC sp_Calificaciones_CRUD 'INSERT', NULL, 5, 5, 2025, 3, 'Sin Novedad'
EXEC sp_Calificaciones_CRUD 'INSERT', NULL, 7, 8, 2025, 3

--3-- Actualizar Calificaciones
EXEC sp_Calificaciones_CRUD 'UPDATE', 311, 5, 5, 2024,  2, 'Sin novedad'
                                      --ID_Calificacion
                                        --ID_Estudiante = @ID_Estudiante,
                                            --ID_Materia = @ID_Materia,
                                                --Periodo = @Periodo,
                                                      --Puntaje = @Puntaje,
                                                            --Observaciones = @Observaciones

--4-- Eliminar Calificaciones
EXEC sp_Calificaciones_CRUD 'DELETE', 120

