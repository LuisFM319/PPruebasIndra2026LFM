
@ModelType InstitutoWeb.Materia


<h2>Editar Materias</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()

    @Html.HiddenFor(Function(m) m.ID_Materia)

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Nombre)
        @Html.TextBoxFor(
                         Function(m) m.Nombre,
                         New With {.class = "form-control"}
                     )
        @Html.ValidationMessageFor(Function(m) m.Nombre)
    </div>

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Skill)
        @Html.TextBoxFor(
                                                   Function(m) m.Skill,
                                                   New With {.class = "form-control"}
                                                  )
        @Html.ValidationMessageFor(Function(m) m.Skill)
    </div>


    @<button type="submit" Class="btn btn-primary">
        Actualizar
    </button>


End Using

<p>
    @Html.ActionLink("Volver a la lista", "Index")
</p>

