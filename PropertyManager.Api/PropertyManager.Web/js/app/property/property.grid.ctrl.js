angular.module('app').controller('PropertyGridController', function ($scope, PropertyResource) {

    /////////////////////////////
    activate();
    ///////////////////////////////Delete selected property form the list.
    $scope.deleteProperty = function (property) {
        property.$remove(function (data) {
            activate();
        })
    };
    ////////////////////////////
    function activate() {
        $scope.properties = PropertyResource.query();
    }


});