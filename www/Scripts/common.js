function signupNewsletter(txtName, txtEmail) {

    var email = txtEmail.value;
    var name = txtName.value;
    var regEmail = /^.+\@(\[?)[a-zA-Z0-9\-\.]+\.([a-zA-Z]{2,3}|[0-9]{1,3})(\]?)$/;

    if (name == '' || name.length == 0) {
        alert("Name is missing");
        return;
    }
    if (email == '' || email.length == 0 || !regEmail.test(email)) {
        alert("Email is missing or invalid");
        return;
    }

    var userData = {
        name: name,
        email: email
    };
    showLoading("submitting your request, please wait...");

    $.ajax({
        type: "POST",
        url: "WebService.asmx/SignupNewsletter",
        data: $.toJSON(userData),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (msg) {
            hideLoading();
            alert("Error processing your request, please try again later or contact us if the problem persists.");
        },
        success: function (msg) {
            hideLoading();
            alert("Your email has been added successfully to our mailing list");
            txtEmail.value = '';
            txtName.value = '';
        }
    });
}


//water mark code
$(document).ready(function () {
    // Define what happens when the textbox comes under focus
    // Remove the watermark class and clear the box
    $(".watermarkOn").focus(function () {
        //debugger;
        var originalText = $(this).val();
        $(this).filter(function () {

            // We only want this to apply if there's not
            // something actually entered
            return $(this).val() == "" || $(this).val() == "Your Name" || $(this).val() == "Your Email"

        }).removeClass("watermarkOn").attr("original", originalText).val("");

    });

    // Define what happens when the textbox loses focus
    // Add the watermark class and default text
    $(".watermarkOn").blur(function () {

        $(this).filter(function () {

            // We only want this to apply if there's not
            // something actually entered
            return $(this).val() == ""

        }).addClass("watermarkOn").val($(this).attr("original"));

    });
});