using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourOcean.Models;
using YourOcean.StatsFolder;

namespace YourOcean
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ocean : ContentPage
    {
        List<Fish> fishes;
        List<Fish> aliveFish;
        List<Fish> dieFish;

        public Ocean()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            fishes = (List<Fish>)App.Database.GetItems();

            aliveFish = new List<Fish>();
            dieFish = new List<Fish>();


            foreach(Fish fish in fishes) {
                if (fish.Alive) aliveFish.Add(fish);
                else dieFish.Add(fish);
            }

            //Очистка бази даних
            //foreach (Fish fish in fishes)
            //{
            //    App.Database.DeleteItem(fish.Id);
            //}

            allFishes.Text = fishes.Count.ToString();
            aliveFishes.Text = aliveFish.Count.ToString();
            dieFishes.Text = dieFish.Count.ToString();

            aliveFish.Reverse();
            dieFish.Reverse();

            base.OnAppearing();
        }

        private async void buttonAlive_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AliveFish
            {
                BindingContext = aliveFish
            });
        }

        private async void buttonDie_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DieFish
            {
                BindingContext = dieFish
            });
        }

        
    }
}