using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YourOcean.Models;

namespace YourOcean
{
    [DesignTimeVisible(false)]

    public partial class MainPage : ContentPage
    {
        Fish fish;
        private double stepValue = 1.0;
        public MainPage()
        {
            InitializeComponent();
        }
        private void sliderTime_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //Test.Text = DateTime.Now.ToString();
            var newStep = Math.Round(e.NewValue / stepValue);
            sliderTime.Value = newStep * stepValue;
        }

        private async void NewCaviar_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(entryName.Text)) 
            {
                await DisplayAlert("Помилка", "Ви не ввели назву", "Ок");
            }
            else
            {
                fish = new Fish();
                fish.DedicatedTime = Convert.ToInt32(sliderTime.Value);
                fish.StartDateTime = DateTime.Now;
                fish.Name = entryName.Text;
                await Navigation.PushAsync(new GrowingCaviar
                {
                    BindingContext = fish
                });
                Navigation.RemovePage(this);
            }
        }
    }
}

// статистика скільки часу потратили за день/тиждень 
// юніт тест