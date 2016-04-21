'use strict';

angular.module('mTable')
.controller('mTable.listUserCtrl', function ($scope, $http, $q, NgTableParams,Restangular, downloadFile) {
    $scope.qInfor = {};

    $scope.tableParams = new NgTableParams(
    
        {
        page: 1,            // show first page
        count: 10,          // count per page
        sorting: {
            badge: 'asc'     // initial sorting
        }
    },
        {
            total: 0,           // length of data
            getData: function (params) {
                /*
                var d = $q.defer();
                var obj = _.extend($scope.qInfor,
                {
                    Page: params.page(),
                    ItemsPerPage: params.count(),
                    OrderBy: params.orderBy()
                });

                $http.post("api/user/pageuser", obj).success(
                function (data) {
                    params.total(data.total);
                    d.resolve(data.result);
                    console.log(data.result);
                });
                return d.promise;
                */
                var obj = _.extend($scope.qInfor,
                    {
                        Page: params.page(),
                        ItemsPerPage: params.count(),
                        OrderBy: params.orderBy()
                    });

                var user = Restangular.all("user");

                return user.customPOST(obj, "pageuser").then(function (data) {
                    params.total(data.total);
                    return data.result;
                })
                

            }
        });

    $scope.search = function () {
        $scope.tableParams.reload();

    }

    $scope.exportData = function () {
   
        $http.post('api/user/export', $scope.qInfor)
        .success(function (data) {
            downloadFile.downloadStaticFile(data);
        });
       
    }
});