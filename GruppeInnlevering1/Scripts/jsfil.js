/*function buttonChangeColor() {

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

}*/


function buttonChangeColor() {

    var button = true;
    var stu = document.getElementById('StudentAntall');
    var vok = document.getElementById('VoksenAntall');
    var bar = document.getElementById('BarnAntall');
    var feil = document.getElementById('StasjonTil').value;
    var feil2 = document.getElementById('st').value;

    $("input[type='text'], input").each(function () {
        console.log("1", button)

       //$("#btnSubmit").attr("disabled", true);
      /*  if ($(this).val() == '') {
            button = false;
            console.log("2", button)

            
        } else */if ($(stu).val() == '' && $(vok).val() == '' && $(bar).val() == '') {
            button = false;
            $('.btn').css({ background: 'lightgrey' })
            $("#btnSubmit").attr("disabled", true);
            console.log("3", button)
        }
        else if (feil == feil2) {
            button = false;
            $('.btn').css({ background: 'lightgrey' })
            $("#btnSubmit").attr("disabled", true);
            console.log("4", button)
        }
        else if ($(stu).val() != '' || $(vok).val() != '' || $(bar).val() != '' && feil != feil) {
            button = true;
            /* console.log($(vok).val())
             console.log($(stu).val())
             console.log($(bar).val())*/
            console.log("5", button)
            $('.btn').css({ background: 'darkseagreen' })
            $("#btnSubmit").attr("disabled", false);
            // $('.btn').css({ background: 'darkseagreen' })
            //$("#btnSubmit").attr("disabled", false);

        } else if ($('input[id=rbtnEnVei]:checked').length > 0 && $(stu).val() != '' && $(vok).val() != '' && $(bar).val() != '' && feil != feil) {
            button = true;
        }
        /*    else if ($(stu).val() != '0' || $(vok).val() != '0' || $(bar).val() != '0') {
                button = true;
                $('.btn').css({ background: 'green' })
                $("#btnSubmit").attr("disabled", false);
    
            } */
    });

    if (button) {
        $('.btn').css({
            "background-color": "hsl(351, 60 %, 11 %)!important",
            "background-repeat": "repeat - x",
            " background-image": "-o - linear - gradient(top, #32ba7b, #3dd38e)",
            "background-image": "linear - gradient(#288b5d, #1d6242)",
            "border-color": "black grey #646363",
            " color": "#fff!important",
            "text - shadow": "0 - 1px 0 rgba(0, 0, 0, 0.62)"
        });
        $("#btnSubmit").attr("disabled", false);

    }
}