using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using AndroidApp.Models;
using AndroidApp.Services;
using SharedApp.Models;

namespace AndroidApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private static AccountService _loginServices;

        public static IDataStore<PemasanganModel> PemasanganService => DependencyService.Get<IDataStore<PemasanganModel>>() ?? new PemasanganServices();
        public static IDataStore<PemasanganModel> PerubahanService => DependencyService.Get<IDataStore<PemasanganModel>>() ?? new PerubahanServices();
        public static IDataStore<PengaduanModel> PengaduanService => DependencyService.Get<IDataStore<PengaduanModel>>() ?? new PengaduanServices();

        public static AccountService AccountServices
        {
            get
            {
                if (_loginServices == null)
                    _loginServices = new AccountService();
                return _loginServices;
            }
        }

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
       
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
