$('#btnAdd').click(function () {
    if ($('#addModalContent').html() == '') {
        $.ajax({
            url: '/admin/add-category',
            type: 'GET',
            success: function (response) {
                $('#addModalContent').html(response)
                $('#addModal').modal('show')
                $('#add-form').submit((e) => {
                    e.preventDefault()
                    const addData = {
                        Name: $('#addModalContent').find('input[name=Name]').val()
                    }
                    $.ajax({
                        url: '/admin/add-category',
                        type: 'POST',
                        data: addData,
                        success: (res) => {
                            $('#btnCloseAddModal').click()
                            bootbox.alert('Kategori başarıyla eklendi', () => {
                                window.location.href = '/admin/list-category'
                            })
                        }
                    })
                })
            }
        })
    }
    else {
        $('#addModal').modal('show')
    }
})

$(".btnDetail").click(function () {
    $('#modalContent').html('');
    $('#updateModal').remove()
    let btn = $(this);
    let id = btn.data('id');
    $.ajax({
        url: '/admin/update-category/' + id,
        type: 'GET',
        success: (response) => {
            $('#modalContent').html(response);
            $('#updateModal').modal('show');
            $('#update-form').submit(function (e) {
                e.preventDefault()
                $('#btnCloseUpdateModal').click()
                const formData = {
                    ID: $('#modalContent').find('input[name=ID]').val(),
                    Name: $('#modalContent').find('input[name=Name]').val(),
                }
                $.ajax({
                    url: '/admin/update-category/',
                    data: formData,
                    type: 'POST',
                    success: (res) => {
                        if (res.response == false) {
                            bootbox.alert(res.message);
                        }
                        else {
                            $('#modalContent').html('');
                            $('#updateModal').remove()
                            bootbox.alert('Kategori bilgileri başarıyla güncellendi', () => {
                                window.location.href = '/admin/list-category'
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
                url: '/admin/delete-category/' + id,
                type: 'POST',
                success: (res) => {
                    if (res.response) {
                        bootbox.alert('Kullanıcı başarıyla silindi', () => {
                            window.location.href = '/admin/list-category'
                        })
                    }
                }
            })
        }
    })

})