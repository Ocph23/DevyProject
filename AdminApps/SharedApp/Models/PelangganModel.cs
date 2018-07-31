using AdminLib.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedApp.Models
{
    public class PelangganModel : BaseNotify, IConvertModel<Pelanggan>
    {
        public Pelanggan ConvertModel()
        {
            return new Pelanggan
            {
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


        public int IdPelanggan
        {
            get { return _idpelanggan; }
            set
            {

                SetProperty(ref _idpelanggan, value);
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

        public string NoIdentitas
        {
            get { return _noidentitas; }
            set
            {

                SetProperty(ref _noidentitas, value);
            }
        }

        public string ScanIdentitas
        {
            get { return _scanidentitas; }
            set
            {

                SetProperty(ref _scanidentitas, value);
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
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email
        {
            get { return _email; }
            set
            {

                SetProperty(ref _email, value);
            }
        }

        public string IdUser
        {
            get { return _iduser; }
            set
            {

                SetProperty(ref _iduser, value);
            }
        }

      

        private int _idpelanggan;
        private string _nama;
        private Gender _jk;
        private string _alamat;
        private string _noidentitas;
        private string _scanidentitas;
        private string _nokontak;
        private string _email;
        private string _iduser;
       
    }
}

