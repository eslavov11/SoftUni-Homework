'use strict';

angular.module('issueTrackingSystem.projects', [
        'ngRoute',
        'issueTrackingSystem.users.authentication',
        'issueTrackingSystem.projects.service'])

    .controller('ProjectController', [
        '$scope',
        '$route',
        '$location',
        'projectService',
        'issueService',
        'authentication',
        function($scope, $route, $location, projectService, issueService, authentication) {
            var projectId = $route.current.params.id;

            projectService.getProjectById(projectId)
                .then(function (project) {
                    $scope.isLeader = project.data.Lead.Username === authentication.getUsername();
                    $scope.isAdmin = authentication.isAdmin();

                    $scope.project = project.data;
                    $scope.prioritiesString = $scope.project.Priorities.map(function(pr){
                        return pr.Name;
                    }).join(", ");

                    $scope.labelsString = $scope.project.Labels.map(function(lbl){
                        return lbl.Name;
                    }).join(", ");

                    $scope.editProject = function () {
                        $location.path("projects/" + $route.current.params.id + '/edit');
                    };

                    $scope.addIssue = function () {
                        $location.path("projects/" + $route.current.params.id + '/add-issue');
                    };
                }, function (error) {
                    console.log(error);
                });

            $scope.filteredIssues = [];
            $scope.currentPage = 1;
            $scope.numPerPage = 5;
            $scope.maxSize = 2;
            $scope.issuesCount = 0;
            $scope.issueTypes = [
                {
                    type: 'My issues',
                    filter: 'Project.Id == ' + projectId + ' and Assignee.Username == \"' + authentication.getUsername() + '\"'
                },
                {
                    type: 'Opened issues',
                    filter: 'Project.Id == ' + projectId + ' and Status.Name == \"Open\"'
                },
                {
                    type: 'In progress',
                    filter: 'Project.Id == ' + projectId + ' and Status.Name == \"InProgress\"'
                },
                {
                    type: 'Closed issues',
                    filter: 'Project.Id == ' + projectId + ' and Status.Name == \"Closed\"'
                },
                {
                    type: 'All issues',
                    filter: 'Project.Id == ' + projectId
                }
            ];
            $scope.selectedIssueType = $scope.issueTypes[0];

            $scope.issuesParams = {
                pageSize: $scope.numPerPage,
                pageNumber: $scope.currentPage,
                filter: $scope.selectedIssueType.filter
            };

            $scope.updateIssues = function () {
                $scope.filteredIssues = [];
                $scope.issuesParams.filter = $scope.selectedIssueType.filter;
                $scope.issuesParams.pageNumber = $scope.currentPage;

                issueService.getIssuesByFilter($scope.issuesParams)
                    .then(function (response) {
                        $scope.filteredIssues = response.data.Issues;
                        $scope.issuesCount = response.data.TotalCount;
                    }, function (error) {
                        console.log(error);
                    })
            };

            $scope.$watch("currentPage + numPerPage", function() {
                $scope.updateIssues();
            });
        }]);