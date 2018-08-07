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
                Icon = "homeicon.png",
                TargetType = typeof(Home)
            });


            menuList.Add(new MasterPageItem()
            {
                Title = "Pengaduan",
                Icon = "contacticon.png",
                TargetType = typeof(Pengaduan)
            });

            menuList.Add(new MasterPageItem()
            {
                Title = "About",
                Icon = "homeicon.png",
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
    }
}