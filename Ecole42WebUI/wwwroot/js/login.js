$(document).ready(function () {
    $('#login-form').submit(function (e) {
        e.preventDefault()

        const loginData = {
            Email: $('input[name=Email]').val(),
            Password: $('input[name=Password]').val()
        }

        $.ajax({
            url: '/admin/login',
            type: 'POST',
            data: loginData,
            success: (res) => {
                if (res.response == false) {
                    bootbox.alert(res.message);
                }
                else {
                    window.location.href = '/admin/dashboard'
                }
            }
        })
    })

})