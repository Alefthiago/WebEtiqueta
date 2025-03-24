$(document).ready(function () {
    //      ELEMENTOS.      //
    const $formAdicionar    = $("#formAdicionarEtiqueta");
    const $btnAdicionar     = $("#btnAdicionar");
    //     /ELEMENTOS.      //

    $formAdicionar.validate({
        rules: {
            "Modelo": {
                required: true
            },
            "Nome": {
                required: true
            },
            "Tipo": {
                required: true
            },
            "Altura": {
                required: true,
                number: true,
                min: 1
            },
            "Largura": {
                required: true,
                number: true,
                min: 1
            },
            "Colunas": {
                required: true,
                number: true,
                min: 1
            },
            "Linhas": {
                required: true,
                number: true,
                min: 1
            }
        },
        messages: {
            "Modelo": {
                required: "O campo Modelo é obrigatório"
            },
            "Nome": {
                required: "O campo Nome é obrigatório"
            },
            "Tipo": {
                required: "O campo Tipo é obrigatório"
            },
            "Altura": {
                required: "O campo Altura é obrigatório",
                number: "O campo Altura deve ser um número",
                min: "O campo Altura deve ser maior que 0"
            },
            "Largura": {
                required: "O campo Largura é obrigatório",
                number: "O campo Largura deve ser um número",
                min: "O campo Largura deve ser maior que 0"
            },
            "Colunas": {
                required: "O campo Colunas é obrigatório",
                number: "O campo Colunas deve ser um número",
                min: "O campo Colunas deve ser maior que 0"
            },
            "Linhas": {
                required: "O campo Linhas é obrigatório",
                number: "O campo Linhas deve ser um número",
                min: "O campo Linhas deve ser maior que 0"
            }
        },
        errorClass: "error",
        errorElement: "span",
        errorPlacement: function (error, element) {
            error.insertAfter(element);
        },
        showErrors: function (errorMap, errorList) {
            this.defaultShowErrors();
            $(".error").css({
                "color": "red",
                "font-size": "12px",
                "display": "block",
                "margin-top": "0.5rem",
                "word-wrap": "break-word",
                "width": "100%"
            });

            $(".error").prev(".form-control").css({
                "border-color": "red",
                "box-sizing": "border-box", 
                "width": "100%",
            });
        }
    });
    $formAdicionar.submit(function (e) {
        if (!$formAdicionar.valid()) {
            return false;
        }

        e.preventDefault();
        $btnAdicionar.val("Carregando...").prop("disabled", true);

        setTimeout(() => {
            e.currentTarget.submit();
        }, 500);
    });
});