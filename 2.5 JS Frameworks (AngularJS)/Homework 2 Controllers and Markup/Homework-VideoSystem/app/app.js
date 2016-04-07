'use strict';

// Declare app level module which depends on views, and components
angular.module('videoSystem', [
        'ngRoute',
        'videoSystem.home',
        'videoSystem.addVideo'
    ])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.otherwise({redirectTo: '/home'});
    }])

    .factory('dataService', function dataService() {
        var videos = [];

        function getAllVideos() {
            return videos;
        }

        function addVideo(video) {
            var newVideo = {
                title: video.title,
                pictureUrl: video.pictureUrl,
                length: video.length || 0,
                category: video.category,
                subscribers: 0,
                date: video.date ? video.date : new Date(),
                haveSubtitles: video.haveSubtitles ? video.haveSubtitles : 'false',
                comments: []
            };

            videos.push(newVideo);
        }

        return {
            getAllVideos: getAllVideos,
            addVideo: addVideo,
        }
    });