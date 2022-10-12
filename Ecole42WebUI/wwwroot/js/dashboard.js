const getIntraId = () => {
	$.ajax({
		url:'/admin/get-intra-id',
		type: 'GET',
		success: (res) => {
			return res;
		}
	})
}
