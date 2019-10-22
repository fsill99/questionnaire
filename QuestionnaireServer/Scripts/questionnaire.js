/// <reference path="jquery-1.9.0.js" />

$(document).ready(function () {
    $('#modal-dialog').on('show', function () {
        var link = $(this).data('link'),
            confirmBtn = $(this).find('.confirm');
    })
    $('#cmdConfirm').click(function () {
        $('form').submit();
    });
});

