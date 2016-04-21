﻿


'use strict';

angular.module('mTable')
.factory("ngTableSimpleList",function () {
    return [{"id":1,"name":"Nissim","age":41,"money":454},{"id":2,"name":"Mariko","age":10,"money":-100},{"id":3,"name":"Mark","age":39,"money":291},{"id":4,"name":"Allen","age":85,"money":871},{"id":5,"name":"Dustin","age":10,"money":378},{"id":6,"name":"Macon","age":9,"money":128},{"id":7,"name":"Ezra","age":78,"money":11},{"id":8,"name":"Fiona","age":87,"money":285},{"id":9,"name":"Ira","age":7,"money":816},{"id":10,"name":"Barbara","age":46,"money":44},{"id":11,"name":"Lydia","age":56,"money":494},{"id":12,"name":"Carlos","age":80,"money":193}];
})
.controller('demoController', function (NgTableParams, ngTableSimpleList) {
   
    var self = this;
    self.tableParams = new NgTableParams({}, {
        data: ngTableSimpleList
    });

    self.cols = [
    { field: "name", title: "Name", show: true },
    { field: "age", title: "Age", show: true },
    { field: "money", title: "Money", show: true }
    ];
});