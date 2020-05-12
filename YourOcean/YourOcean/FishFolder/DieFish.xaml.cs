using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourOcean.Models;
using YourOcean.FishFolder;

namespace YourOcean
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DieFish : ContentPage
    {
        public DieFish()
        {
            InitializeComponent();
        }

        private async void dieFishList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Fish fish = (Fish)e.SelectedItem;
            await Navigation.PushAsync(new FishPage
            {
                BindingContext = fish
            });
        }
    }
}