namespace SkinApp {

    angular.module('SkinApp', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: SkinApp.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: SkinApp.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: SkinApp.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: SkinApp.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: SkinApp.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            })
            .state('build', {
                url: '/build',
                templateUrl: '/ngApp/views/build.html',
                controller: SkinApp.Controllers.BuildController,
                controllerAs: 'controller'
            })
            .state('profile', {
                url: '/profile',
                templateUrl: '/ngApp/views/profile.html',
                controller: SkinApp.Controllers.UserController,
                controllerAs: 'controller'
            })
            .state('forum', {
                url: '/forum',
                templateUrl: '/ngApp/views/forum.html',
                controller: SkinApp.Controllers.ForumController,
                controllerAs: 'controller'
            })
            .state('edit', {
                url: '/forum/edit/:id',
                templateUrl: '/ngApp/views/edit.html',
                controller: SkinApp.Controllers.ForumEditController,
                controllerAs: 'controller'
            })
            .state('new', {
                url: '/forum/new',
                templateUrl: '/ngApp/views/newPost.html',
                controller: SkinApp.Controllers.ForumCreateController,
                controllerAs: 'controller'
            })
            .state('details', {
                url: '/forum/:id',
                templateUrl: '/ngApp/views/details.html',
                controller: SkinApp.Controllers.ForumDetailsController,
                controllerAs: 'controller'
            })
            .state("delete", {
                url: '/forum/delete/:id',
                templateUrl: '/ngApp/views/delete.html',
                controller: SkinApp.Controllers.ForumEditController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: SkinApp.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('admin', {
                url: '/admin',
                templateUrl: '/ngApp/views/admin.html',
                controller: SkinApp.Controllers.AdminController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });


    //angular.module('SkinApp').factory('authInterceptor', (
    //    $q: ng.IQService,
    //    $window: ng.IWindowService,
    //    $location: ng.ILocationService
    //) =>
    //    ({
    //        request: function (config) {
    //            config.headers = config.headers || {};
    //            config.headers['X-Requested-With'] = 'XMLHttpRequest';
    //            return config;
    //        },
    //        responseError: function (rejection) {
    //            if (rejection.status === 401 || rejection.status === 403) {
    //                $location.path('/login');
    //            }
    //            return $q.reject(rejection);
    //        }
    //    })
    //);

    //angular.module('SkinApp').config(function ($httpProvider) {
    //    $httpProvider.interceptors.push('authInterceptor');
    //});



}
