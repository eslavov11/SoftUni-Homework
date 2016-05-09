'use strict';

angular.module('issueTrackingSystem.issues', [
        'ngRoute',
        'issueTrackingSystem.users.authentication',
        'issueTrackingSystem.issues.service'])

    .controller('IssueController', [
        '$scope',
        '$route',
        '$location',
        'issueService',
        'authentication',
        function($scope, $route, $location, issueService , authentication) {
            var issueId = $route.current.params.id;

            issueService.getIssueById(issueId)
                .then(function (response) {
                    $scope.isAssignee = response.data.Assignee.Username === authentication.getUsername();
                    $scope.isLeader = response.data.Author.Username === authentication.getUsername();

                    $scope.issue = response.data;

                    $scope.editIssue = function () {
                        $location.path("issues/" + $route.current.params.id + '/edit');
                    }
                }, function (error) {
                    console.log(error);
                });

            issueService.getIssueCommentsById(issueId)
                .then(function (response) {
                    $scope.comments = response.data;
                }, function (error) {
                    console.log(error);
                });

            $scope.addComment = function () {
                if (!$scope.commentText) {
                    return;
                }

                var comment = {
                    Text: $scope.commentText
                };

                issueService.addIssueComment(issueId, comment)
                    .then(function (response) {
                        $scope.comments = response.data;
                        $scope.commentText = '';
                    }, function (error) {
                        console.log(error);
                    });
            }
        }]);
