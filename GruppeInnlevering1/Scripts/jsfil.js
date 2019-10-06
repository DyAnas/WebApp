function buttonChangeColor() {

    var button = true;
    var stu = document.getElementById('StudentAntall');
    var vok = document.getElementById('VoksenAntall');
    var bar = document.getElementById('BarnAntall');
    var feil = document.getElementById('StasjonTil').value;
    var feil2 = document.getElementById('st').value;

    $("input[type='text'], input").each(function () {

        if ($(stu).val() == '' && $(vok).val() == '' && $(bar).val() == '') {
            button = false;
            $('.btn').css({ background: 'lightgrey' })
            $("#btnSubmit").attr("disabled", true);
        }
        else if (feil == feil2) {
            button = false;
            $('.btn').css({ background: 'lightgrey' })
            $("#btnSubmit").attr("disabled", true);
        }
        else if ($(stu).val() != '' || $(vok).val() != '' || $(bar).val() != '' && feil != feil) {
            button = true;
            $('.btn').css({ background: 'darkseagreen' })
            $("#btnSubmit").attr("disabled", false);

        } else if ($('input[id=rbtnEnVei]:checked').length > 0 && $(stu).val() != '' && $(vok).val() != '' && $(bar).val() != '' && feil != feil) {
            button = true;
        } else if (feil == null) {
            button = false;
        }
    });

    if (button) {
        $('.btn').css({ background: 'darkseagreen' })
        $("#btnSubmit").attr("disabled", false);
    }
}