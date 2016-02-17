angular.module('app').controller('LeaseAddController', function ($scope, $stateParams, LeaseResource) {
    $scope.Lease = {};
  

    $scope.saveLease = function () {

        LeaseResource.save($scope.lease, function () {
            $scope.lease = {};
            alert('Create list successful');


        });
    };

});