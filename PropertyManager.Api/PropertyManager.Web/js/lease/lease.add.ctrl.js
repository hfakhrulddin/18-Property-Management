angular.module('app').controller('LeaseAddController', function ($scope, $stateParams, LeaseResource) {
    $scope.Lease = {};
    $scope.newLease = {};

    $scope.addLease = function () {

        LeaseResource.save($scope.newLease, function () {
            $scope.newLease = {};
            alert('Create list successful');


        });
    };

});