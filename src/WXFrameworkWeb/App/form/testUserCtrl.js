angular.module('mForm')
.controller('mForm.testUserCtrl',
 function ($scope, $http,$state) {


     $scope.setUser = function () {
         $http.get("api/User/ChangeRole?roleID=" + $scope.roleID).success(function (data) {
            
             //$state.go($state.$current, null, { reload: true });
             //$state.reload();
             //var rootUrl = window.location.origin + "/" + "ResourceUtilWeb/";
             //window.location.href = rootUrl;
         });
     }
 });