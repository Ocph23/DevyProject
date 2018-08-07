angular.module("admin.controllers", [])
    .controller('UserController', UserController)
    .controller('DashboardController', DashboardController)
    .controller('PetugasController', PetugasController)
    .controller('PelangganController', PelangganController)
    .controller('PengaduanController', PengaduanController)
    .controller('PemasanganController', PemasanganController)
    .controller('PerubahanController', PerubahanController)
    .controller('LogoutController', LogoutController)
    ;


function UserController($scope,UserServices) {
    UserServices.get().then(function (response) {
        $scope.Profile = response;
    });
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



function PengaduanController($scope, AdminPengaduanServices, AdminPetugasServices) {
    $scope.model = {};
    $scope.Petugas = AdminPetugasServices.Petugas;
    $scope.Pengaduans = AdminPengaduanServices.Pengaduans;
    $scope.EditItem = function (item) {
        $scope.model = item;
    }

    $scope.Save = function (item) {
        if (item.Status == "None")
        {
            item.Status = "Proses";
            item.IdPetugas = item.Petugas.idpetugas;
            AdminPengaduanServices.put(item).then(function (response) { });
        }
    }
  
}

function PemasanganController($scope, AdminPemasanganServices, AdminPetugasServices) {
    $scope.Pemasangans = AdminPemasanganServices.Pemasangans;
    $scope.model = {};
    $scope.Petugas = AdminPetugasServices.Petugas;
    $scope.EditItem = function (item) {
        $scope.model = item;
    }

    $scope.Save = function (item) {
        if (item.Status == "None") {
            item.Status = "Proses";
            item.IdPetugas = item.Petugas.idpetugas;
            AdminPemasanganServices.verify(item).then(function (response) { });
        }
    }
}


function PerubahanController($scope, AdminPerubahanServices, AdminPetugasServices) {
    $scope.Perubahans = AdminPerubahanServices.Perubahans;
    $scope.model = {};
    $scope.Petugas = AdminPetugasServices.Petugas;
    $scope.EditItem = function (item) {
        $scope.model = item;
    }

    $scope.Save = function (item) {
        if (item.Status == "None") {
            item.Status = "Proses";
            item.IdPetugas = item.Petugas.idpetugas;
            AdminPerubahanServices.verify(item).then(function (response) { });
        }
    }

  
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














