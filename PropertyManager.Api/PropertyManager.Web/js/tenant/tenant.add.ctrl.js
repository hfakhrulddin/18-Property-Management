angular.module('app').controller('TenantAddController', function ($scope, $stateParams, TenantResource) {
    
    //get the id from the URL
    $scope.tenant = {};

    $scope.newTenant = {};

    $scope.addTenant = function () {

        TenantResource.save($scope.newTenant, function () {
            $scope.newTenant = {};
            alert('save list successful');

        });
    };

});