var app = app || {};

app.estateController = (function() {
    function EstateController(model, viewBag) {
        this.model = model;
        this.viewBag = viewBag;
    }

    EstateController.prototype.listEstates = function (selector) {
        var _this = this;

        this.model.getAllEstates()
            .then(function(estatesData) {
                var renderData = {
                    estates : [],
                    categories: []
                };

                estatesData.results.forEach(function(es) {
                    if(es.ACL[sessionStorage['userId']]) {
                        var ownedEstate = es;
                        ownedEstate.owned = true;

                        renderData.estates.push(ownedEstate);
                    }else {
                        renderData.estates.push(es);
                    }
                });

                _this.model.getEstatesCategories()
                    .then(function(categoriesData) {
                        renderData.categories = categoriesData.results;

                        _this.viewBag.listEstatesView.load(selector, renderData);
                    }, function(error) {
                        console.log(error);
                    })
            }, function(error) {
                console.log(error);
            })
    };

    EstateController.prototype.filterEstates = function (selector, data) {
        var _this = this;
        var category = null;
        var categories;

        this.model.getEstatesCategories()
            .then(function(catData) {
                categories = catData.results;

                if(data.category !== 'All') {
                    category = categories.filter(function(c) { return c.name == data.category;})[0].objectId;
                }

                _this.model.filterEstates(Number(data.minPrice), Number(data.maxPrice), category)
                    .then(function(estatesData) {
                        var renderData = {
                            estates : [],
                            categories: categories
                        };

                        estatesData.results
                            .filter(function(es) {
                                return es.name.toLowerCase().indexOf(data.name.toLowerCase()) !== -1;
                            }).forEach(function(es) {
                                if(es.ACL[sessionStorage['userId']]) {
                                    var ownedEstate = es;
                                    ownedEstate.owned = true;

                                    renderData.estates.push(ownedEstate);
                                }else {
                                    renderData.estates.push(es);
                                }
                            });

                        _this.viewBag.listEstatesView.load(selector, renderData);
                    });
            });
    };

    EstateController.prototype.showAddPage = function(selector) {
        var _this = this;
        this.model.getEstatesCategories()
            .then(function(data) {
                _this.viewBag.addEsateView.load(selector, {categories:data.results});
            })
            .done();
    };

    EstateController.prototype.showEditPage = function(selector, data) {
        var renderData = {
            name : data.name,
            price : data.price,
            category : data.category,
            objectId : data.objectId
        };

        this.viewBag.editEstateView.load(selector, renderData);
    };

    EstateController.prototype.showDeletePage = function(selector, data) {
        var renderData = {
            name : data.name,
            price : data.price,
            category : data.category,
            objectId : data.objectId
        };

        this.viewBag.deleteEstateView.load(selector, renderData);
    };

    EstateController.prototype.addEstate = function(data) {
        var _this = this;
        var promise = Q.defer();
        this.model.getEstateCategoryByName(data.category)
            .then(function(catData) {
                var estate = {
                    name : data.name,
                    price : Number(data.price),
                    category: {
                        __type : 'Pointer',
                        className : 'Category',
                        objectId : catData.results[0].objectId
                    },
                    ACL : {
                        '*' : {
                            'read' : true
                        }
                    }
                };

                estate.ACL[sessionStorage['userId']] = {
                    'read' : true,
                    'write' :true
                };

                _this.model.addEstate(estate)
                    .then(function(data) {
                        promise.resolve(data);
                    }, function(error) {
                        promise.reject(error);
                    })
            });
        return promise.promise;
    };

    EstateController.prototype.editEstate = function(data) {
        var promise = Q.defer();
        var id = data.objectId;
        var estate = {
            name : data.name,
            price : Number(data.price)
        };

        this.model.editEstate(estate, id)
            .then(function(data) {
                promise.resolve(data);
            },function() {
                promise.reject();
            });

        return promise.promise;
    };

    EstateController.prototype.deleteEstate = function(data) {
        var promise = Q.defer();

        this.model.deleteEstate(data.objectId)
            .then(function(data) {
                promise.resolve(data);
            }, function() {
                promise.reject();
            });

        return promise.promise;
    };

    return {
        load : function(model, viewBag) {
            return new EstateController(model, viewBag);
        }
    }
}());