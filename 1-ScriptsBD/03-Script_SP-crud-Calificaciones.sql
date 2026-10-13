/* 2026-10-09: Creacion del SP CRUD para la tabla Calificaciones */

CREATE PROCEDURE sp_Calificaciones_CRUD
    @Operacion NVARCHAR(10),
    @ID_Calificacion INT = NULL,
    @ID_Estudiante INT = NULL,
    @ID_Materia INT = NULL,
    @Periodo INT = NULL,
    @Puntaje DECIMAL(4,2) = NULL,
    @Observaciones NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
    IF @Operacion = 'INSERT'
        BEGIN 
            INSERT INTO Calificaciones (ID_Estudiante, ID_Materia, Periodo, Puntaje, Observaciones)  VALUES (@ID_Estudiante, @ID_Materia, @Periodo, @Puntaje, @Observaciones)
            INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError) VALUES ('SP_Calificaciones_Insert', 0, 0, 'Exitoso', NULL, 'Registro insertado exitosamente')
        END

    ELSE IF @Operacion = 'UPDATE'
        IF EXISTS (SELECT 1 FROM Calificaciones WHERE ID_Calificacion = @ID_Calificacion)
            BEGIN
                UPDATE Calificaciones
                    SET ID_Estudiante = @ID_Estudiante,
                        ID_Materia = @ID_Materia,
                        Periodo = @Periodo,
                        Puntaje = @Puntaje,
                        Observaciones = @Observaciones
                    WHERE ID_Calificacion = @ID_Calificacion
                
                INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError)   
                    VALUES ('SP_Calificacion_Update', 0, 0, 'Exitoso', NULL, 'Registro actualizado exitosamente')
            END
        ELSE BEGIN 
                    INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError)
                    VALUES ('SP_Calificaciones_Update',NULL,NULL,NULL,NULL,'No se encontró la Calificacion, no se actualizó nada')
                END

    ELSE IF @Operacion = 'DELETE'
        BEGIN
            DELETE FROM Calificaciones WHERE ID_Calificacion = @ID_Calificacion
            INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError)
                VALUES ('SP_Calificaciones_Delete', 0, 0, 'Exitoso', NULL, 'Registro eliminado exitosamente')
        END

    ELSE IF @Operacion = 'SELECT'
        SELECT * FROM Calificaciones   WHERE (@ID_Calificacion IS NULL OR ID_Calificacion = @ID_Calificacion)

    END TRY
    BEGIN CATCH
        -- Registrar el error en la tabla Log_Auditoria
        INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError)
        VALUES (
            ERROR_PROCEDURE(),
            ERROR_NUMBER(),
            ERROR_SEVERITY(),
            ERROR_STATE(),
            ERROR_LINE(),
            ERROR_MESSAGE()
        )
    END CATCH
END