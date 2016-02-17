angular.module('app').controller('WorkorderGridController', function ($scope, WorkorderResource) {
/////////////////////////////////Activate function
    function activate() {

        $scope.workorders = WorkorderResource.query();

    }
/////////////////////////////////Delete function.
    $scope.deleteWorkorder = function (workorder) {
        workorder.$remove(function (data) {
            activate();
        })
    };
//////////////////////////////////Filter by date.
    $scope.getRange = function () {
        $scope.workorders = WorkorderResource.range({ startDate: $scope.OpenedDate, endDate: $scope.ClosedDate });
    }
    //////////////////////////////////Call to update your table.
    activate();
});