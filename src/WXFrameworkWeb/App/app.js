'use strict';


if (typeof String.prototype.endsWith !== 'function') {
    String.prototype.endsWith = function (suffix) {
        return this.indexOf(suffix, this.length - suffix.length) !== -1;
    };
}



angular.module('ngApp', [
  'ngSanitize',
  //'ngAnimate',
  'oc.lazyLoad',
  'ui.router',
  'ui.select',
  'blueimp.fileupload',
  'ngTable',
  'toastr',
  'restangular',
  'angular-loading-bar',
  'ngFileUpload',
  'mgcrea.ngStrap',
  'wx.userPick',
  'wx.jsDraw',
  'wx.uploadPanel',
  'wx.ngUpload',


  'mFactorys',
  'mCommon',
  'mRoute',

  'mSelect',
  'mTable',
  'mForm',
  'mJsdraw',
  'mUpload',
  'mBootstrap'
]);
