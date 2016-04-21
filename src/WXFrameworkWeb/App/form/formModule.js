'use strick';

angular.module('mForm', []).config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('date', {
          url: "/date",
          templateUrl: "App/form/date.cshtml",
          controller: function ($scope) {
              //$scope.items = ["A", "List", "Of", "Items"];
          }
      })
       .state('testuser', {
           url: "/testuser",
           templateUrl: "App/form/testuser.cshtml",
           controller: "mForm.testUserCtrl"
       })
      .state('tab', {
          url: "/tab",
          templateUrl: "App/form/tab.cshtml",
          controller: function ($scope) {
              //$scope.items = ["A", "List", "Of", "Items"];
          }
      })
         .state('element', {
             url: "/element",
             templateUrl: "App/form/form_elements.html",
             controller: "'mForm.formDemoCtrl"
         });
});