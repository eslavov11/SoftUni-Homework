'use strict';

angular.module('issueTrackingSystem.home', [
    'ngRoute',
    'issueTrackingSystem.users.authentication'])

    .controller('HomeController', [
        '$scope',
        '$window',
        'authentication',
        'toastr',
        function($scope, $window , authentication, toastr) {
            if (localStorage.userIsLoggingOut) {
                toastr.info('Successfully logged out.');
                delete localStorage.userIsLoggingOut;
            }

            $scope.user = {};
            $scope.userReg = {};

            $scope.logUser = function () {
                var user = $scope.user;

                if (!user.username ||  !user.password || user.password.toString().length < 6) {
                    return;
                }

                authentication.loginUser(user)
                    .then(function (loggedUser) {
                        localStorage.userIsLogging = true;
                        window.location.reload();
                    }, function (error) {
                        console.log(error);
                    });
            };

            $scope.registerUser = function () {
                var userReg = $scope.userReg;

                if (!userReg.email ||
                    !userReg.password ||
                    !userReg.confirmPassword ||
                    userReg.password.toString().length < 6 ||
                    userReg.confirmPassword.toString().length < 6) {
                    return;
                } else if (userReg.password.toString() !== userReg.confirmPassword.toString()) {
                    toastr.error('Passwords do not match. Try again.');
                    return;
                }

                authentication.registerUser(userReg)
                    .then(function () {
                        var user = {
                            username: userReg.email,
                            password: userReg.password
                        };

                        authentication.loginUser(user)
                            .then(function () {
                                localStorage.userIsRegistrating = true;
                                window.location.reload();
                            });
                    }, function (error) {
                        alert('Register error' + error);
                        console.log(error);
                    });
            };
    }]);