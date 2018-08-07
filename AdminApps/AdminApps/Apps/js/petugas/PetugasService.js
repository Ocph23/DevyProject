angular.module("petugas.services", [])
    .factory("PetugasDashboardServices", PetugasDashboardServices)
    .factory("PetugasPengaduanServices", PetugasPengaduanServices)
    .factory("PetugasPemasanganServices", PetugasPemasanganServices)
    .factory("PetugasPerubahanServices",PetugasPerubahanServices)
    ;


function PetugasDashboardServices(PetugasPemasanganServices, PetugasPerubahanServices, PetugasPengaduanServices, $q) {
    var def = $q.defer();

    var services = {
        data:{},
        get:get
    };

    function get() {
        setTimeout(function () {
            services.data.Pemasangan = PetugasPemasanganServices.Pemasangan;
            services.data.Perubahan = PetugasPerubahanServices.Perubahan;
            services.data.Pengaduan = PetugasPengaduanServices.Pengaduan;
            def.resolve(services.data);
        }, 2000);
        return def.promise;
    }
    return services;
}


function PetugasPengaduanServices($http, $state,  $q,MessageServices) {
    var def = $q.defer();

    var service = {
        instance: false,
        Pengaduans: [],
        get: get, put: EditItem
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
                service.Pengaduan = service.Pengaduans.length;
                service.instance = true;
                def.resolve(response.data);

            }, function (response) {
                if (response.status = 401)
                    MessageServices.error("Anda Tidak memiliki Hak Akses");
                else
                    MessageServices.error(response.data.Message);
                def.reject();
            });
        } else
            def.resolve(this.Pengaduans);

        return def.promise;
    }

    function EditItem(item) {
        $http({
            method: 'put',
            url: '/Api/PetugasPengaduan?Id=' + item.IdPengaduan,
            data: item,
        }).then(function (response) {
            MessageServices.success("Data Tersimpan");
            def.resolve(response.data);
        }, function (response) {
            if (response.status = 401)
                MessageServices.error("Anda Tidak memiliki Hak Akses");
            else
                MessageServices.error(response.data.Message);
            def.reject();
        });
        return def.promise;
    }
}


function PetugasPemasanganServices($http, $state, $q, MessageServices) {
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
                service.Pemasangan = service.Pemasangans.length;
                service.instance = true;
                def.resolve(response.data);

            }, function (response) {
                if (response.status = 401)
                    MessageServices.error("Anda Tidak memiliki Hak Akses");
                else
                    MessageServices.error(response.data.Message);
               
                def.reject();
            });
        } else
            def.resolve(this.Pengaduans);

        return def.promise;
    }

    

    function EditItem(item) {
        $http({
            method: 'put',
            url: '/Api/PetugasPemasangan?Id=' + item.idpemasangan,
            data: item,
        }).then(function (response) {
            MessageServices.success("Data Tersimpan");
            def.resolve(response.data);
        }, function (response) {
            if (response.status = 401)
                MessageServices.error("Anda Tidak memiliki Hak Akses");
            else
                MessageServices.error(response.data.Message);
            def.reject();
        });
        return def.promise;
    }
}

function PetugasPerubahanServices($http, $q, $state, MessageServices) {
    var def = $q.defer();

    var service = {
        instance: false,
        Perubahans: [],
        get: get, put: EditItem
    }
    service.get();
    return service;

    function get() {
        if (!this.instance) {
            $http({
                method: 'Get',
                url: '/Api/PetugasPerubahan',
            }).then(function (response) {

                angular.forEach(response.data, function (value, index) {
                    service.Perubahans.push(value);
                })
                service.Perubahan = service.Perubahans.length;
                service.instance = true;
                def.resolve(response.data);

            }, function (response) {
                if (response.status = 401)
                    MessageServices.error("Anda Tidak memiliki Hak Akses");
                else
                    MessageServices.error(response.data.Message);
                def.reject();
            });
        } else
            def.resolve(this.Pengaduans);

        return def.promise;
    }



    function EditItem(item) {
        $http({
            method: 'put',
            url: '/Api/PetugasPerubahan?Id=' + item.idpemasangan,
            data: item,
        }).then(function (response) {
            MessageServices.success("Data Tersimpan");
            def.resolve(response.data);
        }, function (response) {
            if (response.status = 401)
                MessageServices.error("Anda Tidak memiliki Hak Akses");
            else
                MessageServices.error(response.data.Message);
            def.reject();
        });
        return def.promise;
    }
}