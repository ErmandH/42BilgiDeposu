$(document).ready(function () {
    $('#register-form').submit(function (e) {
        e.preventDefault()
        console.log('test')
        const registerData = {
            Name: $('input[name=Name]').val(),
            Surname: $('input[name=Surname]').val(),
            Email: $('input[name=Email]').val(),
            pass: $('input[name=pass]').val(),
            repass: $('input[name=repass]').val()
        }

        $.ajax({
            url: '/admin/register',
            type: 'POST',
            data: registerData,
            success: (res) => {
                if (res.response == false) {
                    bootbox.alert(res.message);
                }
                else {
                    bootbox.alert("Kaydınız başarıyla gerçekleşti. Üyeliğiniz yöneticiler tarafından onaylandıktan sonra aktif olacak,", () => window.location.href = '/');
                }
            }
        })
    })

})
