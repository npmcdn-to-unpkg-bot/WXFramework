angular.module('mJsdraw')
.controller('mJsdraw.jsDrawSimpleCtrl',
 function ($scope, $http, Restangular, jsDrawService) {
     $http.get("api/compound/GetMol").success(function (data) {
         $scope.mol = data;
     });

     var compound = Restangular.all("compound");

     compound.get("GetMol").then(function (data) {
         alert(data);
   
     });

     $scope.showMol = function()
     {

         alert(jsDrawService.getMolfile("mol1"));
         alert(jsDrawService.getMolWeight("mol1"));
     }
 });
