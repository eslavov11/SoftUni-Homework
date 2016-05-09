'use strict';

angular.module('issueTrackingSystem.issues.addIssue', [
        'ngRoute',
        'issueTrackingSystem.users.authentication',
        'issueTrackingSystem.projects.service',
        'issueTrackingSystem.issues.service',
        'issueTrackingSystem.labels.service'])

    .controller('AddIssueController', [
        '$scope',
        '$location',
        'authentication',
        'projectService',
        'issueService',
        'labelService',
        'toastr',
        function($scope, $location, authentication, projectService, issueService, labelService, toastr) {
            authentication.getAllUsers()
                .then(function (users) {
                    $scope.users = users.data.sort(function(a, b) {
                        return a.Username.localeCompare(b.Username);
                    });
                }, function (error) {
                    console.log(error);
                });

            projectService.getAllProjects()
                .then(function (projects) {
                    $scope.projects = projects.data.sort(function(a, b) {
                        return a.Name.localeCompare(b.Name);
                    });
                }, function (error) {
                    console.log(error);
                });

            $scope.addNewIssue = function () {
                if (!validateData()) {
                    return;
                }

                var assignee = $scope.users.filter(function (user) {
                    return user.Username === $scope.issueData.Assignee;
                })[0];


                var requestData = {
                    PriorityId: $scope.issueData.Priority.Id,
                    Labels: [],
                    DueDate: new Date($scope.issueData.Due).toISOString().slice(0,10),
                    AssigneeId: assignee.Id,
                    ProjectId: $scope.issueData.Project.Id,
                    Title: $scope.issueData.Title,
                    Description: $scope.issueData.Description
                };

                $scope.issueData.LabelsText.split(",").forEach(function(l) {
                    if (l.trim()) {
                        requestData.Labels.push({ Name: l.trim() });
                    }
                });

                issueService.addIssue(requestData)
                    .then(function (success) {
                        console.log(success);
                        $location.path("issues/" + success.data.Id);
                    }, function (error) {
                        console.log(error);
                    })
            };

            $scope.getLabels = function() {
                var stringFilter = $scope.issueData.LabelsText;
                if (stringFilter) {
                    var allFilters = stringFilter.split(',');
                    var lastFilter = allFilters[allFilters.length - 1].trim();

                    if (lastFilter.length >= 2) {
                        labelService.getLabels(lastFilter)
                            .then(function success(response) {
                                $scope.labels = response.data;
                            }, function error(err) {
                                console.log(error);
                                //notifyService.showError("Failed loading data...", err);
                            });
                    } else {
                        $scope.labels = [];
                    }
                }
            };

            $scope.addLabel = function (label) {
                var lastComma = $scope.issueData.LabelsText.lastIndexOf(',');
                if (lastComma !== -1) {
                    $scope.issueData.LabelsText = $scope.issueData.LabelsText.slice(0, lastComma) + ', ';
                } else {
                    $scope.issueData.LabelsText = '';
                }

                $scope.issueData.LabelsText += label.Name + ', ';
                $scope.labels = [];

                $scope.labelSelected = true;
            };

            $scope.getUsersByFilter = function() {
                var stringFilter = $scope.issueData.Assignee;
                if (stringFilter) {
                    if (stringFilter.length >= 2) {
                        authentication.getUsersByFilter(stringFilter)
                            .then(function success(response) {
                                $scope.filteredUsers = response.data;
                            }, function error(err) {
                                console.log(err);
                                //notifyService.showError("Failed loading data...", err);
                            });
                    } else {
                        $scope.filteredUsers = [];
                    }
                }
            };

            $scope.setAssignee = function (assignee) {
                $scope.issueData.Assignee = assignee.Username;
                $scope.filteredUsers = [];

                $scope.userSelected = true;
            };

            function validateData() {
                var data = $scope.issueData || {};

                if (!data.Project) {
                    toastr.error('Please select a project');
                    return false;
                } else if (!data.Priority) {
                    toastr.error('Please select priority');
                    return false;
                } else if (!data.Assignee ||
                    !data.LabelsText ||
                    !data.Due ||
                    !data.Title ||
                    !data.Description) {
                    return false;
                }

                return true;
            }
        }]);