angular.module('app').controller('WorkorderAddController', function ($scope, $stateParams, WorkorderResource) {
    
    //get the id from the URL
    $scope.Workorder = {};

    //$scope.newWorkorder = {};

    $scope.saveWorkorder = function () {

        WorkorderResource.save($scope.workorder, function () {
            $scope.workorder = {};
            alert('save list successful');
        });
    };

});