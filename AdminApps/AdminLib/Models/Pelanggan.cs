using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Models
{
    public class Pelanggan : DTO.pelanggan, IBaseModel<Pelanggan>, IConvertModel<PelangganModel>
    {

        public Pelanggan(int id)
        {
            IdPelanggan = id;
        }

        public Pelanggan() { }

        public PelangganModel ConvertModel()
        {
            return new PelangganModel {
                Alamat = Alamat,
                Email = Email,
                IdPelanggan = IdPelanggan,
                IdUser = IdUser,
                JK = JK,
                Nama = Nama,
                NoIdentitas = NoIdentitas,
                NoKontak = NoKontak,
                ScanIdentitas = ScanIdentitas
            };
        }

        public Task<bool> Delete()
        {
            throw new NotImplementedException();
        }

        public Task<List<Pelanggan>> Get()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var result = db.Pelanggan.Select();
                    var list = new List<Pelanggan>();
                   foreach(var item in result)
                    {
                        list.Add(OcphMapper.Mapper.Map<Pelanggan>(item));
                    }
                    return Task.FromResult(list);
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }
            }
        }

        public Task<Pelanggan> GetById()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var result = db.Pelanggan.Where(O=>O.IdPelanggan==IdPelanggan).FirstOrDefault();
                    if (result != null)
                        return Task.FromResult(OcphMapper.Mapper.Map<Pelanggan>(result));
                    else
                        throw new SystemException("Data Tidak Ditemukan");
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }
            }
        }

        public Task<Pelanggan> SaveChange()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    if(IdPelanggan<=0)
                    {
                        IdPelanggan = db.Pelanggan.InsertAndGetLastID(this);
                        if (IdPelanggan <= 0)
                            throw new SystemException("Data Tidak Tersimpan");
                       
                    }else
                    {
                        if (!db.Pelanggan.Update(O => new { O.Alamat,O.Foto,O.JK,O.Nama,O.NoIdentitas,O.NoKontak,O.ScanIdentitas,O.Verification },this,O=>O.IdPelanggan==IdPelanggan))
                        {
                            throw new SystemException("Data Tidak Tersimpan");
                        }
                    }

                    return Task.FromResult(this as Pelanggan);
                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }
    }
}
