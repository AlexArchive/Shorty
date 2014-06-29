app.controller('shortenerController', function ($scope, $http, $location) {
    $scope.shorten = function (longUrl) {

        //avoid redirect loop
        var thisDomainName = $location.protocol() + "://" + $location.host() + ":" + $location.port();
        if (longUrl.indexOf(thisDomainName) == 0) {
            alert("This URL cannot be shortened. Please try another one.");
            return;
        }

        $http.post("/", { 'longUrl': longUrl })
            .success(function (response) {
                $scope.longUrl = "http://localhost:25040/" + response["absolouteIdentifier"];
            })
            .error(function () {
                alert("Whops. The server is unavailable at this time.");
            });
    };
});