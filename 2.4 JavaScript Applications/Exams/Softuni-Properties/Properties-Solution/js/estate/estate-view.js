var app = app || {};

app.estateViews = (function() {
    function EstateViews() {
        this.listEstatesView = {
            load : loadEstates
        };
        this.addEsateView = {
            load : loadAddEstate
        };
        this.editEstateView = {
            load : loadEditEstate
        };
        this.deleteEstateView = {
            load : loadDeleteEstate
        };
    }

    function loadEstates (selector, data) {
        $.get('templates/list-estate.html', function(template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        }).then(function() {
            $('.edit-button').click(function () {
                var data = getElementData(this);

                $.sammy(function () {
                    this.trigger('showEditEstate', data);
                });

                return false;
            });

            $('.delete-button').click(function () {
                var data = getElementData(this);

                $.sammy(function() {
                    this.trigger('showDeleteEstate', data);
                });

                return false;
            });

            $('#filter').click(function() {
                var name = $('#search-bar').val();
                var minPrice = $('#min-price').val();
                var maxPrice = $('#max-price').val();
                var category = $('#category').val();

                $.sammy(function() {
                    this.trigger('filter', {name : name, minPrice : minPrice, maxPrice : maxPrice, category : category})
                })
            })
        })
    }

    function loadAddEstate (selector,data) {
        $.get('templates/add-estate.html', function(template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        }).then(function() {
            $('#add-estate-button').click(function() {
                var name = $('#name').val();
                var price = $('#price').val();
                var category = $('#category').val();

                $.sammy(function() {
                    this.trigger('add', {name : name, price: price, category : category});
                })
            })
        }).done();
    }

    function loadEditEstate(selector, data) {
        $.get('templates/edit-estate.html', function(template) {
            var outHtml =  Mustache.render(template, data);
            $(selector).html(outHtml);
        }).then(function() {
            $('#edit-estate-button').click(function() {
                var name = $('#item-name').val();
                var price = $('#price').val();
                var id = $(this).attr('data-id');

                $.sammy(function() {
                    this.trigger('editEstate', {name : name, price : price, objectId : id})
                })
            })
        })
    }

    function loadDeleteEstate(selector, data) {
        $.get('templates/delete-estate.html', function(template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        }).then(function() {
            $('#delete-estate-button').click(function() {
                var id = $(this).attr('data-id');

                $.sammy(function() {
                    this.trigger('deleteEstate', {objectId : id})
                })
            })
        })
    }

    function getElementData(element) {
        var name = $($(element).parent().parent().parent().children()[0]).find('.item-name').text();
        var category = $($($(element).parent().parent().parent().children()[0]).find('.category').children()[1]).text();
        var price = $($($(element).parent().parent().parent().children()[0]).find('.price').children()[1]).text();
        var id = $(element).parent().parent().parent().attr('data-id');

        return {name:name, category:category, price:Number(price), objectId:id};
    }

    return {
        load: function() {
            return new EstateViews();
        }
    }
}());