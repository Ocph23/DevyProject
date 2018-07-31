angular.module("admin.controllers", [])
    .controller('UserController', UserController)
    .controller('DashboardController', DashboardController)
    .controller('PetugasController', PetugasController)
    .controller('PelangganController', PelangganController)
    .controller('PengaduanController', PengaduanController)
    .controller('PemasanganController', PemasanganController)
    .controller('UsersController', UsersController)
    ;


function UserController() {

}




function DashboardController() {

}


function PetugasController($scope, AdminPetugasServices) {
    $scope.Petugas = AdminPetugasServices.Petugas;
}



function PelangganController($scope, AdminPelangganServices) {
    $scope.Pelanggans = AdminPelangganServices.Pelanggans;
}



function PengaduanController($scope, AdminPengaduanServices) {
    $scope.Pengaduans = AdminPengaduanServices.Pengaduans;
}

function PemasanganController($scope, AdminPemasanganServices) {
    $scope.Pemasangans = AdminPemasanganServices.Pemasangans;
}


function UsersController() {

}