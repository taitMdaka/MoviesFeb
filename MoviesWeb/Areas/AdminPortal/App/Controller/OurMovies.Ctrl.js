angular.module('ourmovies', ['ngAnimate', 'ui.bootstrap'])
    .controller('OurMovies.Ctrl', ['$scope', 'ourMoviesServ', 'Notification', '$window', function ($scope, ourMoviesServ, notification, $window) {
        $scope.$root.currentPage = 'Ourmovies';
        $scope.ourmovies = [];
        $scope.removeEvents = [];

        eventsServ.getEvents().then(function (result) {
            $scope.events = result;
        });

        $scope.fileSelect = function () {
            var file = document.getElementById('FileData').files[0];
            var reader = new FileReader();
            reader.onload = function () {
                $scope.$apply(function ($scope) {
                    $scope.event.FileData = reader.result;
                    $scope.event.fileName = file.name;
                });
            };
            reader.readAsDataURL(file);
        }

        //Adding items to be removed on Checkbox check
        $scope.addEventsToRemoveOnClick = function (id, e, index) {
            if (!e.target.checked) {
                $scope.removeEvents.splice(index, 1);
            }
            else {
                $scope.removeEvents.push(id);
            }
        }

        //Remove checked Items

        $scope.saveEvent = function () {
            if ($scope.form.$valid) {
                if ($scope.event.Id === null || $scope.event.Id == undefined) {
                    eventsServ.addEvent($scope.event).then(function (result) {
                        $('#newEvent').modal('toggle');
                        notification.success('Event has been added.');
                        $window.location.reload();
                    },
                        function (error) {
                            notification.error(error.data);
                        });
                } else {
                    eventsServ.updateEvent($scope.event).then(function (result) {
                        $('#newEvent').modal('toggle');
                        notification.success('Event has been updated.');
                        $window.location.reload();
                    },
                        function (error) {
                            notification.error(error.data);
                        });
                }
            } else {
                $scope.$root.touchFrom($scope.form);
                notification.warning('Please complete all required field');
            }
        }

        $scope.removeEvent = function (id) {

            $scope.$root.showModalDialog('Are you sure you want to Remove Event?', function () {
                eventsServ.removEvent(id).then(function (result) {
                    $('#myConfirmModal').modal('toggle');
                    notification.success('Event has been removed.');
                    $window.location.reload();
                },
                    function (error) {
                        notification.error(error.data);
                    });
            });

        }

        $scope.cancelModal = function () {
            $scope.event = {};
            $('#newEvent').modal('toggle');
        }

        $scope.newEventClicked = function () {
            $scope.event = {};
        }

        $scope.editEvent = function (id) {
            $scope.event = _.find($scope.events, function (item) { return item.Id === id; });
        }

        //var dateTimePicker = function () {
        //    return {
        //        restrict: "A",
        //        require: "ngModel",
        //        link: function (scope, element, attrs, ngModelCtrl) {
        //            var parent = $(element).parent();
        //            var dtp = parent.datetimepicker({
        //                format: "LL",
        //                showTodayButton: true
        //            });
        //            dtp.on("dp.change", function (e) {
        //                ngModelCtrl.$setViewValue(moment(e.date).format("LL"));
        //                scope.$apply();
        //            });
        //        }
        //    };
        //};

        //$scope.today = function () {
        //    $scope.event = new Date();
        //};
        //$scope.today();

        //$scope.clear = function () {
        //    $scope.event = null;
        //};

        // //Disable weekend selection
        //$scope.enabled = function (date, mode) {
        //    return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
        //};

        //$scope.open = function ($event) {
        //    $scope.status.opened = true;
        //};
        //$scope.open = function ($event2) {
        //    $scope.status.opened = true;
        //};

        //$scope.formats = ['dd-MMMM-yyyy hh:mm:ss', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
        //$scope.format = $scope.formats[0];

        //$scope.status = {
        //    opened: false
        //};

        //var tomorrow = new Date();
        //tomorrow.setDate(tomorrow.getDate() + 1);
        //var afterTomorrow = new Date();
        //afterTomorrow.setDate(tomorrow.getDate() + 2);
        //$scope.events =
        //    [
        //        {
        //            date: tomorrow,
        //            status: 'full'
        //        },
        //        {
        //            date: afterTomorrow,
        //            status: 'partially'
        //        }
        //    ];

        //$scope.getDayClass = function (date, mode) {
        //    if (mode === 'day') {
        //        var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

        //        for (var i = 0; i < $scope.events.length; i++) {
        //            var currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

        //            if (dayToCheck === currentDay) {
        //                return $scope.events[i].status;
        //            }
        //        }
        //    }

        //    return '';
        //};

    }]);