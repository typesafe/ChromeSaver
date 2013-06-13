(function (angular) {

	var texts = [
		'challange',
		'communication',
		'expertise',
		'feedback',
		'kpis',
		'learn',
		'listen',
		'mission',
		'ownership',
		'proactive',
		'simplify',
		'think-business',
		'trust',
		'coach',
		'solve'
	];

	var app = angular.module('App', []);

	app.directive('bg', ['$timeout', function ($timeout) {
		return {
			restrict: 'C',
			link: function (scope, el, attrs) {
				$timeout(function () {
					el.css('opacity', 0.5);
				}, 10000);
			}
		};
	} ]);

	app.controller('MainController', ['$scope', '$timeout', function ($scope, $timeout) {

		var i = -1;
		var c = 0;
		$scope.currentText = texts[i];
		$scope.opacity = 1;
		$scope.animationClass = null;

		$scope.getStyle = function (item) {
			if (item <= c) {
				return { opacity: 1 };
			}
			return {};
		};

		$scope.getAnimation = function (item) {
			if (item <= c) return 'fadeInUpBig';
		};

		var count = function () {
			$timeout(function () {
				c++;
				count();
			}, 2000);
		};

		var iterate = function () {
			$timeout(function () {
				c = 0;
				if (++i == texts.length) {
					i = 0;
				}
				$scope.currentText = texts[i];
				iterate();
			}, 10000);
		};

		iterate();
		count();
	} ]);

})(window.angular);