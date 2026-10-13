<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Aplicacion Prueba</title>

    <link href="~/Content/site.css" rel="stylesheet" />

    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-expand bg-info">
        <div class="navbar-nav">
            @*@Html.ActionLink("Estudiantes", "Index", "Estudiante", Nothing, New With {.class = "nav-link estudiantes"})
                @Html.ActionLink("Materias", "Index", "Materia", Nothing, New With {.class = "nav-link materias"})
                @Html.ActionLink("Calificaciones", "Index", "Calificacion", Nothing, New With {.class = "nav-link calificaciones"})*@

            @Html.ActionLink("Estudiantes", "Index", "Estudiante", Nothing,
            New With {.class = If(ViewContext.RouteData.Values("controller").ToString() = "Estudiante", "nav-link active estudiantes", "nav-link estudiantes")})

            @Html.ActionLink("Materias", "Index", "Materia", Nothing,
                New With {.class = If(ViewContext.RouteData.Values("controller").ToString() = "Materia", "nav-link active materias", "nav-link materias")})

            @Html.ActionLink("Calificaciones", "Index", "Calificacion", Nothing,
                New With {.class = If(ViewContext.RouteData.Values("controller").ToString() = "Calificacion", "nav-link active calificaciones", "nav-link calificaciones")})

        </div>

    </nav>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Aplicacion de Prueba de Estudiantes-Calificaciones</p>
        </footer>
    </div>

    <script src="~/Scripts/acciones1.js"></script>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
