'use strict';

angular.module('issueTrackingSystem.projects.editProject', [
        'ngRoute',
        'issueTrackingSystem.users.authentication',
        'issueTrackingSystem.projects'])

    .controller('EditProjectController', [
        '$scope',
        '$location',
        '$route',
        'projectService',
        'authentication',
        function($scope, $location, $route, projectService , authentication) {
            $scope.contentLoaded = false;
            $scope.isAdmin = authentication.isAdmin();

            authentication.getAllUsers()
                .then(function (users) {
                    $scope.users = users.data.sort(function(a, b) {
                        return a.Username.localeCompare(b.Username);
                    });

                    $scope.projectData.Leader = $scope.users.filter(function (user) {
                        return user.Id === $scope.projectData.Lead.Id;
                    })[0];
                }, function (error) {
                    console.log(error);
                });

            projectService.getProjectById($route.current.params.id)
                .then(function (response) {
                    // redirecting to home if user is not project leader
                    if (response.data.Lead.Id !== authentication.getUserId() &&
                     !$scope.isAdmin) {
                        $location.path("/");
                    }

                    $scope.contentLoaded = true;

                    var labels = [],
                        priorities = [];

                    $scope.projectData = response.data;
                    $scope.projectData.Priorities.forEach(function (priority) {
                        labels.push(priority.Name)
                    });

                    $scope.projectData.Labels.forEach(function (label) {
                        priorities.push(label.Name)
                    });

                    $scope.projectData.Priorities = priorities.join(', ');
                    $scope.projectData.Labels = labels.join(', ');
                }, function (error) {
                    console.log(error);
                });

            $scope.editProject = function () {
                if (!validateData()) {
                    return;
                }

                var requestData = {
                    Id: $scope.projectData.Id,
                    Priorities: [],
                    Labels: [],
                    LeadId: $scope.projectData.Leader.Id,
                    Name: $scope.projectData.Name,
                    Description: $scope.projectData.Description
                };

                $scope.projectData.Labels.toString().split(",").forEach(function(l) {
                    if (l.trim()) {
                        requestData.Labels.push({ Name: l.trim() });
                    }
                });

                $scope.projectData.Priorities.toString().split(",").forEach(function(p) {
                    if (p.trim()) {
                        requestData.Priorities.push({ Name: p.trim() });
                    }
                });

                projectService.editProject(requestData)
                    .then(function (success) {
                        $location.path("projects/" + success.data.Id);
                    }, function (error) {
                        console.log(error);
                    })
            };

            function validateData() {
                var data = $scope.projectData || {};

                if (!data.Leader ||
                    !data.Labels ||
                    !data.ProjectKey ||
                    !data.Name ||
                    !data.Description ||
                    !data.Priorities) {
                    return false;
                }

                return true;
            }
        }]);