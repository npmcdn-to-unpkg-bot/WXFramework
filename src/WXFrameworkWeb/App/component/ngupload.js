angular.module('wx.ngUpload', [])
.directive('ngUpload', ['$parse', 'cfpLoadingBar', 'toastr',
function ($parse, cfpLoadingBar, toastr) {
    return {
        restrict: 'AE',
        scope:{
            success :'&onSuccess'
        },
        link: function (scope, element, attrs, controller) {
            element.fileupload({
                dataType: 'json',
                start: function () {
                    cfpLoadingBar.start();
                },
                done: function (e, data) {
                    cfpLoadingBar.complete();
    
                    if (data.result.length == 0 )
                        toastr.info("", "上传成功");
                    else
                        toastr.info("", data.result[0]);
                    if (scope.success)
                        scope.success();
                },
                fail: function (e, data) {
                    cfpLoadingBar.complete();
                    toastr.error("", JSON.parse(data.jqXHR.responseText).ExceptionMessage);
                }

            });
        }
    };
} ]);