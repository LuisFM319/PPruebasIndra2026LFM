Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports WebGrease.Css

Public Class CalificacionDAL

    Private ReadOnly cadenaConexion As String = ConfigurationManager.ConnectionStrings("ConBD").ConnectionString

    Public Function Listar() As Calificacion

        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Calificaciones_CRUD", con)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Operacion", "SELECT")
                con.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()

                    If dr.Read() Then
                        Dim c As New Calificacion()
                        c.ID_Calificacion = CInt(dr("ID_Calificacion"))
                        c.ID_Estudiante = CInt(dr("ID_Estudiante"))
                        c.ID_Materia = CInt(dr("ID_Materia"))
                        c.Periodo = CInt(dr("Periodo"))
                        c.Puntaje = CDec(dr("Puntaje"))
                        c.Observaciones = dr("Observacioines").ToString()
                        c.Fecha_Registro = dr("Fecha_registro").ToString()

                        Return c
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function


    'Listar Calificacion
    Public Function ObtenerCalificacion(id As Integer) As Calificacion

        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Calificaciones_CRUD", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Operacion", "SELECT")
                cmd.Parameters.Add("@ID_Calificacion", SqlDbType.Int).Value = id
                con.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        Dim c As New Calificacion()
                        c.ID_Calificacion = CInt(dr("ID_Calificacion"))
                        c.ID_Estudiante = CInt(dr("ID_Estudiante"))
                        c.ID_Materia = CInt(dr("ID_Materia"))
                        c.Periodo = CInt(dr("Periodo"))
                        c.Puntaje = CDec(dr("Puntaje"))
                        If Not IsDBNull(dr("Observaciones")) Then
                            c.Observaciones = dr("Observaciones").ToString()
                        End If
                        c.Fecha_Registro = dr("Fecha_registro").ToString()
                        Return c
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function


    'Insertar Calificacion
    Public Sub InsertarCalificacion(cal As Calificacion)
        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Calificaciones_CRUD", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Operacion", "INSERT")
                cmd.Parameters.AddWithValue("@ID_Estudiante", cal.ID_Estudiante)
                cmd.Parameters.AddWithValue("@ID_Materia", cal.ID_Materia)
                cmd.Parameters.AddWithValue("@Periodo", cal.Periodo)
                cmd.Parameters.AddWithValue("@Puntaje", cal.Puntaje)
                cmd.Parameters.AddWithValue("@Observaciones", cal.Observaciones)

                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    'Actualizar Calificacion
    Public Sub ActualizarCalificacion(cal As Calificacion)
        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Calificaciones_CRUD", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Operacion", "UPDATE")
                cmd.Parameters.AddWithValue("@ID_Calificacion", cal.ID_Calificacion)
                cmd.Parameters.AddWithValue("@ID_Estudiante", cal.ID_Estudiante)
                cmd.Parameters.AddWithValue("@ID_Materia", cal.ID_Materia)
                cmd.Parameters.AddWithValue("@Periodo", cal.Periodo)
                cmd.Parameters.AddWithValue("@Puntaje", cal.Puntaje)
                cmd.Parameters.AddWithValue("@Observaciones", cal.Observaciones)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'Eliminar Calificacion
    Public Sub EliminarCalificacion(id As Integer)
        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Calificaciones_CRUD", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Operacion", "DELETE")
                cmd.Parameters.Add("@ID_Calificacion", SqlDbType.Int).Value = id
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class

