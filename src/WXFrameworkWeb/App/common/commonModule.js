'use strick';

angular.module('mCommon', []).config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('noauthorization', {
          url: "/noauthorization",
          templateUrl: "App/common/noauthorization.html"
      });
});