@ModelType IEnumerable(Of InstitutoWeb.Materia)

<h2>Materias...</h2>

<p>
    @Html.ActionLink("Crear una Materia", "Create")
</p>

<table class="table table-bordered">
    <thead>
        <tr>
            <th>ID_Materia</th>
            <th>Nombre</th>
            <th>Skill</th>
            <th>Acciones</th>
        </tr>
    </thead>

    <tbody>
        @For Each item In Model
            @<tr>
                <td>@item.ID_Materia</td>
                <td>@item.Nombre</td>
                <td>@item.Skill</td>
                <td>
                    @Html.ActionLink("Editar", "Edit",
                           New With {.id = item.ID_Materia}
                       )

                    @Using Html.BeginForm(
                "Delete", "Materia",
                New With {.id = item.ID_Materia},
                FormMethod.Post,
                New With {.style = "display:inline"}
             )
                @Html.AntiForgeryToken()
                @<button type="submit"
                         onclick="return confirm('¿Eliminar esta Materia?')">
                    Eliminar
                </button>
                    End Using
                </td>
            </tr>
        Next
    </tbody>
</table>

