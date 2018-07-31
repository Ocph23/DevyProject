'use strict';
angular.module('admin.routes', [])
    .config(function ($stateProvider) {
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
            .state('admin-perubahann', {
                url: '/perubahan',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/perubahan.html',
                controller: 'PerubahanController'
            })
            .state('admin-users', {
                url: '/users',
                parent: 'admin',
                templateUrl: '/apps/templates/admin/users.html',
                controller: 'UsersController'
            })



    })
   ;