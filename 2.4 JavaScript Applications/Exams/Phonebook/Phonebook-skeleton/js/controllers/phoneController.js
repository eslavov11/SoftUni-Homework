var app = app || {};

app.phoneController = (function () {
    function PhoneController(model, viewBag, messages) {
        this.model = model;
        this.viewBag = viewBag;
        this._messages = messages;
    }

    PhoneController.prototype.loadPhones = function (selector) {
        var _this = this;
        this.model.getPhonesByCreator(sessionStorage.userId)
            .then(function (data) {
                var result = {
                    phones: []
                };

                data.forEach(function (phone) {
                    result.phones.push({
                        person: phone.person,
                        number: phone.number,
                        _id: phone._id
                    })
                });

                _this.viewBag.showPhones(selector, result);
            })
    };

    PhoneController.prototype.loadAddPhone = function (selector) {
        this.viewBag.showAddPhone(selector);
    };

    PhoneController.prototype.addPhone = function (data) {
        var _this = this;
        
        var result = {
            person: data.person,
            number: data.number
        };

        this.model.addPhone(result)
            .then(function (success) {
               // console.log(success); // TODO: NOTY
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/phones/'});
                });
                
                _this._messages.success('You have successfully added a new phone!');
            }, function (error) {
                _this._messages.error('There was an error and the phone wasn\'t added.');
            });
    };

    PhoneController.prototype.loadEditPhone = function (selector, data) {
        this.viewBag.showEditPhone(selector, data);
    };

    PhoneController.prototype.editPhone = function (data) {
        this.model.editPhone(data._id, data)
            .then(function (success) {
                console.log(success);
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/phones/'});
                });
            }, function(error) {
                console.error(error);
            })
    };

    PhoneController.prototype.loadDeletePhone = function (selector, data) {
        this.viewBag.showDeletePhone(selector, data);
    };

    PhoneController.prototype.deletePhone = function (data) {
        this.model.deletePhone(data._id)
            .then(function (success) {
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/phones/'});
                });
            }, function(error) {
            console.error(error);
        });
    };

    return {
        load: function (model, viewBag, messages) {
            return new PhoneController(model, viewBag, messages);
        }
    };
}());