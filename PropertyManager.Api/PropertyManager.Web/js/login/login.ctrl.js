angular.module('app').controller('LoginController', function ($scope, AuthenticationService)
{
    $scope.loginData = {};

    $scope.login = function () { AuthenticationService.login($scope.loginData).then


    (
        function(response){location.replace('/#/app/dashboard')},
        function (err) {

            location.replace('/#/app/login');
            alert(err.error_description);
        }
    );
    };
});