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
	public partial class DetailPengaduanView : ContentPage
	{
		public DetailPengaduanView ()
		{
			InitializeComponent ();
            BindingContext = new DetailPemasanganViewModel(Navigation);
		}
	}

    public class DetailPengaduanViewModel:BaseViewModel
    {
        private INavigation navigation;
        public ObservableCollection<PengaduanModel> Source { get; set; }
        public Command RefreshCommand { get; }

        public DetailPengaduanViewModel(INavigation nav)
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
                Source.Clear();
                var result = await PengaduanService.GetItemsAsync();
                foreach (var item in result)
                {
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