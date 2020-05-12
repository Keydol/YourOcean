using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourOcean.Models;

namespace YourOcean
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GrowingCaviar : ContentPage
    {
        private int minutes;
        private int seconds;
        private bool stopTimer;

        public GrowingCaviar()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick); //оновлення кожну секунду
            Device.StartTimer(TimeSpan.FromMinutes(1), OnTimerMinutes);
        }

        protected override void OnAppearing()
        {
            stopTimer = false;

            var fish = (Fish)BindingContext;
            minutes = 0;
            seconds = 5;
            //minutes = fish.DedicatedTime - 1;
            //seconds = 60;

            base.OnAppearing();
        }

        private bool OnTimerTick()
        {
            if (stopTimer)
            {
                return false;
            }
            if (seconds == 0)
            {
                seconds = 59;
                if (minutes == 0)
                {
                    readyCaviar();
                    return false;
                }
            } else
            {
                seconds--;
            }
            timerLabel.Text = minutes.ToString() + ":" + (seconds >= 10 ? seconds.ToString() : "0" + seconds.ToString());
            return true;
        }

        private bool OnTimerMinutes()
        {    
            if (minutes == 0 || stopTimer)
            {
                return false;
            }
            minutes--;
            return true;
        }

        private async void readyCaviar()
        {
            var fish = (Fish)BindingContext;
            fish.EndDateTime = DateTime.Now;
            fish.Alive = true;
            App.Database.SaveItem(fish);

            await DisplayAlert("Успіх!", "Ваша ікра виросла", "Окей");

            await Navigation.PushAsync(new MainPage());
            Navigation.RemovePage(this);
        }

        private async void buttonFf_Clicked(object sender, EventArgs e)
        {
            stopTimer = true;

            var fish = (Fish)BindingContext;
            fish.EndDateTime = DateTime.Now;
            fish.Alive = false;
            App.Database.SaveItem(fish);

            await DisplayAlert("Упс", "Ікра не вижила", "Жаль");

            await Navigation.PushAsync(new MainPage());
            Navigation.RemovePage(this);
        }
    }
}