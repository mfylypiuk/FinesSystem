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
    public partial class CarOwnersPage : ContentPage
    {
        public ObservableCollection<CarOwner> CarOwners { get; set; }

        public CarOwnersPage()
        {
            InitializeComponent();

            CarOwners = new ObservableCollection<CarOwner>();
            BindingContext = this;
        }

        private async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var selectedCarOwner = (CarOwner)layout.BindingContext;
            var carOwnerDetailsPage = new CarOwnerDetailsPage
            {
                BindingContext = selectedCarOwner
            };
            await Navigation.PushAsync(carOwnerDetailsPage);
        }

        private async void CreateCarOwner(object sender, EventArgs e)
        {
            var carOwner = new CarOwner();
            var carOwnerDetailsPage = new CarOwnerDetailsPage
            {
                BindingContext = carOwner
            };
            await Navigation.PushAsync(carOwnerDetailsPage);
        }

        protected override void OnAppearing()
        {
            CarOwners.Clear();

            foreach (var item in App.CarOwnersDatabase.GetItems())
            {
                CarOwners.Add(item);
            }

            base.OnAppearing();
        }
    }
}