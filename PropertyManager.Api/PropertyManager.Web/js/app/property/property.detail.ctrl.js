angular.module('app').controller('PropertyDetailController', function ($scope, $stateParams, PropertyResource) {

    //get the id from the URL
    $scope.property = PropertyResource.get({propertyId: $stateParams.id});

   //Save the new data
    $scope.saveProperty = function(){
        $scope.property.$update(function(){
            alert('save successful');

        }); 
    };
});