'use strict';

angular.module('issueTrackingSystem.labels.service', [])

    .factory('labelService', [
        '$http',
        '$q',
        'BASE_URL',
        function ($http, $q, BASE_URL) {
            function getLabels(filter) {
                var deferred = $q.defer();

                $http.get(BASE_URL + 'Labels/?filter=' + filter)
                    .then(function (success) {
                        deferred.resolve(success);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }

            return {
                getLabels: getLabels
            }
        }]);