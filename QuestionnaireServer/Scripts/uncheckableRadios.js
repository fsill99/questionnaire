/// <reference path="jquery-1.9.0.js" />

function UncheckableRadios(radioSelector)
{
    $(radioSelector).on("click", function (event) {
        var this_input = $(this).prop('tagName') !== 'INPUT' ? $(this).parent().first() : $(this);
        var id = this_input.parent().prop("id");
        var group = id.substring(0, id.lastIndexOf('_'));
        var groupSelector = "#" + group;
        var temp = false;

        if (this_input.attr('checked1') === '11') {
            this_input.attr('checked1', '11')
            temp = true;
        }
        else {
            temp = false;
            this_input.attr('checked1', '22')
        }

        $(groupSelector).children().children().children().children(':radio').prop('checked', false);
        $(groupSelector).children().children().children().children(':radio').attr('checked1', '22')

        if (temp) {
            this_input.prop('checked', false);
            this_input.attr('checked1', '22')
        }
        else {
            this_input.prop('checked', true);
            this_input.attr('checked1', '11')
        }
    });
}

