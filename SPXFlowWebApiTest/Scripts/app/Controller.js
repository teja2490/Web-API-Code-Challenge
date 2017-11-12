var ProductControllers = angular.module("ProductControllers", []);
// this controller call the api method and display the list of employees  
// in list.html  
ProductControllers.controller("ListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('http://localhost:13300/api/Product').success(function (data) {
            $scope.product = data;
            console.log(data);
        });
    }
]);


