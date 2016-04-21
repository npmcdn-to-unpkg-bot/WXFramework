//var EditEmployeeCtrl = function ($scope, $http, $timeout, $routeParams, notificationFactory, $location, $route, badge, opt) {
angular.module('mBootstrap')
    .controller('mBootstrap.editEmployeeCtrl', function ($scope, $http, onSuc) {
        console.log($scope);
        $scope.isPost = true;
        $scope.saveinfo = function () {
            alert("aaa");
            $scope.$hide();
            onSuc();
        }
    });