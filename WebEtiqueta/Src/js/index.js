$(document).ready(function () {
    $('.collapse-item').on('click', function () {
        let targetCollapse = $(this).data('target');
        $('#collapseTwo .collapse').not(targetCollapse).collapse('hide');
        $(targetCollapse).collapse('toggle');
    });
})