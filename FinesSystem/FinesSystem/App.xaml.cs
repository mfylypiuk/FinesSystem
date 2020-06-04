using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FinesSystem.Services;
using FinesSystem.Views;
using System.IO;
using FinesSystem.Repositories;

namespace FinesSystem
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "FinesSystem.db";
        public static CarOwnersRepository carOwnersDatabase;
        public static CarsRepository carsDatabase;

        public static CarOwnersRepository CarOwnersDatabase
        {
            get
            {
                if (carOwnersDatabase == null)
                {
                    carOwnersDatabase = new CarOwnersRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }

                return carOwnersDatabase;
            }
        }

        public static CarsRepository CarsDatabase
        {
            get
            {
                if (carsDatabase == null)
                {
                    carsDatabase = new CarsRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }

                return carsDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
