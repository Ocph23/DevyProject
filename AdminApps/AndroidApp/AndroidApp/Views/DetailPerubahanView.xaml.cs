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
	public partial class DetailPerubahanView : ContentPage
	{
		public DetailPerubahanView ()
		{
			InitializeComponent ();
            BindingContext = new DetailPerubahanViewModel(Navigation);
		}
	}

    public class DetailPerubahanViewModel:BaseViewModel
    {
        private INavigation navigation;
        public ObservableCollection<PemasanganModel> Source { get; set; }
        public Command RefreshCommand { get; }

        public DetailPerubahanViewModel(INavigation nav)
        {
            navigation = nav;
            Source = new ObservableCollection<PemasanganModel>();
            RefreshCommand = new Command(RefreshAction);
            RefreshCommand.Execute(null);
        }

        private async void RefreshAction(object obj)
        {
            await Task.Delay(1000);
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                Source.Clear();
                var result = await PerubahanService.GetItemsAsync();
                int nomor = 0;
                foreach (var item in result)
                {
                    nomor++;
                    item.StatusUbah = nomor;
                    if (item.Petugas != null && !string.IsNullOrEmpty(item.Petugas.Nama))
                        item.ShowPetugas = true;
                    Source.Add(item);
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

    }
}