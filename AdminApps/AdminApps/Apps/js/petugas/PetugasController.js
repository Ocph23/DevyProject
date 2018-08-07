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

    $scope.EditItem = function (item) {
        $scope.model = item;
    }
    $scope.Complete = function (item) {
        item.Status = "Selesai";
        PetugasPerubahanServices.put(item);
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
    $scope.Complete = function (item) {
        item.Status = "Selesai";
        item.WaktuSelesai = new Date();
        PetugasPemasanganServices.put(item);
    }

}

function PetugasPengaduanController($scope, PetugasPengaduanServices) {
    $scope.model = {};
    $scope.Pengaduans = PetugasPengaduanServices.Pengaduans;
    $scope.SelectedItem = function (item) {
        $scope.Item = item;
    }

    $scope.Complete = function (item) {
        item.Status = "Selesai";
        item.WaktuSelesai = new Date();
        PetugasPengaduanServices.put(item);
    }
   

}

function PetugasDashboardController($scope, PetugasDashboardServices) {
    $scope.model = PetugasDashboardServices.get().then(function (response) {
        $scope.model= response;
    });  

}

function PetugasProfileController($scope, UserServices,AdminPetugasServices) {
    UserServices.get().then(function (response) {
        $scope.Profile = response;
    });
    $scope.gambar;
    $scope.Save = function (model) {
        getBase64(model);
       
    }

    function getBase64(model) {
        var reader = new FileReader();
        reader.readAsDataURL(model.Photo);
        reader.onload = function () {
            var gambar = reader.result.split(',');
            model.Foto = gambar[1];
            AdminPetugasServices.put(model);
        };
        reader.onerror = function (error) {
            console.log('Error: ', error);
        };
    }


}



function LogoutController($http, $state, $location,$window) {
    var landingUrl = "http://" + $window.location.host + "/home";
    $window.location.href = landingUrl;
}