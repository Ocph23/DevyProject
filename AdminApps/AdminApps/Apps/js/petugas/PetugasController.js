angular.module("petugas.controllers", [])
    .controller('PetugasPengaduanController', PetugasPengaduanController)
    .controller('PetugasPemasanganController', PetugasPemasanganController)
    .controller('PetugasPerubahanController', PetugasPerubahanController)
    .controller('PetugasDashboardController', PetugasDashboardController)
    .controller('PetugasProfileController', PetugasProfileController)
    .controller('LogoutController', LogoutController)
    ;



function PetugasPerubahanController($scope, PetugasPerubahanServices) {
    $scope.Perubahans = PetugasPerubahanServices.Perubahans;
    $scope.SelectedItem = function (item) {
        $scope.Item = item;
    }

}

function PetugasPemasanganController($scope, PetugasPemasanganServices) {
    $scope.model = {};
    $scope.Pemasangans = PetugasPemasanganServices.Pemasangans;
    $scope.SelectedItem = function (item) {
        $scope.Item = item;
    }

    $scope.EditItem = function (item) {
        $scope.model = item;
    }

}

function PetugasPengaduanController($scope, PetugasPengaduanServices) {
    $scope.model = {};
    $scope.Pengaduans = PetugasPengaduanServices.Pengaduans;
    $scope.SelectedItem = function (item) {
        $scope.Item = item;
    }

   
   

}

function PetugasDashboardController() { }

fun

function LogoutController($http, $state, $location,$window) {
    var landingUrl = "http://" + $window.location.host + "/home";
    $window.location.href = landingUrl;
}