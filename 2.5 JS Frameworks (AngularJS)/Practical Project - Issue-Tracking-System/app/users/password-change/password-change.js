'use strict';

angular.module('issueTrackingSystem.users.passwordChange', [
        'ngRoute',
        'issueTrackingSystem.users.authentication'])

    .controller('PasswordChangeController', [
        '$scope',
        '$location',
        'authentication',
        'toastr',
        function($scope, $location , authentication, toastr) {
            $scope.changePasswordData = {};

            $scope.changePassword = function () {
                var changePasswordData = $scope.changePasswordData;
                if (!validateData(changePasswordData)) {
                    return;
                }

                authentication.changePassword(changePasswordData)
                    .then(function () {
                        toastr.success('You have successfully changed your password.');
                        $location.path('/');
                    }, function (error) {
                        toastr.error('Old password is incorrect.');
                        console.log(error);
                    });
            };

            function validateData(changePasswordData) {
                if (!changePasswordData.OldPassword || !changePasswordData.NewPassword || !changePasswordData.ConfirmPassword) {
                    return false;
                } else if (changePasswordData.OldPassword.length < 6 ||
                    changePasswordData.NewPassword.length < 6 ||
                    changePasswordData.ConfirmPassword.length < 6) {
                    return false;
                } else if (changePasswordData.NewPassword !== changePasswordData.ConfirmPassword) {
                    toastr.error('New psswords do not match');
                    return false;
                } else if (changePasswordData.OldPassword === changePasswordData.NewPassword) {
                    toastr.error('Old password cannot be new password.');
                    return false;
                }

                return true;
            }
        }]);