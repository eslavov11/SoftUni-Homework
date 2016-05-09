'use strict';

angular.module('issueTrackingSystem.navbar', [
        'issueTrackingSystem.users.authentication'])

    .controller('NavbarController', [
        '$scope',
        '$window',
        'authentication',
        function($scope, $window, authentication) {
            $scope.show = authentication.isLoggedIn();
            $scope.username = authentication.getUsername();
            $scope.isAdmin = authentication.isAdmin();
            $scope.showMinMenu = false;
        }]);