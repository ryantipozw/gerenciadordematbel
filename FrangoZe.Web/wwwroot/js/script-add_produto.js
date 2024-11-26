document.addEventListener('DOMContentLoaded', function () {
    var form = document.getElementById('AddProduto');
    var submitButton = document.getElementById('submitButton');

    form.addEventListener('input', function () {
        if (form.checkValidity()) {
            submitButton.disabled = false;
        } else {
            submitButton.disabled = true;
        }
    });
});