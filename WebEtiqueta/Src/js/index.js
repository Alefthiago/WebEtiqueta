﻿import { startConnection } from '../helperJs/QzTrayConfig.js';
$(document).ready(function () {
    startConnection();
    $('.trim-input').on('blur', function () {
        texto = $(this).val();
        texto = texto.trim();
        $(this).val(texto);
    });

    $('.collapse-item').on('click', function () {
        let targetCollapse = $(this).data('target');
        $('#collapseTwo .collapse').not(targetCollapse).collapse('hide');
        $(targetCollapse).collapse('toggle');
    });

    //new DataTable('#dataTable', {
    //    responsive: true,
    //    rowReorder: {
    //        selector: 'td:nth-child(2)'
    //    },
    //    language: {
    //        url: "https://cdn.datatables.net/plug-ins/1.11.3/i18n/pt_br.json",
    //        "info": "",
    //    },
    //    "pageLength": 10,
    //    "lengthChange": false

    //});

    $('#qzTrayAlert').click(function (e) {
        $('#qzTrayAlert').prop('disabled', true);
        e.preventDefault();
         startConnection();
    });
});