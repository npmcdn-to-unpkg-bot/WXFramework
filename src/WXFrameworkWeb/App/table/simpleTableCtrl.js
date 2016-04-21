'use strict';

angular.module('mTable')
.controller('mTable.simpleTableCtrl', function ($scope, NgTableParams) {
    console.log(NgTableParams);
    var self = this;
    self.data = [{ name: "Moroni", age: 50 } /*,*/];
    self.tableParams = new NgTableParams({}, { data: self.data });
    self.list = self.data;


});