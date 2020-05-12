using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourOcean.FishFolder;
using YourOcean.Models;

namespace YourOcean
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AliveFish : ContentPage
    {
        public AliveFish()
        {
            InitializeComponent();
        }

        private async void aliveFishList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Fish fish = (Fish)e.SelectedItem;
            await Navigation.PushAsync(new FishPage
            {
                BindingContext = fish
            });
        }
    }
}