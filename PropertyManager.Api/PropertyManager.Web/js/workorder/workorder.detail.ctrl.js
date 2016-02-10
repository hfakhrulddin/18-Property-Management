angular.module('app').controller('WorkorderDetailController', function ($scope, $stateParams, WorkorderResource) {

    $scope.newWorkorder = {};

    //get the id from the URL
    $scope.workorder = WorkorderResource.get({ workorderId: $stateParams.id });

    //Save the new data
    $scope.saveWorkorder = function () {
        $scope.workorder.$update(function () {
            alert('save successful');
        });
    };


    function activate() {
        $scope.workorders = WorkorderResource.query();
    }


    $scope.addWorkorder = function () {

        WorkorderResource.save($scope.newWorkorder, function () {
            $scope.newWorkorder = {};
            alert('save list successful');
            activate();
        });
    };

});