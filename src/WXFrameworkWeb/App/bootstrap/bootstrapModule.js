'use strick';

angular.module('mBootstrap', []).config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('modal', {
          url: "/modal",
          templateUrl: "App/bootstrap/modal.html",
          controller: "mBootstrap.modalCtrl"
      });
       
});