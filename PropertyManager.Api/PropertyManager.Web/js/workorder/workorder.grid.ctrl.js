angular.module('app').controller('WorkorderGridController', function ($scope, WorkorderResource) {


    function activate() {

        $scope.workorders = WorkorderResource.query();

    }

    activate();


});