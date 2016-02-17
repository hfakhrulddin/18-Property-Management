angular.module('app').controller('PropertyAddController', function ($scope, $stateParams, PropertyResource) {

    $scope.Property = {};

    $scope.saveProperty = function () {

        PropertyResource.save($scope.property, function () {
            $scope.property = {};
            alert('Create property successful');


        });
    };

});