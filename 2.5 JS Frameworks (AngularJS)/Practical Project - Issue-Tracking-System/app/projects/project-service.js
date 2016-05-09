'use strict';

angular.module('issueTrackingSystem.projects.service', [])
    .factory('projectService', [
        '$http',
        '$q',
        'BASE_URL',
        function ($http, $q, BASE_URL) {
            function getProjectById(id) {
                var deferred = $q.defer();

                $http.get(BASE_URL + 'Projects/' + id)
                    .then(function (success) {
                        deferred.resolve(success);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }

            function getProjectsForUser(params) {
                var deferred = $q.defer();

                $http.get(BASE_URL +
                    'Projects/?filter=Lead.Id=\"' +
                    params.leadId +
                    '\"&pageSize=1000' +
                    '&pageNumber=1')
                    .then(function (success) {
                        deferred.resolve(success);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }

            function getAllProjects() {
                var deferred = $q.defer();

                $http.get(BASE_URL + 'Projects/')
                    .then(function (success) {
                        deferred.resolve(success);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }

            function getProjectsPage(params) {
                var deferred = $q.defer();

                $http.get(BASE_URL +
                        'Projects/?filter=&pageSize=' +
                        params.pageSize +
                        '&pageNumber=' +
                        params.pageNumber)
                    .then(function (success) {
                        deferred.resolve(success);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }


            function addProject(projectData) {
                var deferred = $q.defer();

                $http.post(BASE_URL + 'Projects/', projectData)
                    .then(function (success) {
                        deferred.resolve(success);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }

            function editProject(projectData) {
                var deferred = $q.defer();

                $http.put(BASE_URL + 'Projects/' + projectData.Id, projectData)
                    .then(function (success) {
                        deferred.resolve(success);
                    }, function (error) {
                        deferred.reject(error);
                    });

                return deferred.promise;
            }

            return {
                getProjectById: getProjectById,
                getProjectsForUser: getProjectsForUser,
                getProjectsPage: getProjectsPage,
                getAllProjects: getAllProjects,
                addProject: addProject,
                editProject: editProject
            }
        }]);