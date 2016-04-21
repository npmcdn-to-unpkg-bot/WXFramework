


var UploadPanelCtrl = function ($scope, $http) {
  
    //alert($scope.folder);
   
    $scope.$watch('FileFolder', function (value) {
        if (value == undefined)
            return;

        if (value == null)
            return;

        $scope.FetchData();

    });
   
    $scope.FileFolder = $scope.folder;
    $scope.FetchData = function () {
        //console.log("fetch");
        var url = "Ashx/UploadHandler.ashx?FileFolder=" + $scope.FileFolder;
        $scope.loadingFiles = true;
        $scope.options = {
            url: url
        };

        $http.get(url)
    .then(
        function (response) {
            $scope.loadingFiles = false;
            $scope.queue = response.data || [];
        },
        function () {
            $scope.loadingFiles = false;
        }
    );
    }
}


var FileDestroyController = function ($scope, $http) {
    
    var file = $scope.file,
                    state;
    if (file.url) {
        file.$state = function () {
            return state;
        };
        file.$destroy = function () {
            state = 'pending';
            return $http({
                url: file.delete_url,   //Url,
                method: file.delete_type //Type
            }).then(
                            function () {
                                state = 'resolved';
                                $scope.clear(file);
                            },
                            function () {
                                state = 'rejected';
                            }
                        );
        };
    } else if (!file.$cancel && !file._index) {
        file.$cancel = function () {
            $scope.clear(file);
        };
    }
}

angular.module('wx.uploadPanel', [])
.directive("uploadPanel", function () {
    return {
        scope:{
            folder:"@"
        },
        restrict: 'AE',
        templateUrl: 'App/component/uploadpanel.html'
    };
})
.controller("UploadPanelCtrl", UploadPanelCtrl)
.controller("FileDestroyController", FileDestroyController)


