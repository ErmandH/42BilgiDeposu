function showResult(str){
	if (str.length==0) {
		document.getElementById("livesearch").innerHTML="";
		return;
	  }
	  $.ajax({
		url:'/search?query=' + str,
		type:'GET',
		success: (res) => {
			let finalResult = ''
			let len = 0
			if (res.length > 10)
				len = 10
			else
				len = res.length
			for (let index = 0; index < len; index++) {
				const text = res[index];
				const searchHTML = `
				<div class="col-12 search-result rounded">
					${text}
				</div>
				`
				finalResult = finalResult + searchHTML
			}
			document.getElementById("livesearch").innerHTML = finalResult
		}
	})

}

$('#btnLogin').on('click', () => {
	window.location.href = '/admin/login'
})

$('#btnLogout').on('click', () => {
	window.location.href = '/admin/logout'
})

$('#btnPanel').on('click', () => {
	window.location.href = '/admin/dashboard'
})