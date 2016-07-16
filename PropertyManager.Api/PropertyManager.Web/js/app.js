angular.module('app', ['ngResource', 'ui.router', 'LocalStorageModule']);/// LocalStorageService for OAuth 

//angular.module('app').value('apiUrl', 'https://propertyapi.azurewebsites.net/api');

angular.module('app').value('apiUrl', 'http://localhost:50873/api');

angular.module('app').config(function ($stateProvider, $urlRouterProvider, $httpProvider) {
    $httpProvider.interceptors.push('AuthenticationInterceptor');

    $urlRouterProvider.otherwise('home');

    $stateProvider

    .state('home', { url: '/home', templateUrl: '/templates/home/home.html', controller: 'HomeController' })
    .state('app', { url: '/app', templateUrl: '/templates/app/app.html', controller: 'DashboardController' })
        .state('register', { url: '/register', templateUrl: '/templates/register/register.html', controller: 'RegisterController' })
        .state('login', { url: '/login', templateUrl: '/templates/login/login.html', controller: 'LoginController' })

    .state('app.dashboard', { url: '/dashboard', templateUrl: '/templates/app/dashboard/dashboard.html', controller: 'DashboardController' })


    .state('app.property', { url: '/property', abstract: true, template: '<ui-view/>' })
        .state('app.property.grid', { url: '/grid', templateUrl: '/templates/app/property/property.grid.html', controller: 'PropertyGridController' })
        .state('app.property.detail', { url: '/detail/:id', templateUrl: '/templates/app/property/property.detail.html', controller: 'PropertyDetailController' })
        .state('app.property.add', { url: '/add', templateUrl: '/templates/app/property/property.detail.html', controller: 'PropertyAddController' })

    .state('app.lease', { url: '/lease', abstract: true, template: '<ui-view/>' })
        .state('app.lease.grid', { url: '/grid', templateUrl: '/templates/app/lease/lease.grid.html', controller: 'LeaseGridController' })
        .state('app.lease.detail', { url: '/detail/:id', templateUrl: '/templates/app/lease/lease.detail.html', controller: 'LeaseDetailController' })
        .state('app.lease.add', { url: '/add', templateUrl: '/templates/app/lease/lease.detail.html', controller: 'LeaseAddController' })

    .state('app.tenant', { url: '/tenant', abstract: true, template: '<ui-view/>' })
        .state('app.tenant.grid', { url: '/grid', templateUrl: '/templates/app/tenant/tenant.grid.html', controller: 'TenantGridController' })
        .state('app.tenant.detail', { url: '/detail/:id', templateUrl: '/templates/app/tenant/tenant.detail.html', controller: 'TenantDetailController' })
        .state('app.tenant.add', { url: '/add', templateUrl: '/templates/app/tenant/tenant.detail.html', controller: 'TenantAddController' })

    .state('app.workorder', { url: '/workorder', abstract: true, template: '<ui-view/>' })
        .state('app.workorder.grid', { url: '/grid', templateUrl: '/templates/app/workorder/workorder.grid.html', controller: 'WorkorderGridController' })
        .state('app.workorder.detail', { url: '/detail/:id', templateUrl: '/templates/app/workorder/workorder.detail.html', controller: 'WorkorderDetailController' })
        .state('app.workorder.add', { url: '/add', templateUrl: '/templates/app/workorder/workorder.detail.html', controller: 'WorkorderAddController' })
        .state('app.workorder.date', { url: '/date', templateUrl: '/templates/app/workorder/workorder.date.html', controller: 'WorkorderDateController' })

});

angular.module('app').run(function (AuthenticationService) {
    AuthenticationService.initialize();
});