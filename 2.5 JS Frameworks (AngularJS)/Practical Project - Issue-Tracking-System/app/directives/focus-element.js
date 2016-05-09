'use strict';

angular.module('issueTrackingSystem.directives.focusElement', [])

    .directive('focusElement', function($timeout, $parse) {
        return {
            link: function(scope, element, attrs) {
                var model = $parse(attrs.focusElement);
                scope.$watch(model, function(value) {
                    if(value === true) {
                        $timeout(function() {
                            element[0].focus();
                        });
                    }
                });
                element.bind('blur', function() {
                    scope.$apply(model.assign(scope, false));
                });
            }
        };
    });