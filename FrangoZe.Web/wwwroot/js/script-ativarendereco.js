document.addEventListener('DOMContentLoaded', function () {
    var form = document.getElementById('AddReserva');
    var checkEndereco = document.getElementById('checkEntrega');
    var endereco = document.getElementById('enderecoEntrega');
    var numero = document.getElementById('numeroEntrega');
    var bairro = document.getElementById('bairroEntrega');
    var hora = document.getElementById('horaEntrega');
    var submitButton = document.getElementById('submitButton');
    var checkProduto = document.querySelector("input[type='number']");
    

    function verificarSeAlgumaCheckboxMarcada() {
        return Array.from(document.querySelectorAll('.form-check-input')).some(checkbox => checkbox.checked);
    }

    document.querySelectorAll('.form-check-input').forEach((checkbox) => {
        checkbox.addEventListener('change', (event) => {
            const inputQuantidade = event.target
                .closest('p') // Encontra o elemento <p> mais próximo
                .querySelector("input[type='number']"); // Campo de quantidade associado

            if (event.target.checked) {
                algumaMarcada = true;
                inputQuantidade.disabled = false; // Habilitar
                inputQuantidade.required = true;
            } else {
                algumaMarcada = false;
                inputQuantidade.disabled = true; // Desabilitar
                inputQuantidade.required = false;
            }
        });
    }); //chat answer

    form.addEventListener('input', function () {
        if (form.checkValidity() && verificarSeAlgumaCheckboxMarcada()) {
            submitButton.disabled = false;
        } else {
            submitButton.disabled = true;
        }
        if (checkEndereco.checked) {

            endereco.disabled = false;
            numero.disabled = false;
            bairro.disabled = false;

            hora.disabled = false;

            endereco.required = true;
            numero.required = true;
            bairro.required = true;

            hora.required = true;

        } else if (checkEndereco.checked == false) {
            endereco.value = null;
            numero.value = null;
            bairro.value = null;
            hora.value = null;

            endereco.disabled = true;
            numero.disabled = true;
            bairro.disabled = true;
            hora.disabled = true;

            endereco.required = false;
            numero.required = false;
            bairro.required = false;
            hora.required = false;
        }
    });
});