'use strick';

angular.module('mSelect', []).config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('select', {
          url: "/select",
          templateUrl: "App/select/select.cshtml",
          controller: 'mSelect.selectCtrl'
      })
       .state('basicselect', {
           url: "/basicselect",
           templateUrl: "App/select/basicselect.cshtml",
           controller: 'mSelect.basicSelectCtrl'
       });
});