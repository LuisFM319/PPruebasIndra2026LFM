Imports System.Data.SqlClient
Imports System.Web.Mvc


Public Class MateriaController
    Inherits Controller

    Private ReadOnly dal As New MateriaDAL()
    Private cadenaCon As String = ConfigurationManager.ConnectionStrings("ConBD").ConnectionString

    'Consultar todos Materias
    Function Index() As ActionResult
        Dim lista As New List(Of Materia)
        Using con As New SqlConnection(cadenaCon)
            Dim cmd As New SqlCommand("sp_Materias_CRUD", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Operacion", "SELECT")
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                lista.Add(New Materia With {
                    .ID_Materia = reader("ID_Materia"),
                    .Nombre = reader("Nombre").ToString(),
                    .Skill = Convert.ToInt32(reader("Skill"))
                })
            End While
        End Using
        Return View(lista)
    End Function


    'Mostrar formulario de Creacion
    Function Create() As ActionResult
        Return View()
    End Function


    'Guardar Nueva Materia
    <HttpPost>
    Function Create(mat As Materia) As ActionResult

        If ModelState.IsValid Then
            dal.InsertarMateria(mat)
            Return RedirectToAction("Index")
        End If

        Return View(mat)
    End Function

    'Mostrar formulario de Edicion
    Function Edit(id As Integer) As ActionResult

        Dim mat = dal.ObtenerMateria(id)
        If mat Is Nothing Then
            Return HttpNotFound()
        End If

        Return View(mat)
    End Function

    'Guardar cambios
    <HttpPost>
    <ValidateAntiForgeryToken>
    Function Edit(mat As Materia) As ActionResult

        If ModelState.IsValid Then
            dal.ActualizarMateria(mat)
            Return RedirectToAction("Index")
        End If

        Return View(mat)
    End Function


    'Eliminar Materia
    <HttpPost>
    <ValidateAntiForgeryToken>
    Function Delete(id As Integer) As ActionResult

        dal.EliminarMateria(id)
        Return RedirectToAction("Index")

    End Function

End Class
