
angular.module('mUpload')
.controller('mUpload.fileUploadCtrl', function ($scope, $http, Upload, $timeout) {
    $scope.uploadFiles = function (file, errFiles) {
        $scope.f = file;
        $scope.errFile = errFiles && errFiles[0];
        if (file) {
            file.upload = Upload.upload({
                url: 'api/upload/PostFile',
                data: { file: file }
            });

            file.upload.then(function (response) {
                $timeout(function () {
                    file.result = response.data;
                });
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            }, function (evt) {
                file.progress = Math.min(100, parseInt(100.0 *
                                         evt.loaded / evt.total));
            });

            file.upload.catch(function (er) { console.log(er) });
        }
    }
});
					
					
/*
 function ($scope, $http, Upload, $timeout) {
     $scope.uploadFiles = function (files, errFiles) {
         $scope.files = files;
         $scope.errFiles = errFiles;
         angular.forEach(files, function (file) {
             file.upload = Upload.upload({
                 url: 'api/upload/PostFile',
                 data: { file: file }
             });

             file.upload.then(function (response) {
                 $timeout(function () {
                     file.result = response.data;
                 });
             }, function (response) {
                 if (response.status > 0)
                     $scope.errorMsg = response.status + ': ' + response.data;
             }, function (evt) {
                 file.progress = Math.min(100, parseInt(100.0 *
                                          evt.loaded / evt.total));
             });
         });
     }

 }*/
// );
