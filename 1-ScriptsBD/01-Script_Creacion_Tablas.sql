--2026-10-09: Prueba de Base de datos
--Realizada en version: Microsoft SQL Server 2022 

--.Crear la tabla de los Estudiantes:
CREATE TABLE Estudiantes 
    (
        ID_Estudiante INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        Apellido NVARCHAR(100) NOT NULL,
        Edad INT NOT NULL,
        Sexo NVARCHAR(1) NOT NULL,
        Curso NVARCHAR(50) NOT NULL,
        Correo NVARCHAR(150) UNIQUE,
        Observaciones NVARCHAR(100) 
    )

--.Crear la tabla de las Materias:
CREATE TABLE Materias 
    (
        ID_Materia INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL UNIQUE,
        Skill INT 
    )

--.Crear la tabla de las Calificaciones:
CREATE TABLE Calificaciones 
    (
        ID_Calificacion INT IDENTITY(1,1) PRIMARY KEY,
        ID_Estudiante INT NOT NULL,
        ID_Materia INT NOT NULL,
        Periodo INT NOT NULL,
        Puntaje DECIMAL(4,2) CHECK (Puntaje >= 0 AND Puntaje <= 10),
        Observaciones NVARCHAR(100),
        Fecha_Registro DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_Calificaciones_Estudiantes
            FOREIGN KEY (ID_Estudiante) REFERENCES Estudiantes(ID_Estudiante)
                ON DELETE CASCADE
                ON UPDATE CASCADE,
        CONSTRAINT FK_Calificaciones_Materias
            FOREIGN KEY (ID_Materia) REFERENCES Materias(ID_Materia)
                ON DELETE CASCADE
                ON UPDATE CASCADE
    )

CREATE TABLE Log_Auditoria (
    ID_Log INT IDENTITY(1,1) PRIMARY KEY,
    Procedimiento NVARCHAR(128),
    NumeroError INT,
    Severidad INT,
    Estado NVARCHAR(128),
    Linea INT,
    MensajeError NVARCHAR(4000),
    FechaError DATETIME DEFAULT GETDATE()
)
