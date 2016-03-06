var head = 'Basic cGVzaDoxMjM0';

function listCountries() {
    console.log(head);
    $.ajax({
        type: "GET",
        url: "https://baas.kinvey.com/appdata/kid_b186PIixy-/country",
        headers: {"Authorization": head},
        success: function (countryData) { // handle success
            //console.log(countryData);
            appendCountries(countryData);
        },
        error: function (err) {
        }
    });
}

listCountries();

function getTowns(countryId, countryName) {
    $.ajax({
        type: "GET",
        url: "https://baas.kinvey.com/appdata/kid_b186PIixy-/town",
        headers: {"Authorization": head},
        success: function (towns) {
            var filteredTowns = towns.filter(function(town) {
                return town.country._id == countryId;
            });

            appendTowns(countryId, countryName, filteredTowns);
        },
        error: function (err) {
            console.log(err);
        }
    });
}

function appendCountries(countryData) {
    $('#countryWrapper').text('');

    var countryWrapper = $('<div>').attr('id', 'countryWrapper').css('margin', '0 auto').css('width', '350px'),
        h1 = $('<h1>').text('Countries'),
        ul = $('<ul>'),
        addNewItem = $('<span>').text('add new country').css('color', 'blue').css('cursor', 'pointer').click(function () {
            addNew('country');
        });

    countryData.forEach(function (country) {
        var edit = $('<span>').text('edit').css('color', 'blue').css('cursor', 'pointer'),
            del = $('<span>').text('delete').css('color','blue').css('cursor', 'pointer'),
            listTowns = $('<span>').text('list towns').css('color','blue').css('cursor', 'pointer'),
            li = $('<li>');

        li.append(country.name + ' ').append(edit).append(' | ').append(del).append(' | ').append(listTowns);
        del.click(function() {deleteFromCollection('country', country._id)});
        edit.click(function() {editCollection('country', country._id, country.name)});
        listTowns.click(function () {getTowns(country._id, country.name)});

        ul.append(li);
    });

    countryWrapper.append(h1);
    countryWrapper.append(addNewItem);
    countryWrapper.append(ul);

    $('body').prepend(countryWrapper);
}

function appendTowns(countryId, countryName, townsOfCountry) {
    $('#townWrapper').text('');

    var townWrapper = $('<div>').attr('id', 'townWrapper').css('margin', '0 auto').css('width', '350px'),
        h2 = $('<h2>').text('Towns of ' + countryName),
        ul = $('<ul>'),
        addNewItem = $('<span>').text('add new town').css('color', 'blue').css('cursor', 'pointer').click(function () {
            addNewTown('town', countryId, countryName);
        });

    townsOfCountry.forEach(function (town) {
        var edit = $('<span>').text('edit').css('color', 'blue').css('cursor', 'pointer'),
            del = $('<span>').text('delete').css('color','blue').css('cursor', 'pointer'),
            li = $('<li>').attr('id', town.name);

        li.append(town.name + ' ').append(edit).append(' | ').append(del);
        del.click(function() {
           $('#' + town.name).css('display', 'none');
            deleteFromCollection('town', town._id)
        });
        edit.click(function() {editTown('town', town._id, town.name, countryName, countryId)});

        ul.append(li);
    });

    townWrapper.append('<hr>');
    townWrapper.append(h2);
    townWrapper.append(addNewItem);
    townWrapper.append(ul);

    $(townWrapper).insertAfter('#countryWrapper');
}

function addNew(collection) {
    var name = prompt('Enter ' + collection + ' name:');

    if (!name || name == '') {
        alert(collection + ' name cannot be null or empty.');
        return;
    }

    $.ajax({
        type: "POST",
        url: "https://baas.kinvey.com/appdata/kid_b186PIixy-/" + collection,
        headers: {"Authorization": head},
        data:{"name": name},
        success: function() { // handle success
            listCountries();
        },
        error: function(err) {
            alert('Error! ' + collection + ' cannot be added.');
        }
    });
}

function addNewTown(collection, countryId, countryName) {
    var name = prompt('Enter ' + collection + ' name:'),
        countryData = {"_type":"KinveyRef","_id":countryId,"_collection":"country"};

    if (!name || name == '') {
        alert(collection + ' name cannot be null or empty.');
        return;
    }

    $.ajax({
        type: "POST",
        url: "https://baas.kinvey.com/appdata/kid_b186PIixy-/" + collection,
        headers: {"Authorization": head},
        data:{"name": name, "country": countryData},
        success: function() { // handle success
            getTowns(countryId, countryName);
        },
        error: function(err) {
            alert('Error! ' + collection +' cannot be added.');
        }
    });
}

function deleteFromCollection(collection, id) {
    $.ajax({
        type: "DELETE",
        url: "https://baas.kinvey.com/appdata/kid_b186PIixy-/" + collection + "/" + id,
        headers: {"Authorization": head},
        success: function() { // handle success
           listCountries();
        },
        error: function(err) {
            alert('You don\'t have permissions to delete this ' + collection);
        }
    });
}

function editCollection(collection, id, currentName) {
    var name = prompt('Enter new ' + collection + ' name:', currentName);

    if (!name || name == '') {
        alert(collection + ' name cannot be null or empty.');
        return;
    }

    $.ajax({
        type: "PUT",
        url: "https://baas.kinvey.com/appdata/kid_b186PIixy-/" + collection + "/" + id,
        headers: {"Authorization": head},
        data:{"name": name},
        success: function() { // handle success
            listCountries();
        },
        error: function() {
            alert('You don\'t have permissions to edit this ' +  collection);
        }
    });
}

function editTown(collection, id, currentName, countryName, countryId) {
    var name = prompt('Enter new ' + collection + ' name:', currentName),
        countryData = {"_type":"KinveyRef", "_id":countryId, "_collection":"country"};;

    if (!name || name == '') {
        alert(collection + ' name cannot be null or empty.');
        return;
    }

    $.ajax({
        type: "PUT",
        url: "https://baas.kinvey.com/appdata/kid_b186PIixy-/" + collection + "/" + id,
        headers: {"Authorization": head},
        data:{"name": name, "country": countryData},
        success: function() { // handle success
            getTowns(countryId, countryName);
        },
        error: function() {
            alert('You don\'t have permissions to edit this ' +  collection);
        }
    });
}