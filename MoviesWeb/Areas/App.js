//var app = angular.module('app', [
//    'ngRoute',
//    'ngCookies',
//    'ngSanitize',
//    'ui-notification',
//    'ngLoadingSpinner',
//    'ui.tinymce',
//    'angularUtils.directives.dirPagination',
//    'services',
//    'testimonies',
//    'EventsService',
//    'NewsService',
//    'news',
//    'events',
//    'projects',
//    'ProjectsServices',
//    'ProjectCategoriesService',
//    'projectcategories',
//    'SponsorsServices',
//    'Sponsors',
//    'VolunteerOpportunitiesServices',
//    'VolunteerOpportunities',
//    'dashboard',
//    'email',
//    'EmailService',
//    'galleries',
//    'GalleriesServices',
//    'DonationsReports',
//    'DonationReportServices',
//    'DocumentstypeService',
//    'documentstype',
//    'DocumentsServices',
//    'documents',
//    'SponsorRequestServices',
//    'SponsorRequests',
//    'facebookposts',
//    'FacebookService',
//    'careers',
//    'CareerServices',
//    'jobcategories',
//    'JobCategoryService',
//    'DonationGoodsServices',
//    'Applications',
//    'ApplicationsServices',
//    'DonationGoods',
//    'VolunteerEnrollmentsServices',
//    'volunteerenrollments',
//    'datetimepicker',
//    'DonationGoodsSubmissionServices',
//    'DonationGoodsSubmission',
//    'VolunteerRequestsServices',
//    'volunteerrequests',
//    'DonationReportServices',
//    'ProjectDonationsReports'

//]);

//app.config(['$provide', '$routeProvider', '$httpProvider', '$locationProvider', 'NotificationProvider', 'datetimepickerProvider', function ($provide, $routeProvider, $httpProvider, $locationProvider, notificationProvider, datetimepickerProvider) {

//    notificationProvider.setOptions({
//        delay: 10000,
//        startTop: 20,
//        startRight: 10,
//        verticalSpacing: 20,
//        horizontalSpacing: 20,
//        positionX: 'right',
//        positionY: 'top'
//    });

//    //Date time picker config
//    datetimepickerProvider.setOptions({
//        locale: 'en'
//    });

//    // Add an interceptor for AJAX errors
//    //================================================
//    //$httpProvider.interceptors.push(['$q', '$location', function ($q, $location) {
//    //    return {
//    //        'responseError': function (response) {
//    //            if (response.status === 403)
//    //                $location.url('/noAccess');
//    //            return $q.reject(response);
//    //        }
//    //    };
//    //}]);

//    //================================================
//    // Routes
//    //================================================
//    $routeProvider.when('/dashboard', {
//        templateUrl: 'Admin/App/Dashboard',
//        controller: 'dashboardCtrl'
//    });

//    $routeProvider.when('/testimonies', {
//        templateUrl: 'Admin/App/Testimonies',
//        controller: 'testimoniesCtrl'
//    });

//    $routeProvider.when('/Sponsors', {
//        templateUrl: 'Admin/App/Sponsors',
//        controller: 'SponsorsCtrl'
//    });

//    $routeProvider.when('/Events', {
//        templateUrl: 'Admin/App/Events',
//        controller: 'EventsCtrl'
//    });

//    $routeProvider.when('/VolunteerOpportunities', {
//        templateUrl: 'Admin/App/VolunteerOpportunities',
//        controller: 'VolunteerOpportunitiesCtrl'
//    });

//    $routeProvider.when('/Emails', {
//        templateUrl: 'Admin/App/EmailTemplateList',
//        controller: 'EmailCtrl'
//    });
//    $routeProvider.when('/News', {
//        templateUrl: 'Admin/App/AddNews',
//        controller: 'NewsCtrl'
//    });
//    $routeProvider.when('/Projects', {
//        templateUrl: 'Admin/App/Projects',
//        controller: 'ProjectsCtrl'
//    });
//    $routeProvider.when('/ProjectCategories', {
//        templateUrl: 'Admin/App/ProjectCategories',
//        controller: 'ProjectCategoriesCtrl'
//    });

//    $routeProvider.when('/Galleries', {
//        templateUrl: 'Admin/App/Galleries',
//        controller: 'GalleriesCtrl'
//    });

//    $routeProvider.when('/DocumentsType', {
//        templateUrl: 'Admin/App/DocumentsType',
//        controller: 'DocumentsTypeCtrl'
//    });
//    $routeProvider.when('/Documents', {
//        templateUrl: 'Admin/App/Documents',
//        controller: 'DocumentsCtrl'
//    });
//    $routeProvider.when('/Facebook', {
//        templateUrl: 'Admin/App/Facebook',
//        controller: 'FacebookCtrl'
//    });
//    $routeProvider.when('/SponsorRequest', {
//        templateUrl: 'Admin/App/SponsorRequest',
//        controller: 'SponsorRequestCtrl'
//    });
//    $routeProvider.when('/Jobcategory', {
//        templateUrl: 'Admin/App/Jobcategory',
//        controller: 'JobCategoryCtrl'
//    });
//    $routeProvider.when('/GetAllJobApplications', {
//        templateUrl: 'Admin/App/GetAllJobApplications',
//        controller: 'ApplicationsCtrl'
//    });
//    $routeProvider.when('/Jobs', {
//        templateUrl: 'Admin/App/Jobs',
//        controller: 'CareerCtrl'
//    });

//    $routeProvider.when('/VolunteerEnrollment', {
//        templateUrl: 'Admin/App/VolunteerEnrollment',
//        controller: 'VolunteerEnrollmentCtrl'
//    });

//    $routeProvider.when('/VolunteerRequest', {
//        templateUrl: 'Admin/App/VolunteerRequest',
//        controller: 'VolunteerRequestCtrl'
//    });



