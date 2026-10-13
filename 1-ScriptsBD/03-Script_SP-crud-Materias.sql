/* 2026-10-09: Creacion del SP CRUD para la tabla Materias */

CREATE PROCEDURE sp_Materias_CRUD
    @Operacion NVARCHAR(10),
    @ID_Materia INT = NULL,
    @Nombre NVARCHAR(100) = NULL,
    @Skill INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
    IF @Operacion = 'INSERT' 
        BEGIN
            INSERT INTO Materias (Nombre, Skill)   VALUES (@Nombre, @Skill)
            INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError) VALUES ('SP_Materias_Insert', 0, 0, 'Exitoso', NULL, 'Registro insertado exitosamente')
        END

    ELSE IF @Operacion = 'UPDATE'
        IF EXISTS (SELECT 1 FROM Materias WHERE ID_Materia = @ID_Materia)
            BEGIN
                UPDATE Materias
                    SET Nombre = @Nombre,
                    Skill = @Skill
                WHERE ID_Materia = @ID_Materia
                INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError)   
                    VALUES ('SP_Materias_Update', 0, 0, 'Exitoso', NULL, 'Registro actualizado exitosamente');
            END
        ELSE BEGIN 
                    INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError)
                    VALUES ('SP_materias_Update',NULL,NULL,NULL,NULL,'No se encontró la materia, no se actualizó nada')
                END

    ELSE IF @Operacion = 'DELETE'
        BEGIN
            DELETE FROM Materias WHERE ID_Materia = @ID_Materia
            INSERT INTO Log_Auditoria (Procedimiento, NumeroError, Severidad, Estado, Linea, MensajeError)
                VALUES ('SP_Materias_Delete', 0, 0, 'Exitoso', NULL, 'Registro eliminado exitosamente')
        END

    ELSE IF @Operacion = 'SELECT'
        SELECT * FROM Materias          WHERE (@ID_Materia IS NULL OR ID_Materia = @ID_Materia)

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