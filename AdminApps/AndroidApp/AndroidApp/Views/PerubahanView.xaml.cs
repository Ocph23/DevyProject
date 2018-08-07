using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.InputKit.Shared.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PerubahanView : ContentPage
	{
		public PerubahanView ()
		{
			InitializeComponent ();
            BindingContext = new PerubahanViewModel();
		}
	}

    public class PerubahanViewModel:BaseNotify
    {
        private string _selected;

        public PerubahanViewModel()
        {
            SourceItems = new List<string>();
        }

        public List<string> SourceItems { get; }

        public string SelectedItem {
            get { return _selected; }
            set
            {
                SetProperty(ref _selected, value);
            }
        }
    }
}