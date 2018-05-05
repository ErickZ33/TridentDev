// Write your Javascript code.
$(document).ready(function () {

    $('.parallax').parallax();

    var prevScrollpos = window.pageYOffset;
    window.onscroll = function () {
        var currentScrollPos = window.pageYOffset;
        if (prevScrollpos > currentScrollPos) {
            document.getElementById("navbar").style.top = "0";
        } else {
            document.getElementById("navbar").style.top = "-120px";
        }
        prevScrollpos = currentScrollPos;
    }

    $('#button').click(function (event) {
        event.preventDefault();

        $.ajax({

            url: "SubmitForm",
            type: "post",
            data: $("#proj_info").serialize(),
            success: function (result) {
                $("#proj_info").replaceWith(result);
            }

        });
    })

});