'use strict';

angular.module('issueTrackingSystem.projects.allProjects', [
        'ngRoute',
        'issueTrackingSystem.users.authentication',
        'issueTrackingSystem.projects.service'])

    .controller('AllProjectsController', [
        '$scope',
        '$route',
        '$location',
        'projectService',
        function($scope, $route, $location, projectService) {
            $scope.filteredProjects = [];
            $scope.currentPage = 1;
            $scope.numPerPage = 8;
            $scope.maxSize = 5;
            $scope.projectsCount = 0;

            $scope.$watch("currentPage + numPerPage", function() {
                var prParams = {
                    pageSize: $scope.numPerPage,
                    pageNumber: $scope.currentPage
                };
                projectService.getProjectsPage(prParams)
                    .then(function (response) {
                        $scope.filteredProjects = response.data.Projects;
                        $scope.projectsCount = response.data.TotalCount;
                    }, function (error) {
                        console.log(error);
                    });

            });

            $scope.addProject = function () {
                $location.path("projects/add");
            };

            $scope.editProject = function (id) {
                $location.path("projects/" + id + '/edit');
            };

            $scope.openProject = function (id) {
                $location.path("projects/" + id);
            };

            $scope.addIssue = function (id) {
                $location.path("projects/" + id + '/add-issue');
            };
        }]);
