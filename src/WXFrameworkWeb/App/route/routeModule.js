'use strick';

angular.module('mRoute', []).config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('state1', {
          url: "/state1",
          templateUrl: "App/route/state1.html"
      })
      .state('state1.list', {
          url: "/list",
          templateUrl: "App/route/state1.list.html",
          controller: function ($scope) {
              $scope.items = ["A", "List", "Of", "Items"];
          }
      })
      .state('state1.list2', {
          url: "/list2",
          templateUrl: "App/route/state2.list.html",
          controller: function ($scope) {
            $scope.items = ["A", "List", "Of", "Items2"];
          }
      })
      .state('state2', {
          url: "/state2",
          templateUrl: "App/route/state2.html"
      })
      .state('state2.list', {
          url: "/list",
          templateUrl: "App/route/state2.list.html",
          controller: function ($scope) {
              $scope.things = ["A", "Set", "Of", "Things"];
          }
      });
});