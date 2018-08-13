using Plugin.Media;
using Plugin.Media.Abstractions;
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
	public partial class ProfileView : ContentPage
	{
	  	public ProfileView (Profile user)
		{
			InitializeComponent ();
            User = user;
		}

		public Profile User { get; set; }

		private  async void profileGesture_Clicked(object sender, EventArgs e)
		{
			try
			{
                var action = await DisplayActionSheet("Pilih", "Cancel", null, "File", "Camera");
                if(action=="Camera")
                {
                    var task = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        PhotoSize = PhotoSize.Small
                    });
                    User.Photo=  await CompleteTakePhoto(task);

                }else if(action=="File")
                {
                    var task = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions { CustomPhotoSize = 10 });
                    User.Photo = await CompleteTakePhoto(task);
                }
            }
			catch (Exception ex)
			{
				Helpers.ShowMessageError(ex.Message);
			}
		}

        private async Task<ImageSource> CompleteTakePhoto(MediaFile task)
        {
            await Task.Delay(500);
          var imageS=  ImageSource.FromStream(() =>
            {
                var stream = task.GetStream();
               // task.Dispose();
                return stream;
            });


            return imageS;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}