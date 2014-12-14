appControllers.controller('AdminUserCtrl', ['$scope', '$rootScope', '$location', '$window', 'UserService', 'AuthenticationService',
    function AdminUserCtrl($scope, $rootScope, $location, $window, UserService, AuthenticationService) {
        $scope.message = '';
        //Admin User Controller (signIn, logOut)
        $scope.signIn = function signIn(username, password) {
            if (username != "" && password != "") {
                UserService.signIn(username, password).success(function (data) {
                    AuthenticationService.isAuthenticated = true;
                    $window.sessionStorage.token = data.access_token;
                    $window.sessionStorage.userName = data.userName;
                    $location.path('/admin/ec2dashboard');
                    $scope.message = '';
                }).error(function (error) {
                    $scope.message = error.error_description;
                });
            } else {
                $scope.message = "Please enter username and Password";
            }
        }

        $scope.logOut = function logOut() {
            if (AuthenticationService.isAuthenticated) {

                UserService.logOut().success(function (data) {
                    AuthenticationService.isAuthenticated = false;
                    delete $window.sessionStorage.token;
                    $location.path("/");
                }).error(function (status, data) {
                    console.log(status);
                    console.log(data);
                });
            }
            else {
                $location.path("/admin/login");
            }
        }

        $scope.register = function register(username, password, passwordConfirm) {
            if (username != "" && password != "") {
                UserService.register(username, password, passwordConfirm).success(function (data) {
                    $scope.signIn(username, password);
                    $scope.message = '';
                }).error(function (error) {
                    var errorMessages = [];
                    angular.forEach(error.ModelState, function (errorMsg) {
                        errorMessages.push(errorMsg);
                    });
                    $scope.message = errorMessages.join(' ');
                });
            } else {
                $scope.message = "Please enter username and Password to create an account";
            }
        }
    }
]);


appControllers.controller('Ec2InstancesCtrl', ['$scope', '$routeParams', '$sce', 'EC2InstanceService',
    function Ec2InstancesCtrl($scope, $routeParams, $sce, EC2InstanceService) {

        $scope.message = '';
        $scope.eC2ActiveInstances = [];
        $scope.eC2Types = [];
        $scope.eC2States = [];
        $scope.eC2TypesSortOptions = [];
        $scope.eC2StatesSortOptions = [];
        //Mapped to the model to sort

        $scope.currentPage = 1;
        $scope.pageSize = 2;


        EC2InstanceService.getActiveEc2InstancesByPage($scope.currentPage, $scope.pageSize).success(function (data) {
            $scope.eC2ActiveInstances = data.ElasticCloudViewModel;
            $scope.totalItems = data.Pagination.TotalItems;
            $scope.eC2ActiveInstancesCopy = angular.copy($scope.eC2ActiveInstances);
            $scope.predicate = 'Id';
            $scope.eC2TypesSortOptions = EC2InstanceService.getEc2TypeSortOptions(data.ElasticCloudViewModel);
            $scope.eC2StatesSortOptions = EC2InstanceService.getEc2StateSortOptions(data.ElasticCloudViewModel);
        }).error(function (error) {
            $scope.message = error.Message;
        });

        $scope.filterByType = function (appliedFilter) {
            $scope.eC2ActiveInstances = EC2InstanceService.filterResultsByType($scope.eC2ActiveInstances, appliedFilter);
            $scope.eC2TypesSortOptions = EC2InstanceService.getEc2TypeSortOptions($scope.eC2ActiveInstances);
            $scope.eC2StatesSortOptions = EC2InstanceService.getEc2StateSortOptions($scope.eC2ActiveInstances);
            $scope.open = false;
            $scope.isFilterOn = true;
        };

        $scope.filterByState = function (appliedFilter) {
            $scope.eC2ActiveInstances = EC2InstanceService.filterResultsByState($scope.eC2ActiveInstances, appliedFilter);
            $scope.eC2TypesSortOptions = EC2InstanceService.getEc2TypeSortOptions($scope.eC2ActiveInstances);
            $scope.eC2StatesSortOptions = EC2InstanceService.getEc2StateSortOptions($scope.eC2ActiveInstances);
            $scope.openStateDropdown = false;
            $scope.isFilterOn = true;
        };

        $scope.clearFilters = function () {
            $scope.eC2ActiveInstances = angular.copy($scope.eC2ActiveInstancesCopy);
            $scope.eC2TypesSortOptions = EC2InstanceService.getEc2TypeSortOptions($scope.eC2ActiveInstances);
            $scope.eC2StatesSortOptions = EC2InstanceService.getEc2StateSortOptions($scope.eC2ActiveInstances);
            $scope.openStateDropdown = false;
            $scope.open = false;
            $scope.isFilterOn = false;
        };

        $scope.setPage = function (pageNo) {
            $scope.currentPage = pageNo;
        };

        $scope.pageChanged = function () {
            EC2InstanceService.getActiveEc2InstancesByPage($scope.currentPage, $scope.pageSize).success(function (data) {
                $scope.eC2ActiveInstances = data.ElasticCloudViewModel;
                $scope.totalItems = data.Pagination.TotalItems;
                $scope.eC2ActiveInstancesCopy = angular.copy($scope.eC2ActiveInstances);
                $scope.predicate = 'Id';
                $scope.eC2TypesSortOptions = EC2InstanceService.getEc2TypeSortOptions(data.ElasticCloudViewModel);
                $scope.eC2StatesSortOptions = EC2InstanceService.getEc2StateSortOptions(data.ElasticCloudViewModel);
            }).error(function (error) {
                $scope.message = error.Message;
            });
        };

    }
]);

appControllers.controller('AppCtrl', ['$scope', '$rootScope', '$location', '$window', 'UserService', 'AuthenticationService',
    function AppCtrl($scope, $rootScope, $location, $window, UserService, AuthenticationService) {
        $scope.message = '';
        $scope.logOut = function logOut() {
            if (AuthenticationService.isAuthenticated) {
                AuthenticationService.isAuthenticated = false;
                delete $window.sessionStorage.token;
                $location.path("/admin/login");
            }
            else {
                $location.path("/admin/login");
            }
        }
    }
]);