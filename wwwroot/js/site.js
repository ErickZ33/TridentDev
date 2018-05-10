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
        $(this).prop("disabled", true); // disable button for length of function to prevent multiple submits

        $.ajax({

            url: "SubmitForm", // validation route
            type: "post",
            data: $("#proj_info").serialize(),
            success: function (result) {
                // replace form with updates
                $("#proj_info").replaceWith(result);

                // search updates for empty spans

                // get count of empty spans in form element
                var count_empty = 0;

                $('#proj_info').find('span').each( function(index, element) {

                    if($(element).is(':empty')) { 
                        count_empty++; // count valid fields (empty spans)
                    }

                });

                if(count_empty == 4) { // 4 empty spans -> valid form

                    $('#proj_info').find('input, textarea').each( function(index, element) {
                        $(element).val(""); // blank out form details
                    })

                    $('#proj_info').prepend("<p id='form_success'>Form Successfully Submitted. Thank You!</p>");

                }

            }

        }); // end ajax

        // once complete, enable button again
        $(this).prop("disabled", false); 
    }) // end button.click

}); // end document.ready

