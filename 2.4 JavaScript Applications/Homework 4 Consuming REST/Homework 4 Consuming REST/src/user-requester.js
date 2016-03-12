var app = app || {};

app.UserRequester = (function() {
	function UserRequester() {
		this.serviceUrl = app.requester.baseUrl + 'user/' + app.requester.appId;
	}

	UserRequester.prototype.signUp = function(username, password) {
		var requestUrl = this.serviceUrl;
		var data = {
			username: username,
			password: password
		};
		app.requester.makeRequest('POST', requestUrl, data).then(function(success) {
			var result = success;
			sessionStorage['sessionAuth'] = result._kmd.authtoken;
			sessionStorage['userId'] = result._id;
		}, function(error) {
			console.error(error);
		}).done();
	};

	UserRequester.prototype.login = function(username, password) {
		var defer = Q.defer();
		var requestUrl = this.serviceUrl + '/login';
		var data = {
			username: username,
			password: password
		};
		app.requester.makeRequest('POST', requestUrl, data).then(function(success) {
			sessionStorage['sessionKey'] = btoa(username + ':' + password);
			sessionStorage['sessionAuth'] = success._kmd.authtoken;
			sessionStorage['userId'] = success._id;
			defer.resolve();
			// console.log(success);
		}, function(error) {
			console.error(error);
			defer.reject();
		}).done();

		return defer.promise;
	};

	UserRequester.prototype.getInfo = function() {
		var requestUrl = this.serviceUrl + '/_me';

		app.requester.makeRequest('GET', requestUrl, null, true).then(function(success) {
			// attach result to DOM
			//$('#display').text(success.username);
			// console.log(success);
		}, function(error) {
			console.error(error);
		}).done();
	};

	UserRequester.prototype.logout = function() {
		var requestUrl = this.serviceUrl + '/_logout';

		app.requester.makeRequest('POST', requestUrl, null, null).then(function(success) {
			console.log(success);
		}, function(error) {
			console.error(error);
		}).done();
	};

	return UserRequester;
}());