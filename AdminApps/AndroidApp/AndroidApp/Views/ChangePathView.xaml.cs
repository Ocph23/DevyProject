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
	public partial class ChangePathView : ContentPage
	{
		public ChangePathView ()
		{
			InitializeComponent ();
            path.Text = Helpers.Server;
		}

        private void btn_Clicked(object sender, EventArgs e)
        {
            Helpers.Server = path.Text;
            Navigation.PopModalAsync();
        }
    }
}