using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YourOcean.Models;

namespace YourOcean
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "fish.db";  
        public static FishRepository database;

        public static FishRepository Database
        {
            get 
            {
                if (database == null)
                {
                    database = new FishRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public static bool appSleep = false;

        public App()
        {
            InitializeComponent();
            MainPage = new MainTabbedPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            appSleep = true;
        }

        protected override void OnResume()
        {
            appSleep = false;
        }
    }
}
