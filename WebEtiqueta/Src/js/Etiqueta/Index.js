//import { startConnection } from '../../helperJs/QzTrayConfig.js';
const BASE_URL = window.location.origin;
//      ELEMENTOS.      //
const $adicionarEtiquetaModal = $('#adicionarEtiqueta');
//     /ELEMENTOS.      //
$(document).ready(function () {
    //      EVENTOS.      //
    $(document).on('click', '.btn-excluir-etiqueta', function () {
        let id = $(this).data('id');
        deleteEtiqueta(id);
    });

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
                    return `
                        <a href="${BASE_URL}" class="btn btn-success btn-circle" title="Imprimir">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-printer-fill" viewBox="0 0 16 16">
                              <path d="M5 1a2 2 0 0 0-2 2v1h10V3a2 2 0 0 0-2-2zm6 8H5a1 1 0 0 0-1 1v3a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1v-3a1 1 0 0 0-1-1"/>
                              <path d="M0 7a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v3a2 2 0 0 1-2 2h-1v-2a2 2 0 0 0-2-2H5a2 2 0 0 0-2 2v2H2a2 2 0 0 1-2-2zm2.5 1a.5.5 0 1 0 0-1 .5.5 0 0 0 0 1"/>
                            </svg>
                        </a>

                        <a href="${BASE_URL}/Etiqueta/Campos/${row.id}" class="btn btn-primary btn-circle" title="Campos">
                            <i class="fas fa-info-circle"></i>
                        </a>

                        <a href="${BASE_URL}/Etiqueta/Editar/${row.id}" class="btn btn-info btn-circle" title="Editar Modelo">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                              <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                              <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"/>
                            </svg>
                        </a>

                        <a class="btn btn-danger btn-circle btn-excluir-etiqueta" title="Excluir" data-id="${row.id}">
                            <i class="fas fa-trash"></i>
                        </a>
                    `;
                }
            }
        ],
        columnDefs: [
            { orderable: false, targets: [3] }
        ]
    });

});

async function deleteEtiqueta(id) {
    const url = `${BASE_URL}/Etiqueta/Delete/${id}`;

    const r = await Swal.fire({
        icon: 'warning',
        title: 'Atenção',
        text: 'Deseja realmente excluir essa etiqueta?',
        showCancelButton: true,
        confirmButtonText: 'Sim',
    });

    if (r.isConfirmed) {
        try {
            loadTabela("tabelaEtiquetasGeral", 4);
            const requisicao = await fetch(url, {
                method: "DELETE"
            });

            if (!requisicao.ok) {
                const contentType = requisicao.headers.get("content-type");
                let erro;
                if (contentType && contentType.includes("application/json")) {
                    erro = await requisicao.json();
                    abrirAlertaPage("danger", erro.mensagem, erro.logSuporte);
                } else {
                    erro = await requisicao.text();
                    abrirAlertaPage("danger", "Erro inesperado, tente novamente mais tarde ou entre em contato com o suporte");
                }

                console.error("Erro: ", erro);
                return;
            }

            abrirAlertaPage("success", "Etiqueta excluída com sucesso");
        } catch (error) {
            console.error("Erro: ", error);
            abrirAlertaPage("danger", "Erro inesperado ao conectar com o servidor, tente novamente mais tarde ou entre em contato com o suporte");
        } finally {
            $('#tabelaEtiquetasGeral').DataTable().ajax.reload();
        }
    }
}
