$(".btnDetail").click(function () {
    $('#modalContent').html('');
    $('#updateModal').remove()
    let btn = $(this);
    let id = btn.data('id');
    $.ajax({
        url: '/admin/update-user/' + id,
        type: 'GET',
        success: (response) => {
            $('#modalContent').html(response);
            $('#updateModal').modal('show');
            $('#btnUpdate').click(function () {
                $('#btnClose').click()
                const formData = {
                    ID: $('#modalContent').find('input[name=ID]').val(),
                    Name: $('#modalContent').find('input[name=Name]').val(),
                    Surname: $('#modalContent').find('input[name=Surname]').val(),
                    Email: $('#modalContent').find('input[name=Email]').val(),
                    pass: $('#modalContent').find('input[name=pass]').val(),
                    repass: $('#modalContent').find('input[name=repass]').val()
                }
            
                $.ajax({
                    url: '/admin/update-user/',
                    data: formData,
                    type: 'POST',
                    success: (res) => {
                        if (res.response == false) {
                            bootbox.alert(res.message);
                        }
                        else {
                            bootbox.alert('Kullanıcı bilgileri başarıyla güncellendi', () => {
                                window.location.href = '/admin/list-user'
                            })
                        }
                    }
                })
            })
        }
    }) 
});

$('.btnDelete').click(function () {
    
    bootbox.confirm('Silmek istediğinize emin misiniz?', (result) => {
        if (result == true) {
            const id = $(this).data('id')
            $.ajax({
                url: '/admin/delete-user/' + id,
                type: 'POST',
                success: (res) => {
                    if (res.response) {
                        bootbox.alert('Kullanıcı başarıyla silindi', () => {
                            window.location.href = '/admin/list-user'
                        })
                    }
                }
            })
        }
    })

})

$(document).ready(function () {
    $("#search-bar").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table-data tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});