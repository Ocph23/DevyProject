using AndroidApp.ViewModels;
using SharedApp;
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
	public partial class PerubahanView : ContentPage
	{
		public PerubahanView ()
		{
			InitializeComponent ();
            BindingContext = new PerubahanViewModel(Navigation);
		}
	}

    public class PerubahanViewModel:BaseViewModel
    {
        private PemasanganModel _model;
        public List<JenisPemasangan> Items { get; set; }
        public PemasanganModel Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }

        public PerubahanViewModel(INavigation nav)
        {
            Model = new PemasanganModel();
            Items = new List<JenisPemasangan>();
            Items.Add(JenisPemasangan.UbahDaya);
            Items.Add(JenisPemasangan.UbahTarif);
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
                var saved = await PerubahanService.AddItemAsync(Model);
                if (saved)
                {
                    Helpers.ShowMessage("Permohonan Perubahan Berhasil Dikirim");
                    ResetCommand.Execute(null);
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
            Model = new PemasanganModel();
        }

        public INavigation NavigationEventArgs { get; }
        public Command ResetCommand { get; }
        public Command SaveCommand { get; }
    }
}