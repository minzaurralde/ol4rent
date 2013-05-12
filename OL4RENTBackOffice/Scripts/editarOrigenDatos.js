$(document).ready(function () {
    $("#agregarNuevo").click(function () {
        var nombre = $("#NuevoNombre").val();
        var maxid = $("#maxid").val();
        var nuevomax = parseInt(maxid) + 1;
        var hiddenNombre = "<input type=\"hidden\" name=\"nombre" + maxid.toString() + "\" value=\"" + nombre + "\" />";
        var hiddenId = "<input type=\"hidden\" name=\"id" + maxid.toString() + "\" value=\"-1\" />";
        var linkEliminar = "<a onclick='javascript:$(\"#tr" + maxid.toString() + "\").remove();return false;'>Eliminar</a>";
        $("#Atributos tbody").append("<tr id=\"tr" + maxid.toString() + "\"><td>" + nombre + hiddenNombre + hiddenId + "</td><td>" + linkEliminar + "</td></tr>");
        $("#NuevoNombre").val("");
        $("#maxid").val(nuevomax.toString());
        return false;
    });
});