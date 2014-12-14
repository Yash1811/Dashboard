appServices.factory('AuthenticationService', function () {
    var auth = {
        isAuthenticated: false,
        isAdmin: false
    }

    return auth;
});

appServices.factory('TokenInterceptor', function ($q, $window, $location, AuthenticationService) {
    return {
        request: function (config) {
            config.headers = config.headers || {};
            if ($window.sessionStorage.token) {
                config.headers.Authorization = 'Bearer ' + $window.sessionStorage.token;
            }
            return config;
        },

        requestError: function (rejection) {
            return $q.reject(rejection);
        },

        /* Set Authentication.isAuthenticated to true if 200 received */
        response: function (response) {
            if (response != null && response.status == 200 && $window.sessionStorage.token && !AuthenticationService.isAuthenticated) {
                AuthenticationService.isAuthenticated = true;
            }
            return response || $q.when(response);
        },

        /* Revoke client authentication if 401 is received */
        responseError: function (rejection) {
            if (rejection != null && rejection.status === 401 && ($window.sessionStorage.token || AuthenticationService.isAuthenticated)) {
                delete $window.sessionStorage.token;
                AuthenticationService.isAuthenticated = false;
                $location.path("/admin/login");
            }

            return $q.reject(rejection);
        }
    };
});

appServices.factory('UserService', function ($http) {
    return {
        signIn: function (username, password) {
            var data = "grant_type=password&username=" + username + "&password=" + password;
            return $http.post(options.api.base_url + '/Token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } });
        },

        logOut: function () {
            return $http.post(options.api.base_url + '/api/Account/Logout');
        },

        register: function (username, password, confirmPassword) {
            return $http.post(options.api.base_url + '/api/Account/Register', { Email: username, Password: password, ConfirmPassword: confirmPassword });
        }
    }
});

appServices.factory('EC2InstanceService', function ($http, $location) {
    return {

        getActiveEc2InstancesByPage: function (pageNum, pageSize) {
            var apiRequestUrl = '{0}/api/DashBoard/GetEc2Instances?pageNum={1}&pageSize={2}'.format(options.api.base_url, pageNum, pageSize);
            return $http.get(apiRequestUrl);
        },

        filterResultsByType: function (data, appliedFilter) {
            for (var i = data.length - 1; i >= 0; i--) {
                if (data[i].Type !== appliedFilter) {
                    data.splice(i, 1);
                }
            }
            return data;
        },

        filterResultsByState: function (data, appliedFilter) {
            for (var i = data.length - 1; i >= 0; i--) {
                if (data[i].State !== appliedFilter) {
                    data.splice(i, 1);
                }
            }
            return data;
        },

        getEc2TypeSortOptions: function (ec2ActiveResults) {
            var isAdded = false;
            var ec2Types = [];
            angular.forEach(ec2ActiveResults, function (item, key) {
                if (!isKeyInCollection(ec2Types, item.Type)) {
                    ec2Types.push(item.Type);
                    isAdded = true;
                }
            });
            return ec2Types;
        },

        getEc2StateSortOptions: function (ec2ActiveResults) {
            var isAdded = false;
            var ec2States = [];
            angular.forEach(ec2ActiveResults, function (item, key) {
                if (!isKeyInCollection(ec2States, item.State)) {
                    ec2States.push(item.State);
                    isAdded = true;
                }
            });
            return ec2States;
        },

        hasCurrentPageParameter: function () {
            var currentPage = ($location.search()).currentPage;
            return angular.isDefined(currentPage) && currentPage != "";
        },

        getCurrentPageParameter: function () {
            return ($location.search()).currentPage;
        },

        setSearchParameter: function (parameter, value) {
            $location.search(parameter, value);
        }
    }
});


function isKeyInCollection(collection, key) {
    for (var i = 0; i < collection.length; i++) {
        if (collection[i] === key) {
            return true;
        }
    }
    return false;
}

/**
           Util method to extend javascript string object to allow string formatting
           */
String.prototype.format = String.prototype.f = function () {
    var s = this,
        i = arguments.length;

    while (i--) {
        s = s.replace(new RegExp('\\{' + i + '\\}', 'gm'), arguments[i]);
    }
    return s;
};
