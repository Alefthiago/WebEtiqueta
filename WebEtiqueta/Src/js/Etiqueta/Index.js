//import { startConnection } from '../../helperJs/QzTrayConfig.js';
const BASE_URL = window.location.origin;
//      ELEMENTOS.      //
const $adicionarEtiquetaModal = $('#adicionarEtiqueta');
//     /ELEMENTOS.      //

$(document).ready(function () {
    //      EVENTOS.      //
    $adicionarEtiquetaModal.on('hidden.bs.modal', () => $('#formAdicionarEtiqueta').trigger('reset'));
    //     /EVENTOS.      //

    new DataTable('#tabelaEtiquetasGeral', {
        responsive: true,
        rowReorder: {
            selector: 'td:nth-child(2)'
        },
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.3/i18n/pt_br.json",
            "info": "",
        },
        pageLength: 10,
        lengthChange: false,
        ajax: {
            url: `${BASE_URL}/`,
            data: function (d) {
                return {
                    skip: d.start, // From the DataTable
                    qtd: d.length  // From the DataTable
                };
            },
            dataSrc: function (json) {
                if (json.Status === false) {
                    // Handle error (e.g., show an alert or log)
                    alert(json.Mensagem);
                    return [];
                }
                return json.Dados; // Return the data array
            },
            error: function (xhr, error, thrown) {
                // Handle any AJAX errors
                alert('Ocorreu um erro ao carregar os dados. Tente novamente.');
            }
        }
    });


    loadTabela("tabelaEtiquetasGeral", 4);
});