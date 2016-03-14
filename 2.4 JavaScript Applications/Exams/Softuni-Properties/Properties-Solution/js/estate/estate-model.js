var app = app || {};

app.estateModel = (function() {
    function EstateModel (baseUrl, requester, headers) {
        this.baseUrl = baseUrl;
        this.requester = requester;
        this.headers = headers;
    }

    EstateModel.prototype.getAllEstates = function() {
        var serviceUrl = this.baseUrl + 'classes/Estate/?include=category&keys=name,price,ACL,category.name';
        return this.requester.get(serviceUrl, this.headers.getHeaders());
    };

    EstateModel.prototype.filterEstates = function(minPrice, maxPrice, category) {
        var serviceUrl = this.baseUrl + 'classes/Estate/?include=category&keys=name,price,ACL,category.name';
        if(minPrice || maxPrice || category) {
            serviceUrl += '&where=';
            var objQuery = {};
           if(minPrice || maxPrice) {
                objQuery.price = {
                    $gte : minPrice,
                    $lte : maxPrice
                };
            }

            if(category) {
                objQuery.category = {
                    __type : 'Pointer',
                    className : 'Category',
                    objectId : category
                }
            }
            return this.requester.get(serviceUrl + JSON.stringify(objQuery), this.headers.getHeaders());
        }
    };

    EstateModel.prototype.getEstatesCategories = function() {
        var serviceUrl = this.baseUrl + 'classes/Category/';
        return this.requester.get(serviceUrl, this.headers.getHeaders());
    };

    EstateModel.prototype.getEstateCategoryByName = function(name) {
        var serviceUrl = this.baseUrl + 'classes/Category/?where={"name":"' + name + '"}';
        return this.requester.get(serviceUrl, this.headers.getHeaders());
    };

    EstateModel.prototype.addEstate = function(estate) {
        var serviceUrl = this.baseUrl + 'classes/Estate/';
        return this.requester.post(serviceUrl, this.headers.getHeaders(true), estate);
    };

    EstateModel.prototype.editEstate = function(estate, id) {
        var serviceUrl = this.baseUrl + 'classes/Estate/' + id;
        return this.requester.put(serviceUrl, this.headers.getHeaders(true), estate);
    };

    EstateModel.prototype.deleteEstate = function(estateId) {
        var serviceUrl = this.baseUrl + 'classes/Estate/' + estateId;
        return this.requester.delete(serviceUrl, this.headers.getHeaders(true));
    };

    return {
        load: function(baseUrl, requester, headers) {
            return new EstateModel(baseUrl, requester, headers);
        }
    }
}());