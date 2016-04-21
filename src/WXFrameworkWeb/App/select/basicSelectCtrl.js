angular.module('mSelect')
.controller('mSelect.basicSelectCtrl',
 function ($scope, $http, $timeout, $interval, toastr) {

     toastr.success('Hello world!', 'Toastr fun!');
     $scope.itemArray = [
        { id: 1, name: 'first' },
        { id: 2, name: 'second' },
        { id: 3, name: 'third' },
        { id: 4, name: 'fourth' },
        { id: 5, name: 'fifth' },
     ];

     $scope.selected = { value: $scope.itemArray[0] };

     $scope.empTypeList = ["一般", "文艺", "2B"];

     $scope.emp = {};
     $scope.user1 = {};
     $scope.user2 = {};

     $scope.showMsg = function () {

         /*
         var user = Restangular.all("user");
         user.customGet(obj, "pageuser").then(function (data) {
             params.total(data.total);
             return data.result;
         })
         */
         $http.get("api/user/ShowError").success(
                function (data) {
                    
                });
     }



     //$scope.FileFolder = "test99";

 });