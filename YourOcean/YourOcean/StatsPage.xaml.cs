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
    public partial class StatsPage : ContentPage
    {
        List<Fish> fishes;

        public StatsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            fishes = (List<Fish>)App.Database.GetItems();

            base.OnAppearing();
        }

        private async void ButtonStats_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Stats
            {
                BindingContext = fishes
            });
        }

        private async void ButtonStatsLast3Days_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatsLastThreeDays
            {
                BindingContext = fishes
            });
        }

        private async void ButtonStatsAllTime_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatsAllTime
            {
                BindingContext = fishes
            });
        }

        private async void ButtonStatsNumberAllTime_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatsNumber
            {
                BindingContext = fishes
            });
        }

        private async void ButtonStatsNumberLastThreeDays_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatsNumberLastThreeDays
            {
                BindingContext = fishes
            });
        }

        private async void ButtonStatsNumber_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StatsNumberAllTime
            {
                BindingContext = fishes
            });
        }
    }
}