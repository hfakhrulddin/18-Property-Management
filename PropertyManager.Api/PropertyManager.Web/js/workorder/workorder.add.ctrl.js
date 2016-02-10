//angular.module('app').controller('WorkorderAddController', function ($scope, $stateParams, WorkorderResource) {
//    $scope.newWorkorder = {};
//    //get the id from the URL
//    $scope.workorder = WorkorderResource.get({ workorderId: $stateParams.id });

//    function activate() {

//        $scope.workorders = WorkorderResource.query();

//    }

//    $scope.addWorkorder = function () {

//        WorkorderResource.save($scope.newWorkorder, function () {
//            $scope.newWorkorder = {};
//            alert('save list successful');
//            activate();

//        });
//    };

//});