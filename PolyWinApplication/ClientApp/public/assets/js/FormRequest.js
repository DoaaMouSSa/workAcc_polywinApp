
function SubmitForm() {
    var name = document.getElementById("nameClient").value;
    var email = document.getElementById("emailClient").value;
    var phone = document.getElementById("phoneClient").value;
    var message = document.getElementById("messClient").value;
    var formData = JSON.stringify({ name: name, email: email, phone: phone, message: message});
    console.log(JSON.stringify(formData));
        $.ajax({
            type: "POST",
            url: "PolyWinLogIn/AddNewMessage",
            contentType: "application/json;",
            dataType: "json",
            data:formData,
            success: function (data) {
                    swal({
                title: "خدمة الدعم الفنى",
                text: 'تم استلام الرساله  وسيتم التواصل فى أقرب وقت',
                button: {
                    text: "تم",
                }
            });
            },
            failure: function (errMsg) {
                alert("يوجد مشكله مع السرفر");
            }
        });
        }
                         
    