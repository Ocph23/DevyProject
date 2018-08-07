'use strict';
angular.module('admin.routes', [])
    .config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.when('/admin', '/admin/dashboard');
        $stateProvider
            .state('admin', {
                abstract: true,
                url: '/admin',
                templateUrl: '/apps/templates/base.html',
                controller: 'UserController'
            })
            .state('admin-dashboard', {
                url: '/dashboard',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/dashboard.html',
                controller: 'DashboardController'
            })
            .state('admin-profile', {
                url: '/profile',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/profile.html',
                controller: 'PetugasProfileController'
            })

            .state('admin-petugas', {
                url: '/petugas',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/petugas.html',
                controller: 'PetugasController'
            })
            .state('admin-pengaduan', {
                url: '/pengaduan',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/pengaduan.html',
                controller: 'PengaduanController'
            })
            .state('admin-pemasangan', {
                url: '/pemasangan',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/pemasangan.html',
                controller: 'PemasanganController'
            })
            .state('admin-pelanggan', {
                url: '/pelanggan',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/pelanggan.html',
                controller: 'PelangganController'
            })
            .state('admin-perubahan', {
                url: '/perubahan',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/perubahan.html',
                controller: 'PerubahanController'
            })
            .state('logout', {
                url: '/logout',
                parent: 'admin',
                controller: 'LogoutController'
            })



    })
   ;