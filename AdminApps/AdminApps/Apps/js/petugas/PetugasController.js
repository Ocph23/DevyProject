angular.module("petugas.controllers", [])
    .controller('PetugasPengaduanController', PetugasPengaduanController)
    .controller('PetugasPemasanganController', PetugasPemasanganController)
    .controller('PetugasPerubahanController', PetugasPerubahanController)
    .controller('PetugasDashboardController', PetugasDashboardController)
    ;



function PetugasPerubahanController() { }

function PetugasPemasanganController($scope, PetugasPemasanganServices) {
    $scope.Pemasangans = PetugasPemasanganServices.Pemasangans;

}

function PetugasPengaduanController($scope, PetugasPengaduanServices) {
    $scope.Pengaduans = PetugasPengaduanServices.Pengaduans;
}

function PetugasDashboardController() { }