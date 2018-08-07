using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
using SharedApp;

namespace AdminLib.DTO 
{ 
     [TableName("petugas")] 
     public class petugas : Ocph.DAL.BaseNotify
    {
          [PrimaryKey("idpetugas")] 
          [DbColumn("idpetugas")] 
          public int idpetugas 
          { 
               get{return _idpetugas;} 
               set{ 

                    SetProperty(ref _idpetugas, value);
                     }
          } 

          [DbColumn("Nama")] 
          public string Nama 
          { 
               get{return _nama;} 
               set{ 

                    SetProperty(ref _nama, value);
                     }
          } 

          [DbColumn("JK")] 
          public Gender JK 
          { 
               get{return _jk;} 
               set{ 

                    SetProperty(ref _jk, value);
                     }
          } 

          [DbColumn("Alamat")] 
          public string Alamat 
          { 
               get{return _alamat;} 
               set{ 

                    SetProperty(ref _alamat, value);
                     }
          } 

          [DbColumn("NoKontak")] 
          public string NoKontak 
          { 
               get{return _nokontak;} 
               set{ 

                    SetProperty(ref _nokontak, value);
                     }
          } 

          [DbColumn("Email")] 
          public string Email 
          { 
               get{return _email;} 
               set{ 

                    SetProperty(ref _email, value);
                     }
          } 

          [DbColumn("UserId")] 
          public string UserId 
          { 
               get{return _userid;} 
               set{ 

                    SetProperty(ref _userid, value);
                     }
          }
        [DbColumn("Foto")]
        public byte[] Foto
        {
            get { return _Foto; }
            set
            {

                SetProperty(ref _Foto, value);
            }
        }
        private int  _idpetugas;
           private string  _nama;
           private Gender  _jk;
           private string  _alamat;
           private string  _nokontak;
           private string  _email;
           private string  _userid;
        private byte[] _Foto;
    }
}


