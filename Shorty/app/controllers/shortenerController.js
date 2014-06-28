app.controller('shortenerController', function ($scope, $http) {
    $scope.shorten = function (longUrl) {
        $http.post("/", { 'UrlToShorten': longUrl })
            .success(function (response) {
                $scope.longUrl = "http://localhost:25040/" + response["absolouteIdentifier"];
            })
            .error(function () {
                alert("Whops. The server is unavailable at this time.");
            });
    };
});