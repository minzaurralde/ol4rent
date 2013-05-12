﻿$(document).ready(function () {
    $("#agregarNuevo").click(function () {
        var idAtributo = $("#NuevoNombre").val();
        var nombreAtributo = $("#NuevoNombre option:selected").text();
        var valor = $("#NuevoValor").val();
        var maxid = $("#maxid").val();
        var valido = true;
        var i = 0;
        while (valido && i < maxid) {
            if ($("#id" + i.toString()).val().equals(idAtributo)) {
                valido = false;
            }
            i++;
        }
        if (valido) {
            var nuevomax = parseInt(maxid) + 1;
            var hiddenIdAtributo = "<input type=\"hidden\" id=\"id" + maxid.toString() + "\" name=\"id" + maxid.toString() + "\" value=\"" + idAtributo + "\" />";
            var hiddenNombreAtributo = "<input type=\"hidden\" name=\"nombre" + maxid.toString() + "\" value=\"" + nombreAtributo + "\" />";
            var hiddenValor = "<input type=\"hidden\" name=\"valor" + maxid.toString() + "\" value=\"" + valor + "\" />";
            var hiddenIdValor = "<input type=\"hidden\" name=\"idValor" + maxid.toString() + "\" value=\"-1\" />";
            var linkEliminar = "<a onclick='javascript:$(\"#tr" + maxid.toString() + "\").remove();return false;'>Eliminar</a>";
            $("#ValoresAtributo tbody").append("<tr id=\"tr" + maxid.toString() + "\"><td>" + nombreAtributo + hiddenNombreAtributo + hiddenIdAtributo + "</td><td>" + valor + hiddenValor + hiddenIdValor + "</td><td>" + linkEliminar + "</td></tr>");
        } else {
            var nuevomax = parseInt(maxid);
            alert("Ya ha agregado el atributo seleccionado. Por favor, seleccione otro.");
        }
        $("#NuevoNombre").val("");
        $("#NuevoValor").val("");
        $("#maxid").val(nuevomax.toString());
        return false;
    });
});