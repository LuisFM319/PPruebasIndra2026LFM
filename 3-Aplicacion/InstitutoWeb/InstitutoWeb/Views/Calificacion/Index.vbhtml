@ModelType IEnumerable(Of InstitutoWeb.Calificacion)

<h2>Calificaciones...</h2>

<p>
    @Html.ActionLink("Crear una Calificacion", "Create")
</p>

<table class="table table-bordered">
    <thead>
        <tr>
            <th>ID_Calificacion</th>
            <th>ID_Estudiante</th>
            <th>ID_Materia</th>
            <th>Periodo</th>
            <th>Puntaje</th>
            <th>Observaciones</th>
            <th>Fecha_Registro</th>
            <th>Acciones</th>
        </tr>
    </thead>

    <tbody>
        @For Each item In Model
            @<tr>
    <td>@item.ID_Calificacion</td>
    <td>@item.ID_Estudiante</td>
    <td>@item.ID_Materia</td>
    <td>@item.Periodo</td>
    <td>@item.Puntaje</td>
    <td>@item.Observaciones</td>
    <td>@item.Fecha_Registro</td>
    <td>
        @Html.ActionLink("Editar", "Edit",
                            New With {.id = item.ID_Calificacion}
                        )

        @Using Html.BeginForm(
        "Delete", "Calificacion",
        New With {.id = item.ID_Calificacion},
        FormMethod.Post,
        New With {.style = "display:inline"}
        )
@Html.AntiForgeryToken()
@<button type="submit"
         onclick="return confirm('¿Eliminar esta Calificacion?')">
    Eliminar
</button>
        End Using
    </td>
</tr>
        Next
    </tbody>
</table>

