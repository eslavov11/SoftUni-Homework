'use strict';

angular.module('issueTrackingSystem', [
        'ui.bootstrap',
        'ngRoute',
        'ngResource',
        'issueTrackingSystem.directives.focusElement',
        'issueTrackingSystem.navbar',
        'issueTrackingSystem.home',
        'issueTrackingSystem.dashboard',
        'issueTrackingSystem.users.logout',
        'issueTrackingSystem.users.authentication',
        'issueTrackingSystem.users.passwordChange',
        'issueTrackingSystem.projects',
        'issueTrackingSystem.projects.allProjects',
        'issueTrackingSystem.projects.addProject',
        'issueTrackingSystem.projects.editProject',
        'issueTrackingSystem.issues',
        'issueTrackingSystem.issues.addIssue',
        'issueTrackingSystem.issues.editIssue'
    ])
    .config(['$routeProvider', '$httpProvider', function($routeProvider, $httpProvider) {
        $httpProvider.interceptors.push(['$q', 'toastr', function ($q, toastr) {
            toastr.options = {
                timeOut: 1000,
                positionClass: "toast-top-center"
            };

            return {
                'response': function (response) {
                    return response;
                },
                'responseError': function (rejection) {
                    if (rejection.data && rejection.data.error_description) {
                        toastr.error(rejection.data.error_description);
                    }

                    return $q.reject(rejection);
                }
            }
        }]);

        $routeProvider.when('/', {
            templateUrl: localStorage.access_token ? 'app/dashboard/dashboard.html' : 'app/home/home.html',
            controller: localStorage.access_token ? 'DashboardController' : 'HomeController',
            access: {
                requiresLogin: !!localStorage.access_token
            }
        });

        $routeProvider.when('/projects/add', {
            templateUrl: 'app/projects/add-project/add-project.html',
            controller: 'AddProjectController',
            access: {
                requiresAdmin: true
            }
        });

        $routeProvider.when('/projects/:id/edit', {
            templateUrl: 'app/projects/edit-project/edit-project.html',
            controller: 'EditProjectController',
            access: {
                requiresLogin: true
            }
        });

        $routeProvider.when('/projects/:id/add-issue', {
            templateUrl: 'app/issues/add-issue/add-issue.html',
            controller: 'AddIssueController',
            access: {
                requiresLogin: true
            }
        });

        $routeProvider.when('/projects/:id', {
            templateUrl: 'app/projects/project.html',
            controller: 'ProjectController',
            access: {
                requiresLogin: true
            }
        });

        $routeProvider.when('/projects', {
            templateUrl: 'app/projects/all-projects/all-projects.html',
            controller: 'AllProjectsController',
            access: {
                requiresAdmin: true
            }
        });

        $routeProvider.when('/issues/:id/edit', {
            templateUrl: 'app/issues/edit-issue/edit-issue.html',
            controller: 'EditIssueController',
            access: {
                requiresLogin: true
            }
        });

        $routeProvider.when('/issues/:id', {
            templateUrl: 'app/issues/issue.html',
            controller: 'IssueController',
            access: {
                requiresLogin: true
            }
        });

        $routeProvider.when('/logout', {
            template: '',
            controller: 'LogoutController',
            access: {
                requiresLogin: true
            }
        });

        $routeProvider.when('/profile/password', {
            templateUrl: 'app/users/password-change/password-change.html',
            controller: 'PasswordChangeController',
            access: {
                requiresLogin: true
            }
        });

        $routeProvider.otherwise({
            redirectTo: '/'
        });
    }])

    .constant('BASE_URL', 'http://softuni-issue-tracker.azurewebsites.net/')
    .constant('toastr', toastr)

    .run(function ($rootScope, $location, authentication) {
        authentication.refreshToken();

        $rootScope.$on('$routeChangeStart', function (event, next) {
            if (!authentication.isLoggedIn() && next.access.requiresLogin) {
                $location.path('/');
                window.location.reload();
            } else if (!authentication.isAdmin() && next.access.requiresAdmin) {
                $location.path('/');
                window.location.reload();
            }
        });
    });