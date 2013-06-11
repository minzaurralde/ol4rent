function inadecuado(id) {
    $.ajax({
        type: "POST",
        url: "/Bien/Inadecuado/" + id,
        processData: false,
        dataType: "json",
        success: function (data, status, xhr) {
            // no hago nada
        }
    });
}