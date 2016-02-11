angular.module('app').controller('WorkorderAddController', function ($scope, $stateParams, WorkorderResource) {
    
    //get the id from the URL
    $scope.workorder = {};

    $scope.newWorkorder = {};

    $scope.addWorkorder = function () {

        WorkorderResource.save($scope.newWorkorder, function () {
            $scope.newWorkorder = {};
            alert('save list successful');
        });
    };

});