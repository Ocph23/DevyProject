using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SharedApp.Models
{
    public class PemasanganModel : BaseNotify
    {

        public int idpemasangan
        {
            get { return _idpemasangan; }
            set
            {

                SetProperty(ref _idpemasangan, value);
            }
        }

        public string Peruntukan
        {
            get { return _peruntukan; }
            set
            {

                SetProperty(ref _peruntukan, value);
            }
        }

        public int Daya
        {
            get { return _daya; }
            set
            {

                SetProperty(ref _daya, value);
            }
        }

        public string NoGardu
        {
            get { return _nogardu; }
            set
            {

                SetProperty(ref _nogardu, value);
            }
        }


        [JsonConverter(typeof(StringEnumConverter))]
        public JenisTarif JenisTarif
        {
            get { return _jenistarif; }
            set
            {

                SetProperty(ref _jenistarif, value);
            }
        }

        public double Tarif
        {
            get { return _tarif; }
            set
            {

                SetProperty(ref _tarif, value);
            }
        }

        public double UangJaminan
        {
            get { return _uangjaminan; }
            set
            {

                SetProperty(ref _uangjaminan, value);
            }
        }

        public double Biaya
        {
            get { return _biaya; }
            set
            {

                SetProperty(ref _biaya, value);
            }
        }

        public int StatusUbah
        {
            get { return _statusubah; }
            set
            {

                SetProperty(ref _statusubah, value);
            }
        }

        public int IdPelanggan
        {
            get { return _idpelanggan; }
            set
            {

                SetProperty(ref _idpelanggan, value);
            }
        }


        [JsonConverter(typeof(StringEnumConverter))]
        public JenisPemasangan JenisPemasangan
        {
            get { return _jenisPemangsangan; }
            set { SetProperty(ref _jenisPemangsangan, value); }
        }

        public PetugasModel Petugas
        {
            get { return _petugas; }
            set {SetProperty(ref  _petugas , value); }
        }

        public int? IdPetugas
        {
            get { return _idpetugas; }
            set
            {

                SetProperty(ref _idpetugas, value);
            }
        }




        public PelangganModel Pelanggan
        {
            get { return _pelanggan; }
            set { _pelanggan = value; }
        }

        private PetugasModel _petugas;
        private PelangganModel _pelanggan;
        private int _idpemasangan;
        private string _peruntukan;
        private int _daya;
        private string _nogardu;
        private JenisTarif _jenistarif;
        private double _tarif;
        private double _uangjaminan;
        private double _biaya;
        private int _statusubah;
        private int _idpelanggan;
        private JenisPemasangan _jenisPemangsangan;
        private int? _idpetugas;

       
    }
}
