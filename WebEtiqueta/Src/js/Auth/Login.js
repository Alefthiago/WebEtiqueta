const BASE_URL = window.location.origin;
$(document).ready(function () {
    $('#formLogin').submit(function (e) {
        e.preventDefault();
        fetch(`${BASE_URL}/Auth/ValidarLogin`, {
            method: 'POST',
            body: new FormData(this)
        })
        .then(response => {
            if (!response.ok) {
                return response.json().then(errorData => {
                    throw new Error(errorData.msg || 'Ocorreu um erro inesperado tente novamente mais tarde!')
                });
            }

            return response.json();
        })
        .then(data => {
            alert(data.msg);
        })
        .catch(error => {
            console.error('Error:', error);
            alert(error.message);
        });
    });
});