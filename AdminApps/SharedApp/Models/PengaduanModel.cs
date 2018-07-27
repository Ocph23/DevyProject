﻿using AdminLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedApp.Models
{
  public  class PengaduanModel:BaseNotify, IConvertModel<Pengaduan>
    {
        public int IdPengaduan
        {
            get { return _idpengaduan; }
            set
            {

                SetProperty(ref _idpengaduan, value);
            }
        }

        public string Pengaduan
        {
            get { return _pengaduan; }
            set
            {

                SetProperty(ref _pengaduan, value);
            }
        }

        public DateTime WaktuLapor
        {
            get { return _waktulapor; }
            set
            {

                SetProperty(ref _waktulapor, value);
            }
        }

        public DateTime WaktuSelesai
        {
            get { return _waktuselesai; }
            set
            {

                SetProperty(ref _waktuselesai, value);
            }
        }

        public PengaduanStatus Status
        {
            get { return _status; }
            set
            {

                SetProperty(ref _status, value);
            }
        }

        public int IdPetugas
        {
            get { return _idpetugas; }
            set
            {

                SetProperty(ref _idpetugas, value);
            }
        }

        public Petugas Petugas { get; set; }

        private int _idpengaduan;
        private string _pengaduan;
        private DateTime _waktulapor;
        private DateTime _waktuselesai;
        private PengaduanStatus _status;
        private int _idpetugas;

        public Pengaduan ConvertModel()
        {
            return new Pengaduan {
                 IdPengaduan=IdPengaduan, IdPetugas=IdPetugas, Pengaduan=Pengaduan, Petugas=this.Petugas,
                  Status=Status, WaktuLapor=WaktuLapor, WaktuSelesai=WaktuSelesai
            };
        }
    }
}
