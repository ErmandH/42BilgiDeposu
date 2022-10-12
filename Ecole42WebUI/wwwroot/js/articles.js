$.ajax({
    url: '/articles/get-articles',
    type: 'GET',
    success: (res) => {
        $('#table-search').html('')
        new gridjs.Grid({
            search: {
                enabled: true,
            },
            columns: [
                {
                    id: 'title',
                    name: 'Başlık',
                    formatter: (cell) => gridjs.html(cell)
                },
                {
                    id: 'author',
                    name: 'Yazar',
                    formatter: (cell) => gridjs.html(`<b>${cell}</b>`)
                },
                {
                    id: 'date',
                    name: 'Yayınlanma Tarihi',
                    formatter: (cell) => gridjs.html(new Date(Date.parse(cell)).getDate() + '.' + Number(new Date(Date.parse(cell)).getMonth() + 1) + '.' + new Date(Date.parse(cell)).getFullYear())
                }
            ],
            data: res.result,
            pagination: {
                enabled: true,
                limit: 8,
                summary: false
            },
            style: {
                th: {
                    'font-size' : '18px'
                },
                td: {
                    'font-size' : '16px'
                }
            }
        }).render(document.getElementById("table-search"))
        $('input[type=search]').attr('placeholder', 'Arama...')
        $('input[type=search]').attr('arıa-label', 'Arama...')
        const btnHtml = `<a href="/admin/add-article" class="mt-1">Makale Ekle</a>`
        const addBtn = document.createElement('div')
        addBtn.innerHTML = btnHtml;
        $(addBtn).attr('id', 'addArticle')
        $(addBtn).attr('class', 'd-flex')
        document.getElementsByClassName('gridjs-head')[0].appendChild(addBtn)
    }
})



