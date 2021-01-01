using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Worldbuilding_App_Vinteler_Erica_v1.Models;

namespace Worldbuilding_App_Vinteler_Erica_v1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        
        // apelam functiile din WorldbuildingDatabase
        async void OnWorldSaveButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("OnWorldSaveButtonClicked", "Opened [OnWorldSaveButtonClicked].", "Ok.");
            var vworld = (World)BindingContext;
            await App.Database.SaveWorldAsync(vworld);
            await Navigation.PopAsync();
        }

        async void OnWorldDeleteButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("OnWorldDeleteButtonClicked", "Opened [OnWorldDeleteButtonClicked].", "Ok.");
            var vworld = (World)BindingContext;
            await App.Database.DeleteWorldAsync(vworld);
            await Navigation.PopAsync();
        }
        /*
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var worldd = (World)BindingContext;

            listView.ItemsSource = await App.Database.GetWorldListAsync();
        }
        *.
        /*
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage((ShopList)
           this.BindingContext)
            {
                BindingContext = new Product()
            });

        }
        */
    }
}