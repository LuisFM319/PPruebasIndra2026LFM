
@ModelType InstitutoWeb.Calificacion



<h2>Editar Calificaciones</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()

    @Html.HiddenFor(Function(m) m.ID_Calificacion)

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.ID_Estudiante
                           )
        @Html.TextBoxFor(
                                      Function(m) m.ID_Estudiante,
                                      New With {.class = "form-control"}
                                  )
        @Html.ValidationMessageFor(Function(m) m.ID_Estudiante)
    </div>

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.ID_Materia)
        @Html.TextBoxFor(
                                                   Function(m) m.ID_Materia,
                                                   New With {.class = "form-control"}
                                                  )
        @Html.ValidationMessageFor(Function(m) m.ID_Materia)
    </div>

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Periodo)
        @Html.TextBoxFor(
                                                   Function(m) m.Periodo,
                                                   New With {.class = "form-control"}
                                               )
        @Html.ValidationMessageFor(Function(m) m.Periodo)
    </div>

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Puntaje)
        @Html.TextBoxFor(
                                                   Function(m) m.Puntaje,
                                                   New With {.class = "form-control"}
                                               )
        @Html.ValidationMessageFor(Function(m) m.Puntaje)
    </div>

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Observaciones)
        @Html.TextBoxFor(
                                                   Function(m) m.Observaciones,
                                                   New With {.class = "form-control"}
                                               )
        @Html.ValidationMessageFor(Function(m) m.Observaciones)
    </div>


    @<button type="submit" Class="btn btn-primary">
        Actualizar
    </button>


End Using

<p>
    @Html.ActionLink("Volver a la lista", "Index")
</p>

