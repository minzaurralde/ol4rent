function inadecuado(id) {
    $.ajax({
        type: "POST",
        url: "/Bien/Inadecuado/" + id,
        processData: false,
        dataType: "json",
        success: function (data, status, xhr) {
            $("#inadecuado-" + id).text("Se ha marcado el contenido como inadecuado.");
        }
    });
}