function like(id) {
    $.ajax({
        type: "POST",
        url: "/Bien/Like/" + id,
        processData: false,
        dataType: "json",
        success: function (data, status, xhr) {
            // alert($("#like-" + id));
            $("#like-" + id).remove();
        }
    });
}