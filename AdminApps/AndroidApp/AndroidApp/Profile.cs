using SharedApp;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace AndroidApp
{
   public class Profile:BaseNotify
    {
        private byte[] _photoSoucer;
        private ImageSource _photo;
        private string _userName;

        public byte[] PhotoSource {

            get { return _photoSoucer; }
            set
            {
                SetProperty(ref _photoSoucer, value);
                if(value!=null && value.Length>0)
                {
                    LoadPhoto(value);
                }
            }
        }

        private  void LoadPhoto(byte[] value)
        {
            Photo = ImageSource.FromStream(() => new MemoryStream(value));

        }

        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public ImageSource Photo
        {
            get
            {
                if (_photo == null)
                    _photo = ImageSource.FromFile("awesomeuser.png");
                return _photo;
            }
            set
            {
                SetProperty(ref _photo, value);
            }
        }

        public PelangganModel Pelanggan { get;  set; }
    }
}
