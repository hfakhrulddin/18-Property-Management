angular.module('app').factory('WorkorderResource', function (apiUrl , $resource) {

    return $resource(apiUrl + '/workorders/:workorderId', { workorderId: '@WorkOrderId', startDate: '@OpenedDate', endDate: '@ClosedDate' }, {

        'update': {
            method: 'PUT'
        },

        'range': {
            method: 'GET', url: apiUrl + '/workorders/:startDate/:endDate', isArray: true
        }

    });
});