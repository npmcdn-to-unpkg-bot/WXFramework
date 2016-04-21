'use strick';

angular.module('mUpload', []).config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
      .state('fileupload', {
          url: "/fileupload",
          templateUrl: "App/upload/fileupload.cshtml",
          controller: "mUpload.fileUploadCtrl"
      })
      .state('uploadpaneltest', {
          url: "/uploadpaneltest",
          templateUrl: "App/upload/uploadpaneltest.html",
          controller: "mUpload.uploadPanelTestCtrl"
      })
      .state('newfileupload', {
          url: "/newfileupload",
          templateUrl: "App/upload/newfileupload.html",
          controller: "mUpload.newFileUploadCtrl"
      })
      .state('simpleupload', {
          url: "/simpleupload",
          templateUrl: "App/upload/simpleupload.html",
          controller: "mUpload.SimpleUploadCtrl"
      });
});