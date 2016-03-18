var app = app || {};

app.phoneViews = (function () {
    function showPhones(selector, data) {
        $.get('templates/phones.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);

            $('.edit').on('click', function () {
                var phoneId = $(this).parent().parent().attr('data-id');

                var phone = data.phones.filter(function (a) {
                    return a._id == phoneId;
                });

                if (phone.length) {
                    Sammy(function () {
                        this.trigger('show-edit-phone', phone[0]);
                    })
                }
            });
            $('.delete').on('click', function () {
                var phoneId = $(this).parent().parent().attr('data-id');

                var phone = data.phones.filter(function (a) {
                    return a._id == phoneId;
                });

                if (phone.length) {
                    Sammy(function () {
                        this.trigger('show-delete-phone', phone[0]);
                    })
                }
            })

            $('#addPhoneButton').click(function () {
                Sammy(function () {
                    this.trigger('show-add-phone');
                })
            })
        })
    }

    function showAddPhone(selector) {
        $.get('templates/add-phone.html', function (templ) {
            $(selector).html(templ);
            $('#addPhoneButton').on('click', function () {
                var person = $('#personName').val(),
                    number = $('#phoneNumber').val();

                Sammy(function () {
                    this.trigger('add-phone', {person: person, number: number});
                })
            })
        })
    }

    function showEditPhone(selector, data) {
        $.get('templates/edit-phone.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);
            $('#editPhoneButton').on('click', function() {
                var person = $('#personName').val(),
                    number = $('#phoneNumber').val(),
                    id = $(this).attr('data-id');

                Sammy(function () {
                    this.trigger('edit-phone', {person: person, number: number, _id:id});
                })
            })
        })
    }

    function showDeletePhone(selector, data) {
        $.get('templates/delete-phone.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);
            $('#deletePhoneButton').on('click', function() {
                var id = $(this).attr('data-id');

                Sammy(function () {
                    this.trigger('delete-phone', {_id:id});
                })
            })
        })
    }

    return {
        load: function () {
            return {
                showPhones: showPhones,
                showAddPhone: showAddPhone,
                showEditPhone: showEditPhone,
                showDeletePhone: showDeletePhone
            }
        }
    }
}());