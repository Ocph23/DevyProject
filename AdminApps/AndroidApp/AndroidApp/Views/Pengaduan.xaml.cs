using AndroidApp.ViewModels;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Pengaduan : ContentPage
	{
		public Pengaduan ()
		{
			InitializeComponent ();
            BindingContext = new PengaduanViewModel(Navigation);
		}
	}


    public class PengaduanViewModel:BaseViewModel
    {
        private PengaduanModel _model;

        public PengaduanModel Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }

        public PengaduanViewModel(INavigation nav)
        {
            Model = new PengaduanModel();
            Model.WaktuLapor = DateTime.Now;
            NavigationEventArgs = nav;
            ResetCommand = new Command(ResetAction);
            SaveCommand = new Command(SaveAction);
        }

        private async void SaveAction(object obj)
        {
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                var saved = await PengaduanService.AddItemAsync(Model);
                if(saved)
                {
                    Helpers.ShowMessage("Pengaduan Berhasil Dikirim");
                    Model = new PengaduanModel();
                }
            }
            catch (Exception ex)
            {
                Helpers.ShowMessageError(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void ResetAction(object obj)
        {
            Model = new PengaduanModel();
        }

        public INavigation NavigationEventArgs { get; }
        public Command ResetCommand { get; }
        public Command SaveCommand { get; }
    }
}