
var app = angular.module('WeatherApp', []);

(function () {
	//controller to get countries
	angular.module('WeatherApp').controller('weatherController', ['$scope', 'countriesService', 'citiesService', 'weatherService',
		function weatherController($scope, countriesService, citiesService, weatherService) {
			var countries = function () {
				countriesService.getCountries().then(onCountriesComplete, onError);
			};
			var onCountriesComplete = function (data) {
				$scope.countries = data;
				$scope.hide = true;
			};

			var onError = function (error) {
				$scope.error = "There has been an error, " + error;
			};
			$scope.option = $scope.countries;
			$scope.selectAction = function () {
				$scope.country = $scope.selectedCountry;
				onCountryChange();
			};

			var onCountryChange = function () {
				citiesService.getCities($scope.country.code).then(OnCitiesComplete, OnErrorCity);
				$scope.hide = true;
			};
			var OnCitiesComplete = function (data) {
				$scope.cities = data;
			};

			var OnErrorCity = function (error) {
				$scope.error = "There has been an error, " + error;
			};

			$scope.optionCity = $scope.cities;
			$scope.selectCityAction = function () {
				$scope.city = $scope.selectedCity;
				onCityChange();
			};

			var onCityChange = function () {
				weatherService.getWeatherDetails($scope.city.name, $scope.country.code).then(OnWeatherComplete, OnErrorWeather);
				$scope.hide = true;
			};
			var OnWeatherComplete = function (data) {
				$scope.weather = data;
				$scope.hide = false;
			};

			var OnErrorWeather = function (error) {
				$scope.error = "There has been an error, " + error;
			};

			countries();
		}]);
}());