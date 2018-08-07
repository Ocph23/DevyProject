angular.module("admin.controllers", [])
    .controller('UserController', UserController)
    .controller('DashboardController', DashboardController)
    .controller('PetugasController', PetugasController)
    .controller('PelangganController', PelangganController)
    .controller('PengaduanController', PengaduanController)
    .controller('PemasanganController', PemasanganController)
    .controller('LogoutController', LogoutController)
    ;


function UserController() {

}




function DashboardController($scope, AdminDashboard) {
    AdminDashboard.get().then(function (response) {

        $scope.Data = response;
    });
}


function PetugasController($scope, AdminPetugasServices) {
    $scope.model={};
    $scope.Petugas = AdminPetugasServices.Petugas;

    $scope.Save = function (model) {
        if (model.idpetugas == undefined)
            AdminPetugasServices.post(model).then(function (response) { });
        else
            AdminPetugasServices.put(model).then(function (response) { });
    }

    $scope.EditItem = function (item) {
        $scope.model = item;
    }

    $scope.DeleteItem = function (model) {
        AdminPetugasServices.delete(model).then(function (response) {

        });
    }
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


function LogoutController($http, $state, $location) {
    $http({
        method: 'post',
        url: '/account/logoff',
    }).then(function (response) {
        
    }, function (response) {
        alert("Error");
    });
    $location("/home");
}














