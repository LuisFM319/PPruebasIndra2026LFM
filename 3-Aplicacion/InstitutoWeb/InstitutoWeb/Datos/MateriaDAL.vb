Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports WebGrease.Css

Public Class MateriaDAL

    Private ReadOnly cadenaConexion As String = ConfigurationManager.ConnectionStrings("ConBD").ConnectionString

    Public Function Listar() As Materia

        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Materias_CRUD", con)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Operacion", "SELECT")
                con.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()

                    If dr.Read() Then
                        Dim c As New Materia()
                        c.ID_Materia = CInt(dr("ID_Materia"))
                        c.Nombre = dr("Nombre").ToString()
                        c.Skill = CInt(dr("Skill"))
                        Return c
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function


    'Listar Materia
    Public Function ObtenerMateria(id As Integer) As Materia

        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Materias_CRUD", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Operacion", "SELECT")
                cmd.Parameters.Add("@ID_Materia", SqlDbType.Int).Value = id
                con.Open()
                Using dr As SqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        Dim c As New Materia()
                        c.ID_Materia = CInt(dr("ID_Materia"))
                        c.Nombre = dr("Nombre").ToString()
                        c.Skill = CInt(dr("Skill"))
                        Return c
                    End If
                End Using
            End Using
        End Using
        Return Nothing
    End Function


    'Insertar Materias
    Public Sub InsertarMateria(mat As Materia)
        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Materias_CRUD", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Operacion", "INSERT")
                cmd.Parameters.AddWithValue("@Nombre", mat.Nombre)
                cmd.Parameters.AddWithValue("@Skill", mat.Skill)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub


    'Actualizar Materias
    Public Sub ActualizarMateria(mat As Materia)
        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Materias_CRUD", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Operacion", "UPDATE")
                cmd.Parameters.AddWithValue("@ID_Materia", mat.ID_Materia)
                cmd.Parameters.AddWithValue("@Nombre", mat.Nombre)
                cmd.Parameters.AddWithValue("@Skill", mat.Skill)
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'Eliminar Materias
    Public Sub EliminarMateria(id As Integer)
        Using con As New SqlConnection(cadenaConexion)
            Using cmd As New SqlCommand("sp_Materias_CRUD", con)
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Operacion", "DELETE")
                cmd.Parameters.Add("@ID_Materia", SqlDbType.Int).Value = id
                con.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class

