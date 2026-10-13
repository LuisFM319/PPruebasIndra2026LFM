
@ModelType InstitutoWeb.Calificacion


<h2>Crear Calificaciones</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.ID_Estudiante)
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



    @<button id="btnGuardar" Class="btn btn-success">Guardar</button>


End Using

<p>
    @Html.ActionLink("Volver a la lista", "Index")
</p>

