$('.btnDelete').click(function () {
    bootbox.confirm('Silmek istediğinize emin misiniz?', (result) => {
        if (result == true) {
            const id = $(this).data('id')
            $.ajax({
                url: '/admin/delete-question/' + id,
                type: 'POST',
                success: (res) => {
                    if (res.response) {
                        bootbox.alert('Soru başarıyla silindi', () => {
                            window.location.href = '/admin/list-question'
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