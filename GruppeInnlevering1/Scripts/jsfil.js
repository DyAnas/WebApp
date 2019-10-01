function buttonChangeColor() {

    var button = true;
    var stu = document.getElementsByName('student');
    var vok = document.getElementsByName('voksen');
    var bar = document.getElementsByName('barn');
    var feil = document.getElementById('StasjonTil').value;
    var feil2 = document.getElementById('st').value;

    $("input[type='text'], input").each(function () {
        if ($(this).val() == '') {
            button = false;
        } else if ($(stu).val() == '0' && $(vok).val() == '0' && $(bar).val() == '0') {
            button = false;
        } 
        else if (feil == feil2){
            button = false;
        }
    });

    if (button) {
        $('.btn').css({ background: 'darkseagreen' })
    }

}