angular.module('ngApp')
.config([
    '$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push(['$q', 'toastr', function ($q, toastr) {

            return {

                'request': function (config) {

                    if (config.url.endsWith('.cshtml')) {
                        //if (endsWith(config.url, '.cshtml')) {
                        config.url = 'AppView/Load/App/?viewUrl=/' + config.url;
                    }
                    return config;
                },

                'response': function (response) {
                    return response;
                    /*
                    if (!response.config || !response.config.abp || !response.data) {
                        return response;
                    }

                    var defer = $q.defer();

                    abp.ng.http.handleResponse(response, defer);

                    return defer.promise;
                    */
                },

                'responseError': function (response) {
                    var status = response.status;
                    if (status == 401) {
                        window.location = "./";
                        return;
                    }
                    var msgerr = "";
                    if (response.data.ExceptionMessage) {
                        toastr.error(response.data.ExceptionMessage, "错误");
                        msgerr = response.data.ExceptionMessage;
                    }
                    else {
                        toastr.error(response.data.Message, "错误");
                        msgerr = response.data.Message;
                    }
                    $("#errorInfoDialog").text(msgerr);
                    return $q.reject(response);
                }

            };
        }]);
    }
])
.config(function ($stateProvider, $urlRouterProvider) {
    // For any unmatched url, redirect to /state1
    $urlRouterProvider.otherwise("/basicselect");
})

.run(function (Restangular) {
    Restangular.setBaseUrl("api")
})
.run(function ($rootScope, $location, $state,toastr) {
    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams, options) {
        if ($location.path() == "")
            return;
        if (toState.name == "noauthorization")
            return;
        var ary = $location.url().split("/");
        var url = ary[1];
        for (var i = 0; i <= menuList.length - 1; i++) {
            var menu = menuList[i];
            if (menu.url == "#/" + url) {
                return;
            }
        }
        //$location.path('/noauthorization');
        //toastr.error('没有权限', '错误');

        event.preventDefault();
        $state.go('noauthorization');
    });
});

