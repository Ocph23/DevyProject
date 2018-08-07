using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocph.DAL;
using SharedApp;

namespace AdminLib.DTO
{
    [TableName("pelanggan")]
    public class pelanggan : Ocph.DAL.BaseNotify
    {
        [PrimaryKey("IdPelanggan")]
        [DbColumn("IdPelanggan")]
        public int IdPelanggan
        {
            get { return _idpelanggan; }
            set
            {

                SetProperty(ref _idpelanggan, value);
            }
        }

        [DbColumn("Nama")]
        public string Nama
        {
            get { return _nama; }
            set
            {

                SetProperty(ref _nama, value);
            }
        }

        [DbColumn("JK")]
        public Gender JK
        {
            get { return _jk; }
            set
            {

                SetProperty(ref _jk, value);
            }
        }

        [DbColumn("Alamat")]
        public string Alamat
        {
            get { return _alamat; }
            set
            {

                SetProperty(ref _alamat, value);
            }
        }

        [DbColumn("NoIdentitas")]
        public string NoIdentitas
        {
            get { return _noidentitas; }
            set
            {

                SetProperty(ref _noidentitas, value);
            }
        }

        [DbColumn("ScanIdentitas")]
        public byte[] ScanIdentitas
        {
            get { return _scanidentitas; }
            set
            {

                SetProperty(ref _scanidentitas, value);
            }
        }



        [DbColumn("NoKontak")]
        public string NoKontak
        {
            get { return _nokontak; }
            set
            {

                SetProperty(ref _nokontak, value);
            }
        }

        [DbColumn("Email")]
        public string Email
        {
            get { return _email; }
            set
            {

                SetProperty(ref _email, value);
            }
        }

        [DbColumn("IdUser")]
        public string IdUser
        {
            get { return _iduser; }
            set
            {

                SetProperty(ref _iduser, value);
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

        [DbColumn("Verification")]
        public bool Verification
        {
            get { return _Verification; }
            set
            {

                SetProperty(ref _Verification, value);
            }
        }

        private int _idpelanggan;
        private string _nama;
        private Gender _jk;
        private string _alamat;
        private string _noidentitas;
        private byte[] _scanidentitas;
        private string _nokontak;
        private string _email;
        private string _iduser;
        private byte[] _Foto;
        private bool _Verification;
    }
}