//    $routeProvider.when('/DonationGoods', {
//        templateUrl: 'Admin/App/DonationGoods',
//        controller: 'DonationGoodsCtrl'
//    });

//    $routeProvider.when('/GoodsDonationSubmission', {
//        templateUrl: 'Admin/App/GoodsDonationSubmission',
//        controller: 'DonationGoodsSubmissionCtrl'
//    });

//    $routeProvider.when('/Donation', {
//        templateUrl: 'Admin/App/Donation',
//        controller: 'DonationsReportsCtrl'
//    });

//    $routeProvider.when('/CatergoryDonations', {
//        templateUrl: 'Admin/App/_ProjectCatergoryDonations',
//        controller: 'DonationsReportsCtrl'
//    });

//    $routeProvider.when('/ProjectDonations', {
//        templateUrl: 'Admin/App/_ProjectDonations',
//        controller: 'DonationsReportsCtrl'

//    });


//    $routeProvider.otherwise({
//        redirectTo: '/dashboard'
//    });

//    $locationProvider.hashPrefix('');


//    $httpProvider.interceptors.push(['$q', '$location', '$rootScope', function ($q, $location, $rootScope) {
//        if ($rootScope.activeCalls == undefined) {
//            $rootScope.activeCalls = 0;
//        }

//        return {
//            request: function (config) {
//                $rootScope.activeCalls += 1;
//                return config;
//            },
//            requestError: function (rejection) {
//                $rootScope.activeCalls -= 1;
//                if (response.status === 451) //this is a random code, the can be specified in the c# code
//                    $location.url('/noAccess');
//                //return $q.reject(response);
//                if (response.status === 404) //this is a random code, the can be specified in the c# code
//                    $location.url('/login');

//                return $q.reject(rejection);
//            },
//            response: function (response) {
//                $rootScope.activeCalls -= 1;
//                return response;
//            },
//            responseError: function (rejection) {
//                $rootScope.activeCalls -= 1;
//                if (rejection.status === 403) //this is a random code, the can be specified in the c# code
//                    $location.url('/noAccess');
//                return $q.reject(rejection);
//            }
//        };
//    }]);


//}]);

//app.run(['$rootScope', '$http', '$window', 'Notification', function ($rootScope, $http, $window, notification) {

//    $rootScope.tinymceOptions = {
//        onChange: function (e) {
//            // put logic here for keypress and cut/paste changes
//        },
//        inline: false,
//        plugins: 'advlist autolink link image lists charmap print preview',
//        skin: 'lightgray',
//        theme: 'modern'
//    };

//    $rootScope.touchFrom = function (form) {
//        angular.forEach(form.$error, function (field) {
//            angular.forEach(field,
//                function (errorField) {
//                    errorField.$setTouched();

//                });
//        });
//    }

//    $rootScope.unTouchFrom = function (form) {
//        angular.forEach(form.$$controls, function (field) {
//            field.$setUntouched();

//        });
//    }


//    $rootScope.handlefileValidation = function (file) {

//        var fileExtension = file.name.lastIndexOf(".") + 1;
//        var extensionType = "pdf";
//        var stringSbtr = file.name.substring(fileExtension, file.name.length);


//        if (stringSbtr === extensionType || stringSbtr === extensionType.toUpperCase()) {
//            return true;
//        }
//        else {
//            return false;
//        }


//    };

//    $rootScope.$watch('activeCalls', function (newVal, oldVal) {

//        var $body = $('body');

//        if (newVal == 0) {
//            $body.removeClass('show-loading-screen');

//        }
//        else {
//            $body.addClass('show-loading-screen');
//        }
//    });

//    $rootScope.showModalDialog = function (Message, returnFuction) {
//        //Toogle Modal 

//        /*$('#ModalDialog').modal({
//            backdrop: 'static',
//            keyboard: false
//        })*/

//        $("#TriggerModalDialogbtn").trigger("click");

//        $rootScope.modalMessage = Message;
//        if (typeof returnFuction !== "undefined") {
//            $rootScope.onModalClose = returnFuction;
//        } else {
//            $rootScope.onModalClose = null;
//        }

//        $rootScope.thisModalClosing = function () {
//            //Toogle Modal 
//            $('#ModalDialog').modal('toggle');
//        }
//    }

//    $rootScope.PixelControl = function (ReqHeight, RegWidth, UploadedImage) {

//        var reader = new FileReader();

//        var image = new Image();
//        reader.onload = function (e) {
//            image.src = e.target.result;
//            UploadedImage = image;
//            image.onload = function () {
//                var height = ReqHeight;
//                var width = RegWidth;
//                if (height < ReqHeight || width < ReqWidth) {
//                    notification.error("image resolution too low");
//                }
//            }
//        }
//    }

//    $rootScope.scoped = {
//        format: 'HH:mm:ss'
//    };

//    $rootScope.vm = {
//        datetime: '05/13/2011'
//    }
//}
//    //$rootScope.pixelControl = function () {

//    //    var file = document.getElementById('FileData').files[0];
//    //    var reader = new FileReader();
//    //    var image = new Image();
//    //    reader.onload = function (e) {
//    //        image.src = e.target.result;
//    //        image.onload = function () {
//    //            var height = this.height;
//    //            var width = this.width;
//    //            if (height < 250 || width < 370) {
//    //                alert("Image Resolution is too low");

//    //            }
//    //            else {
//    //                $rootScope.$apply(function ($rootScope) {

//    //                    $scope.Gallery.FileData = reader.result;
//    //                    $scope.Gallery.file.Url = $scope.Gallery.FileData;
//    //                    $scope.Gallery.fileName = file.name;

//    //                });
//    //            }
//    //        }
//]);