using AndroidApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidApp.Views.Accounts
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RequestChangePassword : ContentPage
	{
		public RequestChangePassword ()
		{
			InitializeComponent ();
            BindingContext = new RequestChangePasswordViwModel(Navigation);
		}
	}

	public class RequestChangePasswordViwModel:BaseViewModel
	{
		private INavigation navigation;

		public Command RequestCommand { get; }
		public Command BackCommand { get; }

		private string email;

		public string Email
		{
			get { return email; }
			set { SetProperty(ref email ,value); }
		}


		public RequestChangePasswordViwModel(INavigation nav)
		{
			navigation = nav;
			RequestCommand = new Command(RequestAction);
			BackCommand = new Command(BacAction);

		}

		private void BacAction(object obj)
		{
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                   navigation.PopAsync();
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

		private async void RequestAction(object obj)
		{
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
               if(IsValid())
                {
                   var result =await  AccountServices.RequestNewPassword(Email);
                    if(result)
                    {
                        Helpers.ShowMessageError("Sukses, Periksa Email Anda");
                    }else
                    {
                        throw new SystemException("Tidak Berhasil");
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

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(Email))
                return false;
            return true;
        }
    }
}