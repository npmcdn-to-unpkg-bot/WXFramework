angular.module('mBootstrap')
.controller('mBootstrap.modalCtrl',
 function ($scope, $http, $modal) {
     // Show a basic modal from a controller
    var myModal = $modal({ title: 'My Title', template: 'App/bootstrap/dialog.html', show: false });

     // Pre-fetch an external template populated with a custom scope
    var myOtherModal = $modal({ scope: $scope, templateUrl: 'App/bootstrap/dialog.html', show: false });
     // Show when some event occurs (use $promise property to ensure the template has been loaded)
     $scope.showModal = function () {
         myOtherModal.$promise.then(myOtherModal.show);
     }

     $scope.modal = {
         "title": "Title",
         "content": "Hello Modal<br />This is a multiline message!"
     };


     var employeeModal = $modal({ scope: $scope, templateUrl: 'App/bootstrap/editemployee.html', show: false, controller: "mBootstrap.editEmployeeCtrl",
         locals: {onSuc:function(){alert("suc")}} });


     $scope.showEmployee = function () {
         // employeeModal.$promise.then(employeeModal.show);
         console.log(employeeModal);



         employeeModal.$promise.then(employeeModal.show);
        
        
     }

 });