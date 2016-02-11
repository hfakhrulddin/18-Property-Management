angular.module('app').controller('TenantAddController', function ($scope, $stateParams, TenantResource) {
    
    //get the id from the URL
    $scope.Tenant = {};

    $scope.saveTenant = function () {

        TenantResource.save($scope.tenant, function () {
            $scope.tenant = {};
            alert('save list successful');

        });
    };

});