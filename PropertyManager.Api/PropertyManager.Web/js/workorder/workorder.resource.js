angular.module('app').factory('WorkorderResource', function (apiUrl , $resource) {

    return $resource(apiUrl + '/workorders/:workorderId', { workorderId: '@WorkOrderId' }, {

        'update': {
            method: 'PUT'
        }
    });
});