var app = app || {};

app.phoneModel = (function () {
    function PhoneModel(requester) {
        this.requester = requester;
        this.serviceUrl = requester.baseUrl + 'appdata/' + requester.appId + '/phone/';
    }

    PhoneModel.prototype.getPhonesByCreator = function(userId) {
        var requestUrl = this.serviceUrl + '?query={"_acl.creator":"'+ userId + '"}';
        return this.requester.get(requestUrl, true);
    };

    PhoneModel.prototype.addPhone = function(data) {
        return this.requester.post(this.serviceUrl, data, true);
    };

    PhoneModel.prototype.editPhone = function(phoneId, data) {
        var requestUrl = this.serviceUrl + phoneId;
        return this.requester.put(requestUrl, data, true);
    };

    PhoneModel.prototype.deletePhone = function(phoneId) {
        var requestUrl = this.serviceUrl + phoneId;
        return this.requester.remove(requestUrl, true);
    };

    return {
        load: function (requester) {
            return new PhoneModel(requester);
        }
    }
}());