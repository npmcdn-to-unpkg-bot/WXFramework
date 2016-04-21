
angular.module('mUpload')
.controller('mUpload.newFileUploadCtrl', function ($scope, $http, Upload, $timeout) {
    // upload later on form submit or something similar
    $scope.files = [];

    $scope.addFiles = function (files) {
        angular.forEach(files, function (file) {
            file.submit = false;
            file.processing = false;
            $scope.files.push(file);
        });

    }

    $scope.removeFile = function(index) {
        $scope.files.splice(index, 1);
    }

    $scope.deleteFile = function (fileName,index) {
        $http.get("api/file/delete?filename="+fileName).success(function () {
            $scope.files.splice(index, 1);
        });
    }


    $scope.cancelUpload = function () {
        upload.abort();
    }

    $scope.uploadFiles = function () {
        var files = $scope.files;
        angular.forEach(files, function (file) {
            $scope.uploadFile(file);
        });
    }


    $scope.uploadFile = function (file) {
        
        if (file) {
            file.upload = Upload.upload({
                url: 'api/upload/PostFileNew',
                data: { file: file }
            });
            file.processing = true;
            file.upload.then(function (response) {
                $timeout(function () {
                    //console.log(response);
                    file.url = response.data.url;
                    file.submited = true;
                    file.processing = false;
                    //file.state = "submit" 
                });
            }, function (response) {
                if (response.status > 0)
                    file.error = response.status + ': ' + response.data;
             
                file.processing = false;
            }, function (evt) {
                file.progress = Math.min(100, parseInt(100.0 *
                                         evt.loaded / evt.total));
            });

            file.upload.catch(function (er) { console.log(er) });
        }
    }


});
