angular.module('app').controller('WorkorderDetailController', function ($scope, $stateParams, WorkorderResource) {

    //get the id from the URL
    $scope.workorder = WorkorderResource.get({ workorderId: $stateParams.id });

    //Save the new data
    $scope.saveWorkorder = function () {
        $scope.workorder.$update(function () {
            alert('save successful');
        });
    };





});