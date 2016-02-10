angular.module('app').controller('LeaseDetailController', function ($scope, $stateParams, LeaseResource) {

    //get the id from the URL
    $scope.lease = LeaseResource.get({leaseId: $stateParams.id });

    //Save the new data
    $scope.saveLease = function () {
        $scope.lease.$update(function () {
            alert('save successful');
        });
    };

});






