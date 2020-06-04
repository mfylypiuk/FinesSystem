using FinesSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinesSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarOwnerDetailsPage : ContentPage
    {
        public CarOwnerDetailsPage()
        {
            InitializeComponent();
        }

        private void SaveCarOwner(object sender, EventArgs e)
        {
            var carOwner = (CarOwner)BindingContext;

            if (!string.IsNullOrEmpty(carOwner.Name))
            {
                App.CarOwnersDatabase.SaveItem(carOwner);
            }

            Navigation.PopAsync();
        }

        private void DeleteCarOwner(object sender, EventArgs e)
        {
            var carOwner = (CarOwner)BindingContext;
            App.CarOwnersDatabase.DeleteItem(carOwner.Id);

            Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}