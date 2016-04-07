'use strict';

angular.module('videoSystem.home', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/home', {
            templateUrl: 'app/home/home.html',
            controller: 'HomeController'
        });
    }])

    .controller('HomeController', ['$scope', 'dataService', function ($scope, dataService) {
        $scope.videos = dataService.getAllVideos();
        console.log($scope.videos);
    }]);