const BASE_URL = window.location.origin;

$(document).ready(function () {
    $('.trim-input').on('blur', function () {
        let text = $(this).val();
        $(this).val(text.trim());
    });

    $('.close-btn-alert').click(function () {
        $('.card-alert').removeClass('fade-in');
        $('.card-alert').addClass('fade-out');
        //$('#text-alert').text(null);
    });

    $('#formLogin').submit(function (e) {
        e.preventDefault();

        $('#btnLogin').val('Carregando...').prop('disabled', true);

        let formData = new FormData(this);

        fetch(`${BASE_URL}/Auth/ValidarLogin`, {
            method: 'POST',
            body: formData
        })
            .then(response => {
                if (!response.ok) {
                    return response.json().then(errorData => {
                        throw new Error(errorData.msg || 'Ocorreu um erro inesperado tente novamente mais tarde!');
                    });
                }
                return response.json();
            })
            .then(data => {
                window.location.href = `${BASE_URL}`;
            })
            .catch(error => {
                if ($('.card-alert').hasClass('fade-out')) {
                    $('.card-alert').removeClass('fade-out')
                }
                if (!$('.card-alert').hasClass('fade-in')) {
                    $('.card-alert').addClass('fade-in');
                }
                $('#text-alert').text(error.message);
                console.error('Error:', error);
            })
            .finally(() => {
                $('#btnLogin').val('Entrar').prop('disabled', false);
            });
    });
});