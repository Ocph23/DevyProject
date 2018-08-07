using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SharedApp.Models
{
    public class PetugasModel:BaseNotify
    {
        public int idpetugas
        {
            get { return _idpetugas; }
            set
            {

                SetProperty(ref _idpetugas, value);
            }
        }

        public string Nama
        {
            get { return _nama; }
            set
            {

                SetProperty(ref _nama, value);
            }
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public Gender JK
        {
            get { return _jk; }
            set
            {

                SetProperty(ref _jk, value);
            }
        }

        public string Alamat
        {
            get { return _alamat; }
            set
            {

                SetProperty(ref _alamat, value);
            }
        }

        public string NoKontak
        {
            get { return _nokontak; }
            set
            {

                SetProperty(ref _nokontak, value);
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {

                SetProperty(ref _email, value);
            }
        }

        public string UserId
        {
            get { return _userid; }
            set
            {

                SetProperty(ref _userid, value);
            }
        }

        public byte[] Foto
        {
            get { return _Foto; }
            set
            {

                SetProperty(ref _Foto, value);
            }
        }

        private int _idpetugas;
        private string _nama;
        private Gender _jk;
        private string _alamat;
        private string _nokontak;
        private string _email;
        private string _userid;
        private byte[] _Foto;
    }
}
