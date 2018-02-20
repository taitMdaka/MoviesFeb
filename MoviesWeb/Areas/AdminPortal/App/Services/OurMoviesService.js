angular.module('EventsService', [])
    .factory('eventsServ', function ($http) {
        var getEvents = function () {
            return $http.get('/api/event/GetAllEvents', { cache: true }).then(function (data) {
                return data.data;
            });
        }

        var addEvent = function (addEventCommand) {
            return $http.post('/api/event/AddEvent', addEventCommand).then(function (data) {
                return data.data;

            });
        }

        var updateEvent = function (updateEventCommand) {
            return $http.post('/api/event/UpdateEvent', updateEventCommand).then(function (data) {
                return data.data;

            });
        }

        var removEvent = function (eventId) {
            return $http.post('/api/event/RemoveEvent/' + eventId).then(function (data) {
                return data.data;

            });
        }


        return {
            getEvents: getEvents,
            addEvent: addEvent,
            updateEvent: updateEvent,
            removEvent: removEvent
        }


    })