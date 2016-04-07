'use strict';

angular.module('videoSystem.addVideo', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/addVideo', {
            templateUrl: 'app/addVideo/add-video.html',
            controller: 'AddVideoController'
        });
    }])

    .directive('required', function () {
        return {
            restrict: 'A',
            compile: function (element) {
                element.after("<span class='required'>*</span>")
            }
        }
    })

    .controller('AddVideoController', ['$scope', 'dataService', '$window', function ($scope, dataService, $window) {
        $scope.addVideo = function(video) {
            dataService.addVideo(video);
            $window.location.href = '#/home';
        };
    }]);