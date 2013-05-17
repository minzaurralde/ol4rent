$(document).ready(function () {
    $("#IdOrigenDatos").change(function () {
        var idOD = $(this).val();
        $.ajax({
            type: "GET",
            url: "/OrigenDatos/Atributos/" + idOD,
            processData: false,
            dataType: "json",
            success: function (data, status, xhr) {
                $("#ValoresAtributo").find('li').remove();
                $.each(data, function (indice) {
                    var id = data[indice].Id;
                    var nombre = data[indice].Nombre;
                    var idLi = "atr-" + id;
                    var idTxt = "val-" + id;
                    var htmlLiIni = '<li id="' + idLi + '">';
                    var htmlLiFin = "</li>";
                    var htmlLabelIni = '<label for="' + idTxt + '">';
                    var htmlLabelFin = '</label>';
                    var htmlInput = '<input type="text" id="val-' + id + '" name="val-' + id + '" value="" />';
                    $("#ValoresAtributo").append(htmlLiIni + htmlLabelIni + nombre + htmlLabelFin + htmlInput + htmlLiFin);
                });
            }
        });
    });
});