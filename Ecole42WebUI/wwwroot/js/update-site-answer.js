let getEditorData;



$('.btnEdit').click(function (){
	const id = $(this).data('id')
	console.log(parent)
	const btnEdit = $(this)
	const btnDelete = $(`.btnDelete[data-id=${id}]`)
	const answerContent = $(`.answer-content[data-id='${id}']`)
	const saveBtnHtml = '<a class="link-primary" style="cursor: pointer;" id="btnSave">Kaydet</a>'
	
	btnEdit.remove()
	btnDelete.remove()
	document.querySelector(`div[data-id="${id}"]`).innerHTML =  saveBtnHtml
	answerContent.html('')
	const answerEditor = document.createElement('textarea')
	answerEditor.setAttribute("id", "edit-editor");
	answerEditor.setAttribute("name", "Description");
	answerContent.html(answerEditor.outerHTML)
	CKEDITOR.ClassicEditor.create(document.getElementById("edit-editor"), {
		toolbar: {
			items: [
				'findAndReplace', '|',
				'heading', '|',
				'bold', 'italic', 'strikethrough', 'underline', 'code', 'removeFormat', '|',
				'bulletedList', 'numberedList', 'todoList', '|',
				'outdent', 'indent', '|',
				'undo', 'redo',
				'-',
				'fontSize', 'fontFamily', 'fontColor', 'fontBackgroundColor', 'highlight', '|',
				'alignment', '|',
				'link', 'insertImage','uploadImage','blockQuote', 'insertTable', 'mediaEmbed', 'codeBlock', 'htmlEmbed', '|',
				'specialCharacters', 'horizontalLine', '|',
				'sourceEditing'
			],
			shouldNotGroupWhenFull: true
		},
		list: {
			properties: {
				styles: true,
				startIndex: true,
				reversed: true
			}
		},
		heading: {
			options: [
				{ model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
				{ model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
				{ model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
				{ model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
				{ model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
				{ model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
				{ model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' }
			]
		},
		fontFamily: {
			options: [
				'Roboto, sans-serif',
				'Arial, Helvetica, sans-serif',
				'Courier New, Courier, monospace',
				'Georgia, serif',
				'Lucida Sans Unicode, Lucida Grande, sans-serif',
				'Tahoma, Geneva, sans-serif',
				'Times New Roman, Times, serif',
				'Trebuchet MS, Helvetica, sans-serif',
				'Verdana, Geneva, sans-serif'
			],
			supportAllValues: true
		},
		fontSize: {
			options: [10, 12, 14, 'default', 18, 20, 22],
			supportAllValues: true
		},
		htmlSupport: {
			allow: [
				{
					name: /.*/,
					attributes: true,
					classes: true,
					styles: true
				}
			]
		},
		htmlEmbed: {
			showPreviews: true
		},
		link: {
			decorators: {
				addTargetToExternalLinks: true,
				defaultProtocol: 'https://',
				toggleDownloadable: {
					mode: 'manual',
					label: 'Downloadable',
					attributes: {
						download: 'file'
					}
				}
			}
		},
		mention: {
			feeds: [
				{
					marker: '@',
					feed: [
						'@apple', '@bears', '@brownie', '@cake', '@cake', '@candy', '@canes', '@chocolate', '@cookie', '@cotton', '@cream',
						'@cupcake', '@danish', '@donut', '@dragée', '@fruitcake', '@gingerbread', '@gummi', '@ice', '@jelly-o',
						'@liquorice', '@macaroon', '@marzipan', '@oat', '@pie', '@plum', '@pudding', '@sesame', '@snaps', '@soufflé',
						'@sugar', '@sweet', '@topping', '@wafer'
					],
					minimumCharacters: 1
				}
			]
		},
		removePlugins: [
			// These two are commercial, but you can try them out without registering to a trial.
			// 'ExportPdf',
			// 'ExportWord',
			//'CKBox',
			'CKFinder',
			'EasyImage',
			'RealTimeCollaborativeComments',
			'RealTimeCollaborativeTrackChanges',
			'RealTimeCollaborativeRevisionHistory',
			'PresenceList',
			'Comments',
			'TrackChanges',
			'TrackChangesData',
			'RevisionHistory',
			'Pagination',
			'WProofreader',
			'MathType'
		]
	})
		.then(editor => {
			getEditorData = editor
			$.ajax({
				url: '/admin/answer/get-description/' + id,
				type: 'GET',
				success: (res) => {
					editor.setData(res)
					document.getElementById('btnSave').addEventListener('click', () => {
						if (getEditorData.getData() == '') {
							alert("Açıklama kısmı boş bırakılamaz")
							return;
						}
						const data = {
							Description: getEditorData.getData(),
							ID: id,
						}
						$.ajax({
							url:'/admin/update-answer',
							type:'POST',
							data:data,
							success: (res) => {
								if (res.response){
									bootbox.alert('Cevabınız başarıyla güncellendi', () => {
										location.reload()
									})
								}
								else{
									bootbox.alert(res.message)
								}
							}
						})
					})			
				}
			})		
		})
})

$('.btnDelete').click(function () {
    
    bootbox.confirm('Silmek istediğinize emin misiniz?', (result) => {
        if (result == true) {
            const id = $(this).data('id')
            $.ajax({
                url: '/admin/delete-answer/' + id,
                type: 'POST',
                success: (res) => {
                    if (res.response) {
                        bootbox.alert('Cevap başarıyla silindi', () => {
                            location.reload()
                        })
                    }
                }
            })
        }
    })

})