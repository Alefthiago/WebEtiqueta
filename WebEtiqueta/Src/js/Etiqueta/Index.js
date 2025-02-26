//import { startConnection } from '../../helperJs/QzTrayConfig.js';

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
        "pageLength": 10,
        "lengthChange": false,
        //ajax: {
        //    url: "/Home/GetEtiquetas",
        //    dataSrc: ''
        //},
    });
    loadTabela("tabelaEtiquetasGeral");
});