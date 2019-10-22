//disabling radio buttons, asp.net does that in a really ugly way
$(document).ready(function () {
    $(":radio").each(function (i, elem) {
        var jElem = $(elem);
        jElem.prop('disabled', 'disabled');
    });
});

