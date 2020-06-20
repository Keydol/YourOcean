using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourOcean.Models;
using Entry = Microcharts.Entry;

namespace YourOcean.StatsFolder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsLastThreeDays : ContentPage
    {
        List<Fish> fishes;
        int[] live;
        int[] die;
        DateTime dateTime;

        List<Entry> enties;
        public StatsLastThreeDays()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            dataForChart();
            enties = new List<Entry>();

            for (int i = 2; i >= 0; i--)
            {
                enties.Add(new Entry(live[i])
                {
                    Label = dateTime.AddDays(-i).ToString("MM.dd"),
                    ValueLabel = live[i].ToString() + " хв",
                    Color = SkiaSharp.SKColor.Parse("00CED1")
                });

                enties.Add(new Entry(die[i])
                {
                    Label = dateTime.AddDays(-i).ToString("MM.dd"),
                    ValueLabel = die[i].ToString() + " хв",
                    Color = SkiaSharp.SKColor.Parse("#eb4034")
                });
            }

            ChartFish.Chart = new BarChart
            {
                Entries = enties,
                LabelTextSize = 30
            };


            base.OnAppearing();
        }

        private void dataForChart()
        {
            fishes = (List<Fish>)BindingContext;

            dateTime = DateTime.Now;

            live = new int[3];
            die = new int[3];


            foreach (Fish fish in fishes)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (dateTime.AddDays(-i).ToString("d").Equals(fish.StartDateTime.ToString("d")))
                    {
                        if (fish.Alive) live[i] += fish.DedicatedTime;
                        else die[i] += fish.DedicatedTime;
                    }
                }
            }
        }
    }

}