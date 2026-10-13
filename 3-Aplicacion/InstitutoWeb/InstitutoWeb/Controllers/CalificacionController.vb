Imports System.Data.SqlClient
Imports System.Web.Mvc


Public Class CalificacionController
    Inherits Controller

    Private ReadOnly dal As New CalificacionDAL()
    Private cadenaCon As String = ConfigurationManager.ConnectionStrings("ConBD").ConnectionString

    'Consultar todas Calificaciones
    Function Index() As ActionResult
        Dim lista As New List(Of Calificacion)
        Using con As New SqlConnection(cadenaCon)
            Dim cmd As New SqlCommand("sp_Calificaciones_CRUD", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Operacion", "SELECT")
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                lista.Add(New Calificacion With {
                    .ID_Calificacion = reader("ID_Calificacion"),
                    .ID_Estudiante = reader("ID_Estudiante"),
                    .ID_Materia = reader("ID_Materia"),
                    .Periodo = Convert.ToInt32(reader("Periodo")),
                    .Puntaje = Convert.ToDecimal(reader("Puntaje")),
                    .Observaciones = reader("Observaciones").ToString(),
                    .Fecha_Registro = Convert.ToDateTime(reader("Fecha_registro"))
                })
            End While
        End Using
        Return View(lista)
    End Function


    'Mostrar formulario de Creacion
    Function Create() As ActionResult
        Return View()
    End Function


    'Guardar Nueva Calificacion
    <HttpPost>
    Function Create(cal As Calificacion) As ActionResult

        If ModelState.IsValid Then
            dal.InsertarCalificacion(cal)
            Return RedirectToAction("Index")
        End If

        Return View(cal)
    End Function

    'Mostrar formulario de Edicion
    Function Edit(id As Integer) As ActionResult

        Dim cal = dal.ObtenerCalificacion(id)
        If cal Is Nothing Then
            Return HttpNotFound()
        End If

        Return View(cal)
    End Function

    'Guardar cambios
    <HttpPost>
    <ValidateAntiForgeryToken>
    Function Edit(cal As Calificacion) As ActionResult

        If ModelState.IsValid Then
            dal.ActualizarCalificacion(cal)
            Return RedirectToAction("Index")
        End If

        Return View(cal)
    End Function


    'Eliminar Calificacion
    <HttpPost>
    <ValidateAntiForgeryToken>
    Function Delete(id As Integer) As ActionResult

        dal.EliminarCalificacion(id)
        Return RedirectToAction("Index")

    End Function

End Class
