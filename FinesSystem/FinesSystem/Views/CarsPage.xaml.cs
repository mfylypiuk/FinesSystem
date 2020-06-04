using FinesSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinesSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarsPage : ContentPage
    {
        public ObservableCollection<Car> Cars { get; set; }

        public CarsPage()
        {
            InitializeComponent();

            Cars = new ObservableCollection<Car>();
            BindingContext = this;
        }

        private async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var selectedCar = (Car)layout.BindingContext;
            var carDetailsPage = new CarDetailsPage
            {
                BindingContext = selectedCar
            };
            await Navigation.PushAsync(carDetailsPage);
        }

        private async void CreateCar(object sender, EventArgs e)
        {
            var car = new Car();
            var carDetailsPage = new CarDetailsPage
            {
                BindingContext = car
            };
            await Navigation.PushAsync(carDetailsPage);
        }

        protected override void OnAppearing()
        {
            Cars.Clear();

            foreach (var item in App.CarsDatabase.GetItems())
            {
                Cars.Add(item);
            }

            base.OnAppearing();
        }
    }
}