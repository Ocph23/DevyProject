angular.module("petugas.routes", [])
    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.when('/petugas', '/petugas/dashboard');
        $stateProvider
            .state('petugas', {
                abstract: true,
                url: '/petugas',
                templateUrl: '/apps/templates/base.html',
                controller: 'UserController'
            })

            .state('petugas-profile', {
                url: '/profile',
                parent: 'petugas',
                templateUrl: '/apps/templates/petugas/profile.html',
                controller: 'PetugasProfileController'
            })


            .state('petugas-dashboard', {
                url: '/dashboard',
                parent: 'petugas',
                templateUrl: '/apps/templates/petugas/dashboard.html',
                controller: 'PetugasDashboardController'
            })

            .state('petugas-pengaduan', {
                url: '/pengaduan',
                parent: 'petugas',
                templateUrl: '/apps/templates/petugas/pengaduan.html',
                controller: 'PetugasPengaduanController'
            })
          
            .state('petugas-pemasangan', {
                url: '/pemasangan',
                parent: 'petugas',
                templateUrl: '/apps/templates/petugas/pemasangan.html',
                controller: 'PetugasPemasanganController'
            })
            .state('petugas-perubahan', {
                url: '/perubahan',
                parent: 'petugas',
                templateUrl: '/apps/templates/petugas/perubahan.html',
                controller: 'PetugasPerubahanController'
            })

    })




    ;