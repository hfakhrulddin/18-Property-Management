angular.module('app').controller('LeaseGridController', function ($scope, LeaseResource) {

    function activate() {

        $scope.leases = LeaseResource.query();
    }

    activate();


    $scope.deleteLease = function (lease) {
        lease.$remove(function (data) {
            activate();
        })
    };

});