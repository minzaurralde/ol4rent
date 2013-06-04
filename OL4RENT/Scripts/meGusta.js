function like(id) {
    $.ajax({
        type: "POST",
        url: "/Bien/Like/" + id,
        processData: false,
        dataType: "json",
        success: function (data, status, xhr) {
            // no hago nada
        }
    });
}