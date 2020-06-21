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
    public partial class OceanWithFish : ContentPage
    {
        List<Fish> fishes;
        List<Fish> aliveFish;
        List<Fish> dieFish;

        public OceanWithFish()
        {
            InitializeComponent();
            StartAnim();
        }


        private async void StartAnim()
        {
            while (true)
            {
                await Fish1.TranslateTo(-100, Fish1.Y+20, 3000);
                Fish1.RotationY = 180;
                await Fish1.TranslateTo(100, Fish1.Y+20, 3000);
                Fish1.RotationY = 0;
            }
        }

        protected override void OnAppearing()
        {
            Fish1.IsVisible = false;
            Fish11.IsVisible = false;
            Fish12.IsVisible = false;
            Fish13.IsVisible = false;
            Fish14.IsVisible = false;
            Fish15.IsVisible = false;
            Fish16.IsVisible = false;
            Fish17.IsVisible = false;
            Fish18.IsVisible = false;
            Fish19.IsVisible = false;

            Caviar1.IsVisible = false;
            Caviar2.IsVisible = false;
            Caviar3.IsVisible = false;
            Caviar4.IsVisible = false;
            Caviar5.IsVisible = false;
            Caviar6.IsVisible = false;
            Caviar7.IsVisible = false;
            Caviar8.IsVisible = false;
            Caviar9.IsVisible = false;
            Caviar10.IsVisible = false;

            fishes = (List<Fish>)App.Database.GetItems();

            aliveFish = new List<Fish>();
            dieFish = new List<Fish>();

            showFish();
            showCaviar();

            base.OnAppearing();
        }

        private void showCaviar()
        {
            if(dieFish.Count > 0)
            {
                Caviar1.IsVisible = true;
            }

            if (((dieFish.Count * 0.1) + dieFish.Count) >= aliveFish.Count && dieFish.Count > 1)
            {
                Caviar2.IsVisible = true;
            }

            if (((dieFish.Count * 0.2) + dieFish.Count) >= aliveFish.Count && dieFish.Count > 2)
            {
                Caviar3.IsVisible = true;
            }

            if (((dieFish.Count * 0.3) + dieFish.Count) >= aliveFish.Count && dieFish.Count > 3)
            {
                Caviar4.IsVisible = true;
            }

            if (((dieFish.Count * 0.4) + dieFish.Count) >= aliveFish.Count && dieFish.Count > 4)
            {
                Caviar5.IsVisible = true;
            }

            if (((dieFish.Count * 0.5) + dieFish.Count) >= aliveFish.Count && dieFish.Count > 5)
            {
                Caviar6.IsVisible = true;
            }

            if (((dieFish.Count * 0.6) + dieFish.Count) >= aliveFish.Count && dieFish.Count > 6)
            {
                Caviar7.IsVisible = true;
            }

            if (((dieFish.Count * 0.7) + dieFish.Count) >= aliveFish.Count && dieFish.Count > 7)
            {
                Caviar8.IsVisible = true;
            }

            if (((dieFish.Count * 0.8) + dieFish.Count) >= aliveFish.Count && dieFish.Count > 8)
            {
                Caviar9.IsVisible = true;
            }

            if (((dieFish.Count * 0.9) + dieFish.Count) >= aliveFish.Count && dieFish.Count > 9)
            {
                Caviar10.IsVisible = true;
            }
        }

        private void showFish()
        {
            foreach (Fish fish in fishes)
            {
                if (fish.Alive) aliveFish.Add(fish);
                else dieFish.Add(fish);
            }

            if (aliveFish.Count > 0)
            {
                Fish1.IsVisible = true;
            }

            if (((dieFish.Count * 0.1) + dieFish.Count) <= aliveFish.Count && aliveFish.Count > 1)
            {
                Fish13.IsVisible = true;
            }

            if (((dieFish.Count * 0.2) + dieFish.Count) <= aliveFish.Count && aliveFish.Count > 2)
            {
                Fish19.IsVisible = true;
            }

            if (((dieFish.Count * 0.3) + dieFish.Count) <= aliveFish.Count && aliveFish.Count > 3)
            {
                Fish11.IsVisible = true;
            }

            if (((dieFish.Count * 0.4) + dieFish.Count) <= aliveFish.Count && aliveFish.Count > 4)
            {
                Fish17.IsVisible = true;
            }

            if (((dieFish.Count * 0.5) + dieFish.Count) <= aliveFish.Count && aliveFish.Count > 5)
            {
                Fish16.IsVisible = true;
            }

            if (((dieFish.Count * 0.6) + dieFish.Count) <= aliveFish.Count && aliveFish.Count > 6)
            {
                Fish12.IsVisible = true;
            }

            if (((dieFish.Count * 0.7) + dieFish.Count) <= aliveFish.Count && aliveFish.Count > 7)
            {
                Fish14.IsVisible = true;
            }

            if (((dieFish.Count * 0.8) + dieFish.Count) <= aliveFish.Count && aliveFish.Count > 8)
            {
                Fish18.IsVisible = true;
            }

            if (((dieFish.Count * 0.9) + dieFish.Count) <= aliveFish.Count && aliveFish.Count > 9)
            {
                Fish15.IsVisible = true;
            }
        }
    }
}