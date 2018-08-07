angular.module("admin.services", [])
    .factory("AdminDashboard",AdminDashboard)
    .factory("AdminPelangganServices", AdminPelangganServices)
    .factory("AdminPengaduanServices", AdminPengaduanServices)
    .factory("AdminPemasanganServices", AdminPemasanganServices)
    .factory("AdminPerubahanServices", AdminPerubahanServices)
    .factory("AdminPetugasServices", AdminPetugasServices)
    ;


function AdminDashboard($http, $q) {
    var def = $q.defer();
    var service = {
        instance: false,
        Data:{},
        get: get
    };

    function get() {
        if (!this.instance) {
            $http({
                method: 'Get',
                url: '/Api/AdminDashboard',
            }).then(function (response) {
                service.Data = response.data;

                service.instance = true;
                def.resolve(response.data);

            }, function (response) {
                if (response.status = 404)
                    alert("Anda Tidak memiliki Hak Akses");
                def.reject();
            });
        } else
            def.resolve(this.Data);

        return def.promise;
    }

    service.get();
    return service;
}

function AdminPelangganServices($http, $q) {
    var def = $q.defer();
    var service = {
        instance:false,
        Pelanggans:[],
        get:get,verify:verify
    };

    function get() {
        if (!this.instance) {
            $http({
                method: 'Get',
                url: '/Api/AdminPelanggan',
            }).then(function (response) {

                angular.forEach(response.data, function (value, index) {
                    service.Pelanggans.push(value);
                })

                service.instance = true;
                def.resolve(response.data);

            }, function (response) {
                if (response.status = 404)
                    alert("Anda Tidak memiliki Hak Akses");
                def.reject();
            });
        } else
            def.resolve(this.Pelanggans);

        return def.promise;
    }


    function verify() {

    }

    service.get();
    return service;

}

function AdminPengaduanServices($http, $q) {
    var def = $q.defer();
    var service = {
        instance: false,
        Pengaduans: [],
        get: get, verify: verify
    };

    function get() {
        if (!this.instance) {
            $http({
                method: 'Get',
                url: '/Api/AdminPengaduan',
            }).then(function (response) {

                angular.forEach(response.data, function (value, index) {
                    service.Pengaduans.push(value);
                })

                service.instance = true;
                def.resolve(response.data);

            }, function (response) {
                if (response.status = 404)
                    alert("Not Found Link");
                else
                    alert(response.data);
                def.reject();
            });
        } else
            def.resolve(this.Pengaduans);

        return def.promise;
    }


    function verify() {

    }

    service.get();
    return service;
}


function AdminPemasanganServices($http, $q) {
    var def = $q.defer();
    var service = {
        instance: false,
        Pemasangans: [],
        get: get, verify: verify
    };

    function get() {
        if (!this.instance) {
            $http({
                method: 'Get',
                url: '/Api/AdminPemasangan',
            }).then(function (response) {

                angular.forEach(response.data, function (value, index) {
                    service.Pemasangans.push(value);
                })

                service.instance = true;
                def.resolve(response.data);

            }, function (response) {
                if (response.status = 404)
                    alert("Not Found Link");
                else
                    alert(response.data);
                def.reject();
            });
        } else
            def.resolve(this.Pemasangans);

        return def.promise;
    }


    function verify() {

    }

    service.get();
    return service;
}


function AdminPerubahanServices($http, $q) {
    var def = $q.defer();
    var service = {
        instance: false,
        Perubahans: [],
        get: get, verify: verify
    };

    function get() {
        if (!this.instance) {
            $http({
                method: 'Get',
                url: '/Api/AdminPerubahan',
            }).then(function (response) {

                angular.forEach(response.data, function (value, index) {
                    service.Pengaduans.push(value);
                })

                service.instance = true;
                def.resolve(response.data);

            }, function (response) {
                if (response.status = 404)
                    alert("Not Found Link");
                else
                    alert(response.data);
                def.reject();
            });
        } else
            def.resolve(this.Perubahans);

        return def.promise;
    }


    function verify() {

    }

    service.get();
    return service;
}


function AdminPetugasServices($http,$q) {
    var def = $q.defer();
    var service = {
        instance: false,
        Petugas: [],
        get: get, verify: verify, post: post, put: put, delete: deleteItem
    };

    function get() {
        if (!this.instance) {
            $http({
                method: 'Get',
                url: '/Api/AdminPetugas',
            }).then(function (response) {
                angular.forEach(response.data, function (value, index) {
                    service.Petugas.push(value);
                })
                service.instance = true;
                def.resolve(response.data);

            }, function (response) {
                if (response.status = 404)
                    alert("Not Found Link");
                else
                    alert(response.data);
                def.reject();
            });
        } else
            def.resolve(this.Petugas);

        return def.promise;
    }

    function post(model) {
        $http({
            method: 'post',
            url: '/Api/AdminPetugas',data:model
        }).then(function (response) {
            service.Petugas.push(response.data);
            alert("Data Tersimpan");
            service.instance = true;
            def.resolve(response.data);

        }, function (response) {
            alert(response.data);
            def.reject();
            });


        return def.promise;
    }

    function put(model) {
        $http({
            method: 'put',
            url: '/Api/AdminPetugas?Id='+model.idpetugas, data: model
        }).then(function (response) {
            service.Petugas.push(response.data);
            alert("Data Tersimpan");
            service.instance = true;
            def.resolve(response.data);

        }, function (response) {

            alert(response.data.Message);
            def.reject();
        });


        return def.promise;
    }

    function deleteItem(model) {
        $http({
            method: 'delete',
            url: '/Api/AdminPetugas?Id=' + model.idpetugas
        }).then(function (response) {
            var index = service.Petugas.indexOf(model, 1);
            service.Petugas.splice(index, 1);
            alert("Data Terhapus");
            service.instance = true;
            def.resolve(response.data);

        }, function (response) {

            alert(response.data.Message);
            def.reject();
        });


        return def.promise;
    }



    function verify() {

    }

    service.get();
    return service;
}