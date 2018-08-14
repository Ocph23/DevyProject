using AndroidApp.ViewModels;
using SharedApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
        private List<MasterPageItem> menuList;
        private MainPageViewModel vm = new MainPageViewModel();
      
        public MainPage ()
		{
            InitializeComponent();
            BindingContext = vm;
            menuList = new List<MasterPageItem>();
            // Adding menu items to menuList and you can define title ,page and icon  
            menuList.Add(new MasterPageItem()
            {
                Name= "Home",
                Title = "Home",
                Icon = "awesomehome.png",
                TargetType = typeof(Home)
            });
            menuList.Add(new MasterPageItem()
            {
                Name = "Pemasangan",
                Title = "Layanan Pemasangan Baru",
                Icon = "awesomeedit.png",
                TargetType = typeof(DetailPemasanganView)
                //TargetType = typeof(PemasanganView)
            });

            menuList.Add(new MasterPageItem()
            {
                Name="Perubahan",
                Title = "Layanan Perubahan",
                Icon = "awesomeexchange.png",
                TargetType = typeof(DetailPerubahanView)
            });


            menuList.Add(new MasterPageItem()
            {
                Name = "Pengaduan",
                Title = "Layanan Pengaduan Gangguan",
                Icon = "awesomeexclamation.png",
                TargetType = typeof(DetailPengaduanView)
            });

            menuList.Add(new MasterPageItem()
            {
                Name= "About",
                Title = "About",
                Icon = "awesomehelp.png",
                TargetType = typeof(AboutPage)
            });

            menuList.Add(new MasterPageItem()
            {
                Name="Logout",
                Title = "Logout",
                Icon = "awesomehelp.png",
                TargetType = typeof(AboutPage)
            });

            // Setting our list to be ItemSource for ListView in MainPage.xaml  
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page  
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Home)));
           
        }

        

        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            if (item != null && !string.IsNullOrEmpty(item.Name))
            {
                switch (item.Name)
                {
                    case "Pemasangan":
                        if(vm.Pemasangan==null)
                            page = typeof(PemasanganView);
                        break;
                   
                    case "Perubahan":
                        if (vm.Perubahan == null || vm.Perubahan.Count() <= 0)
                            page = typeof(PerubahanView);
                        break;

                    case "Pengaduan":
                        if (vm.Pengaduan == null || vm.Pengaduan.Count() <= 0)
                            page = typeof(Pengaduan);
                        break;

                    case "Logout":
                        var app = await Helpers.GetBaseApp();
                        app.ChangeScreen(new Accounts.Login());
                        break;

                    default:
                        break;
                }
            }


            if(page!=null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;
            }


            
        }

        public void SetCurrenttarget(string name)
        {
           var resul= menuList.Where(O => O.Name.ToUpper() == name.ToUpper()).FirstOrDefault();
            Detail = new NavigationPage((Page)Activator.CreateInstance(resul.TargetType));
            IsPresented = false;
        }

        private void profileGesture_Clicked(object sender, EventArgs e)
        {
            Detail= new NavigationPage(new ProfileView(vm.User));
            IsPresented = false;
        }
    }


    public class MainPageViewModel:BaseViewModel
    {
        private Profile _user;

        public Profile User {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public PemasanganModel Pemasangan { get; private set; }
        public IEnumerable<PemasanganModel> Perubahan { get; private set; }
        public IEnumerable<PengaduanModel> Pengaduan { get; private set; }

        public MainPageViewModel()
        {
            AccountServices.GetProfile().ContinueWith(x=> CompleteProfile(x));
            PemasanganService.GetItemsAsync().ContinueWith(x=>CompletePemasangan(x));
            PerubahanService.GetItemsAsync().ContinueWith(x => CompletePerubahan(x));
            PengaduanService.GetItemsAsync().ContinueWith(x => CompletePengaduan(x));

        }


        private async void CompletePengaduan(Task<IEnumerable<PengaduanModel>> x)
        {
            var result = (await x);
            Pengaduan = result;
        }


        private async void CompletePerubahan(Task<IEnumerable<PemasanganModel>> x)
        {
            var result = (await x);
            Perubahan = result;
        }

        private async void CompletePemasangan(Task<IEnumerable<PemasanganModel>> x)
        {
            var result = (await x);
            Pemasangan = result.FirstOrDefault();

        }

        private async void CompleteProfile(Task<PelangganModel> x)
        {
            var result = await x;
            if(result!=null)
            {
                User = new Profile { UserName = result.Nama, PhotoSource = result.Foto };
                User.Pelanggan = result;
                if(result.Foto!=null && result.Foto.Length>0)
                {
                    User.PhotoSource = result.Foto;
                }
            }
           
        }
        
    }
}