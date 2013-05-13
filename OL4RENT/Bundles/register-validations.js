$(document).ready(function () {
    $("#RegisterForm").validate({
        rules: {
            UserName: { required: true, minlength: 1, maxlength: 64 },
            Contraseña: { required: true, minlength: 6, maxlength: 100 },
            ConfirmPassword: { required: true, minlength: 6, maxlength: 100, equalTo: "#Contrase_a" }
        },
        messages: {
            UserName: { required: "El nombre de usuario es obligatorio.", minlength: "El nombre de usuario debe contener por lo menos {0} caracter", maxlength: "El nombre de usuario debe contener como máximo {0} caracteres."},
            Contraseña: { required: "La contraseña es obligatoria", minlength: "La contraseña debe tener como mínimo {0} caracteres.", maxlength: "La contraseña debe tener como máximo {0} caracteres." },
            ConfirmPassword: { required: "Debe ingresar la contraseña nuevamente para confirmarla.", minlength: "La confirmación de la contreseña de tener como mínimo {0} caracteres", maxlength: "La confirmación de la contraseña debe contener como máximo {0} caracteres", equalTo: "La contraseña y la confirmación deben coincidir." }
        }
    });
});