@ModelType IEnumerable(Of InstitutoWeb.Estudiante)

<h2>Estudiantes...</h2>

<p>
      @Html.ActionLink("Crear un Estudiante", "Create")
</p>

<table class="table table-bordered">
    <thead>
            <tr>
            <th> ID_Estudiante</th>
            <th> Nombre</th>
            <th> Apellido</th>
            <th> Edad</th>
            <th> Sexo</th>
            <th> Curso</th>
            <th> Correo</th>
            <th> Observaciones</th>
            <th> Acciones</th>
        </tr>
    </thead>

    <tbody>
    @For Each item In Model
@<tr>
    <td>@item.ID_Estudiante</td>
    <td>@item.Nombre</td>
    <td>@item.Apellido</td>
    <td>@item.Edad</td>
    <td>@item.Sexo</td>
    <td>@item.Curso</td>
    <td>@item.Correo</td>
    <td>@item.Observaciones</td>
    <td>
        @Html.ActionLink("Editar", "Edit",
              New With {.id = item.ID_Estudiante}
          )

        @Using Html.BeginForm(
                            "Delete", "Estudiante",
                            New With {.id = item.ID_Estudiante},
                            FormMethod.Post,
                            New With {.style = "display:inline"}
                         )
        @Html.AntiForgeryToken()
        @<button type="submit"
                 onclick="return confirm('¿Eliminar este Estudiante?')">
            Eliminar
        </button>
                    End Using
    </td>
</tr>
Next
        </tbody>
</table>
