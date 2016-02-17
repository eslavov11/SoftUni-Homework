function processTravelAgencyCommands(commands) {
    'use strict';

    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    }

    var Models = (function() {
        var Destination = (function() {
            function Destination(location, landmark) {
                this.setLocation(location);
                this.setLandmark(landmark);
            }

            Destination.prototype.getLocation = function() {
                return this._location;
            }

            Destination.prototype.setLocation = function(location) {
                if (location === undefined || location === "") {
                    throw new Error("Location cannot be empty or undefined.");
                }
                this._location = location;
            }

            Destination.prototype.getLandmark = function() {
                return this._landmark;
            }

            Destination.prototype.setLandmark = function(landmark) {
                if (landmark === undefined || landmark == "") {
                    throw new Error("Landmark cannot be empty or undefined.");
                }
                this._landmark = landmark;
            }

            Destination.prototype.toString = function() {
                return this.constructor.name + ": " +
                    "location=" + this.getLocation() +
                    ",landmark=" + this.getLandmark();
            }

            return Destination;
        }());

        var Travel = (function() {
            function Travel(name, startDate, endDate, price) {
                if (this.constructor === Travel) {
                    throw new Error("Cannot create instance of Travel.");
                }
                this.setName(name);
                this.setStartDate(startDate);
                this.setEndDate(endDate);
                this.setPrice(price);
            }

            Travel.prototype.getName = function() {
                return this._name;
            }

            Travel.prototype.setName = function(name) {
                if (name === undefined || name === "") {
                    throw new Error("Name cannot be empty or undefined.");
                }
                this._name = name;
            }

            Travel.prototype.getStartDate = function() {
                return this._startDate;
            }

            Travel.prototype.setStartDate = function(startDate) {
                if (startDate === undefined || !(startDate instanceof Date)) {
                    throw new Error("Start date should be a non-empty date object.")
                }
                this._startDate = startDate;
            }

            Travel.prototype.getEndDate = function() {
                return this._endDate;
            }

            Travel.prototype.setEndDate = function(endDate) {
                if (endDate === undefined || !(endDate instanceof Date)) {
                    throw new Error("End date should be a non-empty date object.")
                }
                this._endDate = endDate;
            }

            Travel.prototype.getPrice = function() {
                return this._price;
            }

            Travel.prototype.setPrice = function(price) {
                if (price === undefined || isNaN(price) || price < 0) {
                    throw new Error("Price cannot be negative.");
                }
                this._price = price;
            }

            Travel.prototype.getTravelInfo = function() {
                return " * " + this.constructor.name + ": " +
                    "name=" + this.getName() +
                    ",start-date=" + formatDate(this.getStartDate()) +
                    ",end-date=" + formatDate(this.getEndDate()) +
                    ",price=" + this.getPrice().toFixed(2);
            }

            Travel.prototype.toString = function() {
                return this.getTravelInfo();
            }

            return Travel;
        }());

        var Excursion = (function() {
            Excursion.extends(Travel);

            function Excursion(name, startDate, endDate, price, transport) {
                Travel.apply(this, arguments);
                this.setTransport(transport);
                this._destinations = [];
            }

            Excursion.prototype.getTransport = function() {
                return this._transport;
            }

            Excursion.prototype.setTransport = function(transport) {
                if (transport === undefined || transport === "") {
                    throw new Error("Transport cannot be empty or undefined.");
                }
                this._transport = transport;
            }

            Excursion.prototype.getDestinations = function() {
                return this._destinations;
            }

            Excursion.prototype.addDestination = function(destination) {
                this.getDestinations().push(destination);
            }

            Excursion.prototype.removeDestination = function(destination) {
                var index = this.getDestinations().indexOf(destination);
                if (index !== -1) {
                    this.getDestinations().splice(index, 1);
                } else {
                    throw new Error("Travel does not contain such destination.");
                }
            }

            Excursion.prototype.getDestinationsInfo = function() {
                var destinationsInfo;
                destinationsInfo = " ** Destinations: " +
                    (this.getDestinations().length > 0 ? this.getDestinations().join(";") : "-");

                return destinationsInfo;
            }

            Excursion.prototype.toString = function() {
                return Travel.prototype.getTravelInfo.call(this) +
                    ",transport=" + this.getTransport() + "\n" + this.getDestinationsInfo();
            }

            return Excursion;
        }());

        var Vacation = (function() {
            Vacation.extends(Travel);

            function Vacation(name, startDate, endDate, price, location, accommodation) {
                Travel.apply(this, arguments);
                this.setLocation(location);
                this.setAccommodation(accommodation);
            }

            Vacation.prototype.getLocation = function() {
                return this._location;
            }

            Vacation.prototype.setLocation = function(location) {
                if (location === undefined || location === "") {
                    throw new Error("Location cannot be empty or undefined.");
                }
                this._location = location;
            }

            Vacation.prototype.getAccommodation = function() {
                return this._accommodation;
            }

            Vacation.prototype.setAccommodation = function(accommodation) {
                if (accommodation !== undefined && accommodation === "") {
                    throw new Error("Accommodation cannot be empty.");
                }
                this._accommodation = accommodation;
            }

            Vacation.prototype.toString = function() {
                return Travel.prototype.toString.call(this) +
                    ",location=" + this.getLocation() +
                    (this.getAccommodation() ? ",accommodation=" + this.getAccommodation() : "");
            }

            return Vacation;
        }());

        var Cruise = (function() {

            var CRUISE_TRANSPORT = "cruise liner";

            Cruise.extends(Excursion);

            function Cruise(name, startDate, endDate, price, transport, startDock) {
                Excursion.call(this, name, startDate, endDate, price, CRUISE_TRANSPORT, startDock);
                this.setStartDock(startDock);
            }

            Cruise.prototype.getStartDock = function() {
                return this._startDock;
            }

            Cruise.prototype.setStartDock = function(startDock) {
                if (startDock !== undefined && startDock === "") {
                    throw new Error("Start dock cannot be empty.");
                }
                this._startDock = startDock;
            }

            Cruise.prototype.toString = function() {
                return Excursion.prototype.toString.call(this) +
                    (this.getStartDock() ? ",start-dock=" + this.getStartDock() : "");
            }

            return Cruise;
        }());

        return {
            Destination: Destination,
            Travel: Travel,
            Excursion: Excursion,
            Vacation: Vacation,
            Cruise: Cruise
        }
    }());

    var TravellingManager = (function(){
        var _travels;
        var _destinations;

        function init() {
            _travels = [];
            _destinations = [];
        }

        var CommandProcessor = (function() {

            function processInsertCommand(command) {
                var object;

                switch (command["type"]) {
                    case "excursion":
                        object = new Models.Excursion(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["transport"]);
                        _travels.push(object);
                        break;
                    case "vacation":
                        object = new Models.Vacation(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["location"], command["accommodation"]);
                        _travels.push(object);
                        break;
                    case "cruise":
                        object = new Models.Cruise(command["name"], parseDate(command["start-date"]), parseDate(command["end-date"]),
                            parseFloat(command["price"]), command["start-dock"]);
                        _travels.push(object);
                        break;
                    case "destination":
                        object = new Models.Destination(command["location"], command["landmark"]);
                        _destinations.push(object);
                        break;
                    default:
                        throw new Error("Invalid type.");
                }

                return object.constructor.name + " created.";
            }

            function processDeleteCommand(command) {
                var object,
                    index,
                    destinations;

                switch (command["type"]) {
                    case "destination":
                        object = getDestinationByLocationAndLandmark(command["location"], command["landmark"]);
                        _travels.forEach(function(t) {
                            if (t instanceof Models.Excursion && t.getDestinations().indexOf(object) !== -1) {
                                t.removeDestination(object);
                            }
                        });
                        index = _destinations.indexOf(object);
                        _destinations.splice(index, 1);
                        break;
                    case "excursion":
                    case "vacation":
                    case "cruise":
                        object = getTravelByName(command["name"]);
                        index = _travels.indexOf(object);
                        _travels.splice(index, 1);
                        break;
                    default:
                        throw new Error("Unknown type.");
                }

                return object.constructor.name + " deleted.";
            }

            function processListCommand(command) {
                return formatTravelsQuery(_travels);
            }

            function processFilterInPriceRange(command) {
                var type = command["type"],
                    priceMin = parseFloat(command["price-min"]),
                    priceMax = parseFloat(command["price-max"]),
                    filteredByType,
                    filteredByPrice,
                    sortedByDateAsc;

                filteredByType = _travels
                    .filter(function(e) {
                        switch (type) {
                            case "excursion":
                                return e.constructor.name === "Excursion";
                            case "vacation":
                                return e.constructor.name === "Vacation";
                            case "cruise":
                                return e.constructor.name === "Cruise";
                            case "all":
                                return true;
                            default:
                                return false;
                        }
                    });

                filteredByPrice = filteredByType
                    .filter(function(e) {
                        return priceMin <= e.getPrice() && e.getPrice() <= priceMax;
                    });

                sortedByDateAsc = filteredByPrice
                    .sort(function(e1, e2) {
                        var dateOne = e1.getStartDate().valueOf(),
                            dateTwo = e2.getStartDate().valueOf();

                        if (dateOne === dateTwo) {
                            return e1.getName().localeCompare(e2.getName());
                        }
                        return dateOne - dateTwo;
                    });

                return formatTravelsQuery(sortedByDateAsc);
            }

            function processAddDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.addDestination(destination);

                return "Added destination to " + travel.getName() + ".";
            }

            function processRemoveDestinationCommand(command) {
                var destination = getDestinationByLocationAndLandmark(command["location"], command["landmark"]),
                    travel = getTravelByName(command["name"]);

                if (!(travel instanceof Models.Excursion)) {
                    throw new Error("Travel does not have destinations.");
                }
                travel.removeDestination(destination);

                return "Removed destination from " + travel.getName() + ".";
            }

            // Functions below are not revealed

            function getTravelByName(name) {
                var i;

                for (i = 0; i < _travels.length; i++) {
                    if (_travels[i].getName() === name) {
                        return _travels[i];
                    }
                }
                throw new Error("No travel with such name exists.");
            }

            function getDestinationByLocationAndLandmark(location, landmark) {
                var i;

                for (i = 0; i < _destinations.length; i++) {
                    if (_destinations[i].getLocation() === location
                        && _destinations[i].getLandmark() === landmark) {
                        return _destinations[i];
                    }
                }
                throw new Error("No destination with such location and landmark exists.");
            }

            function formatTravelsQuery(travels) {
                var queryString = "";

                if (travels.length > 0) {
                    queryString += travels.join("\n");
                } else {
                    queryString = "No results.";
                }

                return queryString;
            }

            return {
                processInsertCommand: processInsertCommand,
                processDeleteCommand: processDeleteCommand,
                processListCommand: processListCommand,
                processFilterTravelsCommand: processFilterInPriceRange,
                processAddDestinationCommand: processAddDestinationCommand,
                processRemoveDestinationCommand: processRemoveDestinationCommand
            }
        }());

        var Command = (function() {
            function Command(cmdLine) {
                this._cmdArgs = processCommand(cmdLine);
            }

            function processCommand(cmdLine) {
                var parameters = [],
                    matches = [],
                    pattern = /(.+?)=(.+?)[;)]/g,
                    key,
                    value,
                    split;

                split = cmdLine.split("(");
                parameters["command"] = split[0];
                while ((matches = pattern.exec(split[1])) !== null) {
                    key = matches[1];
                    value = matches[2];
                    parameters[key] = value;
                }

                return parameters;
            }

            return Command;
        }());

        function executeCommands(cmds) {
            var commandArgs = new Command(cmds)._cmdArgs,
                action = commandArgs["command"],
                output;

            switch (action) {
                case "insert":
                    output = CommandProcessor.processInsertCommand(commandArgs);
                    break;
                case "delete":
                    output = CommandProcessor.processDeleteCommand(commandArgs);
                    break;
                case "add-destination":
                    output = CommandProcessor.processAddDestinationCommand(commandArgs);
                    break;
                case "remove-destination":
                    output = CommandProcessor.processRemoveDestinationCommand(commandArgs);
                    break;
                case "list":
                    output = CommandProcessor.processListCommand(commandArgs);
                    break;
                case "filter":
                    output = CommandProcessor.processFilterTravelsCommand(commandArgs);
                    break;
                default:
                    throw new Error("Unsupported command.");
            }

            return output;
        }

        return {
            init: init,
            executeCommands: executeCommands
        }
    }());

    var parseDate = function (dateStr) {
        if (!dateStr) {
            return undefined;
        }
        var date = new Date(Date.parse(dateStr.replace(/-/g, ' ')));
        var dateFormatted = formatDate(date);
        if (dateStr != dateFormatted) {
            throw new Error("Invalid date: " + dateStr);
        }
        return date;
    }

    var formatDate = function (date) {
        var day = date.getDate();
        var monthName = date.toString().split(' ')[1];
        var year = date.getFullYear();
        return day + '-' + monthName + '-' + year;
    }

    var output = "";
    TravellingManager.init();

    commands.forEach(function(cmd) {
        var result;
        if (cmd != "") {
            try {
                result = TravellingManager.executeCommands(cmd) + "\n";
            } catch (e) {
                result = "Invalid command." + "\n";
            }
            output += result;
        }
    });

    return output;
}

// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

(function() {
    var arr = [];
    if (typeof (require) == 'function') {
        // We are in node.js --> read the console input and process it
        require('readline').createInterface({
            input: process.stdin,
            output: process.stdout
        }).on('line', function(line) {
            arr.push(line);
        }).on('close', function() {
            console.log(processTravelAgencyCommands(arr));
        });
    }
})();