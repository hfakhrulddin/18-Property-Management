angular.module('app').controller('TenantDetailController', function ($scope, $stateParams, TenantResource) {

    //get the id from the URL
    $scope.tenant = TenantResource.get({ tenantId: $stateParams.id });

    //Save the new data
    $scope.saveTenant = function () {
        $scope.tenant.$update(function () {
            alert('save successful');
        });
    };





});