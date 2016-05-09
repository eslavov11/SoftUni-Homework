'use strict';

angular.module('issueTrackingSystem.dashboard', [
        'ngRoute',
        'issueTrackingSystem.users.authentication',
        'issueTrackingSystem.issues.service',
        'issueTrackingSystem.projects.service'])

    .controller('DashboardController', [
        '$scope',
        '$location',
        'authentication',
        'issueService',
        'projectService',
        'toastr',
        function($scope, $location, authentication, issueService, projectService, toastr) {
            if (localStorage.userIsRegistrating) {
                toastr.success('Registered successfully.');
                delete localStorage.userIsRegistrating;
            } else if (localStorage.userIsLogging) {
                toastr.info('Successfully logged in.');
                delete localStorage.userIsLogging;
            }

            $scope.username = localStorage.username;
            $scope.isAdmin = authentication.isAdmin();

            $scope.predicate = 'DueDate';
            $scope.reverse = true;
            $scope.order = function (predicate) {
                $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : false;
                $scope.predicate = predicate;
            };

            $scope.addNewProject = function() {
                $location.path("/projects/add");
            };

            $scope.listAllProjects = function() {
                $location.path("/projects");
            };

            $scope.editIssue = function (id) {
                $location.path("issues/" + id + '/edit');
            };

            $scope.openIssue = function (id) {
                $location.path("issues/" + id);
            };

            var projectsParams = {
                leadId: authentication.getUserId()
            };

            projectService.getProjectsForUser(projectsParams)
                .then(function (response) {
                    $scope.projects = response.data.Projects;
                }, function (error) {
                    console.log(error);
                });

            function checkForDuplicates(name, array) {
                var found = false;
                for(var i = 0; i < array.length; i++) {
                    if (array[i].Name === name) {
                        found = true;
                        break;
                    }
                }

                return found;
            }

            $scope.filteredIssues = [];
            $scope.currentPage = 1;
            $scope.numPerPage = 8;
            $scope.maxSize = 5;
            $scope.issuesCount = 0;
            $scope.$watch("currentPage + numPerPage", function() {
                var isParams = {
                    pageSize: $scope.numPerPage,
                    pageNumber: $scope.currentPage,
                    orderBy: 'DueDate desc'
                };
                issueService.getUserIssues(isParams)
                    .then(function (response) {
                        $scope.filteredIssues = response.data.Issues;
                        $scope.issuesCount = response.data.TotalCount;

                        var issueProjects = [];
                        response.data.Issues.forEach(function (issue) {
                            if (!checkForDuplicates(issue.Project.Name, issueProjects)) {
                                issueProjects.push(issue.Project);
                            }
                        });

                        $scope.issueProjects = issueProjects;
                    }, function (error) {
                        console.log(error);
                    })
            });
        }]);