import { startConnection } from './QzTrayConfig';
$(document).ready(function () {
    $('.collapse-item').on('click', function () {
        let targetCollapse = $(this).data('target');
        $('#collapseTwo .collapse').not(targetCollapse).collapse('hide');
        $(targetCollapse).collapse('toggle');
    });

    $('#myTable').DataTable();
    $('[data-toggle="tooltip"]').tooltip();

    $('#recarregarQzTray').click(function (e) {
        e.preventDefault();
        alert()
    });
})
        startConnection();