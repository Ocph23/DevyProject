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
	public partial class PemasanganView : ContentPage
	{
		public PemasanganView ()
		{
			InitializeComponent ();
            BindingContext = new PemasanganViewModel(Navigation);
		}
	}


    public class PemasanganViewModel : BaseViewModel
    {
        private PemasanganModel _model;

        public PemasanganModel Model
        {
            get { return _model; }
            set { SetProperty(ref _model, value); }
        }

        public PemasanganViewModel(INavigation nav)
        {
            Model = new PemasanganModel();
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
                var saved = await PemasanganService.AddItemAsync(Model);
                if (saved)
                {
                    Helpers.ShowMessage("Permohonan Pemasangan Berhasil Dikirim");
                    ResetCommand.Execute(null);
                    var app = await Helpers.GetMainPageAsync();
                    if(app!=null)
                    {
                        app.SetCurrenttarget("Pemasangan");
                    }
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