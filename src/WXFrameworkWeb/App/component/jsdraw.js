angular.module('wx.jsDraw', [])
.factory("jsDrawService", function () {
    return {
        getMolfile: function (id) {
            var editor = JSDraw.get(id);
            return editor.getMolfile(false);
        },
        getMolWeight: function (id) {
            var editor = JSDraw.get(id);
            return editor.getMolWeight();
        }
    };
})
.directive('jsDraw', ['$timeout',
function ($timeout) {
    return {
        restrict: 'AE',
        require: '?ngModel',
        link: function (scope, element, attrs, controller) {
            var options = {};
            var opts = angular.extend({}, options, scope.$eval(attrs.jsDraw));
            function guid() {
                function s4() {
                    return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
                }
                return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
s4() + '-' + s4() + s4() + s4();
            }

            var newId = guid();
            if (opts.idMode == "static")
            {
                newId = element.attr("id");
            }
            else
            {
                element.attr("id", newId);
            }

            var fn = function (ep) {
                if (controller) {
                    if (scope.$$phase || scope.$root.$$phase) {
                        return;
                    }
                    scope.$apply(
                        function () {
                            controller.$setViewValue(ep.getMolfile(false));
                        }
                    );
                }
            };

            if (controller) {
                controller.$render = function () {
                    var editor = JSDraw.get(newId);
                    if (editor) {
                        editor.setMolfile(controller.$viewValue);
                    }
                }
            }

            $timeout(function () {
                var obj = null;
                if (controller && controller.$viewValue) {
                    obj = controller.$viewValue;
                }
                JSDraw.create(newId, { dataformat: "molfile", skin: "w8", data: obj, ondatachange: fn });
                controller.$render();
            });
        }
    };
}
]);