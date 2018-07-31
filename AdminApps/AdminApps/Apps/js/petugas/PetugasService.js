angular.module("petugas.services", [])
    .factory("PetugasDashboardServices", PetugasDashboardServices)
    .factory("PetugasPengaduanServices", PetugasPengaduanServices)
    .factory("PetugasPemasanganServices", PetugasPemasanganServices)
    .factory("PetugasPerubahanServices",PetugasPerubahanServices)
    ;


function PetugasDashboardServices() {
    var services = {};
    return services;
}


function PetugasPengaduanServices($http, $state,  $q) {
    var def = $q.defer();

    var service = {
        instance: false,
        Pengaduans: [],
        get: get, post: post, delete: deleteItem, put: EditItem
    }
    service.get();
    return service;

    function get() {
        if (!this.instance) {
            $http({
                method: 'Get',
                url: '/Api/PetugasPengaduan',
            }).then(function (response) {

                angular.forEach(response.data, function (value, index) {
                    service.Pengaduans.push(value);
                })

                service.instance = true;
                def.resolve(response.data);

            }, function (response) {
                if (response.status = 404)
                    $state.go('login');
                def.reject();
            });
        } else
            def.resolve(this.Pengaduans);

        return def.promise;
    }

    function post(data) {
        $http({
            method: 'Post',
            url: '/Api/PetugasPengaduan',
            data: data,
        }).then(function (response) {
            service.Pengaduans.push(response.data);
            def.resolve(response.data);
        }, function (response) {
            def.reject();
            if (response.status = 404)
                $state.go('login');

        });
        return def.promise;
    }


    function deleteItem(item) {
        $http({
            method: 'delete',
            url: '/Api/PetugasPengaduan?Id=' + item.Id,
            data: item,
        }).then(function (response) {
            var index = service.Pengaduans.indexOf(item, 1);
            service.Pengaduans.splice(index, 1);
            def.resolve(response.data);
        }, function (response) {
            alert("Data Tidak Terhapus");
            def.reject();
        });
        return def.promise;
    }

    function EditItem(item) {
        $http({
            method: 'put',
            url: '/Api/PetugasPengaduan?Id=' + item.Id,
            data: item,
        }).then(function (response) {
            alert("Data Tersimpan");
            def.resolve(response.data);
        }, function (response) {
            alert("Data Tidak Tersimpan");
            def.reject();
        });
        return def.promise;
    }
}


function PetugasPemasanganServices($http,$state,$q) {
    var def = $q.defer();

    var service = {
        instance: false,
        Pemasangans: [],
        get: get, put: EditItem
    }
    service.get();
    return service;

    function get() {
        if (!this.instance) {
            $http({
                method: 'Get',
                url: '/Api/PetugasPemasangan',
            }).then(function (response) {

                angular.forEach(response.data, function (value, index) {
                    service.Pemasangans.push(value);
                })

                service.instance = true;
                def.resolve(response.data);

            }, function (response) {
                if (response.status = 404)
                    $state.go('login');
                def.reject();
            });
        } else
            def.resolve(this.Pengaduans);

        return def.promise;
    }

    

    function EditItem(item) {
        $http({
            method: 'put',
            url: '/Api/PetugasPengaduan?Id=' + item.Id,
            data: item,
        }).then(function (response) {
            alert("Data Tersimpan");
            def.resolve(response.data);
        }, function (response) {
            alert("Data Tidak Tersimpan");
            def.reject();
        });
        return def.promise;
    }
}

function PetugasPerubahanServices() {

}