'use strict';

angular.module('mFactorys', [])
    .factory('downloadFile', function () {
        return {
            downloadStaticFile: function (fileName) {
                var iframe = document.createElement("iframe");
                iframe.setAttribute("src", fileName);
                iframe.setAttribute("style", "display: none");
                document.body.appendChild(iframe);
            }

        };
    });

