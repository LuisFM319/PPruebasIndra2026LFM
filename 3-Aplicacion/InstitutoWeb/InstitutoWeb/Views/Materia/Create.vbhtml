
@ModelType InstitutoWeb.Materia

<h2>Crear Materias</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()

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



    @<button id="btnGuardar" Class="btn btn-success">Guardar</button>

End Using

<p>
    @Html.ActionLink("Volver a la lista", "Index")
</p>

