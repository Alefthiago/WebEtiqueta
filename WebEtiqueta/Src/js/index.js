import { startConnection } from './QzTrayConfig.js';
$(document).ready(function () {
    $('.collapse-item').on('click', function () {
        let targetCollapse = $(this).data('target');
        $('#collapseTwo .collapse').not(targetCollapse).collapse('hide');
        $(targetCollapse).collapse('toggle');
    });

    new DataTable('#dataTable', {
        responsive: true,
        rowReorder: {
            selector: 'td:nth-child(2)'
        },
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.3/i18n/pt_br.json",
            "info": "",
        }

    });

    $('#qzTrayAlert').click(function (e) {
        $('#qzTrayAlert').prop('disabled', true);
        e.preventDefault();
         startConnection();
    });

    startConnection();
});