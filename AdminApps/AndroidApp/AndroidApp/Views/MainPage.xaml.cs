using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
        private List<MasterPageItem> menuList;

        public MainPage ()
		{
            InitializeComponent();
            menuList = new List<MasterPageItem>();
            // Adding menu items to menuList and you can define title ,page and icon  
            menuList.Add(new MasterPageItem()
            {
                Title = "Home",
                Icon = "awesomehome.png",
                TargetType = typeof(Home)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Layanan Pemasangan Baru",
                Icon = "awesomeedit.png",
                TargetType = typeof(Pengaduan)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Layanan Perubahan",
                Icon = "awesomeexchange.png",
                TargetType = typeof(Pengaduan)
            });


            menuList.Add(new MasterPageItem()
            {
                Title = "Layanan Pengaduan Gangguan",
                Icon = "awesomeexclamation.png",
                TargetType = typeof(Pengaduan)
            });

            menuList.Add(new MasterPageItem()
            {
                Title = "About",
                Icon = "awesomehelp.png",
                TargetType = typeof(AboutPage)
            });

            // Setting our list to be ItemSource for ListView in MainPage.xaml  
            navigationDrawerList.ItemsSource = menuList;
            // Initial navigation, this can be used for our home page  
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Home)));

        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

        private void profileGesture_Clicked(object sender, EventArgs e)
        {

        }
    }
}