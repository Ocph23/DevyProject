﻿using AdminLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedApp.Models
{
    public class PemasanganModel : BaseNotify, IConvertModel<Pemasangan>
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

        public string JenisTarif
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

      

        public Petugas Petugas
        {
            get { return _petugas; }
            set {SetProperty(ref  _petugas , value); }
        }



     

        public Pelanggan Pelanggan
        {
            get { return _pelanggan; }
            set { _pelanggan = value; }
        }

        private Petugas _petugas;
        private Pelanggan _pelanggan;
        private int _idpemasangan;
        private string _peruntukan;
        private int _daya;
        private string _nogardu;
        private string _jenistarif;
        private double _tarif;
        private double _uangjaminan;
        private double _biaya;
        private int _statusubah;
        private int _idpelanggan;

        public Pemasangan ConvertModel()
        {
            return new Pemasangan
            {
                Pelanggan=Pelanggan,
                Biaya = Biaya,
                Daya = Daya, 
                Petugas = Petugas,
                IdPelanggan = IdPelanggan,
                idpemasangan = idpemasangan,
                JenisTarif = JenisTarif,
                NoGardu = NoGardu,
                Peruntukan = Peruntukan,
                StatusUbah = StatusUbah,
                Tarif = Tarif,
                UangJaminan = UangJaminan
            };
        }
    }
}
