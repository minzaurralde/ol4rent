$(document).ready(function () {
    $("#agregarNuevo").click(function () {
        var nombre = $("#NuevoNombre").val();
        var tipo = $("#NuevoTipo").val();
        var maxid = $("#maxid").val();
        var valido = true;
        var i = 0;
        while (valido && i < maxid) {
            if ($("#nombre" + i.toString()).val() == nombre) {
                valido = false;
            }
            i++;
        }
        if (valido) {
            var nuevomax = parseInt(maxid) + 1;
            var hiddenNombre = "<input type=\"hidden\" id=\"nombre" + maxid.toString() + "\" name=\"nombre" + maxid.toString() + "\" value=\"" + nombre + "\" />";
            var hiddenTipo = "<input type=\"hidden\" name=\"tipo" + maxid.toString() + "\" value=\"" + tipo + "\" />";
            var linkEliminar = "<a onclick='javascript:$(\"#tr" + maxid.toString() + "\").remove();return false;'>Eliminar</a>";
            $("#caracteristicas tbody").append("<tr id=\"tr" + maxid.toString() + "\"><td>" + nombre + hiddenNombre + "</td><td>" + tipo + hiddenTipo + "</td><td>" + linkEliminar + "</td></tr>");
        } else {
            var nuevomax = parseInt(maxid);
            alert("Ya ha agregado la caracteristica de bien ingresada. Por favor, utilice otro nombre.");
        }
        $("#NuevoNombre").val("");
        $("#NuevoTipo").val("");
        $("#maxid").val(nuevomax.toString());
        return false;
    });
    $(function () {
        $("#NombreUsuarioPropietario").autocomplete({
            minLength: 2,
            source: function (request, response) {
                $.getJSON("/Account/Buscar?query=" + request.term, function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Key,
                            value: item.Value
                        };
                    }));
                });
            }
        });
    });
});