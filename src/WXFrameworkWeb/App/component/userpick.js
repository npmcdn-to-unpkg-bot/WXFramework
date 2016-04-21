angular.module('wx.userPick', [])
.directive('userPick', function () {
    return {
        restrict: 'EA', 
        require: '^ngModel',
        scope: {
            ngModel: '=',
        },
        templateUrl: 'App/component/userpick.html',
        controller: function ($http) {
            var vm = this;
            this.refreshUsers = function (s) {
                //badge handle
                if (s.length > 0)
                {
                    var reg = /^\d+$/;
                    if (s.match(reg)||s[0]=="T")
                    {
                        if (s.length <= 4)
                            return;
                    }

                }
                var params = { searchText: s };
                return $http.get(
                  'api/user/searchUser/',
                  { params: params }
                ).success(function (response) {
                    vm.users = response;
                });
            };
        },
        controllerAs: 'vm'
    }
});