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
	public partial class ProfileEditView : ContentPage
	{
		public ProfileEditView ()
		{
			InitializeComponent ();
		}

        private void profileGesture_Clicked(object sender, EventArgs e)
        {

        }
    }
}