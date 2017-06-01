foodVentures.services.person = foodVentures.services.person || {};

foodVentures.services.person.select = function (id, onSuccess, onError) {
	var url = '/api/people/' + id;
	var settings = {
		cache: false,
		dataType: "json",
		success: onSuccess,
		error: onError,
		type: 'GET'
	};
	$.ajax(url, settings);
};

foodVentures.services.person.update = function (id, data, onSuccess, onError) {
    var url = "/api/people/" + id + "/edit";
    var settings = {
        cache: false,
        type: "PUT",
        contentType: "application/json",
        dataType: "json",
        success: onSuccess,
        error: onError,
        data: JSON.stringify(data)
    };
    $.ajax(url, settings);
};
