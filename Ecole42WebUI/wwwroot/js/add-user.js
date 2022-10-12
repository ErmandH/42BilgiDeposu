function addButton() {
    bootbox.confirm("Emin misiniz?", (result) => {
        if (result == true) {
            let formData = {
                Name: $('input[name=Name]').val(),
                Surname: $('input[name=Surname]').val(),
                Email: $('input[name=Email]').val(),
                pass: $('input[name=pass]').val(),
                repass: $('input[name=repass]').val()
            }
            $.ajax({
                url: '/admin/add-user',
                data: formData,
                type: 'POST',
                success: (res) => {
                    if (res.response == false) {
                        bootbox.alert(res.message);
                    }
                    else {
                        bootbox.alert('Kullanıcı başarıyla eklendi', () => {
                            window.location.href = '/admin/list-user'
                        })
                    }
                }
            })
        }
    })
}
