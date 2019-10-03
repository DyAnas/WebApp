function buttonChangeColor() {

    var button = true;
    var stu = document.getElementsById('StudentAntall');
    var vok = document.getElementsById('VoksenAntall');
    var bar = document.getElementsById('BarnAntall');
    var feil = document.getElementById('StasjonTil').value;
    var feil2 = document.getElementById('st').value;

    $("input[type='text'], input").each(function () {
        $("#btnSubmit").attr("disabled", true);
        if ($(this).val() == '') {
            button = false;
        } else if ($(stu).val() == '0' && $(vok).val() == '0' && $(bar).val() == '0') {
            button = false;
            $('.btn').css({ background: 'grey' })
        } 
        else if (feil == feil2){
            button = false;
            $('.btn').css({ background: 'grey' })
        }
    });

    if (button) {
        $('.btn').css({ background: 'darkseagreen' })
        $("#btnSubmit").attr("disabled", false);
    }

}