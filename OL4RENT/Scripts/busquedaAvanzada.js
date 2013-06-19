$(document).ready(function () {
    $(function () {
        $("#Propietario").autocomplete({
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