angular.module('app').controller('PropertyAddController', function ($scope, $stateParams, PropertyResource) {
    
    $scope.property = {};

    $scope.newProperty = {};

    $scope.addProperty = function () {

        PropertyResource.save($scope.newProperty, function () {
            $scope.newProperty = {};
            alert('Create property successful');


        });
    };

});