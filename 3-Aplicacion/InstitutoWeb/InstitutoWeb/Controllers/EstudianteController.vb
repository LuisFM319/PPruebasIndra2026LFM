Imports System.Data.SqlClient
Imports System.Web.Mvc


Public Class EstudianteController
    Inherits Controller

    Private ReadOnly dal As New EstudianteDAL()
    Private cadenaCon As String = ConfigurationManager.ConnectionStrings("ConBD").ConnectionString

    'Consultar todos los Estudiantes
    Function Index() As ActionResult
        Dim lista As New List(Of Estudiante)
        Using con As New SqlConnection(cadenaCon)
            Dim cmd As New SqlCommand("sp_Estudiantes_CRUD", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Operacion", "SELECT")
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                lista.Add(New Estudiante With {
                    .ID_Estudiante = reader("ID_Estudiante"),
                    .Nombre = reader("Nombre").ToString(),
                    .Apellido = reader("Apellido").ToString(),
                    .Edad = Convert.ToInt32(reader("Edad")),
                    .Sexo = reader("Sexo").ToString(),
                    .Curso = reader("Curso").ToString(),
                    .Correo = reader("Correo").ToString(),
                    .Observaciones = reader("Observaciones").ToString()
                })
            End While
        End Using
        Return View(lista)
    End Function


    'Mostrar formulario de Creacion
    Function Create() As ActionResult
        Return View()
    End Function


    'Guardar Nuevo Estudiante
    <HttpPost>
    Function Create(est As Estudiante) As ActionResult
        Try
            If ModelState.IsValid Then
                dal.InsertarEstudiante(est)
                Return RedirectToAction("Index")

                TempData("Mensaje") = "Grabado exitoso"
                Return RedirectToAction("Index")
            End If
        Catch ex As Exception
            TempData("Mensaje") = "No grabado: " & ex.Message
        End Try

        Return View(est)
    End Function

    'Mostrar formulario de Edicion
    Function Edit(id As Integer) As ActionResult

        Dim est = dal.ObtenerEstudiante(id)
        If est Is Nothing Then
            Return HttpNotFound()
        End If

        Return View(est)
    End Function

    'Guardar cambios
    <HttpPost>
    <ValidateAntiForgeryToken>
    Function Edit(est As Estudiante) As ActionResult

        If ModelState.IsValid Then
            dal.ActualizarEstudiante(est)
            Return RedirectToAction("Index")
        End If

        Return View(est)
    End Function


    'Eliminar Estudiante
    <HttpPost>
    <ValidateAntiForgeryToken>
    Function Delete(id As Integer) As ActionResult

        dal.EliminarEstudiante(id)
        Return RedirectToAction("Index")

    End Function

End Class
