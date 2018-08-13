using AndroidApp.ViewModels;
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
	public partial class Home : ContentPage
	{
		public Home ()
		{
			InitializeComponent ();
            this.BindingContext = new HomeViewModel();
		}

        
    }


    public class HomeViewModel :BaseViewModel
    {
        public HomeViewModel()
        {
            LoadAsync();
        }
        private async void LoadAsync()
        {
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                await Task.Delay(5000);
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