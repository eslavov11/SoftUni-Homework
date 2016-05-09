'use strict';

angular.module('issueTrackingSystem.users.logout', [
        'issueTrackingSystem.users.authentication'])

    .controller('LogoutController', [
        '$scope',
        '$location',
        'authentication',
        'toastr',
        function($scope, $location, authentication, toastr) {
            authentication.logoutUser()
                .then(function () {
                    window.location.reload();
                }, function (error) {
                    toastr.error('Error logging out');
                    console.log(error);
                });
        }]);