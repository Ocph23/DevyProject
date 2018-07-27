using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
 
 namespace AdminLib.DTO 
{ 
     [TableName("pemasangan")] 
     public class pemasangan :BaseNotify  
   {
          [PrimaryKey("idpemasangan")] 
          [DbColumn("idpemasangan")] 
          public int idpemasangan 
          { 
               get{return _idpemasangan;} 
               set{ 

                    SetProperty(ref _idpemasangan, value);
                     }
          } 

          [DbColumn("Peruntukan")] 
          public string Peruntukan 
          { 
               get{return _peruntukan;} 
               set{ 

                    SetProperty(ref _peruntukan, value);
                     }
          } 

          [DbColumn("Daya")] 
          public int Daya 
          { 
               get{return _daya;} 
               set{ 

                    SetProperty(ref _daya, value);
                     }
          } 

          [DbColumn("NoGardu")] 
          public string NoGardu 
          { 
               get{return _nogardu;} 
               set{ 

                    SetProperty(ref _nogardu, value);
                     }
          } 

          [DbColumn("JenisTarif")] 
          public string JenisTarif 
          { 
               get{return _jenistarif;} 
               set{ 

                    SetProperty(ref _jenistarif, value);
                     }
          } 

          [DbColumn("Tarif")] 
          public double Tarif 
          { 
               get{return _tarif;} 
               set{ 

                    SetProperty(ref _tarif, value);
                     }
          } 

          [DbColumn("UangJaminan")] 
          public double UangJaminan 
          { 
               get{return _uangjaminan;} 
               set{ 

                    SetProperty(ref _uangjaminan, value);
                     }
          } 

          [DbColumn("Biaya")] 
          public double Biaya 
          { 
               get{return _biaya;} 
               set{ 

                    SetProperty(ref _biaya, value);
                     }
          } 

          [DbColumn("StatusUbah")] 
          public int StatusUbah 
          { 
               get{return _statusubah;} 
               set{ 

                    SetProperty(ref _statusubah, value);
                     }
          } 

          [DbColumn("IdPelanggan")] 
          public int IdPelanggan 
          { 
               get{return _idpelanggan;} 
               set{ 

                    SetProperty(ref _idpelanggan, value);
                     }
          }


        [DbColumn("IdPetugas")]
        public int IdPetugas
        {
            get { return _idpetugas; }
            set
            {

                SetProperty(ref _idpetugas, value);
            }
        }

        private int  _idpemasangan;
           private string  _peruntukan;
           private int  _daya;
           private string  _nogardu;
           private string  _jenistarif;
           private double  _tarif;
           private double  _uangjaminan;
           private double  _biaya;
           private int  _statusubah;
           private int  _idpelanggan;
        private int _idpetugas;
    }
}


