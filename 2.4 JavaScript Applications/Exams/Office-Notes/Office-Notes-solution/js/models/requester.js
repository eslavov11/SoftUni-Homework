var app = app || {};

app.requester = (function() {
    function Requester() {
    }

    Requester.prototype.get = function (headers, url) {
        return makeRequest('GET', headers, url);
    };

    Requester.prototype.post = function (headers, url, data) {
        return makeRequest('POST', headers, url, data)
    };

    Requester.prototype.put = function (headers, url, data) {
        return makeRequest('PUT', headers, url, data);
    };

    Requester.prototype.delete = function (headers, url) {
        return makeRequest('DELETE', headers, url);
    };

    function makeRequest(method, headers, url, data) {
        var deffer = Q.defer();

        $.ajax({
            method: method,
            headers: headers,
            url: url,
            data: JSON.stringify(data),
            success: function (data) {
                deffer.resolve(data);
            },
            error: function (error) {
                deffer.reject(error);
            }
        });

        return deffer.promise;
    }

    return {
        load: function (baseUrl) {
            return new Requester(baseUrl);
        }
    }
}());