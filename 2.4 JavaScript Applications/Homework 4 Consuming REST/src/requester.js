var app = app || {};

app.requester = (function() {
    function Requester(appId, appSecret) {
        this.appId = appId;
        this.appSecret = appSecret;
        this.baseUrl = 'https://baas.kinvey.com/';
    }

    Requester.prototype.makeRequest = function(method, url, data, useSession) {
        var token;
        var defer = Q.defer();
        var options = {
            method: method,
            url: url,
            data: JSON.stringify(data),
            success: function(data) {
                defer.resolve(data);
            },
            error: function(error) {
                defer.reject(error);
            }
        };

        if (!useSession) {
            token = this.appId + ':' + this.appSecret;
            options.beforeSend = function(xhr) {
                xhr.setRequestHeader('Content-Type', 'application/json');
                xhr.setRequestHeader('Authorization', 'Basic ' + btoa(token));
            };
        } else {
            tokenAuth = sessionStorage['sessionAuth'];
            tokenKey = sessionStorage['sessionKey'];
            options.beforeSend = function(xhr) {
                if (method === 'PUT') {
                    xhr.setRequestHeader('Content-Type', 'application/json');
                    xhr.setRequestHeader('Authorization', 'Basic ' + tokenKey);
                } else if (method === 'DELETE') {
                    xhr.setRequestHeader('Authorization', 'Basic ' + tokenKey);
                } else {
                    xhr.setRequestHeader('Content-Type', 'application/json');
                    xhr.setRequestHeader('Authorization', 'Kinvey ' + tokenAuth);
                }
            };
        }

        $.ajax(options);

        return defer.promise;
    };

    return {
        config: function(appId, appSecret) {
            app.requester = new Requester(appId, appSecret);
        }
    };
}());
