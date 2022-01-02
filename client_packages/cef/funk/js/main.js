$('#btnSubmit').on('click', function (e) {
    let frequenz = document.getElementById("frequenzInput");
	mp.trigger('Client:Funk:ChangeFrequenz', frequenz.value);
})

$('#btnClose').on('click', function (e) {
	mp.trigger('Client:Funk:Close');
})