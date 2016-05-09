'use strict';

angular.module('issueTrackingSystem.issues.editIssue', [
        'ngRoute',
        'issueTrackingSystem.users.authentication',
        'issueTrackingSystem.projects.service',
        'issueTrackingSystem.issues.service'])

    .controller('EditIssueController', [
        '$scope',
        '$location',
        '$route',
        'projectService',
        'issueService',
        'authentication',
        'toastr',
        function($scope, $location, $route, projectService, issueService, authentication, toastr) {
            $scope.contentLoaded = false;

            issueService.getIssueById($route.current.params.id)
                .then(function (response) {
                    // redirecting to home if user is not lead or assignee
                    if (response.data.Author.Id !== authentication.getUserId() &&
                        response.data.Assignee.Id !== authentication.getUserId()) {
                        $location.path("/");
                    }

                    $scope.contentLoaded = true;

                    $scope.issueData = response.data;

                    getUsers();

                    renderContent();
                }, function (error) {
                    console.log(error);
                });

            function getUsers() {
                authentication.getAllUsers()
                    .then(function (users) {
                        $scope.users = users.data.sort(function(a, b) {
                            return a.Username.localeCompare(b.Username);
                        });

                        $scope.issueData.Assignee = $scope.users.filter(function (user) {
                            return user.Id === $scope.issueData.Assignee.Id;
                        })[0];

                        getProjects();

                    }, function (error) {
                        console.log(error);
                    });
            }

            function getProjects() {
                projectService.getAllProjects()
                    .then(function (projects) {
                        $scope.projects = projects.data.sort(function(a, b) {
                            return a.Name.localeCompare(b.Name);
                        });

                        $scope.issueData.Project = $scope.projects.filter(function (p) {
                            return p.Id === $scope.issueData.Project.Id;
                        })[0];

                        $scope.issueData.Priority = $scope.issueData.Project.Priorities[0];
                    }, function (error) {
                        console.log(error);
                    });
            }

            function renderContent() {
                $scope.isProjectLead = $scope.issueData.Author.Id === authentication.getUserId();

                var labels = [];

                $scope.issueData.Labels.forEach(function (label) {
                    labels.push(label.Name)
                });
                $scope.issueData.Labels = labels.join(', ');
                $scope.issueData.DueDate = new Date($scope.issueData.DueDate.slice(0,10));

                $scope.editIssue = function () {
                    if (!validateData()) {
                        return;
                    }

                    var requestData = {
                        Id: $scope.issueData.Id,
                        PriorityId: $scope.issueData.Priority.Id,
                        Labels: [],
                        DueDate: new Date($scope.issueData.DueDate).toISOString().slice(0,10),
                        AssigneeId: $scope.issueData.Assignee.Id,
                        ProjectId: $scope.issueData.Project.Id,
                        Title: $scope.issueData.Title,
                        Description: $scope.issueData.Description
                    };

                    $scope.issueData.Labels.toString().split(",").forEach(function(l) {
                        if (l.trim()) {
                            requestData.Labels.push({ Name: l.trim() });
                        }
                    });

                    issueService.editIssue(requestData)
                        .then(function (success) {
                            $location.path("issues/" + success.data.Id);
                        }, function (error) {
                            console.log(error);
                        })
                };
                
                $scope.changeStatus = function (statusId) {
                    issueService.editIssueStatus($scope.issueData.Id,statusId)
                        .then(function () {
                            toastr.info('Status changed');
                            $route.reload();
                        }, function (error) {
                            toastr.error('Error changing status');
                            console.log(error);
                        })
                }
            }

            function validateData() {
                var data = $scope.issueData || {};
                if (!data.Assignee ||
                    !data.Labels ||
                    !data.Project ||
                    !data.DueDate ||
                    !data.Priority ||
                    !data.Title ||
                    !data.Description) {
                    return false;
                }

                return true;
            }
        }]);