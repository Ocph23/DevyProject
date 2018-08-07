using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Models
{
    public class Petugas : DTO.petugas, IBaseModel<Petugas>, IConvertModel<PetugasModel>
    {
        private Domains.PetugasDomain petugasDomain = new Domains.PetugasDomain();

        public PetugasModel ConvertModel()
        {
            return OcphMapper.Mapper.Map<PetugasModel>(this);
        }

        public Task<bool> Delete()
        {
            try
            {

                using (var db = new OcphDbContext())
                {
                    var result = db.Petugas.Delete(O => O.idpetugas == this.idpetugas);
                    if (result)
                        return Task.FromResult(true);
                    else
                        throw new SystemException("Data Tidak Ditemukan");
                }
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }

        public Task<Petugas> GetByUserId()
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.Petugas.Where(O => O.UserId == this.UserId).FirstOrDefault();
                    if (result != null)
                    {
                        var item = new Petugas
                        {
                            Alamat = result.Alamat,
                            Email = result.Email,
                            idpetugas = result.idpetugas,
                            JK = result.JK,
                            Nama = result.Nama,
                            NoKontak = result.NoKontak,
                            UserId = result.UserId
                        };
                        return Task.FromResult(item);


                    }
                    else
                        throw new SystemException("Data Tidak Ditemukan");
                }
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }

        public Task<List<Petugas>> Get()
        {
            try
            {

                using (var db = new OcphDbContext())
                {
                    var result = (from a in db.Petugas.Select()
                                  select OcphMapper.Mapper.Map<Petugas>(a)
                            ).ToList();

                    return Task.FromResult(result);
                }
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }

        public Task<Petugas> GetById()
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.Petugas.Where(O => O.idpetugas == this.idpetugas).FirstOrDefault();
                    if (result != null)
                    {
                        var item = OcphMapper.Mapper.Map<Petugas>(result);
                        return Task.FromResult(item);


                    }
                    else
                        throw new SystemException("Data Tidak Ditemukan");
                }
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }

        public Task<Petugas> SaveChange()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    if (idpetugas <= 0)
                    {
                        idpetugas = db.Petugas.InsertAndGetLastID(this);
                        if (idpetugas > 0)
                            return Task.FromResult(this);
                        else
                            throw new SystemException("Data Tidak Tersimpan");

                    }
                    else
                    {
                        if (db.Petugas.Update(O => new { O.Alamat, O.JK, O.Nama, O.NoKontak }, this, O => O.idpetugas == this.idpetugas))
                            return Task.FromResult(this);
                        else
                            throw new SystemException("Data Tidak Tersimpan");
                    }
                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }

    }
}
