import { startConnection } from '../helperJs/QzTrayConfig.js';
$(document).ready(function () {
    startConnection();
    $('.trim-input').on('blur', function () {
        let text = $(this).val();
        $(this).val(text.trim());
    });

    $('.intP-input').on('input', function () {
        this.value = this.value.replace(/\D/g, '');
    });

    $('.collapse-item').on('click', function () {
        let targetCollapse = $(this).data('target');
        $('#collapseTwo .collapse').not(targetCollapse).collapse('hide');
        $(targetCollapse).collapse('toggle');
    });

    $('#qzTrayAlert').click(function (e) {
        $('#qzTrayAlert').prop('disabled', true);
        e.preventDefault();
         startConnection();
    });
});