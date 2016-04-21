'use strick';

angular.module('mJsdraw', []).config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('jsdrawsimple', {
          url: "/jsdrawsimple",
          templateUrl: "App/jsdraw/jsdrawsimple.cshtml",
          controller: 'mJsdraw.jsDrawSimpleCtrl',
          resolve: {
              dojoReady: function ($q, $timeout) {
                  var deferred = $q.defer();
                  dojo.ready(function() {
                      deferred.resolve(true);
                  });
                  return deferred.promise;
              }
          }
      });
      
});