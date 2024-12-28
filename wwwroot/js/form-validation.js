// form-validation.js

$(document).ready(function () {
    // عند إرسال النموذج
    $("form").submit(function (event) {
        var isValid = true;

        // التحقق من حقل Age
        var age = $("#Age").val();
        if (age <= 0) {
            isValid = false;
            alert("Age must be greater than 0.");
        }

        // التحقق من حقل Fees
        var fees = $("#Fees").val();
        if (fees <= 0) {
            isValid = false;
            alert("Fees must be greater than 0.");
        }

        // إذا لم يكن النموذج صحيحًا، قم بإلغاء الإرسال
        if (!isValid) {
            event.preventDefault();
        }
    });
});
