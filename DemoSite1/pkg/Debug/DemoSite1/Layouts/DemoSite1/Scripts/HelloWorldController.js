var app = angular.module('app.demo', []);

app.controller('HelloWorldController', [
    '$scope', function ($scope) {
        $scope.name = '';
        $scope.message = 'Hello, World!!';
    }
]);