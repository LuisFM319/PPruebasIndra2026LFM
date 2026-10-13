
@ModelType InstitutoWeb.Estudiante

<h2>Crear Estudiantes</h2>

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
        @Html.LabelFor(Function(m) m.Apellido)
        @Html.TextBoxFor(
                                      Function(m) m.Apellido,
                                      New With {.class = "form-control"}
                                     )
        @Html.ValidationMessageFor(Function(m) m.Apellido)
    </div>

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Edad)
        @Html.TextBoxFor(
                                      Function(m) m.Edad,
                                      New With {.class = "form-control"}
                                  )
        @Html.ValidationMessageFor(Function(m) m.Edad)
    </div>

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Sexo)
        @Html.TextBoxFor(
                                      Function(m) m.Sexo,
                                      New With {.class = "form-control"}
                                  )
        @Html.ValidationMessageFor(Function(m) m.Sexo)
    </div>

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Curso)
        @Html.TextBoxFor(
                                      Function(m) m.Curso,
                                      New With {.class = "form-control"}
                                  )
        @Html.ValidationMessageFor(Function(m) m.Curso)
    </div>

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Correo)
        @Html.TextBoxFor(
                         Function(m) m.Correo,
                         New With {.class = "form-control"}
                     )
        @Html.ValidationMessageFor(Function(m) m.Correo)
    </div>

    @<div class="form-group">
        @Html.LabelFor(Function(m) m.Observaciones)
        @Html.TextBoxFor(
                                      Function(m) m.Observaciones,
                                      New With {.class = "form-control"}
                                  )
        @Html.ValidationMessageFor(Function(m) m.Observaciones)
    </div>


    @<button id = "btnGuardar" Class="btn btn-success">Guardar</button>


End Using

<p>
    @Html.ActionLink("Volver a la lista", "Index")
</p>

