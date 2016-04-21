'use strick';

angular.module('mTable', []).config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('listUser', {
          url: "/listuser",
          templateUrl: "App/table/listuser.cshtml",
          controller: 'mTable.listUserCtrl'
      })
      .state('colvisibility', {
          url: "/colvisibility",
          templateUrl: "App/table/colvisibility.cshtml",
          controller: 'demoController',
          controllerAs: "demo"
      })
      .state('simpletable', {
          url: "/simpletable",
          templateUrl: "App/table/simpletable.cshtml",
          controller: 'mTable.simpleTableCtrl',
           controllerAs: "vm"
       })
});