/* 2026-10-09: Creacion del SP CRUD para la tabla Estudiantes */

CREATE PROCEDURE sp_Estudiantes_CRUD
    @Operacion NVARCHAR(10), -- 'INSERT','UPDATE','DELETE','SELECT'
    @ID_Estudiante INT = NULL,
    @Nombre NVARCHAR(100) = NULL,
    @Apellido NVARCHAR(100) = NULL,
    @Edad INT = NULL,
    @Sexo NVARCHAR(1) = NULL,
    @Curso NVARCHAR(50) = NULL,
    @Correo NVARCHAR(150) = NULL,
    @Observaciones NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
    IF @Operacion = 'INSERT'
        BEGIN
            INSERT INTO Estudiantes (Nombre, Apellido, Edad, Sexo, Curso, Correo, Observaciones)  VALUES (@Nombre, @Apellido, @Edad, @Sexo, @Curso, @Correo, @Observaciones)
            INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError) VALUES ('SP_Estudiantes_Insert', 0, 0, 'Exitoso', NULL, 'Registro insertado exitosamente')
        END
    ELSE IF @Operacion = 'UPDATE'
        IF EXISTS (SELECT 1 FROM Estudiantes WHERE ID_Estudiante = @ID_Estudiante)
            BEGIN
                UPDATE Estudiantes
                SET Nombre = @Nombre,
                    Apellido = @Apellido,
                    Edad = @Edad,
                    Sexo = @Sexo,
                    Curso = @Curso,
                    Correo = @Correo,
                    Observaciones = @Observaciones
                WHERE ID_Estudiante = @ID_Estudiante
                
                INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError)   
                    VALUES ('SP_Estudiantes_Update', 0, 0, 'Exitoso', NULL, 'Registro actualizado exitosamente')

            END
            ELSE BEGIN 
                    INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError)
                    VALUES ('SP_Estudiantes_Update',NULL,NULL,NULL,NULL,'No se encontró el estudiante, no se actualizó nada')
                END

    ELSE IF @Operacion = 'DELETE'
        BEGIN
            DELETE FROM Estudiantes WHERE ID_Estudiante = @ID_Estudiante
            INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError)
            VALUES ('SP_Estudiantes_Delete', 0, 0, 'Exitoso', NULL, 'Registro eliminado exitosamente')
        END

    ELSE IF @Operacion = 'SELECT'
        SELECT * FROM Estudiantes  WHERE (@ID_Estudiante IS NULL OR ID_Estudiante = @ID_Estudiante)

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