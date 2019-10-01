function canChangeColor() {

    var can = true;

    $("input[type='text'], input").each(function () {
        if ($(this).val() == '') {
            can = false;
        }
    });

    if (can) {
        $('.btn').css({ background: 'darkseagreen' })
    }

}