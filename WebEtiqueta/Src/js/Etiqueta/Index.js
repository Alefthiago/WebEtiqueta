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
        serverSide: true,
        //rowReorder: {
        //    selector: 'td:nth-child(2)'
        //},
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.3/i18n/pt_br.json",
            info: "",
            infoEmpty: "",
            infoFiltered: "",
            lengthMenu: "",
            loadingRecords: () => loadTabela("tabelaEtiquetasGeral", 4),
            paginate: {
                first: "<<",
                last: ">>",
                next: ">",
                previous: "<"
            },
        },
        pageLength: 10,
        lengthChange: false,
        ajax: {
            url: `${BASE_URL}/Etiqueta/ListarEtiquetasExe`,
            type: 'GET',
            data: function (d) {
                d.skip = d.start;
                d.qtd = d.length;
                d.search = d.search.value;
                d.orderable = d.order[0].dir;
                d.order = d.order[0].column;
                loadTabela("tabelaEtiquetasGeral", 4)
            },
            dataSrc: function (json) {
                return json.data;
            },
            error: function (xhr, status, error) {
                if (xhr.responseJSON !== undefined) {
                    let resposta = xhr.responseJSON;
                    console.error("Erro: ", resposta.logSuporte);
                    abrirAlertaPage("danger", resposta.mensagem, resposta.logSuporte);
                } else {
                    console.error("Erro: ", error);
                    abrirAlertaPage("danger", "Erro inesperado ao conectar com o servidor, tente novamente mais tarde ou entre em contato com o suporte");
                }
            }
        },
        columns: [
            { data: 'nome' },
            { data: 'modelo' },
            { data: 'tipo' },
            {
                data: 'id',
                render: function (data, type, row) {
                    return `<button class="btn btn-primary btn-sm" onclick="editarEtiqueta(${data})">Editar</button>`;
                }
            }
        ],
        columnDefs: [
            { orderable: false, targets: [3] }
        ]
    });
});