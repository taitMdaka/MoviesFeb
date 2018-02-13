angular.module('OurMoviesService', [])
    .factory('ourMoviesServ', function ($http) {
        var ListOurMovies = function () {
            return $http.get('/api/adminweb/ListMovies', { cache: true }).then(function (data) {
                return data.data;
            });
        };

        var addMovies = function (AddMoviesCommand) {
            return $http.post('/api/adminweb/AddMovies', AddMoviesCommand).then(function (data) {
                return data.data;
            });
        };

        //        var updateTestimony = function (updateTestimonyCommand) {
        //            return $http.post('/api/adminweb/UpdateTestimonies', updateTestimonyCommand).then(function (data) {
        //                return data.data;
        //            });
        //        }

        //        var deleteTestimony = function (Id) {
        //            return $http.post('/api/AdminWeb/RemoveTestimony/' + Id).then(function (data) {
        //                return data.data;

        //            });
        //        }

        //        return {
        //            getTestimonies: getTestimonies,
        //            addTestimony: addTestimony,
        //            updateTestimony: updateTestimony,
        //            deleteTestimony: deleteTestimony
        //        }
    });