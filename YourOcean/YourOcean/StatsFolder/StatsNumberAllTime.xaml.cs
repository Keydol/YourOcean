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
    public partial class StatsNumberAllTime : ContentPage
    {
        List<Fish> fishes;
        int live;
        int die;
        DateTime dateTime;

        List<Entry> enties;
        public StatsNumberAllTime()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            dataForChart();
            enties = new List<Entry>();


            enties.Add(new Entry(live)
            {
                Label = "Живі",
                ValueLabel = live.ToString(),
                Color = SkiaSharp.SKColor.Parse("00CED1")
            });

            enties.Add(new Entry(die)
            {
                Label = "Мертві",
                ValueLabel = die.ToString(),
                Color = SkiaSharp.SKColor.Parse("#eb4034")
            });

            ChartFish.Chart = new LineChart
            {
                Entries = enties,
                LabelTextSize = 35
            };


            base.OnAppearing();
        }
        private void dataForChart()
        {
            fishes = (List<Fish>)BindingContext;

            dateTime = DateTime.Now;

            foreach (Fish fish in fishes)
            {
                if (fish.Alive) live++;
                else die++;
            }
        }
    }
}