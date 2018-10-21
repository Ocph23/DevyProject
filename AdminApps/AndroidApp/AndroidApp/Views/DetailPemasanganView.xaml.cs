using AndroidApp.ViewModels;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPemasanganView : ContentPage
	{
		public DetailPemasanganView ()
		{
			InitializeComponent ();

            BindingContext = new DetailPemasanganViewModel(Navigation);
		}
	}

    public class DetailPemasanganViewModel:BaseViewModel
    {
        public PemasanganModel Model { get => _pemasangan; set => SetProperty(ref _pemasangan, value); }
        private INavigation navigation;
        private PemasanganModel _pemasangan;
        public Command RefreshCommand { get; }

        public DetailPemasanganViewModel(INavigation nav)
        {
            navigation = nav;
            RefreshCommand = new Command(RefreshAction);
            RefreshCommand.Execute(null);
        }

        private async void RefreshAction(object obj)
        {
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                var result = await PemasanganService.GetItemsAsync();

                Model = result.FirstOrDefault();
                if (Model!=null && Model.Petugas != null && !string.IsNullOrEmpty(Model.Petugas.Nama))
                    Model.ShowPetugas = true;

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
        
    }



}