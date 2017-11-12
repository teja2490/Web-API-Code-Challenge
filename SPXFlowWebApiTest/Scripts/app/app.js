var ProductApp = angular.module('ProductApp', ['ngRoute', 'ProductControllers']);
ProductApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/list',
    {
        templateUrl: "/Product/list",
        controller: "ListController"
    }).
        when('/Review',
    {
        templateUrl: 'Product/Review.html',
        controller: 'ListController'
    }).
    when('/create',
    {
        templateUrl: 'Product/edit.html',
        controller: 'EditController'
    }).
    when('/edit/:id',
    {
        templateUrl: 'Product/edit.html',
        controller: 'EditController'
    }).
    when('/delete/:id',
    {
        templateUrl: 'Product/delete.html',
        controller: 'DeleteController'
    }).
    otherwise(
    {
        redirectTo: '/list'
    });
}]);