$('#btnAdd').click(() => {
    $('#addModal').modal('show')
})

$('#add-form').submit((e) => {
    e.preventDefault()
    const addData = {
        Title: $('#addModalContent').find('input[name=Title]').val(),
        URL: $('#addModalContent').find('input[name=URL]').val(),
        projectID: $('#addModalContent').find('select[name=projectID]').val()
    }
    $.ajax({
        url: '/admin/add-useful-link',
        type: 'POST',
        data: addData,
        success: (res) => {
            $('#btnCloseAddModal').click()
            bootbox.alert('Link başarıyla eklendi', () => {
                window.location.href = '/admin/list-useful-link'
            })
        }
    })
})

$('.btnDelete').click(function () {

    bootbox.confirm('Silmek istediğinize emin misiniz?', (result) => {
        if (result == true) {
            const id = $(this).data('id')
            $.ajax({
                url: '/admin/delete-useful-link/' + id,
                type: 'POST',
                success: (res) => {
                    if (res.response) {
                        bootbox.alert('Link başarıyla silindi', () => {
                            window.location.href = '/admin/list-useful-link'
                        })
                    }
                }
            })
        }
    })

})


$(".btnDetail").click(function () {
    $('#modalContent').html('');
    $('#updateModal').remove()
    let btn = $(this);
    let id = btn.data('id');
    $.ajax({
        url: '/admin/update-useful-link/' + id,
        type: 'GET',
        success: (response) => {
            $('#modalContent').html(response);
            $('#updateModal').modal('show');
            $('#update-form').submit(function (e) {
                e.preventDefault()
                $('#btnCloseUpdateModal').click()
                const formData = {
                    ID: $('#modalContent').find('input[name=ID]').val(),
                    Title: $('#modalContent').find('input[name=Title]').val(),
                    URL: $('#modalContent').find('input[name=URL]').val(),
                    projectID: $('#modalContent').find('select[name=projectID]').val()
                }
                $.ajax({
                    url: '/admin/update-useful-link/',
                    data: formData,
                    type: 'POST',
                    success: (res) => {
                        if (res.response == false) {
                            bootbox.alert(res.message);
                        }
                        else {
                            $('#modalContent').html('');
                            $('#updateModal').remove()
                            bootbox.alert('Kullanıcı bilgileri başarıyla güncellendi', () => {
                                window.location.href = '/admin/list-useful-link'
                            })
                        }
                    }
                })
            })
        }
    })
});

$(document).ready(function () {
    $("#search-bar").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#table-data tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});