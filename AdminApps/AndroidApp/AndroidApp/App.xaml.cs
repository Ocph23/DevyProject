using System;
using Xamarin.Forms;
using AndroidApp.Views;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace AndroidApp
{
	public partial class App : Application
	{
        public AuthenticationToken Token { get; set; }

        public App ()
		{
			InitializeComponent();
            MessagingCenter.Subscribe<MessagingCenterAlert>(this, "message", async (message) =>
            {
                await Current.MainPage.DisplayAlert(message.Title, message.Message, message.Cancel);

            });
           
            SetMainPage();
		}



        internal Task<AuthenticationToken> GetToken()
        {
            return Task.FromResult(Token);
        }

        internal Task SetToken(AuthenticationToken token)
        {
            try
            {
                Token = token;
                return Task.FromResult(1);
            }
            catch (Exception)
            {
                return Task.FromResult(0);
            }
        }


        private  void SetMainPage()
        {
            var login = new Views.Accounts.Login();
            Current.MainPage = login;
        }


        public void ChangeScreen(Page page)
        {
            Current.MainPage = page;
        }


        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
