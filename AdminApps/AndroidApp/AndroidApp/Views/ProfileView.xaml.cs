using AndroidApp.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Drawing;

namespace AndroidApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfileView : ContentPage
	{
		public ProfileView (Profile user)
		{
			InitializeComponent ();
            vm = new ProfileViewModel(user);
            BindingContext = vm;
		}

        private ProfileViewModel vm;

        

		private  async void profileGesture_Clicked(object sender, EventArgs e)
		{
			try
			{
				var action = await DisplayActionSheet("Pilih", "Cancel", null, "File", "Camera");
				if(action=="Camera")
				{
					var task = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
					{
						PhotoSize = PhotoSize.Custom, CustomPhotoSize=90, CompressionQuality=60
					});
					vm.User.Photo=  await CompleteTakePhoto(task);

				}else if(action=="File")
				{
					var task = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions  {PhotoSize= PhotoSize.Custom, CustomPhotoSize = 2 });
					vm.User.Photo = await CompleteTakePhoto(task);
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
				return stream;
			});
            using (var memoryStream = new MemoryStream())
            {

                task.GetStream().CopyTo(memoryStream);
                vm.User.Pelanggan.Foto = memoryStream.ToArray();

            }
            return imageS;
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
            if (vm.User.Pelanggan.Foto.Length >21000)
                Helpers.ShowMessageError("Gambar Terlalu Besar");
            else
            vm.Save(vm.User.Pelanggan);
		}

       
    }


    public class ProfileViewModel : BaseViewModel
    {
        public Profile User { get; set; }

        public ProfileViewModel(Profile user)
        {
            this.User = user;
        }

        internal async void Save(PelangganModel pelanggan)
        {
            try
            {
                var saved = await AccountServices.SaveProfile(pelanggan);
                if (saved)
                {
                    Helpers.ShowMessage("Profil Tersimpan");
                }
                else
                {
                    Helpers.ShowMessageError("Tidak Tersimpan");
                }
            }
            catch (Exception ex)
            {

                Helpers.ShowMessageError(ex.Message);
            }
        }
    }
}