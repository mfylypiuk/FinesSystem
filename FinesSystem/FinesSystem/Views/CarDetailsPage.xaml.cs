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
    public partial class CarDetailsPage : ContentPage
    {
        public ObservableCollection<string> CarOwners { get; set; }

        public CarDetailsPage()
        {
            InitializeComponent();

            CarOwners = new ObservableCollection<string>();

            foreach (var item in App.CarOwnersDatabase.GetItems())
            {
                CarOwners.Add(item.Name);
            }

            BindingContext = this;
        }

        private void SaveCar(object sender, EventArgs e)
        {
            var car = (Car)BindingContext;

            if (!string.IsNullOrEmpty(car.Number))
            {
                App.CarsDatabase.SaveItem(car);
            }

            Navigation.PopAsync();
        }

        private void DeleteCar(object sender, EventArgs e)
        {
            var car = (Car)BindingContext;
            App.CarsDatabase.DeleteItem(car.Id);

            Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OwnerPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}