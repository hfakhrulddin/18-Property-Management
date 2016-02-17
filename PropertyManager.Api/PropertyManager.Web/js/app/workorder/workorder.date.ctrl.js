angular.module('app').controller('WorkorderDateController', function ($scope, WorkorderResource) {

   
    $scope.getRange = function () {
    $scope.workorders = WorkorderResource.range({ startDate: $scope.OpenedDate, endDate: $scope.ClosedDate });
  
    }

});