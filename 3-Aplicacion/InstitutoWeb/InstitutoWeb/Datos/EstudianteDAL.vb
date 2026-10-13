Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports WebGrease.Css

Public Class EstudianteDAL

    Private ReadOnly cadenaConexion As String = ConfigurationManager.ConnectionStrings("ConBD").ConnectionString

    Public Function Listar() As Estudiante

        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Estudiantes_CRUD", con)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Operacion", "SELECT")
                con.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()

                    If dr.Read() Then
                        Dim c As New Estudiante()
                        c.ID_Estudiante = CInt(dr("ID_Estudiante"))
                        c.Nombre = dr("Nombre").ToString()
                        c.Apellido = dr("Apellido").ToString()
                        c.Edad = CInt(dr("Edad"))
                        '.Apellido = reader("Apellido").ToString(),
                        '.Edad = Convert.ToInt32(reader("Edad")),
                        c.Sexo = dr("Sexo").ToString()
                        c.Curso = dr("Curso").ToString()
                        c.Correo = dr("Correo").ToString()
                        If Not IsDBNull(dr("Observaciones")) Then
                            c.Observaciones = dr("Observaciones").ToString()
                        End If

                        Return c
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function


    'Listar Estudiante
    Public Function ObtenerEstudiante(id As Integer) As Estudiante

        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Estudiantes_CRUD", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Operacion", "SELECT")
                cmd.Parameters.Add("@ID_Estudiante", SqlDbType.Int).Value = id
                con.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        Dim c As New Estudiante()
                        c.ID_Estudiante = CInt(dr("ID_Estudiante"))
                        c.Nombre = dr("Nombre").ToString()
                        c.Apellido = dr("Apellido").ToString()
                        c.Edad = CInt(dr("Edad"))
                        '.Apellido = reader("Apellido").ToString(),
                        '.Edad = Convert.ToInt32(reader("Edad")),
                        c.Sexo = dr("Sexo").ToString()
                        c.Curso = dr("Curso").ToString()
                        c.Correo = dr("Correo").ToString()
                        If Not IsDBNull(dr("Observaciones")) Then
                            c.Observaciones = dr("Observaciones").ToString()
                        End If

                        Return c
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function


    'Insertar Estudiante
    Public Sub InsertarEstudiante(est As Estudiante)
        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Estudiantes_CRUD", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Operacion", "INSERT")
                cmd.Parameters.AddWithValue("@Nombre", est.Nombre)
                cmd.Parameters.AddWithValue("@Apellido", est.Apellido)
                cmd.Parameters.AddWithValue("@Edad", est.Edad)
                cmd.Parameters.AddWithValue("@Sexo", est.Sexo)
                cmd.Parameters.AddWithValue("@Curso", est.Curso)
                cmd.Parameters.AddWithValue("@Correo", est.Correo)
                cmd.Parameters.AddWithValue("@Observaciones", est.Observaciones)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    'Actualizar Estudiante
    Public Sub ActualizarEstudiante(est As Estudiante)
        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Estudiantes_CRUD", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Operacion", "UPDATE")
                cmd.Parameters.AddWithValue("@ID_Estudiante", est.ID_Estudiante)
                cmd.Parameters.AddWithValue("@Nombre", est.Nombre)
                cmd.Parameters.AddWithValue("@Apellido", est.Apellido)
                cmd.Parameters.AddWithValue("@Edad", est.Edad)
                cmd.Parameters.AddWithValue("@Sexo", est.Sexo)
                cmd.Parameters.AddWithValue("@Curso", est.Curso)
                cmd.Parameters.AddWithValue("@Correo", est.Correo)
                cmd.Parameters.AddWithValue("@Observaciones", est.Observaciones)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'Eliminar Estudiante
    Public Sub EliminarEstudiante(id As Integer)
        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Estudiantes_CRUD", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Operacion", "DELETE")
                cmd.Parameters.Add("@ID_Estudiante", SqlDbType.Int).Value = id
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class

