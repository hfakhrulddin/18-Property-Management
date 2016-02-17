angular.module('app').factory('AuthenticationService', function ($http, $q, localStorageService, apiUrl) {
    /////initial state should be false.
    var state = {
        authorized : false
    };

    ///////this will be loaded when the user open the page. Keep the user login till it will expire the token.
    function initialize(){
        var token = localStorageService.get('token');

        if (token) {
            state.authorized = true;
        }
    }

    //////Has the registeratiion object which we will send to the API backend..../api/accounts/register
    function register(registeration){
        return $http.post(apiUrl+'/accounts/register', registeration).then(
            function (response){
                return response;
            }
            );
    }

    //////this object has the password and user name & this will call... /api/token
    function login(loginData){
    
        var data = 'grant_type=password&username=' + loginData.username + '&password=' + loginData.password;
        var deferred = $q.defer();


        return $http.post(apiUrl + '/token', data, { header: { 'content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {localStorageService.Set('token', { token: response.access_token });

            state.authorized = true;
            deferred.resolve(response);


        }).error(function (err, status) {
            logout();
            deferred.reject(err);
        })
        return deferred.promise;
    }

    ///// logOut method.
    function logout() {
        localStorageService.remove('token');
        state.authorized = false;
    }
    
    ///// this like encapsluation for OOP backend.
    return {
        state: state,
        initialize: initialize,
        register: register,
        login: login,
        logout: logout
    };

});