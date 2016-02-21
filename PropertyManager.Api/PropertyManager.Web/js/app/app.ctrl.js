angular.module('app').controller('AppController', function ($scope) {

    $scope.logout = function () {
        AuthenticationService.logout().then(function () { location.replace('/#/app/home') });
    };

});