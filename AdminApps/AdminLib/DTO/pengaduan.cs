using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
using SharedApp;

namespace AdminLib.DTO 
{ 
     [TableName("pengaduan")] 
     public class pengaduan : Ocph.DAL.BaseNotify
    {
          [PrimaryKey("IdPengaduan")] 
          [DbColumn("IdPengaduan")] 
          public int IdPengaduan 
          { 
               get{return _idpengaduan;} 
               set{ 

                    SetProperty(ref _idpengaduan, value);
                     }
          }

        [DbColumn("IdPelanggan")]
        public int IdPelanggan
        {
            get { return _idpelanggan; }
            set
            {

                SetProperty(ref _idpelanggan, value);


            }
        }

          [DbColumn("Pengaduan")] 
          public string Pengaduan 
          { 
               get{return _pengaduan;} 
               set{ 

                    SetProperty(ref _pengaduan, value);
                     }
          } 

          [DbColumn("WaktuLapor")] 
          public DateTime WaktuLapor 
          { 
               get{return _waktulapor;} 
               set{ 

                    SetProperty(ref _waktulapor, value);
                     }
          } 

          [DbColumn("WaktuSelesai")] 
          public DateTime WaktuSelesai 
          { 
               get{return _waktuselesai;} 
               set{ 

                    SetProperty(ref _waktuselesai, value);
                     }
          } 

          [DbColumn("Status")] 
          public Status Status 
          { 
               get{return _status;} 
               set{ 

                    SetProperty(ref _status, value);
                     }
          } 

          [DbColumn("IdPetugas")] 
          public int? IdPetugas 
          { 
               get{return _idpetugas;} 
               set{ 

                    SetProperty(ref _idpetugas, value);
                     }
          } 

          private int  _idpengaduan;
           private string  _pengaduan;
           private DateTime  _waktulapor;
           private DateTime  _waktuselesai;
           private Status  _status;
           private int?  _idpetugas;
        private int _idpelanggan;
    }
}


