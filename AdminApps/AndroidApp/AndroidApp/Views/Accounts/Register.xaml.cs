using AndroidApp.ViewModels;
using SharedApp.Models;
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
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
            this.BindingContext = new RegisterViewModel(Navigation);
        }
    }


    public class RegisterViewModel : BaseViewModel
    {
        private INavigation nav;
        private RegisterModel _model;

        public RegisterModel Model {
            get { return _model; }
            set { SetProperty(ref _model, value);
            }
        }
        public Command RegisterCommand { get; }

        public RegisterViewModel() { }
        public RegisterViewModel(INavigation nav)
        {
            this.nav = nav;
            RegisterCommand = new Command(RegisterAction);
            Model = new RegisterModel();
            Model.Nama = "Aldrich";
            Model.Email = "aldrich@gmail.com";
            Model.Password = "Sony@77";
            Model.ConfirmPassword= "Sony@77";
        }

        private async void RegisterAction(object obj)
        {
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                if (IsValid())
                {
                    var register = await AccountServices.Register(Model);
                    if (register)
                    {
                        Helpers.ShowMessageError("Sukses");
                    }
                }
                else
                    throw new SystemException("Register Tidak Berhasil");
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
            if (string.IsNullOrEmpty(Model.Nama) || string.IsNullOrEmpty(Model.ConfirmPassword) || 
                string.IsNullOrEmpty(Model.Email) || string.IsNullOrEmpty(Model.Password))
                return false;
            return true;
        }
    }
}