using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Models
{
    public class Pemasangan : DTO.pemasangan, IBaseModel<Pemasangan>, IConvertModel<PemasanganModel>
    {
        public Pemasangan() { }
        public Pemasangan(int id)
        {
            this.idpemasangan = id;
        }

        public Petugas Petugas { get; internal set; }
        public Pelanggan Pelanggan { get; internal set; }

        public PemasanganModel ConvertModel()
        {
            return OcphMapper.Mapper.Map<PemasanganModel>(this);
        }

        public Task<bool> Delete()
        {

            using (var db = new OcphDbContext())
            {
                try
                {
                    if (db.Pemasangan.Delete(O => O.idpemasangan == idpemasangan))
                        return Task.FromResult(true);
                    else
                        throw new SystemException("Data Tidak Terhapus");

                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }
            }
        }

        public Task<List<Pemasangan>> Get()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var result = (from a in db.Pemasangan.Select().AsEnumerable()
                                join b in db.Pelanggan.Select() on a.IdPelanggan equals b.IdPelanggan
                                 select new Pemasangan
                                 {
                                     Biaya = a.Biaya, JenisPemasangan=a.JenisPemasangan, 
                                     Daya = a.Daya, IdPetugas=a.IdPetugas,
                                     IdPelanggan = a.IdPelanggan,
                                     idpemasangan = a.idpemasangan,
                                     JenisTarif = a.JenisTarif,
                                     NoGardu = a.NoGardu,
                                     Pelanggan = new Pelanggan
                                     {
                                         Alamat = b.Alamat,
                                         Email = b.Email, IdPelanggan = b.IdPelanggan, IdUser = b.IdUser, JK = b.JK,
                                         Nama = b.Nama, NoIdentitas = b.NoIdentitas, NoKontak = b.NoKontak, ScanIdentitas = b.ScanIdentitas
                                     },
                                     Peruntukan = a.Peruntukan,
                                     StatusUbah = a.StatusUbah,
                                     Tarif = a.Tarif,
                                     UangJaminan = a.UangJaminan,

                                     
                                 }).ToList();
                    foreach(var item in result)
                    {
                        if(item.IdPetugas!=null && item.IdPetugas>0)
                        {
                            var p = db.Petugas.Where(O => O.idpetugas == item.IdPetugas).FirstOrDefault();
                            item.Petugas = OcphMapper.Mapper.Map<Petugas>(p);
                        }
                    }

                    return Task.FromResult(result);

                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }

        public Task<Pemasangan> GetById()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var result = (from a in db.Pemasangan.Where(O=>O.idpemasangan==idpemasangan)
                                 join b in db.Pelanggan.Select() on a.IdPelanggan equals b.IdPelanggan
                                 select new Pemasangan
                                 {
                                     Biaya = a.Biaya,
                                     Daya = a.Daya,
                                     IdPelanggan = a.IdPelanggan,
                                     idpemasangan = a.idpemasangan,
                                     JenisTarif = a.JenisTarif,
                                     NoGardu = a.NoGardu,
                                     Pelanggan = new Pelanggan
                                     {
                                         Alamat = b.Alamat,
                                         Email = b.Email,
                                         IdPelanggan = b.IdPelanggan,
                                         IdUser = b.IdUser,
                                         JK = b.JK,
                                         Nama = b.Nama,
                                         NoIdentitas = b.NoIdentitas,
                                         NoKontak = b.NoKontak,
                                         ScanIdentitas = b.ScanIdentitas
                                     },
                                     Peruntukan = a.Peruntukan,
                                     StatusUbah = a.StatusUbah,
                                     Tarif = a.Tarif,
                                     UangJaminan = a.UangJaminan
                                 }).FirstOrDefault();
                    if (result == null)
                        throw new SystemException("Data Tidak Ditemukan");
                    else
                    {
                        if (result.IdPetugas != null && result.IdPetugas > 0)
                        {
                            var p = db.Petugas.Where(O => O.idpetugas == result.IdPetugas);
                            result.Petugas = OcphMapper.Mapper.Map<Petugas>(p);
                        }

                    }

                    return Task.FromResult(result);



                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }

        public Task<Pemasangan> SaveChange()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    if (idpemasangan<= 0)
                    {
                        idpemasangan = db.Pemasangan.InsertAndGetLastID(this);
                        if (idpemasangan <= 0)
                            throw new SystemException("Data Tidak Tersimpan");
                    }
                    else
                    {
                        if (!db.Pemasangan.Update(O => new { O.IdPetugas, O.Biaya, O.Daya, O.IdPelanggan,O.JenisTarif,O.NoGardu,O.Peruntukan,O.StatusUbah,O.Tarif,O.UangJaminan}, this, O => O.idpemasangan== idpemasangan))
                            throw new SystemException("Data Tidak Tersimpan");
                    }

                    return Task.FromResult(this);
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }

            }
        }
    }
}
