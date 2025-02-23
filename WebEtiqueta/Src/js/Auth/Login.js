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

    $('#formLogin').submit(async function (e) {
        e.preventDefault();
        $('#btnLogin').val('Carregando...').prop('disabled', true);

        //$("#usuarioLogin").val(function (index, value) {
        //    return value.toLowerCase();
        //});

        let formData = new FormData(this);

        try
        {
            const requisicao = await fetch(`${BASE_URL}/Auth/ValidarLogin`, {
                method: "POST",
                body: formData
            });

            if (!requisicao.ok)
            {
                const contentType = requisicao.headers.get("content-type");
                if (contentType && contentType.includes("application/json")) {
                    const erro = await requisicao.json();
                    console.error("Erro: ", erro);
                    abrirAlertaPage("danger", erro.mensagem, erro.logSuporte);
                } else
                {
                    const erro = await requisicao.text();
                    console.error("Erro: ", erro);
                    abrirAlertaPage("danger", "Erro inesperado, tente novamente mais tarde ou entre em contato com o suporte");
                }
                return;
            }

            window.location.href = `${BASE_URL}`;
        } catch (error)
        {
            console.error("Erro: ", error);
            abrirAlertaPage("danger", "Erro inesperado ao conectar com o servidor, tente novamente mais tarde ou entre em contato com o suporte");
        } finally
        {
            $('#btnLogin').val('Entrar').prop('disabled', false);
        }
    });
});