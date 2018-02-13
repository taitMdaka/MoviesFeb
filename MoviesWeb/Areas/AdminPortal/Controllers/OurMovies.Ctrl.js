angular.module('ourmovies', [])
    .controller('OurMoviesCtrl', ['$scope', '$http', 'ourMoviesServ', '$window', 'Notification', function ($scope, $http, ourMoviesServ, $window, notification) {
        $scope.$root.currentPage = 'Movies';
        $scope.ourmovies = [];

        OurMoviesCtrl.ListOurMovies().then(function (result) {
            $scope.Movies = result;
        });

        //$scope.fileSelect = function () {
        //    var file = document.getElementById('FileData').files[0];
        //    var reader = new FileReader();
        //    reader.onload = function () {
        //        $scope.$apply(function ($scope) {
        //            $scope.testimony.FileData = reader.result;
        //            $scope.testimony.FileName = file.name;
        //        });
        //    };
        //    reader.readAsDataURL(file);
        //}


        $scope.saveMovies = function () {
            if ($scope.form.$valid) {
                if ($scope.ourmovies.Id === null || $scope.ourmovies.Id === undefined) {
                    ourMoviesServ.AddMovies($scope.Movies).then(function (result) {
                        $('#newMovies').modal('toggle');
                        notification.success('Testimony has been added.');
                        $window.location.reload();
                    },
                        function (error) {
                            notification.error(error.data);
                        });
                } else {
                    testimoniesServ.updateTestimony($scope.testimony).then(function (result) {
                        $('#newTestimony').modal('toggle');
                        notification.success('Testimony has been updated.');
                    },
                        function (error) {
                            notification.error(error.data);
                        });
                }
            } else {
                $scope.$root.touchFrom($scope.form);
                notification.warning('Please complete all required field');
            }
        };

        //$scope.cancelModal = function () {
        //    $scope.testimony = {};
        //    $('#newTestimony').modal('toggle');
        //}

        //$scope.newTestimonyClicked = function () {
        //    $scope.testimony = {};
        //}

        //$scope.editiTestimony = function (id) {
        //    $scope.testimony = _.find($scope.testimonies, function (item) { return item.Id === id; });

        //}

        $scope.RemoveTestimony = function (id) {
            $scope.$root.showModalDialog('Are you sure you want to Remove Testimony ?', function () {

                testimoniesServ.deleteTestimony(id).then(function (result) {
                    $('#myConfirmModal').modal('toggle');
                    notification.success('Testimony Has Been Removed.');
                    $window.location.reload();

                },
                    function (error) {
                        notification.error(error.data);
                    });
            });
        };
    }]);